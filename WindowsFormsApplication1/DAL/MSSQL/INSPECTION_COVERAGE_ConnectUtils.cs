using RBI.Object;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.Object.ObjectMSSQL;
namespace RBI.DAL.MSSQL
{
    class INSPECTION_COVERAGE_ConnectUtils
    {
        public void add(int PlanID, int EquipmentID, int ComponentID, String Remarks, String Findings, String FindingRTF)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "INSERT INTO [dbo].[INSPECTION_COVERAGE]" +
                        "([PlanID]" +
                        ",[EquipmentID]" +
                        ",[ComponentID]" +
                        ",[Remarks]" +
                        ",[Findings]" +
                        ",[FindingRTF])" +
                        "VALUES" +
                        "('" + PlanID + "'" +
                        ",'" + EquipmentID + "'" +
                        ",'" + ComponentID + "'" +
                        ",'" + Remarks + "'" +
                        ",'" + Findings + "'" +
                        ",'" + FindingRTF + "')";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "ADD FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void edit(int ID, int PlanID, int EquipmentID, int ComponentID, String Remarks, String Findings, String FindingRTF)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                        "UPDATE [dbo].[INSPECTION_COVERAGE]" +
                        "SET [PlanID] = '" + PlanID + "'" +
                        ",[EquipmentID] = '" + EquipmentID + "'" +
                        ",[ComponentID] = '" + ComponentID + "'" +
                        ",[Remarks] = '" + Remarks + "'" +
                        ",[Findings] = '" + Findings + "'" +
                        ",[FindingRTF] ='" + FindingRTF + "'" +
                        "WHERE [ID] = '" + ID + "' ";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "EDIT FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void delete(int CoverageID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                        "DELETE FROM [dbo].[INSPECTION_COVERAGE]" +
                        "WHERE [CoverageID] = '" + CoverageID + "' ";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "DELETE FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void deletebyPlanID(int PlanID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                        "DELETE FROM [dbo].[INSPECTION_COVERAGE]" +
                        "WHERE [PlanID] = '" + PlanID + "' ";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "DELETE FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void deletebyComponentID(int ComponentID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                        "DELETE FROM [dbo].[INSPECTION_COVERAGE]" +
                        "WHERE [ComponentID] = '" + ComponentID + "' ";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "DELETE FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public List<INSPECTION_COVERAGE> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<INSPECTION_COVERAGE> list = new List<INSPECTION_COVERAGE>();
            INSPECTION_COVERAGE obj = null;
            String sql = " Use [rbi] Select [ID]" +
                          ",[PlanID]" +
                          ",[EquipmentID]" +
                          ",[ComponentID]" +
                          ",[Remarks]" +
                          ",[Findings]" +
                          ",[FindingRTF]" +
                          "From [dbo].[INSPECTION_COVERAGE]";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            obj = new INSPECTION_COVERAGE();
                            obj.ID = reader.GetInt32(0);
                            obj.PlanID = reader.GetInt32(1);
                            obj.EquipmentID = reader.GetInt32(2);
                            obj.ComponentID = reader.GetInt32(3);
                            if (!reader .IsDBNull(4))
                            {
                                obj.Remarks = reader.GetString(4);
                            }
                            if (!reader.IsDBNull(5))
                            {
                                obj.Findings = reader.GetString(5);
                            }
                            if (!reader.IsDBNull(6))
                            {
                                obj.FindingRTF = reader.GetString(6);
                            }
                            list.Add(obj);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "GET DATA FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }

        public List<INSPECTION_COVERAGE> getDataID(int PlanID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<INSPECTION_COVERAGE> list = new List<INSPECTION_COVERAGE>();
            INSPECTION_COVERAGE obj = null;
            String sql = " Use [rbi] Select [ID]" +
                          ",[PlanID]" +
                          ",[EquipmentID]" +
                          ",[ComponentID]" +
                          ",[Remarks]" +
                          ",[Findings]" +
                          ",[FindingRTF]" +
                          "From [dbo].[INSPECTION_COVERAGE] where PlanID = '" + PlanID + "'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            obj = new INSPECTION_COVERAGE();
                            obj.ID = reader.GetInt32(0);
                            obj.PlanID = reader.GetInt32(1);
                            obj.EquipmentID = reader.GetInt32(2);
                            obj.ComponentID = reader.GetInt32(3);
                            if (!reader.IsDBNull(4))
                            {
                                obj.Remarks = reader.GetString(4);
                            }
                            if (!reader.IsDBNull(5))
                            {
                                obj.Findings = reader.GetString(5);
                            }
                            if (!reader.IsDBNull(6))
                            {
                                obj.FindingRTF = reader.GetString(6);
                            }
                            list.Add(obj);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "GET DATA FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }
        public List<int> getIDbyComponentID(int ComponentID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<int> list = new List<int>();
            int ID = -1;
            String sql = "Use [rbi]" +
                        "SELECT [ID]" +
                        "From [dbo].[INSPECTION_COVERAGE] where ComponentID = '" + ComponentID + "'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            ID = reader.GetInt32(0);
                        }
                        list.Add(ID);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "GET DATA FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }
        public List<int> getIDbyPlanID(int PlanID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<int> list = new List<int>();
            int ID = 0;
            String sql = "Use [rbi]" +
                        "SELECT [ID]" +
                        "From [dbo].[INSPECTION_COVERAGE] where PlanID = '" + PlanID + "'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            ID = reader.GetInt32(0);
                        }
                        list.Add(ID);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "GET DATA FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }
        public int getPlanIDbyID(int ID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            int PlanID = -1;
            String sql = "Use [rbi]" +
                        "SELECT [PlanID]" +
                        "From [dbo].[INSPECTION_COVERAGE] where ID = '" + ID + "'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            PlanID = reader.GetInt32(0);
                        }
                       
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "GET DATA FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return PlanID;
        }
        public int getEquipmentID(int ID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            int PlanID = -1;
            String sql = "Use [rbi]" +
                        "SELECT [EquipmentID]" +
                        "From [dbo].[INSPECTION_COVERAGE] where ID = '" + ID + "'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            PlanID = reader.GetInt32(0);
                        }

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "GET DATA FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return PlanID;
        }
        public int getComponentID(int ID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            int PlanID = -1;
            String sql = "Use [rbi]" +
                        "SELECT [ComponentID]" +
                        "From [dbo].[INSPECTION_COVERAGE] where ID = '" + ID + "'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            PlanID = reader.GetInt32(0);
                        }

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "GET DATA FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return PlanID;
        }
        public int getIDbyEquipmentIDandComponentID(int EquipmentID, int ComponentID,int PlanID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            int ID = -1;
            String sql = "Use [rbi]" +
                        "SELECT [ID]" +
                        "From [dbo].[INSPECTION_COVERAGE] where EquipmentID = '" + EquipmentID + "' and ComponentID = '"+ ComponentID+ "' and PlanID = '"+ PlanID+"'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            ID = reader.GetInt32(0);
                        }
                        
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "GET DATA FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return ID;
        }
       public List<int> getlistIDbyEquipmentIDandComponentID(int EquipmentID, int ComponentID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<int> list = new List<int>();
            int ID = 0;
            String sql = "Use [rbi]" +
                        "SELECT [ID]" +
                        "From [dbo].[INSPECTION_COVERAGE]  where EquipmentID = '" + EquipmentID + "' and ComponentID = '" + ComponentID + "'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            ID = reader.GetInt32(0);
                        }
                        list.Add(ID);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "GET DATA FAIL!");
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

    
