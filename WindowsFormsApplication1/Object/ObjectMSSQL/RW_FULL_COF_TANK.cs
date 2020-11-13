using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    public class RW_FULL_COF_TANK
    {
        public int ID { get; set; }
        public float CoFValue { get; set; }
        public String CoFCategory { get; set; }
        public float ProdCost { get; set; }
        public float EquipOutageMultiplier { get; set; }
        public float equipcost { get; set; }
        public float popdens { get; set; }
        public float injcost { get; set; }
        public float CoFMatrixValue { get; set; }
    }
}
