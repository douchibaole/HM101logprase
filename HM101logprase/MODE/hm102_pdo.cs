using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Models
{
    ///<summary>
    ///轧钢二线PDO主数据表
    ///</summary>
    [SugarTable("hm102_pdo")]
    public partial class hm102_pdo
    {
           public hm102_pdo(){


           }
           /// <summary>
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public long MESSAGE_ID {get;set;}

           /// <summary>
           /// Desc:生产日期
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PRO_DATE {get;set;}

           /// <summary>
           /// Desc:生产时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PRO_TIME {get;set;}

           /// <summary>
           /// Desc:钢板号Product
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string STEEL_NO {get;set;}

           /// <summary>
           /// Desc:钢种Steel
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string STEEL_GRADE {get;set;}

           /// <summary>
           /// Desc:热态板坯厚度Hot Slab thick
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? HOT_SLAB_THICK {get;set;}

           /// <summary>
           /// Desc:Hard_A13
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? STEEL_HARD_A13 {get;set;}

           /// <summary>
           /// Desc:Hard_A14
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? STEEL_HARD_A14 {get;set;}

           /// <summary>
           /// Desc:热态目标厚度Hot Target thick
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? HOT_TARGET_THICK {get;set;}

           /// <summary>
           /// Desc:L3厚度公差
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? STEEL_THICK_TOLERANCE_FROM_L3 {get;set;}

           /// <summary>
           /// Desc:成品厚度公差PDI:Thick tolerance
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? STEEL_THICK_TOLERANCE {get;set;}

           /// <summary>
           /// Desc:成品宽度切边量PDI:Width side cut (mm)
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? STEEL_WIDTH_SIDE_CUT {get;set;}

           /// <summary>
           /// Desc:母料尺寸Size
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SLAB_SIZE {get;set;}

           /// <summary>
           /// Desc:母料重量Weight
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? SLAB_WEIGHT {get;set;}

           /// <summary>
           /// Desc:热态板坯宽度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? HOT_SLAB_WIDTH {get;set;}

           /// <summary>
           /// Desc:母料吨米
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? SLAB_TONM {get;set;}

           /// <summary>
           /// Desc:母料温度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? SLAB_TEMP {get;set;}

           /// <summary>
           /// Desc:热态目标宽度Hot Target width
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? HOT_TARGET_WIDTH {get;set;}

           /// <summary>
           /// Desc:目标尺寸
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string REQ_SIZE {get;set;}

           /// <summary>
           /// Desc:目标重量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? REQ_WEIGHT {get;set;}

           /// <summary>
           /// Desc:热态板坯长度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? HOT_SLAB_LENGTH {get;set;}

           /// <summary>
           /// Desc:目标吨米
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? REQ_TONM {get;set;}

           /// <summary>
           /// Desc:热态目标长度Hot Target length
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? HOT_TARGET_LENGTH {get;set;}

           /// <summary>
           /// Desc:化学成分C
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_C {get;set;}

           /// <summary>
           /// Desc:化学成分Si
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_SI {get;set;}

           /// <summary>
           /// Desc:化学成分Mn
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_MN {get;set;}

           /// <summary>
           /// Desc:化学成分P
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_P {get;set;}

           /// <summary>
           /// Desc:化学成分S
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_S {get;set;}

           /// <summary>
           /// Desc:化学成分Cu
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_CU {get;set;}

           /// <summary>
           /// Desc:化学成分Ni
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_NI {get;set;}

           /// <summary>
           /// Desc:化学成分Cr
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_CR {get;set;}

           /// <summary>
           /// Desc:化学成分As
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_AS {get;set;}

           /// <summary>
           /// Desc:化学成分Sn
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_SN {get;set;}

           /// <summary>
           /// Desc:化学成分Nb
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_NB {get;set;}

           /// <summary>
           /// Desc:化学成分V
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_V {get;set;}

           /// <summary>
           /// Desc:化学成分Als
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_AL {get;set;}

           /// <summary>
           /// Desc:化学成分Ti
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_TI {get;set;}

           /// <summary>
           /// Desc:化学成分Mo
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_MO {get;set;}

           /// <summary>
           /// Desc:化学成分B
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_B {get;set;}

           /// <summary>
           /// Desc:化学成分W
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_W {get;set;}

           /// <summary>
           /// Desc:化学成分Ca
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_CA {get;set;}

           /// <summary>
           /// Desc:化学成分H
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_H {get;set;}

           /// <summary>
           /// Desc:化学成分O
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_O {get;set;}

           /// <summary>
           /// Desc:L2 run flag
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? L2_RUN_FLAG {get;set;}

           /// <summary>
           /// Desc:实测宽度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? MEASURED_WIDTH {get;set;}

           /// <summary>
           /// Desc:道次总数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? PASS_NUMBER {get;set;}

           /// <summary>
           /// Desc:MAS_L_S
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? MAS_L_S {get;set;}

           /// <summary>
           /// Desc:MAS_L1_S
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? MAS_L1_S {get;set;}

           /// <summary>
           /// Desc:MAS_L2_S
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? MAS_L2_S {get;set;}

           /// <summary>
           /// Desc:MAS_DH_S
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? MAS_DH_S {get;set;}

           /// <summary>
           /// Desc:MAS_G_S
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? MAS_G_S {get;set;}

           /// <summary>
           /// Desc:MAS_DG_S
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? MAS_DG_S {get;set;}

           /// <summary>
           /// Desc:MAS_FS1_S
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? MAS_FS1_S {get;set;}

           /// <summary>
           /// Desc:MAS_FS_S
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? MAS_FS_S {get;set;}

           /// <summary>
           /// Desc:MAS_L_B
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? MAS_L_B {get;set;}

           /// <summary>
           /// Desc:MAS_L1_B
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? MAS_L1_B {get;set;}

           /// <summary>
           /// Desc:MAS_L2_B
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? MAS_L2_B {get;set;}

           /// <summary>
           /// Desc:MAS_DH_B
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? MAS_DH_B {get;set;}

           /// <summary>
           /// Desc:MAS_G_B
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? MAS_G_B {get;set;}

           /// <summary>
           /// Desc:MAS_DG_B
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? MAS_DG_B {get;set;}

           /// <summary>
           /// Desc:MAS_FS1_B
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? MAS_FS1_B {get;set;}

           /// <summary>
           /// Desc:MAS_FS_B
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? MAS_FS_B {get;set;}

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
