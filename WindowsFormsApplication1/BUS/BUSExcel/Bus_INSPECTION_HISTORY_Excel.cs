using RBI.DAL;
using RBI.Object.ObjectMSSQL;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBI.BUS.BUSExcel
{
    class Bus_INSPECTION_HISTORY_Excel
    {
        RW_INSPECTION_DETAIL obj;
        ExcelConnect exConn = new ExcelConnect();
        public OleDbConnection getConnect(String path)
        {
            return exConn.connectionExcel(path);
        }
        public List<RW_INSPECTION_DETAIL> getListInsp(String path)
        {
            List<RW_INSPECTION_DETAIL> list = new List<RW_INSPECTION_DETAIL>();
            OleDbConnection conn = getConnect(path);
            try
            {
                conn.Open();
                String sql = "SELECT * FROM [Inspections$] ";
                OleDbCommand cmd = new OleDbCommand(sql,conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        if (!(reader.IsDBNull(2) || reader.IsDBNull(3) || reader.IsDBNull(4) || reader.IsDBNull(6)))
                        {
                            obj = new RW_INSPECTION_DETAIL();
                            //obj.ID = 1;
                            obj.InspPlanName = reader[0].ToString();
                            //obj.Ins = reader[1].ToString();
                            //obj.EquipmentID = reader[2].ToInt32();
                            //obj.ComponentID = reader[3].ToInt32();
                            //obj.DMItemID = reader[4]();
                            //obj.InspectionDate = reader[5].ToString();
                            try
                            {
                                obj.InspectionDate = Convert.ToDateTime(reader[6].ToString());
                            }
                            catch
                            {
                                obj.InspectionDate = DateTime.Now;
                            }
                            try
                            {
                                //obj.InspectionEffective = reader[7].ToString();
                            }
                            catch
                            {
                                //obj.InspectionEffective = "E";
                            }
                            list.Add(obj);
                        }
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("ERROR!" + e.ToString());
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }

    }
}
