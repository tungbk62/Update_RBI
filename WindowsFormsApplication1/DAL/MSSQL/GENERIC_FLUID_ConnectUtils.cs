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
    class GENERIC_FLUID_ConnectUtils
    {
        public void add(String GenericFluid,String ExamplesOfApplicable,int FluidType, float NBP,float MW,float Density,int AmbientState,int AutoIgnitionTemperature, int ChemicalFactor,int HealthDegree,
                       int Flammability,int Reactivity)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                            "INSERT INTO [dbo].[GENERIC_FLUID]" +
                            "([GenericFluid]" +
                            "[ExamplesOfApplicable]" +
                            "[FluidType]" +
                            ",[NBP]" +
                            ",[MW]" +
                            ",[Density]" +
                            ",[AmbientState]" +
                            ",[AutoIgnitionTemperature]" +
                            ",[ChemicalFactor]" +
                            ",[HealthDegree]" +
                            ",[Flammability]" +
                            ",[Reactivity])" +
                            "VALUES" +
                            "('" + GenericFluid + "'" +
                            ",'" + ExamplesOfApplicable + "'" +
                            ",'" + FluidType + "'" +
                            ",'" + NBP + "'" +
                            ",'" + MW + "'" +
                            ",'" + Density + "'" +
                            ",'" + AmbientState + "'" +
                            ",'" + AutoIgnitionTemperature + "'" +
                            ",'" + ChemicalFactor + "'" +
                            ",'" + HealthDegree + "'" +
                            ",'" + Flammability + "'" +
                            ",'" + Reactivity + "')";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
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
        public void edit(int GenericFluidID, String GenericFluid, String ExamplesOfApplicable, int FluidType, float NBP, float MW, float Density, int AmbientState, int AutoIgnitionTemperature, int ChemicalFactor, int HealthDegree,
                       int Flammability,int Reactivity)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                            "UPDATE [dbo].[GENERIC_FLUID]" +
                            "   SET [GenericFluidID] = '" + GenericFluidID + "'" +
                            "      ,[GenericFluid] = '" + GenericFluid + "'" +
                            "      ,[ExamplesOfApplicable] = '" + ExamplesOfApplicable + "'" +
                            "      ,[FluidType] = '" + FluidType + "'" +
                            "      ,[NBP] = '" + NBP + "'" +
                            "      ,[MW] = '" + MW + "'" +
                            "      ,[Density] = '" + Density + "'" +
                            "      ,[AmbientState] = '" + AmbientState + "'" +
                            "      ,[AutoIgnitionTemperature] = '" + AutoIgnitionTemperature + "'" +
                            "      ,[ChemicalFactor] = '" + ChemicalFactor + "'" +
                            "      ,[HealthDegree] = '" + HealthDegree + "'" +
                            "      ,[Flammability] = '" + Flammability + "'" +
                            "      ,[Reactivity] = '" + Reactivity + "'" +
                            " WHERE [GenericFluidID] = '" + GenericFluidID + "'";
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
        public void delete(int GenericFluidID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] DELETE FROM [dbo].[GENERIC_FLUID] WHERE [GenericFluidID] = '" + GenericFluidID + "'";
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
    
    public List<GENERIC_FLUID> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<GENERIC_FLUID> list = new List<GENERIC_FLUID>();
            GENERIC_FLUID obj = null;
            String sql = " Use [rbi] Select [GenericFluidID]" +                    
                          ",[GenericFluid]" +
                          ",[ExamplesOfApplicable]" +
                          ",[FluidType]" +
                          ",[NBP]" +
                          ",[MW]" +
                          ",[Density]" +
                          ",[AmbientState]" +
                          ",[AutoIgnitionTemperature]" +
                          ",[ChemicalFactor]" +
                          ",[HealthDegree]" +
                          ",[Flammability]" +
                          ",[Reactivity]" +
                          "From [dbo].[GENERIC_FLUID]";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                { 
                    while(reader .Read())
                    {

                    if (reader.HasRows)
                    {
                        obj = new GENERIC_FLUID();
                        obj.GenericFluidID = reader.GetInt32(0);
                        obj.GenericFluid = reader.GetString(1);
                        if(!reader.IsDBNull(2))
                        {
                        obj.ExamplesOfApplicable = reader.GetString(2);
                        }
                        obj.FluidType = reader.GetInt32(3);
                        if(!reader .IsDBNull(4))
                        {
                        obj.NBP = reader.GetFloat(4);
                        }
                        if(!reader .IsDBNull(5))
                        {
                        obj.MW = reader.GetFloat(5);
                        }
                        if(!reader .IsDBNull(6))
                        {
                        obj.Density = reader.GetFloat(6);
                        }
                        obj.AmbientState = reader.GetInt32(7);
                        if(!reader.IsDBNull(8))
                        {
                        obj.AutoIgnitionTemperature = reader.GetInt32(8);
                        }
                        if (!reader .IsDBNull(9))
                        {
                        obj.ChemicalFactor = reader.GetInt32(9);
                        }
                        if(!reader .IsDBNull(10))
                        {
                        obj.HealthDegree = reader.GetInt32(10);
                        }
                        if(!reader .IsDBNull(11))
                        {
                        obj.Flammability = reader.GetInt32(11);
                        }
                        if(!reader .IsDBNull(12))
                        {
                        obj.Reactivity = reader.GetInt32(12);
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
         
    }
}


