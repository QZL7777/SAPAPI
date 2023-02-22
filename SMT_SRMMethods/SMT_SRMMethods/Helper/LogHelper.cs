using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class LogHelper
{
    private static object Lockobj = new object();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="msg"></param>
    public static void WriteLog(string msg)
    {
        lock (Lockobj)
        {
            try
            {
                StreamWriter sw = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + "Log\\" + DateTime.Now.ToString("yyyy-MM-dd") + "-Log.txt");
                sw.WriteLine("记录时间：" + DateTime.Now);
                sw.WriteLine("输出：" + msg);
                sw.WriteLine("----------------------------------------------------------");
                sw.Flush();//写入
                sw.Close();//关闭流
            }
            catch (Exception)
            {

            }
        }
    }
}