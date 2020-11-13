using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    public class RW_FULL_FINALCOF
    {
        public int ID { get; set; }
        public float ComponentDamageCosts { get; set; }
        public float EquipmentOutageMultiplier { get; set; }
        public float LossProductCost { get; set; }
        public float PopDen { get; set; }
        public float InjCost { get; set; }
        public float EnviCost { get; set; }
    }
}
