using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using HTWL.Communication;
using Models;
using SqlSugar;
using SteelLogImporter.Parser;
using XYGCommunication;
using XYGCommunication.LogNet;



namespace SteelLogImporter
{
    public partial class Form1 : Form
    {
        private string _selectedFilePath;
        private SqlSugarClient DBClinet;
        private readonly LogParser _logParser = new LogParser();
        private FileSystemWatcher _watcher;
        private Timer _successTimer;
        public static ILogNet LogNet { get; set; }




        public Form1()
        {
            InitializeComponent();
            DBClinet = Communication.dbMYSQL2;
            StartMonitoring(@"F:\logs"); // 替换为实际的目标文件夹路径
            Process processes = Process.GetCurrentProcess();
            string name = processes.ProcessName;
            LogNet = new LogNetDateTime("F:\\中厚板二级\\HM101PDOPARSELOG\\" + name, GenerateMode.ByEveryDay);
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
                // 等待文件写入完成
                WaitForFileToBeReady(e.FullPath);

                // 处理日志文件
                ProcessLogFile(e.FullPath);
            }
            catch (Exception ex)
            {
                LogNet.WriteInfo(e.FullPath + " -数据解析失败" + ex.Message);
                MessageBox.Show($"数据解析失败: {ex.Message}");
               
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
            MessageBox.Show($"监控出错: {e.GetException().Message}");
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

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "日志文件 (*.txt)|*.txt|所有文件 (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _selectedFilePath = ofd.FileName;
                    txtFilePath.Text = _selectedFilePath;
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedFilePath))
            {
                MessageBox.Show("请选择日志文件");
                return;
            }

