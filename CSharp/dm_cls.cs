using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace KFL.Models
{
    class dm_cls
    {
        private SqlConnection conn_KFL = new SqlConnection(
       "Server=tcp:vxambkie2a.database.windows.net,1433;Database=KFL;User ID=WYK@vxambkie2a;Password=Ds066354169;Trusted_Connection=False;Encrypt=True;Connection Timeout=30");


        private SqlConnection conn_hrcardchangeQ = new SqlConnection(
        "workstation id=mkhrc2;packet size=4096;user id=sa;data source='192.168.1.6';" +
        "persist security info=False;initial catalog=hrcardchange;password=ruh0y@ngfu;Connect Timeout=600");

        private SqlConnection conn_hrcardchangeU = new SqlConnection(
        "workstation id=mkhrc3;packet size=4096;user id=sa;data source='192.168.1.6';" +
        "persist security info=False;initial catalog=hrcardchange;password=ruh0y@ngfu;Connect Timeout=600");


        private SqlConnection conn_rhwr = new SqlConnection(
        "workstation id=mkrhwr;packet size=4096;user id=sa;data source='192.168.1.6';" +
        "persist security info=False;initial catalog=rhwr;password=ruh0y@ngfu;Connect Timeout=600");

        private SqlConnection conn_MaxData = new SqlConnection(
       "workstation id=mkmax;packet size=4096;user id=HoHsin;data source='192.168.1.33';" +
       "persist security info=False;initial catalog=MaxData;password=ruh0y@ngfu;Connect Timeout=600");



        /// <summary>
        /// 查詢 KFL
        /// </summary>
        /// <param name="commstring"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public DataSet exeQuery_KFL(string commstring, string tablename)
        {
            System.Data.SqlClient.SqlDataAdapter dal = new SqlDataAdapter(commstring, conn_KFL);
            DataSet ds1 = new DataSet();
            dal.Fill(ds1, tablename);
            ds1.Dispose();
            return ds1;
        }

        /// <summary>
        /// 新增  hrcardchange
        /// </summary>
        /// <param name="commstring"></param>
        /// <returns></returns>
        public string update_KFL(string commstring)
        {
            System.Data.SqlClient.SqlDataAdapter dal = new SqlDataAdapter(commstring, conn_KFL);
            SqlCommand insert_command = new SqlCommand();
            conn_KFL.Close();
            conn_KFL.Open();
            insert_command.Connection = conn_KFL;
            insert_command.CommandText = commstring;
            insert_command.CommandTimeout = 500;
            dal.UpdateCommand = insert_command;
            try
            {
                dal.UpdateCommand.ExecuteNonQuery();
                conn_KFL.Close();
                return "ok";
            }
            catch (Exception e)
            {

                conn_KFL.Close();
                return e.Message.ToString();
            }
            finally
            {
                //清除
                insert_command.Cancel();
                conn_KFL.Close();
                conn_KFL.Dispose();
            }
        }


        /// <summary>
        /// 查詢 hrcardchange
        /// </summary>
        /// <param name="commstring"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public DataSet exeQuery_hrcardchange(string commstring, string tablename)
        {
            System.Data.SqlClient.SqlDataAdapter dal = new SqlDataAdapter(commstring, conn_hrcardchangeQ);
            DataSet ds1 = new DataSet();

            try
            {
                dal.Fill(ds1, tablename);
                return ds1;
            }
            catch (Exception)
            {
                System.Threading.Thread.Sleep(1000);
                dal.Fill(ds1, tablename);
                return ds1;
                //throw;
            }

            finally
            {
                //清除
                conn_hrcardchangeQ.Close();
                conn_hrcardchangeQ.Dispose();
            }

        }

        /// <summary>
        /// 新增  hrcardchange
        /// </summary>
        /// <param name="commstring"></param>
        /// <returns></returns>
        public string update_hrcardchange(string commstring)
        {
            System.Data.SqlClient.SqlDataAdapter dal = new SqlDataAdapter(commstring, conn_hrcardchangeU);
            SqlCommand insert_command = new SqlCommand();
            conn_hrcardchangeU.Close();
            conn_hrcardchangeU.Open();
            insert_command.Connection = conn_hrcardchangeU;
            insert_command.CommandText = commstring;
            insert_command.CommandTimeout = 500;
            dal.UpdateCommand = insert_command;
            try
            {
                dal.UpdateCommand.ExecuteNonQuery();
                conn_hrcardchangeU.Close();
                return "ok";
            }
            catch (Exception e)
            {

                conn_hrcardchangeU.Close();
                return e.Message.ToString();
            }
            finally
            {
                //清除
                insert_command.Cancel();
                conn_hrcardchangeU.Close();
                conn_hrcardchangeU.Dispose();
            }
        }

        /// <summary>
        /// 查詢 rhwr
        /// </summary>
        /// <param name="commstring"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public DataSet exeQuery_rhwr(string commstring, string tablename)
        {
            System.Data.SqlClient.SqlDataAdapter dal = new SqlDataAdapter(commstring, conn_rhwr);
            dal.SelectCommand.CommandTimeout = 600;
            DataSet ds1 = new DataSet();
            dal.Fill(ds1, tablename);
            ds1.Dispose();
            return ds1;
        }

        /// <summary>
        /// 查詢 MaxDat
        /// </summary>
        /// <param name="commstring"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public DataSet exeQuery_MaxData(string commstring, string tablename)
        {
            System.Data.SqlClient.SqlDataAdapter dal = new SqlDataAdapter(commstring, conn_MaxData);
            DataSet ds1 = new DataSet();
            dal.Fill(ds1, tablename);
            ds1.Dispose();
            return ds1;
        }


        public void MK_Log(string SYS, string SData, string EmployeeNo)
        {
            string psql;
            psql = "INSERT INTO MK_Log(SYS, SData, EmployeeNo)" +
                   "VALUES(" +
                   " '" + SYS + "' " +
                   ",'" + SData + "' " +
                   ",'" + EmployeeNo + "' " +
                   ")";
            update_hrcardchange(psql);
        }

        /// <summary>
        /// 是否為日期
        /// </summary>
        /// <param name="strDate"></param>
        /// <returns></returns>
        public bool IsDate(string strDate)
        {
            try
            {
                DateTime.Parse(strDate);
                return true;
            }
            catch
            {
                return false;
            }

        }


        public void MK_Log2(string SYS, string SData, string EmployeeNo, string SDT)
        {
            string psql;
            psql = "INSERT INTO MK_Log(SYS, SData, EmployeeNo,SDT)" +
                   "VALUES(" +
                   " '" + SYS + "' " +
                   ",'" + SData + "' " +
                   ",'" + EmployeeNo + "' " +
                   ",'" + SDT + "' " +
                   ")";
            update_hrcardchange(psql);
        }



    }

}
