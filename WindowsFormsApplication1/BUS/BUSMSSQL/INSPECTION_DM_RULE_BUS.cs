using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL
{
    class INSPECTION_DM_RULE_BUS
    {
        INSPECTION_DM_RULE_ConnectUtils DAL = new INSPECTION_DM_RULE_ConnectUtils();
        public List<int> getDMItemID(int IMItemID, int IMTypeID)
        {
            return DAL.getDMItemID(IMItemID,IMTypeID);
        }
    }
}
