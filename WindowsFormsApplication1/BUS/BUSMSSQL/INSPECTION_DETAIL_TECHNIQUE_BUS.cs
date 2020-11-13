using System;
using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.Object;

namespace RBI.BUS.BUSMSSQL
{
    class INSPECTION_DETAIL_TECHNIQUE_BUS
    {
        INSPECTION_DETAIL_TECHNIQUE_ConnectUtils DAL = new INSPECTION_DETAIL_TECHNIQUE_ConnectUtils();
        public void add(INSPECTION_DETAIL_TECHNIQUE obj)
        {
            DAL.add( obj.CoverageID, obj.IMItemID, obj.IMTypeID, obj.InspectionType, obj.Coverage, obj.NDTMethod);
        }
        public void edit(INSPECTION_DETAIL_TECHNIQUE obj)
        {
            DAL.edit(obj.ID, obj.CoverageID, obj.IMItemID, obj.IMTypeID, obj.InspectionType, obj.Coverage);
        }
        public void delete(INSPECTION_DETAIL_TECHNIQUE obj)
        {
            DAL.delete(obj.ID);
        }
        public List<INSPECTION_DETAIL_TECHNIQUE> getDataSource()
        {
            return DAL.getDataSource();
        }
        public List<INSPECTION_DETAIL_TECHNIQUE> getDataSource(int CoverageID)
        {
            return DAL.getDataSource(CoverageID);
        }
        public void deletebyCoverageID(int CoverageID)
        {
            DAL.deletebyCoverageID(CoverageID);
        }
    }
}
