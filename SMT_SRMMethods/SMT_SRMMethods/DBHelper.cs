using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace SMT_SRMMethods
{
    public class DBHelper
    {
        // public static string str = @"Data Source=(local);Initial Catalog=BPMDBWQ;User ID=sa;Password=123456";
        //打开数据库
        public static string str = string.Empty;

        static DBHelper()
        {
            XmlNodeList root;
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("Server.config");
            root = xmlDocument.GetElementsByTagName("application");
            string Server = root[0].SelectSingleNode("database").SelectSingleNode("Server").InnerText;
            string Uid = root[0].SelectSingleNode("database").SelectSingleNode("Uid").InnerText;
            string Password = root[0].SelectSingleNode("database").SelectSingleNode("Password").InnerText;
            string Database = root[0].SelectSingleNode("database").SelectSingleNode("Database").InnerText;
            str = string.Format(@"Data Source={0};Initial Catalog={1};User ID={2};Password={3}", Server, Database, Uid, Password);

        }
        public static void open()
        {
            SqlConnection conn = new SqlConnection(str);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        //存储过程的查询
        public static DataSet selectTable(string Tab, SqlParameter[] sp)
        {
            SqlConnection conn = new SqlConnection(str);

            DataSet ds = new DataSet();
            try
            {
                conn.Open();//打开数据库
                SqlCommand comm = new SqlCommand(Tab, conn);
                comm.CommandType = CommandType.StoredProcedure;
                if (sp != null)
                {
                    comm.Parameters.AddRange(sp);

                }
                SqlDataAdapter sda = new SqlDataAdapter(comm);
                sda.Fill(ds);
            }
            catch (Exception e)
            {


            }
            finally
            {

                conn.Close();

            }
            return ds;
        }

        //事务
        public static int shiwu(List<string> sql)
        {
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            int s = 0;
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                for (int i = 0; i < sql.Count; i++)
                {
                    SqlCommand comm = new SqlCommand(sql[i], conn, tran);
                    s = comm.ExecuteNonQuery();
                }
                tran.Commit();
            }
            catch
            {

                tran.Rollback();
                s = -1;
            }
            return s;
        }

        //存储过程添加
        public static int inserttTable(string Tab, SqlParameter[] sp)
        {
            SqlConnection conn = new SqlConnection(str);
            int a = 0;
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(Tab, conn);
                comm.CommandType = CommandType.StoredProcedure;
                if (sp != null)
                {
                    comm.Parameters.AddRange(sp);
                }
                a = comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {

            }
            finally
            {
                conn.Close();
            }
            return a;



        }

        //查询
        public static DataTable Getselect(string SQL, SqlParameter[] sp)
        {
            SqlConnection conn = new SqlConnection(str);
            DataSet ds = new DataSet();
            try
            {
                
                open();
                SqlDataAdapter sda = new SqlDataAdapter(SQL, conn);
                if (sp != null)
                {
                    sda.SelectCommand.Parameters.AddRange(sp);
                }
                sda.Fill(ds);
            }
            catch (Exception e)
            {


            }
            finally
            {
                conn.Close();

            }
            return ds.Tables[0];

        }

        //添加
        public static bool insert(string SQL, SqlParameter[] sp)
        {
            SqlConnection conn = new SqlConnection(str);
            bool a = false;
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(SQL, conn);
                if (sp != null)
                {
                    comm.Parameters.AddRange(sp);
                }
                if (comm.ExecuteNonQuery() > 0)
                {
                    a = true;

                }

            }
            catch (Exception e)
            {


            }
            finally
            {
                conn.Close();

            }
            return a;


        }
    }
}
