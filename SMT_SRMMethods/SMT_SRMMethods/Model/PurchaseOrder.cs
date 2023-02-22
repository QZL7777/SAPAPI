using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMT_SRMMethods.Model
{
     public class PurchaseOrder
    {
        public string EBELN { get; set; }
        public string BEDAT { get; set; }
        public string BSART { get; set; }
        public string LIFNR { get; set; }
        public string EKORG { get; set; }
        public string EKGRP { get; set; }
        public string EBELP { get; set; }
        public string TXZ01 { get; set; }
        public string MATNR { get; set; }
        public string WERKS { get; set; }
        public string LGORT { get; set; }
        public string MATKL { get; set; }
        public string MENGE { get; set; }
        public string MEINS { get; set; }
        public string NETPR { get; set; }
        public string PEINH { get; set; }
        public string RETPO { get; set; }
        public string KNTTP { get; set; }
        public string PSTYP { get; set; }
        public string ZAUFNR { get; set; }
        public string WEPOS { get; set; }
        public string REPOS { get; set; }
        public string WEUNB { get; set; }
        public string WEBRE { get; set; }
        public string KOSTL { get; set; }
        public string ANLN1 { get; set; }
        public string EINDT { get; set; }
        public string ZFLAG { get; set; }

    }
    public class PurchaseOrderData
    {
        public PurchaseOrder zsrm_pr_return { get; set; }
    }
}
