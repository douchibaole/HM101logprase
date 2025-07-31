using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//using Entitys;
using Models;


namespace SteelLogImporter.Parser
{
    public class LogParser
    {
        private string _rollingStage = string.Empty;
        private static readonly Random random = new Random();
       
        public (hm101_pdo mainLog, List<hm101_pdo_pass> passLogs) ParseLog(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            var mainLog = new hm101_pdo();
            var passLogs = new List<hm101_pdo_pass>();
            var currentSection = string.Empty;


            long messageId = MessageIdGenerator.GenerateMessageId();
            mainLog.MESSAGE_ID = messageId;


            foreach (var line in lines)
            {
                var trimLine = line.Trim();
                if (string.IsNullOrEmpty(trimLine)) continue;

                // 识别不同的数据段
                if (trimLine.StartsWith("*  RAL-NEU  *"))
                {
                    currentSection = "PruductDate";
                   // continue;
                }else if (trimLine.StartsWith("------------------------          ---------------------------------------                             time:"))
                {
                    currentSection = "PruductTime";
                   // continue;
                }
                else if (trimLine.StartsWith("* STEEL REFERENCE"))
                {
                    currentSection = "SteelReference";
                    //continue;
                }
                else if (trimLine.Contains("* Chemical elements"))
                {
                    currentSection = "Chemical";
                    //continue;
                }
                else if (trimLine.StartsWith("* Rough MILL CHARACTERISTICS"))
                {
                    currentSection = "RoughMill";
                    //continue;
                }
                else if (trimLine.StartsWith("* Finish MILL CHARACTERISTICS"))
                {
                    currentSection = "FinishMill";
                    //continue;
                }
               
                else if (trimLine.Contains("* Operater IMM data"))
                {
                    currentSection = "IMMData";
                    //continue;
                }

                else if (trimLine.Contains("* Rolling measured data"))
                {
                    currentSection = "RollingData";
                    //continue;
                }

                else
                {
                    //currentSection = string.Empty;
                }

                // 解析不同段的数据
                switch (currentSection)
                {
                    case "PruductDate":
                        ParsePruductDate(trimLine, mainLog);
                        break;
                    case "PruductTime":
                        ParsePruductTime(trimLine, mainLog);
                        break;
                    case "SteelReference":
                        ParseSteelReference(trimLine, mainLog);
                        break;
                    case "Chemical":
                        ParseChemical(trimLine, mainLog);
                        break;
                    case "RoughMill":
                        ParseRoughMill(trimLine, mainLog);
                        break;
                    case "FinishMill":
                        ParseFinishMill(trimLine, mainLog);
                        break;
                    case "IMMData":
                        ParseIMMData(trimLine, mainLog);
                        break;



                    case "RollingData":
                        ParseRollingData(trimLine, passLogs, mainLog);
                        break;
                }
            }

            return (mainLog, passLogs);
        }



        private void ParsePruductDate(string line, hm101_pdo log)
        {
            if (line.StartsWith("*  RAL-NEU  *"))
            {
                log.PRO_DATE = ExtractValueWithLength(line,1,0,10);
            }
        }

        private void ParsePruductTime(string line, hm101_pdo log)
        {
            if (line.StartsWith("------------------------          ---------------------------------------                             time"))
            {
                log.PRO_TIME = ExtractValueWithLength(line, 1, 0,15);
            }
        }

