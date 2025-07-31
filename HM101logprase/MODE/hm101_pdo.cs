using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Models
{
    ///<summary>
    ///轧钢一线PDO主表数据
    ///</summary>
    [SugarTable("hm101_pdo")]
    public partial class hm101_pdo
    {
           public hm101_pdo(){


           }
           /// <summary>
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public long MESSAGE_ID {get;set;}

           /// <summary>
           /// Desc:生产的日期
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PRO_DATE {get;set;}

           /// <summary>
           /// Desc:生产的时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PRO_TIME {get;set;}

           /// <summary>
           /// Desc:钢板号 Product
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string STEEL_NO {get;set;}

           /// <summary>
           /// Desc:钢种 Steel
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string STEEL_GRADE {get;set;}

           /// <summary>
           /// Desc:热态板坯厚度 Hot  Slab thick
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
           /// Desc:热态目标厚度 Hot Target thick
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? HOT_TARGET_THICK {get;set;}

           /// <summary>
           /// Desc:冷态目标厚度 Cold Target thick
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? COLD_TARGET_THICK {get;set;}

           /// <summary>
           /// Desc:成品厚度公差 PDI:THick tolerance
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? STEEL_THICK_TOLERANCE {get;set;}

           /// <summary>
           /// Desc:成品宽度切边量 PDI:Width side cut (mm):
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? STEEL_WIDTH_SIDE_CUT {get;set;}

           /// <summary>
           /// Desc:母料尺寸 Size
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SLAB_SIZE {get;set;}

           /// <summary>
           /// Desc:母料重量 Weight
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
           /// Desc:热态目标宽度 Hot Target width
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
           /// Desc:热态目标长度 Hot Target length
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? HOT_TARGET_LENGTH {get;set;}

           /// <summary>
           /// Desc:化学成分 C
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_C {get;set;}

           /// <summary>
           /// Desc:化学成分 Si
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_SI {get;set;}

           /// <summary>
           /// Desc:化学成分 Mn
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_MN {get;set;}

           /// <summary>
           /// Desc:化学成分 P
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_P {get;set;}

           /// <summary>
           /// Desc:化学成分 S
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_S {get;set;}

           /// <summary>
           /// Desc:化学成分 Cu
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_CU {get;set;}

           /// <summary>
           /// Desc:化学成分 Ni
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_NI {get;set;}

           /// <summary>
           /// Desc:化学成分 Cr
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_CR {get;set;}

           /// <summary>
           /// Desc:化学成分 As
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_AS {get;set;}

           /// <summary>
           /// Desc:化学成分 Sn
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_SN {get;set;}

           /// <summary>
           /// Desc:化学成分 Nb
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_NB {get;set;}

           /// <summary>
           /// Desc:化学成分 V
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_V {get;set;}

           /// <summary>
           /// Desc:化学成分 Als
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_ALS {get;set;}

           /// <summary>
           /// Desc:化学成分 Ti
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_TI {get;set;}

           /// <summary>
           /// Desc:化学成分 Mo
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_MO {get;set;}

           /// <summary>
           /// Desc:化学成分 B
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_B {get;set;}

           /// <summary>
           /// Desc:化学成分 W
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_W {get;set;}

           /// <summary>
           /// Desc:化学成分 Ca
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_CA {get;set;}

           /// <summary>
           /// Desc:化学成分 H
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_H {get;set;}

           /// <summary>
           /// Desc:化学成分 O
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_O {get;set;}

           /// <summary>
           /// Desc:化学成分 Ceq
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_CEQ {get;set;}

           /// <summary>
           /// Desc:化学成分 Sb
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_SB {get;set;}

           /// <summary>
           /// Desc:化学成分 VTiNb
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_VTINB {get;set;}

           /// <summary>
           /// Desc:化学成分 MoCr
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_MOCR {get;set;}

           /// <summary>
           /// Desc:化学成分 Alt
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_ALT {get;set;}

           /// <summary>
           /// Desc:化学成分 CEV
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHEMICAL_CEV {get;set;}

           /// <summary>
           /// Desc:粗轧工作辊半径
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? RM_WORK_ROLL_RADIUS {get;set;}

           /// <summary>
           /// Desc:粗轧工作辊长度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? RM_WORK_ROLL_LENGTH {get;set;}

           /// <summary>
           /// Desc:粗轧工作辊凸度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? RM_WORK_ROLL_CROWN {get;set;}

           /// <summary>
           /// Desc:粗轧支撑辊半径
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? RM_BACK_UP_ROLL_RADIUS {get;set;}

           /// <summary>
           /// Desc:粗轧支撑辊长度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? RM_BACK_UP_ROLL_LENGTH {get;set;}

           /// <summary>
           /// Desc:粗轧支撑辊凸度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? RM_BACK_UP_ROLL_CROWN {get;set;}

           /// <summary>
           /// Desc:粗轧零调力
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? RM_ZERO_FORCE {get;set;}

           /// <summary>
           /// Desc:精轧工作辊半径
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? FM_WORK_ROLL_RADIUS {get;set;}

           /// <summary>
           /// Desc:精轧工作辊长度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? FM_WORK_ROLL_LENGTH {get;set;}

           /// <summary>
           /// Desc:精轧工作辊凸度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? FM_WORK_ROLL_CROWN {get;set;}

           /// <summary>
           /// Desc:精轧支撑辊半径
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? FM_BACK_UP_ROLL_RADIUS {get;set;}

           /// <summary>
           /// Desc:精轧支撑辊长度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? FM_BACK_UP_ROLL_LENGTH {get;set;}

           /// <summary>
           /// Desc:精轧支撑辊凸度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? FM_BACK_UP_ROLL_CROWN {get;set;}

           /// <summary>
           /// Desc:精轧零调力
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? FM_ZERO_FORCE {get;set;}

           /// <summary>
           /// Desc:策略号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? STRATEGY_NUMBER {get;set;}

           /// <summary>
           /// Desc:激活的阶段
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ACTIVE_PHASES {get;set;}

           /// <summary>
           /// Desc:环境温度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? IMM_AIR_TEMP {get;set;}

           /// <summary>
           /// Desc:从 1 号加热炉出炉后的输送时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? IMM_TRANSFER_TIME {get;set;}

           /// <summary>
           /// Desc:（粗轧出口）温度控制轧制温度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? IMM_TCR_TEMP {get;set;}

           /// <summary>
           /// Desc:目标温度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? IMM_TAR_TEMP {get;set;}

           /// <summary>
           /// Desc:（粗轧出口）温度控制轧制厚度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? IMM_TCR_THICK {get;set;}

           /// <summary>
           /// Desc:板形反馈值
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? IMM_PROFILE_FB {get;set;}

           /// <summary>
           /// Desc:精轧机最大允许轧制力
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? IMM_MAX_ROLLING_FORCE {get;set;}

           /// <summary>
           /// Desc:来自 HMI 的目标厚度调整量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? IMM_TARGET_THICK_ADJUSTMENT {get;set;}

           /// <summary>
           /// Desc:来自 HMI 的切边量调整
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? IMM_SIDE_CUT_ADJUSTMENT {get;set;}

           /// <summary>
           /// Desc:Slab 表面温度 measured from T_R2
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? IMM_SLAB_TEMP_T_R2 {get;set;}

           /// <summary>
           /// Desc:温度控制轧制标志
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? IMM_TCR_FLAG {get;set;}

           /// <summary>
           /// Desc:温度控制轧制阶段 1 目标温度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? IMM_TCR1_TMP {get;set;}

           /// <summary>
           /// Desc:温度控制轧制阶段 2 目标温度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? IMM_TCR2_TMP {get;set;}

           /// <summary>
           /// Desc:温度控制轧制阶段 1 目标厚度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? IMM_TCR1_THK {get;set;}

           /// <summary>
           /// Desc:温度控制轧制阶段 2 目标厚度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? IMM_TCR2_THK {get;set;}

           /// <summary>
           /// Desc:tar_tmp_max
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? IMM_TAR_TMP_MAX {get;set;}

           /// <summary>
           /// Desc:tar_tmp_min
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? IMM_TAR_TMP_MIN {get;set;}

           /// <summary>
           /// Desc:tar_thk_max
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? IMM_TAR_THK_MAX {get;set;}

           /// <summary>
           /// Desc:tar_thk_min
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? IMM_TAR_THK_MIN {get;set;}

           /// <summary>
           /// Desc:tcr_tmpSetup
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? IMM_TCR_TMPSETUP {get;set;}

           /// <summary>
           /// Desc:get_gypdi_flg
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? IMM_GET_GYPDI_FLG {get;set;}

           /// <summary>
           /// Desc:Prod_status
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? IMM_PROD_STATUS {get;set;}

           /// <summary>
           /// Desc:L2 run flag
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? IMM_L2_RUN_FLAG {get;set;}

           /// <summary>
           /// Desc:Stand mod
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? IMM_STAND_MOD {get;set;}

           /// <summary>
           /// Desc:粗轧开始时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string RM_START_TIME {get;set;}

           /// <summary>
           /// Desc:粗轧结束时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string RM_END_TIME {get;set;}

           /// <summary>
           /// Desc:精轧开始时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string FM_START_TIME {get;set;}

           /// <summary>
           /// Desc:精轧结束时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string FM_END_TIME {get;set;}

           /// <summary>
           /// Desc:实测宽度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? MEASURED_WIDTH {get;set;}

           /// <summary>
           /// Desc:实测长度
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? REAL_PRODUCT_LENGTH {get;set;}

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
