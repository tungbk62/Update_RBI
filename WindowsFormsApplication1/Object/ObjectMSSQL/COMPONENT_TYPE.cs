using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class COMPONENT_TYPE
    {
        public int ComponentTypeID { set; get; }
        public String ComponentTypeName { set; get; }
        public String ComponentTypeCode { set; get; }
        public String Shape { set; get; }
        public float ShapeFactor { set; get; }
    }
}
