using BPM.Server;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SMT_SRMMethods.Helper;
using SMT_SRMMethods.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SMT_SRMMethods
{
    public class SAPAPI
    {
        #region 新增供应商
        public JObject InsertGYSInfo(SUPPLIER sUPPLIER)
        {
            JObject rv = new JObject();
            try
            {
                SUPPLIERDATA c = new SUPPLIERDATA();
                List<SUPPLIER> s = new List<SUPPLIER>();
                s.Add(sUPPLIER);
                c.zvendor = s;
                var data = JsonConvert.SerializeObject(c);
                string url = BPMServerConfig.GetValue("SAPUrl") + "/" + BPMServerConfig.GetValue("GYS");
                string account = BPMServerConfig.GetValue("SAPAccount"); //"IF_SEVICES";
                string pwd = BPMServerConfig.GetValue("SAPPwd");  //"KShp@2023ks";
                string returnJson = HttpHelper.PostSap(url, data, account, pwd);
                JObject jo = JObject.Parse(returnJson);
                if (jo["return"]["type"].ToString() == "S")
                {
                    if (jo["zvendor"][0]["type"].ToString() == "S")
                    {
                        //调用成功 获取接口返回的客户编码  
                        string supplierCode = jo["zvendor"][0]["lifnr"].ToString();
                        if (supplierCode != null)
                        {
                            rv["lifnr"] = supplierCode;
                            rv["Success"] = true;
                        }                       
                    }
                    else
                    {
                        string Message  = jo["zvendor"][0]["message"].ToString();
                        rv["lifnr"] = "";
                        rv["Success"] = false;
                        rv["Message"] = Message;
                    }                       
                } 
                else
                {
                    string Message = jo["result"]["message"].ToString();
                    rv["lifnr"] = "";
                    rv["Success"] = false;
                    rv["Message"] = Message;
                }             
            }
            catch (Exception ex)
            {
                rv["lifnr"] = "";
                rv["Success"] = false;
                rv["Message"] = ex.Message;
            }
            return rv;

        }
        #endregion

        #region 采购信息接口记录接口
        public JObject PurchaseInfoInsert(PurchaseInfo purchaseInfo) {
            JObject rv = new JObject();
            try
            {
                PurchaseInfoData c = new PurchaseInfoData();
                List<PurchaseInfo> s = new List<PurchaseInfo>();
                s.Add(purchaseInfo);
                c.zdata = s;
                var data = JsonConvert.SerializeObject(c);
                string url = BPMServerConfig.GetValue("SAPUrl") + "/" + BPMServerConfig.GetValue("cgxx");
                string account = BPMServerConfig.GetValue("SAPAccount"); //"IF_SEVICES";
                string pwd = BPMServerConfig.GetValue("SAPPwd");  //"KShp@2023ks";
                string returnJson = HttpHelper.PostSap(url, data, account, pwd);
                JObject jo = JObject.Parse(returnJson);
                if (jo["return"]["type"].ToString() == "S")
                {
                    if (jo["zdata"][0]["type"].ToString() == "S")
                    {
                        //调用成功 获取接口返回的客户编码  
                        string infnr = jo["zdata"][0]["infnr"].ToString();
                        if (infnr != null)
                        {
                            rv["infnr"] = infnr;
                            rv["Success"] = true;
                        }                       
                    }
                    else
                    {
                        string Message = jo["zdata"][0]["message"].ToString();
                        rv["infnr"] = "";
                        rv["Success"] = false;
                        rv["Message"] = Message;
                    }
                }
                else
                {                 
                    string Message = jo["result"]["message"].ToString();
                    rv["infnr"] = "";
                    rv["Success"] = false;
                    rv["Message"] = Message;
                }

            }
            catch (Exception ex)
            {
                rv["infnr"] = "";
                rv["Success"] = false;
                rv["Message"] = ex.Message;
            }
            return rv;
        }
        #endregion
        #region 采购订单接口
        public JObject PurchaseOrderInsert(PurchaseOrder purchaseOrder)
        {
            JObject rv = new JObject();
            try
            {
                PurchaseOrderData c = new PurchaseOrderData();
                c.zsrm_pr_return = purchaseOrder;               
                var data = JsonConvert.SerializeObject(c);
                string url = BPMServerConfig.GetValue("SAPUrl") + "/" + BPMServerConfig.GetValue("cgdd");
                string account = BPMServerConfig.GetValue("SAPAccount"); //"IF_SEVICES";
                string pwd = BPMServerConfig.GetValue("SAPPwd");  //"KShp@2023ks";
                string returnJson = HttpHelper.PostSap(url, data, account, pwd);
                JObject jo = JObject.Parse(returnJson);
                if (jo["return"]["type"].ToString() == "S")
                {
                    if (jo["zsrmPrReturn"]["type"].ToString() == "S")
                    {
                        //调用成功 获取接口返回的客户编码  
                        string preqNo = jo["zsrmPrReturn"]["preqNo"].ToString();
                        string ztype = jo["zsrmPrReturn"]["ztype"].ToString();
                        if (preqNo != null)
                        {
                            rv["preqNo"] = preqNo;
                            rv["ztype"] = ztype;
                            rv["Success"] = true;
                        }
                    }
                    else
                    {
                        string Message = jo["zsrmPrReturn"]["message"].ToString();
                        rv["preqNo"] = "";
                        rv["ztype"] = "";
                        rv["Success"] = false;
                        rv["Message"] = Message;
                    }
                }
                else
                {
                    string Message = jo["result"]["message"].ToString();
                    rv["preqNo"] = "";
                    rv["ztype"] = "";
                    rv["Success"] = false;
                    rv["Message"] = Message;
                }

            }
            catch (Exception ex)
            {
                rv["preqNo"] = "";
                rv["ztype"] = "";
                rv["Success"] = false;
                rv["Message"] = ex.Message;
            }
            return rv;
        }
        #endregion
        #region 采购申请信息接口
        public JObject PurchaseApplyInsert(PurchaseApply purchaseApply)
        {
            JObject rv = new JObject();
            try
            {
                PurchaseApplyData c = new PurchaseApplyData();
                c.zsrm_pr_return = purchaseApply;
                var data = JsonConvert.SerializeObject(c);
                string url = BPMServerConfig.GetValue("SAPUrl") + "/" + BPMServerConfig.GetValue("CGSQ");
                string account = BPMServerConfig.GetValue("SAPAccount"); //"IF_SEVICES";
                string pwd = BPMServerConfig.GetValue("SAPPwd");  //"KShp@2023ks";
                string returnJson = HttpHelper.PostSap(url, data, account, pwd);
                JObject jo = JObject.Parse(returnJson);
                if (jo["return"]["type"].ToString() == "S")
                {
                    if (jo["zsrmPoReturn"]["type"].ToString() == "S")
                    {
                        //调用成功 获取接口返回的客户编码  
                        string poNumber = jo["zsrmPoReturn"]["poNumber"].ToString();
                        string ztype = jo["zsrmPoReturn"]["ztype"].ToString();
                        if (poNumber != null)
                        {
                            rv["poNumber"] = poNumber;
                            rv["ztype"] = ztype;
                            rv["Success"] = true;
                        }
                    }
                    else
                    {
                        string Message = jo["zsrmPoReturn"]["message"].ToString();
                        rv["poNumber"] = "";
                        rv["ztype"] = "";
                        rv["Success"] = false;
                        rv["Message"] = Message;
                    }
                }
                else
                {                
                    string Message = jo["result"]["message"].ToString();
                    rv["poNumber"] = "";
                    rv["ztype"] = "";
                    rv["Success"] = false;
                    rv["Message"] = Message;
                }

            }
            catch (Exception ex)
            {
                rv["poNumber"] = "";
                rv["ztype"] = "";
                rv["Success"] = false;
                rv["Message"] = ex.Message;
            }
            return rv;
        }
        #endregion
    }
}