            try
            {
                // 处理日志文件
                ProcessLogFile(_selectedFilePath);
            }
            catch (Exception ex)
            {
                LogNet.WriteInfo(_selectedFilePath + " -数据解析失败" + ex.Message);
                MessageBox.Show($"数据解析失败: {ex.Message}");
            }
        }

        private void ProcessLogFile(string filePath)
        {
            // 解析日志
            var (mainLog, passLogs) = _logParser.ParseLog(filePath);

            hm101_pdo LogPrase = new hm101_pdo();
            List<hm101_pdo_pass> listLogPrasepass = new List<hm101_pdo_pass>();

            LogPrase.MESSAGE_ID = mainLog.MESSAGE_ID;
            LogPrase.PRO_DATE = mainLog.PRO_DATE;
            LogPrase.PRO_TIME = mainLog.PRO_TIME;
            LogPrase.STEEL_NO = mainLog.STEEL_NO;
            LogPrase.STEEL_GRADE = mainLog.STEEL_GRADE;
            LogPrase.HOT_SLAB_THICK = mainLog.HOT_SLAB_THICK;
            LogPrase.STEEL_HARD_A13 = mainLog.STEEL_HARD_A13;
            LogPrase.STEEL_HARD_A14 = mainLog.STEEL_HARD_A14;
            LogPrase.HOT_TARGET_THICK = mainLog.HOT_TARGET_THICK;
            LogPrase.COLD_TARGET_THICK = mainLog.COLD_TARGET_THICK;
            LogPrase.STEEL_THICK_TOLERANCE = mainLog.STEEL_THICK_TOLERANCE;
            LogPrase.STEEL_WIDTH_SIDE_CUT = mainLog.STEEL_WIDTH_SIDE_CUT;
            LogPrase.SLAB_SIZE = mainLog.SLAB_SIZE;
            LogPrase.SLAB_WEIGHT = mainLog.SLAB_WEIGHT;
            LogPrase.HOT_SLAB_WIDTH = mainLog.HOT_SLAB_WIDTH;
            LogPrase.SLAB_TONM = mainLog.SLAB_TONM;
            LogPrase.SLAB_TEMP = mainLog.SLAB_TEMP;
            LogPrase.HOT_TARGET_WIDTH = mainLog.HOT_TARGET_WIDTH;
            LogPrase.REQ_SIZE = mainLog.REQ_SIZE;
            LogPrase.REQ_WEIGHT = mainLog.REQ_WEIGHT;
            LogPrase.HOT_SLAB_LENGTH = mainLog.HOT_SLAB_LENGTH;
            LogPrase.REQ_TONM = mainLog.REQ_TONM;
            LogPrase.HOT_TARGET_LENGTH = mainLog.HOT_TARGET_LENGTH;
            // 化学成分字段
            LogPrase.CHEMICAL_C = mainLog.CHEMICAL_C;
            LogPrase.CHEMICAL_SI = mainLog.CHEMICAL_SI;
            LogPrase.CHEMICAL_MN = mainLog.CHEMICAL_MN;
            LogPrase.CHEMICAL_P = mainLog.CHEMICAL_P;
            LogPrase.CHEMICAL_S = mainLog.CHEMICAL_S;
            LogPrase.CHEMICAL_CU = mainLog.CHEMICAL_CU;
            LogPrase.CHEMICAL_NI = mainLog.CHEMICAL_NI;
            LogPrase.CHEMICAL_CR = mainLog.CHEMICAL_CR;
            LogPrase.CHEMICAL_AS = mainLog.CHEMICAL_AS;
            LogPrase.CHEMICAL_SN = mainLog.CHEMICAL_SN;
            LogPrase.CHEMICAL_NB = mainLog.CHEMICAL_NB;
            LogPrase.CHEMICAL_V = mainLog.CHEMICAL_V;
            LogPrase.CHEMICAL_ALS = mainLog.CHEMICAL_ALS;
            LogPrase.CHEMICAL_TI = mainLog.CHEMICAL_TI;
            LogPrase.CHEMICAL_MO = mainLog.CHEMICAL_MO;
            LogPrase.CHEMICAL_B = mainLog.CHEMICAL_B;
            LogPrase.CHEMICAL_W = mainLog.CHEMICAL_W;
            LogPrase.CHEMICAL_CA = mainLog.CHEMICAL_CA;
            LogPrase.CHEMICAL_H = mainLog.CHEMICAL_H;
            LogPrase.CHEMICAL_O = mainLog.CHEMICAL_O;
            LogPrase.CHEMICAL_CEQ = mainLog.CHEMICAL_CEQ;
            LogPrase.CHEMICAL_SB = mainLog.CHEMICAL_SB;
            LogPrase.CHEMICAL_VTINB = mainLog.CHEMICAL_VTINB;
            LogPrase.CHEMICAL_MOCR = mainLog.CHEMICAL_MOCR;
            LogPrase.CHEMICAL_ALT = mainLog.CHEMICAL_ALT;
            LogPrase.CHEMICAL_CEV = mainLog.CHEMICAL_CEV;
            // 补充轧机参数字段
            LogPrase.RM_WORK_ROLL_RADIUS = mainLog.RM_WORK_ROLL_RADIUS;
            LogPrase.RM_WORK_ROLL_LENGTH = mainLog.RM_WORK_ROLL_LENGTH;
            LogPrase.RM_WORK_ROLL_CROWN = mainLog.RM_WORK_ROLL_CROWN;
            LogPrase.RM_BACK_UP_ROLL_RADIUS = mainLog.RM_BACK_UP_ROLL_RADIUS;
            LogPrase.RM_BACK_UP_ROLL_LENGTH = mainLog.RM_BACK_UP_ROLL_LENGTH;
            LogPrase.RM_BACK_UP_ROLL_CROWN = mainLog.RM_BACK_UP_ROLL_CROWN;
            LogPrase.RM_ZERO_FORCE = mainLog.RM_ZERO_FORCE;
            LogPrase.FM_WORK_ROLL_RADIUS = mainLog.FM_WORK_ROLL_RADIUS;
            LogPrase.FM_WORK_ROLL_LENGTH = mainLog.FM_WORK_ROLL_LENGTH;
            LogPrase.FM_WORK_ROLL_CROWN = mainLog.FM_WORK_ROLL_CROWN;
            LogPrase.FM_BACK_UP_ROLL_RADIUS = mainLog.FM_BACK_UP_ROLL_RADIUS;
            LogPrase.FM_BACK_UP_ROLL_LENGTH = mainLog.FM_BACK_UP_ROLL_LENGTH;
            LogPrase.FM_BACK_UP_ROLL_CROWN = mainLog.FM_BACK_UP_ROLL_CROWN;
            LogPrase.FM_ZERO_FORCE = mainLog.FM_ZERO_FORCE;
            // 补充轧制时间字段
            LogPrase.RM_START_TIME = mainLog.RM_START_TIME;
            LogPrase.RM_END_TIME = mainLog.RM_END_TIME;
            LogPrase.FM_START_TIME = mainLog.FM_START_TIME;
            LogPrase.FM_END_TIME = mainLog.FM_END_TIME;
            LogPrase.STRATEGY_NUMBER = mainLog.STRATEGY_NUMBER;
            LogPrase.ACTIVE_PHASES = mainLog.ACTIVE_PHASES;
            // IMM参数字段
            LogPrase.IMM_AIR_TEMP = mainLog.IMM_AIR_TEMP;
            LogPrase.IMM_TRANSFER_TIME = mainLog.IMM_TRANSFER_TIME;
            LogPrase.IMM_TCR_TEMP = mainLog.IMM_TCR_TEMP;
            LogPrase.IMM_TAR_TEMP = mainLog.IMM_TAR_TEMP;
            LogPrase.IMM_TCR_THICK = mainLog.IMM_TCR_THICK;
            LogPrase.IMM_PROFILE_FB = mainLog.IMM_PROFILE_FB;
            LogPrase.IMM_MAX_ROLLING_FORCE = mainLog.IMM_MAX_ROLLING_FORCE;
            LogPrase.IMM_TARGET_THICK_ADJUSTMENT = mainLog.IMM_TARGET_THICK_ADJUSTMENT;
            LogPrase.IMM_SIDE_CUT_ADJUSTMENT = mainLog.IMM_SIDE_CUT_ADJUSTMENT;
            LogPrase.IMM_SLAB_TEMP_T_R2 = mainLog.IMM_SLAB_TEMP_T_R2;
            LogPrase.IMM_TCR_FLAG = mainLog.IMM_TCR_FLAG;
            LogPrase.IMM_TCR1_TMP = mainLog.IMM_TCR1_TMP;
            LogPrase.IMM_TCR2_TMP = mainLog.IMM_TCR2_TMP;
            LogPrase.IMM_TCR1_THK = mainLog.IMM_TCR1_THK;
            LogPrase.IMM_TCR2_THK = mainLog.IMM_TCR2_THK;
            LogPrase.IMM_TAR_TMP_MAX = mainLog.IMM_TAR_TMP_MAX;
            LogPrase.IMM_TAR_TMP_MIN = mainLog.IMM_TAR_TMP_MIN;
            LogPrase.IMM_TAR_THK_MAX = mainLog.IMM_TAR_THK_MAX;
            LogPrase.IMM_TAR_THK_MIN = mainLog.IMM_TAR_THK_MIN;
            LogPrase.IMM_TCR_TMPSETUP = mainLog.IMM_TCR_TMPSETUP;
            LogPrase.IMM_GET_GYPDI_FLG = mainLog.IMM_GET_GYPDI_FLG;
            LogPrase.IMM_PROD_STATUS = mainLog.IMM_PROD_STATUS;
            LogPrase.IMM_L2_RUN_FLAG = mainLog.IMM_L2_RUN_FLAG;
            LogPrase.IMM_STAND_MOD = mainLog.IMM_STAND_MOD;
            LogPrase.MEASURED_WIDTH = mainLog.MEASURED_WIDTH;
            LogPrase.REAL_PRODUCT_LENGTH = mainLog.REAL_PRODUCT_LENGTH;

            LogPrase.CREATE_TIME = DateTime.Now;



            // 导入道次数据
            foreach (var passLog in passLogs)
            {
                hm101_pdo_pass LogPrasepass = new hm101_pdo_pass();

               
                LogPrasepass.STEEL_NO = mainLog.STEEL_NO;

                // 粗轧（RM）相关属性
                LogPrasepass.RM_PASS = passLog.RM_PASS;
                LogPrasepass.RM_THICK = passLog.RM_THICK;
                LogPrasepass.RM_GAP = passLog.RM_GAP;
                LogPrasepass.RM_WIDTH = passLog.RM_WIDTH;
                LogPrasepass.RM_SURFT = passLog.RM_SURFT;
                LogPrasepass.RM_CORET = passLog.RM_CORET;
                LogPrasepass.RM_AVGT = passLog.RM_AVGT;
                LogPrasepass.RM_FORCE = passLog.RM_FORCE;
                LogPrasepass.RM_SPEED = passLog.RM_SPEED;
                LogPrasepass.RM_CURRENT = passLog.RM_CURRENT;
                LogPrasepass.RM_OILTHK = passLog.RM_OILTHK;
                LogPrasepass.RM_DHRATE = passLog.RM_DHRATE;
                LogPrasepass.RM_INTERVAL = passLog.RM_INTERVAL;
                // 精轧（FM）相关属性
                LogPrasepass.FM_PASS = passLog.FM_PASS;
                LogPrasepass.FM_THICK = passLog.FM_THICK;
                LogPrasepass.FM_GAP = passLog.FM_GAP;
                LogPrasepass.FM_WIDTH = passLog.FM_WIDTH;
                LogPrasepass.FM_SURFT = passLog.FM_SURFT;
                LogPrasepass.FM_CORET = passLog.FM_CORET;
                LogPrasepass.FM_AVGT = passLog.FM_AVGT;
                LogPrasepass.FM_FORCE = passLog.FM_FORCE;
                LogPrasepass.FM_SPEED = passLog.FM_SPEED;
                LogPrasepass.FM_CURRENT = passLog.FM_CURRENT;
                LogPrasepass.FM_OILTHK = passLog.FM_OILTHK;
                LogPrasepass.FM_DHRATE = passLog.FM_DHRATE;
                LogPrasepass.FM_INTERVAL = passLog.FM_INTERVAL;
                LogPrasepass.CREATE_TIME = DateTime.Now;
                LogPrasepass.MESSAGE_ID = passLog.MESSAGE_ID;
                listLogPrasepass.Add(LogPrasepass);
            }
         
            DBClinet.Insertable(LogPrase).ExecuteCommand();
            DBClinet.Insertable(listLogPrasepass).ExecuteCommand();

            LogNet.WriteInfo(filePath+" -数据解析成功");
          //  MessageBox.Show("数据解析成功");
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBClinet.DbFirst.IsCreateAttribute().CreateClassFile("c:\\Demo", "Models");
        }

  



    }
}