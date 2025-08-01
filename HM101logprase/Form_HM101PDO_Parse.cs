﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Timers;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Configuration;
using HTWL.Communication;
using Models;
using SqlSugar;
using SteelLogImporter.Parser;
using XYGCommunication;
using XYGCommunication.LogNet;
using System.Threading.Tasks;



namespace SteelLogImporter
{
    public partial class Form_HM101PDO_Parse : Form
    {        
        private SqlSugarClient DBClinet;
        private readonly LogParser _logParser = new LogParser();
        private FileSystemWatcher _watcher; 
        public static ILogNet LogNet { get; set; }   
        private Queue<string> _fileQueue = new Queue<string>();
        private System.Timers.Timer _processingTimer;

        public delegate void LogReceivedEventHandler(string logMessage);
        public event LogReceivedEventHandler LogReceived;

        public Form_HM101PDO_Parse()
        {
            InitializeComponent();
            DBClinet = Communication.dbMYSQL2;

            string logDirectoryPath = ConfigurationManager.AppSettings["LogDirectoryPath"];
            StartMonitoring(logDirectoryPath);
           
            Process processes = Process.GetCurrentProcess();
            string name = processes.ProcessName;
            string logOutputPath = ConfigurationManager.AppSettings["LogOutputPath"];
            LogNet = new LogNetDateTime(logOutputPath + name, GenerateMode.ByEveryDay);

        

            // 添加日志事件处理
            LogReceived += (message) =>
            {
                if (richTextBoxLog.InvokeRequired)
                {
                    richTextBoxLog.Invoke(new Action<string>((msg) =>
                    {
                        AddLogToUI(msg);
                    }), message);
                }
                else
                {
                    AddLogToUI(message);
                }
            };

            // 初始化定时器，每250ms触发一次
            _processingTimer = new System.Timers.Timer(250);
            _processingTimer.Elapsed += OnProcessingTimerElapsed;
            _processingTimer.Start();

           
        }

        private void StartMonitoring(string path)
        {
            _watcher = new FileSystemWatcher(path);
            _watcher.Filter = "*.txt";
            _watcher.Created += OnFileCreated;
            _watcher.Changed += OnFileChanged;
            _watcher.Renamed += OnFileRenamed;
            _watcher.Error += OnError;
            _watcher.IncludeSubdirectories = true;
            _watcher.EnableRaisingEvents = true;
        }

        private void OnFileCreated(object sender, FileSystemEventArgs e)
        {
            try
            {                
                _fileQueue.Enqueue(e.FullPath);
            }
            catch (Exception ex)
            {
                LogNet.WriteInfo(e.FullPath + " -数据解析失败" + ex.Message);
                LogReceived?.Invoke(e.FullPath + " -数据解析失败" + ex.Message);

                this.Invoke((MethodInvoker)(() =>
                {
                    MessageBox.Show($"数据解析失败: {ex.Message}");
                }));
            }
        }

        private void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            // 处理文件更改事件
        }

        private void OnFileRenamed(object sender, RenamedEventArgs e)
        {
            // 处理文件重命名事件
        }

        private void OnError(object sender, ErrorEventArgs e)
        {
            LogNet.WriteInfo(" -数据解析失败" + e.GetException().Message);
            LogReceived?.Invoke( " -数据解析失败" + e.GetException().Message);
            this.Invoke((MethodInvoker)(() =>
            {
                MessageBox.Show($"数据解析失败: {e.GetException().Message}");
            }));
        }

        private void WaitForFileToBeReady(string filePath)
        {
            int maxAttempts = 10;
            int attempts = 0;
            while (attempts < maxAttempts)
            {
                try
                {
                    using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                    {
                        stream.Close();
                        break;
                    }
                }
                catch (IOException)
                {
                    System.Threading.Thread.Sleep(1000); // 等待 1 秒
                    attempts++;
                }
            }
        }

