using RBI.Object.ObjectMSSQL;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace RBI.DAL.MSSQL
{
    class RW_INSPECTION_DETAIL_ConnUtils
    {
        public void add(int ID, int EquipmentID, int ComponentID, int Coverage_DetailID, String InspPlanname, DateTime InspectionDate, int DMItemID, String EffectivenessCode, String InspectionSummary, int IsCarriedOut, DateTime CarriedOutDate, int IsActive)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                        "INSERT INTO [dbo].[RW_INSPECTION_DETAIL] " +
                        "([ID] " +
                        ",[EquipmentID] " +
                        ",[ComponentID] " +
                        ",[Coverage_DetailID] " +
                        ",[InspPlanName] " +
                        ",[InspectionDate] " +
                        ",[DMItemID] " +
                        ",[EffectivenessCode] " +
                        ",[InspectionSummary] " +
                        ",[IsCarriedOut] " +
                        ",[CarriedOutDate] " +
                        ",[IsActive])" +
                        " VALUES " +
                        "('" + ID + "'" +
                        ",'" + EquipmentID + "'" +
                        ",'" + ComponentID + "'" +
                        ",'" + Coverage_DetailID + "'" +
                        ",'" + InspPlanname + "'" +
                        ",'" + InspectionDate + "'" +
                        ",'" + DMItemID + "'" +
                        ",'" + EffectivenessCode + "'" +
                        ",'" + InspectionSummary + "'" +
                        ",'" + IsCarriedOut + "'" +
                        ",'" + CarriedOutDate + "'" +
                        ",'" + IsActive + "')";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                // do nothing
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void edit(int ID, int DetailID, int EquipmentID, int ComponentID, int Coverage_DetailID, String InspPlanname, DateTime InspectionDate, int DMItemID, String EffectivenessCode, String InspectionSummary, int IsCarriedOut, DateTime CarriedOutDate, int IsActive)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                        "UPDATE [dbo].[RW_INSPECTION_DETAIL]" +
                        "   SET [ID] = '" + ID + "'" +
                        ",[DetailID] = '" + DetailID + "'" +
                        ",[EquipmentID] = '" + EquipmentID + "'" +
                        ",[ComponentID] = '" + ComponentID + "'" +
                        ",[Coverage_DetailID] = '" + Coverage_DetailID + "'" +
                        ",[InspPlanName] = '" + InspPlanname + "'" +
                        ",[InspectionDate] = '" + InspectionDate + "'" +
                        ",[DMItemID] = '" + DMItemID + "'" +
                        ",[EffectivenessCode] = '" + EffectivenessCode + "'" +
                        ",[InspectionSummary] = '" + InspectionSummary + "'" +
                        ",[IsCarriedOut] = '" + IsCarriedOut + "'" +
                        ",[CarriedOutDate] = '" + CarriedOutDate + "'" +
                        ",[IsActive] = '" + IsActive + "'" +
                        " WHERE [ID] = '" + ID + "'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                // do nothing
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void delete(int ID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                        "DELETE FROM [dbo].[RW_INSPECTION_DETAIL] WHERE [ID] = '" + ID + "'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                // do nothing
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public List<RW_INSPECTION_DETAIL> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<RW_INSPECTION_DETAIL> list = new List<RW_INSPECTION_DETAIL>();
            RW_INSPECTION_DETAIL obj = null;
            String sql = "SELECT [ID]" +
                        ",[DetailID] " +
                        ",[EquipmentID]" +
                        ",[ComponentID]" +
                        ",[Coverage_DetailID]" +
                        ",[InspPlanName]" +
                        ",[InspectionDate]" +
                        ",[DMItemID]" +
                        ",[EffectivenessCode]" +
                        ",[InspectionSummary]" +
                        ",[IsCarriedOut]" +
                        ",[CarriedOutDate]" +
                        ",[IsActive]" +
                        "  FROM [rbi].[dbo].[RW_INSPECTION_DETAIL]";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            obj = new RW_INSPECTION_DETAIL();
                            obj.ID = reader.GetInt32(0);
                            obj.DetailID = reader.GetInt32(1);
                            obj.EquipmentID = reader.GetInt32(2);
                            obj.ComponentID = reader.GetInt32(3);
                            obj.Coverage_DetailID = reader.GetInt32(4);
                            obj.InspPlanName = reader.GetString(5);
                            obj.InspectionDate = reader.GetDateTime(6);
                            obj.DMItemID = reader.GetInt32(7);
                            obj.EffectivenessCode = reader.GetString(8);
                            obj.IsCarriedOut = reader.GetInt32(9);
                            obj.CarriedOutDate = reader.GetDateTime(10);
                            obj.IsActive = reader.GetInt32(11);
                            list.Add(obj);
                        }
                    }
                }
            }
            catch
            {
                // do nothing
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }
         public List<RW_INSPECTION_DETAIL> getDataSourcebyID(int ID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<RW_INSPECTION_DETAIL> list = new List<RW_INSPECTION_DETAIL>();
            RW_INSPECTION_DETAIL obj = null;
            String sql = "SELECT [ID]" +
                        ",[DetailID] " +
                        ",[EquipmentID]" +
                        ",[ComponentID]" +
                        ",[Coverage_DetailID]" +
                        ",[InspPlanName]" +
                        ",[InspectionDate]" +
                        ",[DMItemID]" +
                        ",[EffectivenessCode]" +
                        ",[InspectionSummary]" +
                        ",[IsCarriedOut]" +
                        ",[CarriedOutDate]" +
                        ",[IsActive]" +
                        "  FROM [rbi].[dbo].[RW_INSPECTION_DETAIL] WHERE [ID] ='" + ID + "'"; 
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            obj = new RW_INSPECTION_DETAIL();
                            obj.ID = reader.GetInt32(0);
                            obj.DetailID = (Int32)reader.GetInt64(1);
                            obj.EquipmentID = reader.GetInt32(2);
                            obj.ComponentID = reader.GetInt32(3);
                            obj.Coverage_DetailID = (Int32)reader.GetInt64(4);
                            obj.InspPlanName = reader.GetString(5);
                            obj.InspectionDate = reader.GetDateTime(6);
                            obj.DMItemID = reader.GetInt32(7);
                            obj.EffectivenessCode = reader.GetString(8);
                            obj.InspectionSummary= reader.GetString(9);
                            obj.IsCarriedOut = (reader.GetBoolean(10)==true)?1:0;
                            obj.CarriedOutDate = reader.GetDateTime(11);
                            obj.IsActive = reader.GetBoolean(12)==true?1:0;
                            list.Add(obj);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // do nothing
                MessageBox.Show(e.ToString(), "ADD FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }
        public List<RW_INSPECTION_DETAIL> getDataComp(int CompID)
        {
            List<RW_INSPECTION_DETAIL> list = new List<RW_INSPECTION_DETAIL>();
            RW_INSPECTION_DETAIL obj = null;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "SELECT [ID]" +
                        ",[DetailID] " +
                        ",[EquipmentID]" +
                        ",[ComponentID]" +
                        ",[Coverage_DetailID]" +
                        ",[InspPlanName]" +
                        ",[InspectionDate]" +
                        ",[DMItemID]" +
                        ",[EffectivenessCode]" +
                        ",[InspectionSummary]" +
                        ",[IsCarriedOut]" +
                        ",[CarriedOutDate]" +
                        ",[IsActive]" +
                        " FROM [rbi].[dbo].[RW_INSPECTION_DETAIL] WHERE [ComponentID] ='" + CompID + "'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            obj = new RW_INSPECTION_DETAIL();
                            obj.ID = reader.GetInt32(0);
                            obj.DetailID = reader.GetInt32(1);
                            obj.EquipmentID = reader.GetInt32(2);
                            obj.ComponentID = reader.GetInt32(3);
                            obj.Coverage_DetailID = reader.GetInt32(4);
                            obj.InspPlanName = reader.GetString(5);
                            obj.InspectionDate = reader.GetDateTime(6);
                            obj.DMItemID = reader.GetInt32(7);
                            obj.EffectivenessCode = reader.GetString(8);
                            obj.IsCarriedOut = reader.GetInt32(9);
                            obj.CarriedOutDate = reader.GetDateTime(10);
                            obj.IsActive = reader.GetInt32(11);
                            list.Add(obj);
                        }
                    }
                }
            }
            catch
            {
                // do nothing
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }
        // check Inspection History da ton tai hay chua
        // dieu kien: compNum, DM, namTien hanh Insp phai la duy nhat: vd: comp =1, DM = Thinning, Date = 2017
        // neu trong nam 2017 co tien hanh bat ky lan Insp nao nua thi se chay lenh update cho insp cua nam do
        public Boolean checkExist(int CompID, int DMItemID, DateTime InspDate)
        {
            Boolean exist = false;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "SELECT * FROM [rbi].[dbo].[RW_INSPECTION_DETAIL] WHERE [ComponentID] ='" + CompID + "' AND [DMItemID] ='" + DMItemID + "' AND [InspectionDate] like '%" + InspDate.Year + "%'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            exist = true;
                        }
                    }
                }
            }
            catch
            {
                // do nothing
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return exist;
        }

        // lay ra lastInspDate 
        public DateTime getLastInspDate(int CompID, int DMItemID, DateTime ComissionDate)
        {
            DateTime dt = ComissionDate;
            SqlConnection con = MSSQLDBUtils.GetDBConnection();
            con.Open();
            String sql = "SELECT MAX([InspectionDate]) FROM [rbi].[dbo].[RW_INSPECTION_DETAIL] WHERE [ComponentID] = '" + CompID + "' and [DMItemID] = '" + DMItemID + "'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = con;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            dt = reader.GetDateTime(0);
                        }
                    }
                }
            }
            catch
            {
                // do nothing
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return dt;
        }
        // lay ra maxInspec Eff
        public String getMaxInspEffec(int CompID, int DMItemID)
        {
            String eff = "E";
            SqlConnection con = MSSQLDBUtils.GetDBConnection();
            con.Open();
            String sql = "SELECT MIN([EffectivenessCode]) FROM [rbi].[dbo].[RW_INSPECTION_DETAIL] WHERE [ComponentID] = '" + CompID + "' and [DMItemID] = '" + DMItemID + "'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = con;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            if (!reader.IsDBNull(0))
                                eff = reader.GetString(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("get Data inspection fail" + ex.ToString(), "Cortek");
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return eff;
        }
        // dem so lan inspection
        public int InspectionNumber(int CompID, int DMItemID)
        {
            int num = 0;
            SqlConnection con = MSSQLDBUtils.GetDBConnection();
            con.Open();
            String sql = "SELECT COUNT([EffectivenessCode]) FROM [rbi].[dbo].[RW_INSPECTION_DETAIL] WHERE [ComponentNumber] = '" + CompID + "' and [DMItemID] = '" + DMItemID + "'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = con;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            num = reader.GetInt32(0);
                        }
                    }
                }
            }
            catch
            {
                // do nothing
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return num;
        }
        public int InspectionTypeNumber(int CompID, int DMItemID, String type)
        {
            int num = 0;
            SqlConnection con = MSSQLDBUtils.GetDBConnection();
            con.Open();
            String sql = "SELECT COUNT([EffectivenessCode]) FROM [rbi].[dbo].[RW_INSPECTION_DETAIL] WHERE [ComponentNumber] = '" + CompID + "' and [DMItemID] = '" + DMItemID + "' and [EffectivenessCode] = '" + type + "'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = con;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            num = reader.GetInt32(0);
                        }
                    }
                }
            }
            catch
            {
                // do nothing
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return num;
        }
    }
}
// Them cac ham vao day 