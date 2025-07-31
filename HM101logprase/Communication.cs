using SqlSugar;


namespace HTWL.Communication
{
    public class Communication
    {
     
        public static string ConnectionString5 = "server=10.0.36.105;port=3306;database=hbis_tpqc_interface;user=test;password=test;";
        public static SqlSugarClient dbMYSQL2 = new SqlSugarClient(new ConnectionConfig()
        {
            ConnectionString = ConnectionString5,
            DbType = DbType.MySql,
            IsAutoCloseConnection = true,
        },db =>
   {

       db.Aop.OnLogExecuting = (sql, pars) =>
       {

           //获取原生SQL推荐 5.1.4.63  性能OK
           //Console.WriteLine(UtilMethods.GetNativeSql(sql, pars));

           //获取无参数化SQL 对性能有影响，特别大的SQL参数多的，调试使用
           //Console.WriteLine(UtilMethods.GetSqlString(DbType.SqlServer,sql,pars))


       };

       //注意多租户 有几个设置几个
       //db.GetConnection(i).Aop

   });


        
    }

  
}