        private void ProcessLogFile(string filePath)
        {
            // 解析日志
            var (mainLog, passLogs) = _logParser.ParseLog(filePath);

            hm101_pdo LogPrase = new hm101_pdo();
            List<hm101_pdo_pass> listLogPrasepass = new List<hm101_pdo_pass>();         

            // 实现属性复制
            ObjectMapper.Map(
                source: mainLog,
                target: LogPrase,
                ignoreProperties: new List<string> { "CREATE_TIME" }, // 排除需要单独处理的属性
                customMappings: new Dictionary<string, string>
                {
                    // 如有名称不同但需要复制的属性，在这里配置映射
                    // 例如：{"源属性名", "目标属性名"}
                    // {"OLD_FIELD", "NEW_FIELD"}
                }
            );

            // 特殊属性单独处理（保持业务特殊性）
            LogPrase.CREATE_TIME = DateTime.Now;

            // 导入道次数据
            foreach (var passLog in passLogs)
            {
                hm101_pdo_pass LogPrasepass = new hm101_pdo_pass();          
              
                // 实现属性复制
                ObjectMapper.Map(
                    source: passLog,
                    target: LogPrasepass,
                    ignoreProperties: new List<string> { "CREATE_TIME", "STEEL_NO" }, // 排除需要单独处理的属性
                    customMappings: new Dictionary<string, string>
                    {
                        // 如有名称不同但需要复制的属性，在这里配置映射
                        // 例如：{"源属性名", "目标属性名"}
                        // {"OLD_FIELD", "NEW_FIELD"}
                    }
                );

                // 特殊属性单独处理（保持业务特殊性）
                LogPrasepass.STEEL_NO = mainLog.STEEL_NO;
                LogPrasepass.CREATE_TIME = DateTime.Now;
                listLogPrasepass.Add(LogPrasepass);
            }
         
            DBClinet.Insertable(LogPrase).ExecuteCommand();
            DBClinet.Insertable(listLogPrasepass).ExecuteCommand();

            LogNet.WriteInfo(filePath+" -数据解析成功");
            LogReceived?.Invoke(filePath + " -数据解析成功");


        }


        private DateTime? GetLatestCreateTime()
        {
            return DBClinet.Queryable<hm101_pdo>().Max(it => it.CREATE_TIME);
        }

        private void OnProcessingTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (_fileQueue.Count > 0)
            {
                string filePath = _fileQueue.Dequeue();                    
                try
                {
                    // 等待文件写入完成
                    WaitForFileToBeReady(filePath);

                    // 处理日志文件
                    ProcessLogFile(filePath);
                }
                catch (Exception ex)
                {
                    LogNet.WriteInfo(filePath + " -数据解析失败" + ex.Message);
                    LogReceived?.Invoke(filePath + " -数据解析失败" + ex.Message);

                    this.Invoke((MethodInvoker)(() =>
                    {
                        MessageBox.Show($"数据解析失败: {ex.Message}");
                    }));
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBClinet.DbFirst.IsCreateAttribute().CreateClassFile("c:\\Demo", "Models");
        }

        // 在Form1类中添加
        private void AddLogToUI(string message)
        {
            // 限制日志显示行数，防止内存溢出
            if (richTextBoxLog.Lines.Length > 1000)
            {
                // 保留最后500行
                var lines = richTextBoxLog.Lines.Skip(richTextBoxLog.Lines.Length - 500).ToArray();
                richTextBoxLog.Lines = lines;
            }

            // 添加新日志，包含时间戳
            richTextBoxLog.AppendText($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}\n");
            // 滚动到最新日志
            richTextBoxLog.ScrollToCaret();
        }

        // Form1.cs 新增Load事件处理
        private void Form1_Load(object sender, EventArgs e)
        {
            // 窗体显示后，在后台异步处理历史日志
            Task.Run(() =>
            {
                try
                {
                    string logDirectoryPath = ConfigurationManager.AppSettings["LogDirectoryPath"];
                    DateTime? latestCreateTime = GetLatestCreateTime();

                    if (Directory.Exists(logDirectoryPath))
                    {
                        string[] logFiles = Directory.GetFiles(logDirectoryPath, "*.txt", SearchOption.AllDirectories);
                        foreach (string logFile in logFiles)
                        {
                            FileInfo fileInfo = new FileInfo(logFile);
                            if ((latestCreateTime == null || fileInfo.CreationTime > latestCreateTime.Value) &&
                                fileInfo.CreationTime >= new DateTime(2025, 7, 31, 0, 0, 0))
                            {
                                try
                                {
                                    WaitForFileToBeReady(logFile);
                                    ProcessLogFile(logFile);
                                }
                                catch (Exception ex)
                                {
                                    LogNet.WriteInfo(logFile + " -数据解析失败" + ex.Message);
                                    LogReceived?.Invoke(logFile + " -数据解析失败" + ex.Message);

                                    this.Invoke((MethodInvoker)(() =>
                                    {
                                        MessageBox.Show($"数据解析失败: {ex.Message}");
                                    }));
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogNet.WriteInfo("初始化历史日志处理失败: " + ex.Message);
                }
            });
        }
    }
}