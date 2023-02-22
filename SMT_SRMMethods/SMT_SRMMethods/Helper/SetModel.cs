using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMT_SRMMethods.Helper
{
    class SetModel
    {
        public static object SetModelValue(string FieldName, string Value, object obj)
        {
            Type Ts = obj.GetType();
            object v = Convert.ChangeType(Value, Ts.GetProperty(FieldName).PropertyType);
            Ts.GetProperty(FieldName).SetValue(obj, v, null);
            return obj;
        }


    }
}
