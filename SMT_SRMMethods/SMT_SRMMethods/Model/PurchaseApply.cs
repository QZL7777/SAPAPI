using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMT_SRMMethods.Model
{
    public class PurchaseApply
    {
        public string BANFN { get; set; }
        public string BNFPO { get; set; }
        public string BSART { get; set; }
        public string EKGRP { get; set; }
        public string AFNAM { get; set; }
       // public string EKGRP { get; set; }
        public string LOEKZ { get; set; }
        public string TXZ01 { get; set; }
        public string MATNR { get; set; }
        public string WERKS { get; set; }
        public string LGORT { get; set; }
        public string MATKL { get; set; }
        public string MENGE { get; set; }
        public string MEINS { get; set; }
        public string BADAT { get; set; }
        public string LFDAT { get; set; }
        public string PREIS { get; set; }
        public string PEINH { get; set; }
        public string KNTTP { get; set; }
        public string PSTYP { get; set; }
        public string WEPOS { get; set; }
        public string REPOS { get; set; }
        public string WEUNB { get; set; }
        public string ZAUFNR { get; set; }
        public string KOSTL { get; set; }
        public string ANLN1 { get; set; }
        public string ZFLAG { get; set; }

    }

    public class PurchaseApplyData
    {
        public PurchaseApply zsrm_pr_return { get; set; }
    }

}
