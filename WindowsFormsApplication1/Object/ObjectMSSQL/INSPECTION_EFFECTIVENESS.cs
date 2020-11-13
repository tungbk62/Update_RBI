using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class INSPECTION_EFFECTIVENESS
    {
       public String EffectivenessCode { set; get; }
        public String EffectivenessDescription { set; get; }
        public INSPECTION_EFFECTIVENESS(String x, String y)
        {
            EffectivenessCode = x;
            EffectivenessDescription = y;
        }
        public INSPECTION_EFFECTIVENESS() { }
    }
}
