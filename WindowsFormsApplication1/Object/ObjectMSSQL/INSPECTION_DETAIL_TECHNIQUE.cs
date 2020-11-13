using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class INSPECTION_DETAIL_TECHNIQUE
    {
        public int ID { get; set; }
        public int CoverageID { get; set; }
        public int IMItemID { get; set; }
        public int IMTypeID { get; set; }
        public int InspectionType { get; set; }
        public int Coverage { get; set; }
        public String NDTMethod { get; set; }
        
    }
}