        private void ParseSteelReference(string line, hm101_pdo log)
        {
            if (line.StartsWith("- Product :"))
            {
                log.STEEL_NO = ExtractValueWithLength(line, 1,0 ,25);
                log.SLAB_SIZE = ExtractValueWithLength(line, 2, 0,25);
                log.REQ_SIZE = ExtractValueWithLength(line, 3, 0,20);
            }

            else if (line.StartsWith("- Steel   :"))
            {
                log.STEEL_GRADE = ExtractValueWithLength(line, 1, 0,25);
                log.SLAB_WEIGHT = ParseDecimalValue(line, 2, 0, 20);
                log.REQ_WEIGHT = ParseDecimalValue(line, 3, 0, 20);
            }

            else if (line.StartsWith("- Hot  Slab thick (mm):"))
            {
                log.HOT_SLAB_THICK = ParseDecimalValue(line, 1, 0, 10); 
                log.HOT_SLAB_WIDTH = ParseDecimalValue(line, 2, 0, 20);
                log.HOT_SLAB_LENGTH = ParseDecimalValue(line, 3, 0, 20);
            }
            else if (line.StartsWith("- Hard A13:"))
            {
                log.STEEL_HARD_A13 = ParseDecimalValue(line, 1, 0, 25);
                log.SLAB_TONM = ParseDecimalValue(line, 2, 0, 20);
                log.REQ_TONM = ParseDecimalValue(line, 3, 0, 20);

            }

            else if (line.StartsWith("- Hard A14:"))
            {
                log.STEEL_HARD_A14 = ParseDecimalValue(line, 1, 0, 25);
                log.SLAB_TEMP = ParseDecimalValue(line, 2, 0, 20);
               
            }

            else if (line.StartsWith("- Hot Target thick(mm):"))
            {
                log.HOT_TARGET_THICK = ParseDecimalValue(line, 1, 0, 10);
                log.HOT_TARGET_WIDTH = ParseDecimalValue(line, 2, 0, 20);
                log.HOT_TARGET_LENGTH = ParseDecimalValue(line, 3, 0, 20);
            }

            else if (line.StartsWith("- Cold Target thick(mm):"))
            {
                log.COLD_TARGET_THICK = ParseDecimalValue(line, 1, 0, 15);            
            }

            else if (line.StartsWith("- PDI:THick tolerance (mm):"))
            {
                log.STEEL_THICK_TOLERANCE = ParseDecimalValue(line, 2, 0, 15);
            }
            else if (line.StartsWith("- PDI:Width side cut (mm):"))
            {
                log.STEEL_WIDTH_SIDE_CUT = ParseDecimalValue(line, 2, 0, 15);
            }

            else
            {
                //预留解析其他数据段的逻辑
            }
            // 解析其他钢卷基本信息...
        }

        private void ParseChemical(string line, hm101_pdo log)
        {
            if (line.StartsWith("C      ="))
            {
                log.CHEMICAL_C = ParseDecimalValue(line, 1, 0, 12);
                log.CHEMICAL_SI = ParseDecimalValue(line, 2, 0, 12);
                log.CHEMICAL_MN = ParseDecimalValue(line, 3, 0, 12);
                log.CHEMICAL_P = ParseDecimalValue(line, 4, 0, 12);
                log.CHEMICAL_S = ParseDecimalValue(line, 5, 0, 12);
            }
            else if (line.StartsWith("Cu     ="))
            {
                log.CHEMICAL_CU = ParseDecimalValue(line, 1, 0, 12);
                log.CHEMICAL_NI = ParseDecimalValue(line, 2, 0, 12);
                log.CHEMICAL_CR = ParseDecimalValue(line, 3, 0, 12);
                log.CHEMICAL_AS = ParseDecimalValue(line, 4, 0, 12);
                log.CHEMICAL_SN = ParseDecimalValue(line, 5, 0, 12);
            }
            else if (line.StartsWith("Nb     ="))
            {
                log.CHEMICAL_NB = ParseDecimalValue(line, 1, 0, 12);
                log.CHEMICAL_V = ParseDecimalValue(line, 2, 0, 12);
                log.CHEMICAL_ALS = ParseDecimalValue(line, 3, 0, 12);
                log.CHEMICAL_TI = ParseDecimalValue(line, 4, 0, 12);
                log.CHEMICAL_MO = ParseDecimalValue(line, 5, 0, 12);
            }
            else if (line.StartsWith("B      ="))
            {
                log.CHEMICAL_B = ParseDecimalValue(line, 1, 0, 12);
                log.CHEMICAL_W = ParseDecimalValue(line, 2, 0, 12);
                log.CHEMICAL_CA = ParseDecimalValue(line, 3, 0, 12);
                log.CHEMICAL_H = ParseDecimalValue(line, 4, 0, 12);
                log.CHEMICAL_O = ParseDecimalValue(line, 5, 0, 12);
            }
            else if (line.StartsWith("Ceq    ="))
            {
                log.CHEMICAL_CEQ = ParseDecimalValue(line, 1, 0, 12);
                log.CHEMICAL_SB = ParseDecimalValue(line, 2, 0, 12);
                log.CHEMICAL_VTINB = ParseDecimalValue(line, 3, 0, 12);
                log.CHEMICAL_MOCR = ParseDecimalValue(line, 4, 0, 12);
                log.CHEMICAL_ALT = ParseDecimalValue(line, 5, 0, 12);
            }
            else if (line.StartsWith("CEV    ="))
            {
                log.CHEMICAL_CEV = ParseDecimalValue(line, 1, 0, 12);
            }
        }

