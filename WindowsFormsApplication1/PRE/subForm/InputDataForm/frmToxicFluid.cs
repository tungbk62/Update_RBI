using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.DAL.MSSQL;
using System.Data.SqlClient;
namespace RBI.PRE.subForm.InputDataForm
{
    public partial class frmToxicFluid : Form
    {
        public string Representative_Fluid = null;
        public frmToxicFluid()
        {
            InitializeComponent();
            SqlConnection con = MSSQLDBUtils.GetDBConnection();
            try
            {
                con.Open();
                string query = "SELECT COFFluid[Representative Fluid], ExamplesOfApplicable[Example of Applicable Material], FluidType[Fluid Type], MW, NBP[Normal Boiling Poin (°C)], Density [Liquid Density(kg/m^3)],AmbientState[Ambient State], AutoIgnitionTemperature[Auto-ignition Temperature(°C)]  FROM dbo.COF_FLUID WHERE (COFFluidID >13 AND COFFluidID != 17 AND COFFluidID != 24 AND COFFluidID != 26 AND COFFluidID != 27 AND COFFluidID != 28 AND COFFluidID != 30  )";
                DataTable data1 = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.Fill(data1);
                //Console.WriteLine("a="+a);
                con.Close();
                dtgvToxicFluid.DataSource = data1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void dtgvToxicFluid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;
            Representative_Fluid = dtgvToxicFluid.Rows[numrow].Cells[0].Value.ToString();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (Representative_Fluid == null) Representative_Fluid = dtgvToxicFluid.Rows[0].Cells[0].Value.ToString();
            this.Close();
        }

        private void dtgvToxicFluid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;
            Representative_Fluid = dtgvToxicFluid.Rows[numrow].Cells[0].Value.ToString();
            if (Representative_Fluid == null) Representative_Fluid = dtgvToxicFluid.Rows[0].Cells[0].Value.ToString();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
