using RBI.DAL.MSSQL;
using RBI.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.Object.ObjectMSSQL;
namespace RBI.BUS.BUSMSSQL
{
    public class RW_FULL_COF_HOLE_SIZE_BUS
    {
        RW_FULL_COF_HOLE_SIZE_ConnectUtils DAL = new RW_FULL_COF_HOLE_SIZE_ConnectUtils();
        public void add(RW_FULL_COF_HOLE_SIZE obj)
        {
            DAL.add(obj.ID, obj.GFF_small, obj.GFF_medium, obj.GFF_large, obj.GFF_rupture, obj.A1, obj.A2, obj.A3, obj.A4, obj.W1, obj.W2, obj.W3, obj.W4, obj.t_n1, obj.t_n2, obj.t_n3, obj.t_n4, obj.ld_max_1, obj.ld_max_2, obj.ld_max_3, obj.ld_max_4, 
                obj.mass_add_1, obj.mass_add_2, obj.mass_add_3, obj.mass_add_4, obj.mass_avail_1, obj.mass_avail_2, obj.mass_avail_3, obj.mass_avail_4, obj.rate_1, obj.rate_2, obj.rate_3, obj.rate_4, obj.ld_1, obj.ld_2, obj.ld_3, obj.ld_4, obj.mass_1, 
                obj.mass_2, obj.mass_3, obj.mass_4, obj.eneff_1, obj.eneff_2, obj.eneff_3, obj.eneff_4, obj.factIC_1, obj.factIC_2, obj.factIC_3, obj.factIC_4, obj.ReleaseType_1, obj.ReleaseType_2, obj.ReleaseType_3, obj.ReleaseType_4);
        }
        public void edit(RW_FULL_COF_HOLE_SIZE obj)
        {
            DAL.edit(obj.ID, obj.GFF_small, obj.GFF_medium, obj.GFF_large, obj.GFF_rupture, obj.A1, obj.A2, obj.A3, obj.A4, obj.W1, obj.W2, obj.W3, obj.W4, obj.t_n1, obj.t_n2, obj.t_n3, obj.t_n4, obj.ld_max_1, obj.ld_max_2, obj.ld_max_3, obj.ld_max_4,
                obj.mass_add_1, obj.mass_add_2, obj.mass_add_3, obj.mass_add_4, obj.mass_avail_1, obj.mass_avail_2, obj.mass_avail_3, obj.mass_avail_4, obj.rate_1, obj.rate_2, obj.rate_3, obj.rate_4, obj.ld_1, obj.ld_2, obj.ld_3, obj.ld_4, obj.mass_1,
                obj.mass_2, obj.mass_3, obj.mass_4, obj.eneff_1, obj.eneff_2, obj.eneff_3, obj.eneff_4, obj.factIC_1, obj.factIC_2, obj.factIC_3, obj.factIC_4, obj.ReleaseType_1, obj.ReleaseType_2, obj.ReleaseType_3, obj.ReleaseType_4);

        }
        public void delete(RW_FULL_COF_HOLE_SIZE obj)
        {
            DAL.delete(obj.ID);
        }
        public List<RW_FULL_COF_HOLE_SIZE> getDataSource()
        {
            return DAL.getDataSource();
        }
        public RW_FULL_COF_HOLE_SIZE getData(int ID)
        {
            return DAL.getData(ID);
        }
        public Boolean checkExistCoFHS(int ID)
        {
            return DAL.checkExistCoFHS(ID);
        }
    }
}