        private void ParseRoughMill(string line, hm101_pdo log)
        {
            if (line.Contains("- Work roll radius"))
            {
                log.RM_WORK_ROLL_RADIUS = ParseDecimalValue(line, 1, 0, 50);
            }
            else if (line.Contains("- Work roll length"))
            {
                log.RM_WORK_ROLL_LENGTH = ParseDecimalValue(line, 1, 0, 50);
            }
            else if (line.Contains("- Work roll crown"))
            {
                log.RM_WORK_ROLL_CROWN = ParseDecimalValue(line, 1, 0, 50);
            }
            else if (line.Contains("- Back up roll radius"))
            {
                log.RM_BACK_UP_ROLL_RADIUS = ParseDecimalValue(line, 1, 0, 50);
            }
            else if (line.Contains("- Back up roll length"))
            {
                log.RM_BACK_UP_ROLL_LENGTH = ParseDecimalValue(line, 1, 0, 50);
            }
            else if (line.Contains("- Back up roll crown"))
            {
                log.RM_BACK_UP_ROLL_CROWN = ParseDecimalValue(line, 1, 0, 50);
            }
            else if (line.Contains("- Zero Force"))
            {
                log.RM_ZERO_FORCE = ParseDecimalValue(line, 1, 0, 50);
            }
        }

        private void ParseFinishMill(string line, hm101_pdo log)
        {
            if (line.Contains("- Work roll radius"))
            {
                log.FM_WORK_ROLL_RADIUS = ParseDecimalValue(line, 1, 0, 50);
            }
            else if (line.Contains("- Work roll length"))
            {
                log.FM_WORK_ROLL_LENGTH = ParseDecimalValue(line, 1, 0, 50);
            }
            else if (line.Contains("- Work roll crown"))
            {
                log.FM_WORK_ROLL_CROWN = ParseDecimalValue(line, 1, 0, 50);
            }
            else if (line.Contains("- Back up roll radius"))
            {
                log.FM_BACK_UP_ROLL_RADIUS = ParseDecimalValue(line, 1, 0, 50);
            }
            else if (line.Contains("- Back up roll length"))
            {
                log.FM_BACK_UP_ROLL_LENGTH = ParseDecimalValue(line, 1, 0, 50);
            }
            else if (line.Contains("- Back up roll crown"))
            {
                log.FM_BACK_UP_ROLL_CROWN = ParseDecimalValue(line, 1, 0, 50);
            }
            else if (line.Contains("- Zero Force"))
            {
                log.FM_ZERO_FORCE = ParseDecimalValue(line, 1, 0, 50);
            }
            else if (line.Contains("STRATEGY : "))
            {
                log.STRATEGY_NUMBER = Convert.ToInt32(ParseDecimalValue(line, 2, 0, 50));
            }
            else if (line.Contains("Active phases"))
            {
                log.ACTIVE_PHASES = ExtractValueWithLength(line, 1, 0, 20);
            }
        }

