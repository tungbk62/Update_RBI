using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using RBI.DAL.MSSQL;
namespace RBI.PRE.subForm
{
    public partial class frmModelFluid : Form
    {
        public string Representative_Fluid = null;
        public frmModelFluid()
        {
            InitializeComponent();
            SqlConnection con = MSSQLDBUtils.GetDBConnection();
            try
            {
                con.Open();
                string query = "SELECT COFFluid[Representative Fluid], ExamplesOfApplicable[Example of Applicable Material], FluidType[Fluid Type], MW, NBP[Normal Boiling Poin (°C)], Density [Liquid Density(kg/m^3)],AmbientState[Ambient State], AutoIgnitionTemperature[Auto-ignition Temperature(°C)]  FROM dbo.COF_FLUID";
                DataTable data1 = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.Fill(data1);
                con.Close();
                dtgvModelFluid.DataSource = data1;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }
     

      

        private void dtgvModelFluid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;
            Representative_Fluid = dtgvModelFluid.Rows[numrow].Cells[0].Value.ToString();
        }

        private void dtgvModelFluid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;
            Representative_Fluid = dtgvModelFluid.Rows[numrow].Cells[0].Value.ToString();
            if (Representative_Fluid == null) Representative_Fluid = dtgvModelFluid.Rows[0].Cells[0].Value.ToString();
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (Representative_Fluid == null) Representative_Fluid = dtgvModelFluid.Rows[0].Cells[0].Value.ToString();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
