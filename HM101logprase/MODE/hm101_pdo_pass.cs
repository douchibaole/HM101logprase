using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Models
{
    ///<summary>
    ///轧钢一线PDO解析道次相关详细数据表
    ///</summary>
    [SugarTable("hm101_pdo_pass")]
    public partial class hm101_pdo_pass
    {
        public hm101_pdo_pass()
        {


        }
        /// <summary>
        /// Desc:主键
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true)]
        public long MESSAGE_ID { get; set; }

        /// <summary>
        /// Desc:钢板号
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string STEEL_NO { get; set; }

        /// <summary>
        /// Desc:粗轧道次
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int? RM_PASS { get; set; }

        /// <summary>
        /// Desc:粗轧厚度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal? RM_THICK { get; set; }

        /// <summary>
        /// Desc:粗轧辊缝
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal? RM_GAP { get; set; }

        /// <summary>
        /// Desc:粗轧宽度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal? RM_WIDTH { get; set; }

        /// <summary>
        /// Desc:粗轧表面温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal? RM_SURFT { get; set; }

        /// <summary>
        /// Desc:粗轧心部温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal? RM_CORET { get; set; }

        /// <summary>
        /// Desc:粗轧平均温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal? RM_AVGT { get; set; }

        /// <summary>
        /// Desc:粗轧轧制力
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal? RM_FORCE { get; set; }

        /// <summary>
        /// Desc:粗轧轧辊转速
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal? RM_SPEED { get; set; }

        /// <summary>
        /// Desc:粗轧电机电流
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal? RM_CURRENT { get; set; }

        /// <summary>
        /// Desc:粗轧油膜厚度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal? RM_OILTHK { get; set; }

        /// <summary>
        /// Desc:粗轧压下率
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal? RM_DHRATE { get; set; }

        /// <summary>
        /// Desc:粗轧道次间隔时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal? RM_INTERVAL { get; set; }

        /// <summary>
        /// Desc:精轧道次
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int? FM_PASS { get; set; }

        /// <summary>
        /// Desc:精轧厚度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal? FM_THICK { get; set; }

        /// <summary>
        /// Desc:精轧辊缝
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal? FM_GAP { get; set; }

        /// <summary>
        /// Desc:精轧宽度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal? FM_WIDTH { get; set; }

        /// <summary>
        /// Desc:精轧表面温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal? FM_SURFT { get; set; }

        /// <summary>
        /// Desc:精轧心部温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal? FM_CORET { get; set; }

        /// <summary>
        /// Desc:精轧平均温度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal? FM_AVGT { get; set; }

        /// <summary>
        /// Desc:精轧轧制力
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal? FM_FORCE { get; set; }

        /// <summary>
        /// Desc:精轧轧辊转速
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal? FM_SPEED { get; set; }

        /// <summary>
        /// Desc:精轧电机电流
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal? FM_CURRENT { get; set; }

        /// <summary>
        /// Desc:精轧油膜厚度
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal? FM_OILTHK { get; set; }

        /// <summary>
        /// Desc:精轧压下率
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal? FM_DHRATE { get; set; }

        /// <summary>
        /// Desc:精轧道次间隔时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal? FM_INTERVAL { get; set; }

        /// <summary>
        /// Desc:创建时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? CREATE_TIME { get; set; }

        /// <summary>
        /// Desc:更新时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? UPDATE_TIME { get; set; }

    }
}