        private void ParseIMMData(string line, hm101_pdo log)
        {
            if (line.Contains("- Air temperature is"))
            {
                log.IMM_AIR_TEMP = ParseDecimalValue(line, 1, 0, 15);
            }
            else if (line.Contains("Transfer time (s)"))
            {
                log.IMM_TRANSFER_TIME = ParseDecimalValue(line, 1, 0, 10);
            }
            else if (line.Contains("- TCR temperature(C)"))
            {
                // 解析TCR温度、目标温度、TCR厚度（同一行多个参数）
                log.IMM_TCR_TEMP = ParseDecimalValue(line, 1, 0, 15);
                log.IMM_TAR_TEMP = ParseDecimalValue(line, 2, 0, 15);
                log.IMM_TCR_THICK = ParseDecimalValue(line, 3, 0, 15);
            }
            else if (line.Contains("- profile_fb is"))
            {
                log.IMM_PROFILE_FB = ParseDecimalValue(line, 1, 0, 15);
            }
            else if (line.Contains("- max rolling Force of finish stand"))
            {
                log.IMM_MAX_ROLLING_FORCE = ParseDecimalValue(line, 1, 0, 15);
            }
            else if (line.Contains("- Target thick adjustment from HMI"))
            {
                log.IMM_TARGET_THICK_ADJUSTMENT = ParseDecimalValue(line, 1, 0, 15);
            }
            else if (line.Contains("- Side cut adjustment from HMI"))
            {
                log.IMM_SIDE_CUT_ADJUSTMENT = ParseDecimalValue(line, 1, 0, 15);
            }

            else if (line.Contains("- Slab surface temperature measured from T_R2"))
            {

                log.IMM_SLAB_TEMP_T_R2 = ParseDecimalValue(line, 1, 0, 10);
            }

            else if (line.Contains("Cortrol rolling data"))
            {
                // 注意原文本中"Cortrol"可能为"Control"的拼写错误，按实际文本匹配
                log.IMM_TCR_FLAG = Convert.ToInt32(ParseDecimalValue(line, 2, 0, 50));
            }
            else if (line.Contains("- tcr1_tmp:"))
            {
                log.IMM_TCR1_TMP = ParseDecimalValue(line, 1, 0, 15);
            }
            else if (line.Contains("- tcr2_tmp:"))
            {
                log.IMM_TCR2_TMP = ParseDecimalValue(line, 1, 0, 15);
            }
            else if (line.Contains("- tcr1_thk:"))
            {
                log.IMM_TCR1_THK = ParseDecimalValue(line, 1, 0, 15);
            }
            else if (line.Contains("- tcr2_thk:"))
            {
                log.IMM_TCR2_THK = ParseDecimalValue(line, 1, 0, 15);
            }

            else if (line.Contains("- tar_tmp_max:"))
            {
                log.IMM_TAR_TMP_MAX = ParseDecimalValue(line, 1, 0, 15);
            }
            else if (line.Contains("- tar_tmp_min:"))
            {
                log.IMM_TAR_TMP_MIN = ParseDecimalValue(line, 1, 0, 15);
            }
            else if (line.Contains("- tar_thk_max:"))
            {
                log.IMM_TAR_THK_MAX = ParseDecimalValue(line, 1, 0, 15);
            }
            else if (line.Contains("- tar_thk_min:"))
            {
                log.IMM_TAR_THK_MIN = ParseDecimalValue(line, 1, 0, 15);
            }
            else if (line.Contains("- tcr_tmpSetup:"))
            {
                log.IMM_TCR_TMPSETUP = ParseDecimalValue(line, 1, 0, 15);
            }
            else if (line.Contains("- get_gypdi_flg"))
            {
                log.IMM_GET_GYPDI_FLG = Convert.ToInt32(ParseDecimalValue(line, 1, 0, 10));
            }
            else if (line.Contains("- Prod_status"))
            {
                log.IMM_PROD_STATUS = Convert.ToInt32(ParseDecimalValue(line, 1, 0, 10));
            }
            else if (line.Contains("- L2 run flag"))
            {
                log.IMM_L2_RUN_FLAG = Convert.ToInt32(ParseDecimalValue(line, 1, 0, 10));
            }
            else if (line.Contains("Stand mod"))
            {
                log.IMM_STAND_MOD = Convert.ToInt32(ParseDecimalValue(line, 4, 0, 10));
            }

           
            else 
            { 
                //预留
            }
           

        }


        private void ParseRollingData(string line, List<hm101_pdo_pass> passLogs, hm101_pdo mainLog)
        {

            // 1. 识别start/end时间
            if (line.Contains("Rough mill Start Time"))
            {
                mainLog.RM_START_TIME = ExtractValueWithLength(line, 1, 0, 20);
            }
            else if (line.Contains("Rough mill End Time"))
            {
                mainLog.RM_END_TIME = ExtractValueWithLength(line, 1, 0, 20);
            }
            else if (line.Contains("Finish mill Start Time"))
            {
                mainLog.FM_START_TIME = ExtractValueWithLength(line, 1, 0, 20);
            }
            else if (line.Contains("Finish mill End Time"))
            {
                mainLog.FM_END_TIME = ExtractValueWithLength(line, 1, 0, 20);
            }

            else if (line.Contains("Measured Width"))
            {
                mainLog.MEASURED_WIDTH = ParseDecimalValue(line, 1, 0, 20);
            }
            else if (line.Contains("Real product Length"))
            {
                mainLog.REAL_PRODUCT_LENGTH = ParseDecimalValue(line, 1, 0, 20);
            }


            // 1. 识别粗轧/精轧阶段（通过日志中的阶段标记行）
            if (line.Contains("Rough mill Start Time"))
            {
                _rollingStage = "Rough"; // 进入粗轧阶段
                return;
            }
            else if (line.Contains("Finish mill Start Time"))
            {
                _rollingStage = "Finish"; // 进入精轧阶段
                return;
            }
            else if (line.Contains("Rough mill End Time") || line.Contains("Finish mill End Time"))
            {
                _rollingStage = ""; // 阶段结束
                return;
            }

            // 2. 解析道次数据行（以数字开头且含|分隔符）
            if (char.IsDigit(line[0]) && line.Contains("|"))
            {
                var pass = ParsePassLine(line);
                if (pass != null)
                {
                    passLogs.Add(pass);
                }
            }


        }





