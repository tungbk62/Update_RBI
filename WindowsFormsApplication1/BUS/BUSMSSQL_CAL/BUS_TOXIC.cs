using RBI.Object.ObjectMSSQL_CAL;
using RBI.DAL.MSSQL_CAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL_CAL
{
    class BUS_TOXIC
    {
        MSSQL_RBI_CAL_ConnUtils DAL_CAL = new MSSQL_RBI_CAL_ConnUtils();
        public TOXIC_511_512 getList511_512(string toxicName, string Conti)
        {
            return DAL_CAL.GET_TBL_511_512(toxicName, Conti);
        }
        public TOXIC_513 getList513(string Toxic, string ReleaseType, string ContinuousReleasesDuration)
        {
            return DAL_CAL.GET_TBL_513(Toxic, ReleaseType, ContinuousReleasesDuration);
        }
    }
}
