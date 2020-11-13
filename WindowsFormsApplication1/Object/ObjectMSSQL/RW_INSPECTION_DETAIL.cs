using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class RW_INSPECTION_DETAIL
    {
        public int ID { set; get; }
        public String SiteName { set; get; }
        public String FacilityName { set; get; }
        public int DetailID { set; get; }
        public int EquipmentID { set; get; }
        public int ComponentID {set; get;}
        public int Coverage_DetailID {set; get;}
        public String InspPlanName {set; get;}
        public DateTime InspectionDate {set; get;}
        public int DMItemID {set; get;}
        public String EffectivenessCode {set; get;}
        public String InspectionSummary {set; get;}
        public int IsCarriedOut {set; get;}
        public DateTime CarriedOutDate { set; get; }
        public int IsActive { set; get; }
    }
}
