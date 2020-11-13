using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class INSPECTION_COVERAGE
    {
        public int ID { get; set; }
        public int PlanID { get; set; }
        public String InspectionPlanName { get; set; }
        public String InspectionPlanDate { get; set; } 
        public int EquipmentID { get; set; }
        public String EquipmentName { get; set; }
        public int ComponentID {get;set;}
        public String ComponentName { get; set; }
        public String Remarks { get; set; }
        public String Findings { get; set; }
        public String FindingRTF { get; set; }
}
}
