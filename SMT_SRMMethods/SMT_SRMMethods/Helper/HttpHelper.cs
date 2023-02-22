using Newtonsoft.Json.Linq;
using SMT_SRMMethods.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace SMT_SRMMethods
{
    internal class HttpHelper
    {
        /// <summary>
        /// 获取token使用
        /// </summary>
        /// <param name="url"></param>
        /// <param name="JsonData"></param>
        /// <param name="token"></param>
        /// <param name="ParameterType"></param>
        /// <returns></returns>
        public static string PostToken(string url, string JsonData, string token, string ParameterType = "x-www-form-urlencoded")
        {
            var httpClient = new HttpClient();
            HttpContent content = null;
            if (ParameterType.Equals("x-www-form-urlencoded"))
            {
                var data = new List<KeyValuePair<string, string>>();
                JObject rv = JObject.Parse(JsonData);
                foreach (var item in rv)
                {
                    data.Add(new KeyValuePair<string, string>(item.Key, Convert.ToString(item.Value)));
                }
                content = new FormUrlEncodedContent(data);
            }
            else if (ParameterType.Equals("json"))
            {
                content = new StringContent(JsonData, Encoding.UTF8, "application/json");
            }
            if (!string.IsNullOrEmpty(token))
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", token);

            var response = httpClient.PostAsync(url, content).Result.Content.ReadAsStringAsync().Result;
            return response;
        }

        /// <summary>
        /// 其他接口使用
        /// </summary>
        /// <param name="url"></param>
        /// <param name="JsonData"></param>
        /// <param name="token"></param>
        /// <param name="ParameterType"></param>
        /// <returns></returns>
        public static string Post(string url, string JsonData, string token, string ParameterType = "x-www-form-urlencoded")
        {
            var httpClient = new HttpClient();
            HttpContent content = null;
            if (ParameterType.Equals("x-www-form-urlencoded"))
            {
                var data = new List<KeyValuePair<string, string>>();
                JObject rv = JObject.Parse(JsonData);
                foreach (var item in rv)
                {
                    data.Add(new KeyValuePair<string, string>(item.Key, Convert.ToString(item.Value)));
                }
                content = new FormUrlEncodedContent(data);
            }
            else if (ParameterType.Equals("json"))
            {
                content = new StringContent(JsonData, Encoding.UTF8, "application/json");
            }
            if (!string.IsNullOrEmpty(token))
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

            var response = httpClient.PostAsync(url, content).Result.Content.ReadAsStringAsync().Result;
            return response;
        }

        public static string PostSap(string url, string content,string account,string pwd)
        {
            //url = BPMServerConfig.GetValue("SAPUrl")+"/"+ BPMServerConfig.GetValue("kehu");
            // account = BPMServerConfig.GetValue("SAPAccount"); //"IF_SEVICES";
            // pwd = BPMServerConfig.GetValue("SAPPwd");  //"KShp@2023ks";
            HttpWebRequest httpWeb = (HttpWebRequest)WebRequest.Create(url);
            httpWeb.Headers.Add("Accept", "application/json");//添加消息头
            httpWeb.Timeout = 20000;
            httpWeb.Method = "POST";
            httpWeb.ContentType = "application/json; charset=utf-8";
          
            byte[] bytePara = Encoding.UTF8.GetBytes(content);
            using (Stream reqStream = httpWeb.GetRequestStream())
            {
                reqStream.Write(bytePara, 0, bytePara.Length);
            }
            CredentialCache credentialCache = new CredentialCache();
            credentialCache.Add(new Uri(url), "Basic", new NetworkCredential(account, pwd));
            httpWeb.Credentials = credentialCache;
            httpWeb.Headers.Add("Authorization", "Basic" + Convert.ToBase64String(Encoding.UTF8.GetBytes($"{account}:{pwd}")));
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWeb.GetResponse();
            Stream stream = httpWebResponse.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream, Encoding.GetEncoding("utf-8"));
            //获得返回值
            string result = streamReader.ReadToEnd();
            stream.Close();
            return result;
        }
       



    }
}
