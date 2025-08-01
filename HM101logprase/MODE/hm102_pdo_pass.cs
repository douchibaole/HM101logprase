using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Models
{
    ///<summary>
    ///轧钢二线PDO道次详情表
    ///</summary>
    [SugarTable("hm102_pdo_pass")]
    public partial class hm102_pdo_pass
    {
           public hm102_pdo_pass(){


           }
           /// <summary>
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public long MESSAGE_ID {get;set;}

           /// <summary>
           /// Desc:钢板号
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string STEEL_NO {get;set;}

           /// <summary>
           /// Desc:粗轧道次
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? RM_PASS {get;set;}

           /// <summary>
           /// Desc:DsGap
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? RM_DSGAP {get;set;}

           /// <summary>
           /// Desc:NdsGap
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? RM_NDSGAP {get;set;}

           /// <summary>
           /// Desc:DsFrc
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? RM_DSFRC {get;set;}

           /// <summary>
           /// Desc:NdsFrc
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? RM_NDSFRC {get;set;}

           /// <summary>
           /// Desc:Recal_thk
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? RM_RECAL_THK {get;set;}

           /// <summary>
           /// Desc:Up_spd
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? RM_UP_SPD {get;set;}

           /// <summary>
           /// Desc:Dw_spd
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? RM_DW_SPD {get;set;}

           /// <summary>
           /// Desc:T_measued
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? RM_T_MEASUED {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? CREATE_TIME {get;set;}

           /// <summary>
           /// Desc:更新时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? UPDATE_TIME {get;set;}

    }
}
