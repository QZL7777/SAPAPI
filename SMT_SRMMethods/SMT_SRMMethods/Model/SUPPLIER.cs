using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMT_SRMMethods.Model
{
    public class SUPPLIER
    {
        public string LIFNR { get; set; }

        public string BUKRS { get; set; }

        public string EKORG { get; set; }
        public string KTOKK { get; set; }

        public string NAME1 { get; set; }
        /// <summary>
        /// 默认003
        /// </summary>
        public string ANRED { get; set; }
        public string SORT1 { get; set; }

        public string STRAS { get; set; }
        public string  PSTLZ { get; set; }
        public string ORT01 { get; set; }

        public string LAND1 { get; set; }

        public string SPRAS { get; set; }

        public string TELF2 { get; set; }
        public string TELF1 { get; set; }
        public string TELFX { get; set; }

        public string STCD5 { get; set; }
        public string AKONT { get; set; }
        public string ZWELS { get; set; }
        public string XVERR { get; set; }
        public string WAERS { get; set; }

        public string ZTERM { get; set; }

        public string INCO1 { get; set; }
        public string INCO2 { get; set; }
        /// <summary>
        /// 默认0001
        /// </summary>
        public string BVTYP { get; set; }

        public string BANKS { get; set; }

        public string BANKL { get; set; }

        public string BANKN { get; set; }

        public string KOINH { get; set; }

        public string ZFLAG { get; set; }


    }

    public class SUPPLIERDATA
    {

        public List<SUPPLIER> zvendor { get; set; }

    }


}
