using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBI.PRE.subForm.InputDataForm
{
    public partial class frmTankModelFluid : Form
    {
        public string Fluid_Column = null;
        public frmTankModelFluid()
        {
            InitializeComponent();
            showInDtgv();
           // dtgvTankModelFluid.DataSource=
        }
        public void showInDtgv()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Fluid",typeof(string)));
            table.Columns.Add(new DataColumn("Representative", typeof(string)));
            table.Columns.Add(new DataColumn("Density", typeof(float))); 
            table.Columns.Add(new DataColumn("MW", typeof(float)));
            table.Columns.Add(new DataColumn("Viscosity", typeof(float)));
            table.Rows.Add("Gasoline", "C6-C8", 684.018, 100, 0.00401);
            table.Rows.Add("Light Diesel Oil", "C9-C12", 734.011, 149, 0.00104);
            table.Rows.Add("Heavy Diesel Oil", "C13-C16", 764.527, 205, 0.00246);
            table.Rows.Add("Fuel Oil", "C17-C25", 775.019, 280, 0.0369);
            table.Rows.Add("Crude Oil", "C17-C25", 775.019, 280, 0.0369);
            table.Rows.Add("Heavy Fuel Oil", "C25+", 900.026, 422, 0.046);
            table.Rows.Add("Heavy Crude Oil", "C25+", 900.026, 422, 0.046);
            table.Rows.Add("Water", "Water+", 1000, 18, 1);
            dtgvTankModelFluid.DataSource = table;
        }

        private void dtgvTankModelFluid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;
            Fluid_Column = dtgvTankModelFluid.Rows[numrow].Cells[0].Value.ToString();
        }

        private void dtgvTankModelFluid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;
            Fluid_Column = dtgvTankModelFluid.Rows[numrow].Cells[0].Value.ToString();
            if (Fluid_Column == null) Fluid_Column = dtgvTankModelFluid.Rows[0].Cells[0].Value.ToString();
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (Fluid_Column == null) Fluid_Column = dtgvTankModelFluid.Rows[0].Cells[0].Value.ToString();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