        private string ExtractValueWithLength(string line, int startColonIndex, int startIndex, int length)
        {
            int colonCount = 0;
            int startPosition = 0;

            // 找到第 startColonIndex 个冒号的位置
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == ':' || line[i] == '=')
                {
                    colonCount++;
                    if (colonCount == startColonIndex)
                    {
                        startPosition = i + 1;
                        break;
                    }
                }
            }

            if (startPosition > 0)
            {
                if (startPosition + startIndex < line.Length)
                {
                    int availableLength = line.Length - (startPosition + startIndex);
                    int actualLength = Math.Min(length, availableLength);
                    string value = line.Substring(startPosition + startIndex, actualLength).Trim();
                    return value;
                }
            }

            return string.Empty;
        }



        private decimal? ParseDecimalValue(string line, int startColonIndex, int startIndex, int length)
        {
            var valueStr = ExtractValueWithLength(line, startColonIndex, startIndex, length);
            if (decimal.TryParse(valueStr, out var value))
            {
                return value;
            }
            return null;
        }


        private hm101_pdo_pass ParsePassLine(string line)
        {            
            // 分割行数据（按|分割，移除空项并修剪空格）
            var parts = line.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(p => p.Trim())
                            .ToArray();

            // 校验字段数量（至少13个字段，对应表格列）
            if (parts.Length < 13)
                return null;

            var pass = new hm101_pdo_pass();

            // 根据当前阶段（粗轧/精轧）赋值对应属性
            if (_rollingStage == "Rough")
            {
                // 粗轧数据映射（RM_前缀属性）
                
                pass.RM_PASS = (int)ParseDecimal(parts[0]);
                pass.RM_THICK = ParseDecimal(parts[1]);
                pass.RM_GAP = ParseDecimal(parts[2]);
                pass.RM_WIDTH = ParseDecimal(parts[3]);
                pass.RM_SURFT = ParseDecimal(parts[4]);
                pass.RM_CORET = ParseDecimal(parts[5]);
                pass.RM_AVGT = ParseDecimal(parts[6]);
                pass.RM_FORCE = ParseDecimal(parts[7]);
                pass.RM_SPEED = ParseDecimal(parts[8]);
                pass.RM_CURRENT = ParseDecimal(parts[9]);
                pass.RM_OILTHK = ParseDecimal(parts[10]);
                pass.RM_DHRATE = ParseDecimal(parts[11]);
                pass.RM_INTERVAL = ParseDecimal(parts[12]);
            }
            else if (_rollingStage == "Finish")
            {
                // 精轧数据映射（FM_前缀属性）
                
               pass.FM_PASS = (int?)ParseDecimal(parts[0]);

                pass.FM_THICK = ParseDecimal(parts[1]);
                pass.FM_GAP = ParseDecimal(parts[2]);
                pass.FM_WIDTH = ParseDecimal(parts[3]);
                pass.FM_SURFT = ParseDecimal(parts[4]);
                pass.FM_CORET = ParseDecimal(parts[5]);
                pass.FM_AVGT = ParseDecimal(parts[6]);
                pass.FM_FORCE = ParseDecimal(parts[7]);
                pass.FM_SPEED = ParseDecimal(parts[8]);
                pass.FM_CURRENT = ParseDecimal(parts[9]);
                pass.FM_OILTHK = ParseDecimal(parts[10]);
                pass.FM_DHRATE = ParseDecimal(parts[11]);
                pass.FM_INTERVAL = ParseDecimal(parts[12]);
            }
            long messageId = MessageIdGenerator.GenerateMessageId();            
            pass.MESSAGE_ID = messageId;
            return pass;
        }

        // 辅助方法：字符串转decimal?（处理空值或无效格式）
        private decimal? ParseDecimal(string value)
        {
            if (decimal.TryParse(value, out decimal result))
                return result;
            return null; // 无效格式返回空
        }


    }
}