using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMT_SRMMethods.Model
{
    public class PurchaseInfo
    {
        public string INFNR { get; set; }
        public string LIFNR { get; set; }
        public string MATNR { get; set; }
        public string EKORG { get; set; }
        public string WERKS { get; set; }
        public string ESOKZ { get; set; }
        public string LOEKZ { get; set; }
        public string MAHN1 { get; set; }
        public string URZLA { get; set; }
        public string REGIO { get; set; }
        public string MEINS { get; set; }
        public string UMREN { get; set; }
        public string UMREZ { get; set; }
        public string TELF1 { get; set; }
        public string APLFZ { get; set; }
        public string EKGRP { get; set; }
        public string NORBM { get; set; }
        public string MINBM { get; set; }
        public string NETPR { get; set; }
        public string PEINH { get; set; }
        public string BSTAE { get; set; }
        public string MWSKZ { get; set; }
        public string ZFLAG { get; set; }
    }

    public class PurchaseInfoData
    {
        public List<PurchaseInfo> zdata { get; set; }
    }




}
