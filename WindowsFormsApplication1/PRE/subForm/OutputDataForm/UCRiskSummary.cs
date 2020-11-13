using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.BUS.BUSMSSQL;
namespace RBI.PRE.subForm.OutputDataForm
{
    public partial class UCRiskSummary : UserControl
    {
        public UCRiskSummary()
        {
            InitializeComponent();
            //DrawRiskMatrix();
        }
        public UCRiskSummary(int ID)
        {
            InitializeComponent();
            DrawRiskMatrix(ID);
        }
        Graphics g;
        private void DrawRiskMatrix(int ID)
        {
            RW_FULL_POF_BUS busPoF = new RW_FULL_POF_BUS();
            float[] DF = busPoF.getDF(ID);
            RW_FULL_FCOF_BUS busCoF = new RW_FULL_FCOF_BUS();
            RW_FULL_COF_BUS rw_full_COF_bus = new RW_FULL_COF_BUS();
            //RW_FULL_COF rw_full_COF = new RW_FULL_COF();
            //RW_ASSESSMENT_BUS rwAssBus = new RW_ASSESSMENT_BUS();
            //EQUIPMENT_MASTER_BUS eqipMasBus = new EQUIPMENT_MASTER_BUS();
            
            //float CoF = 0;
            //if (eqipMasBus.getEquipmentTypeID(rwAssBus.getEquipmentID(ID)) != 11)//la thiet bi thuong
            //     CoF = rw_full_COF_bus.getCoFValue(ID);
            float CoF = rw_full_COF_bus.getCoFValue(ID);
            int width = picRiskSummary.Width - 16;
            int height = picRiskSummary.Height - 16;
            int x = width / 5;
            int y = height / 5;
            picRiskSummary.Image = new Bitmap(width, height);
            g = Graphics.FromImage(this.picRiskSummary.Image);
            //tô màu
            SolidBrush red = new SolidBrush(Color.Red);
            
            Rectangle recRed1 = new Rectangle(x * 3 + 2, 8, x * 2 - 4, y);
            Rectangle recRed2 = new Rectangle(x * 4, 8+y-2, x - 2, y * 2 - 4);
            g.FillRectangle(red, recRed1);
            g.FillRectangle(red, recRed2);
            SolidBrush orange = new SolidBrush(Color.Orange);
            Rectangle recOrange1 = new Rectangle(8, 8, x * 3 - 6, y - 2);
            Rectangle recOrange2 = new Rectangle(x * 2 + 2, y + 6, x * 2 - 2, y - 2);
            Rectangle recOrange3 = new Rectangle(x * 3, y * 2, x, y + 2);
            Rectangle recOrange4 = new Rectangle(x * 4, y * 3 + 2, x - 2, y * 2 - 4);
            g.FillRectangle(orange, recOrange1);
            g.FillRectangle(orange, recOrange2);
            g.FillRectangle(orange, recOrange3);
            g.FillRectangle(orange, recOrange4);
            SolidBrush lightGreen = new SolidBrush(Color.LightGreen);
            Rectangle recLightGreen1 = new Rectangle(8, y * 2 + 5, x * 2 - 5, y - 2);
            Rectangle recLightGreen2 = new Rectangle(x+5, y * 3, x-2 , y);
            g.FillRectangle(lightGreen, recLightGreen1);
            g.FillRectangle(lightGreen, recLightGreen2);
            //
            SolidBrush limeGreen = new SolidBrush(Color.LimeGreen);
            Rectangle recLimeGreen1 = new Rectangle(8, y * 3 + 1, x - 2, 2 * y - 2);
            Rectangle recLimeGreen2 = new Rectangle(x, y * 4 + 1, x+4 ,  y-2 );
            g.FillRectangle(limeGreen, recLimeGreen1);
            g.FillRectangle(limeGreen, recLimeGreen2);
            SolidBrush yellow = new SolidBrush(Color.Yellow);
            Rectangle recYellow1 = new Rectangle(8, y + 6, x * 2 - 4, y - 2);
            Rectangle recYellow2 = new Rectangle(x * 2 + 4, y * 2 + 4, x - 2, y * 3 - 6);
            Rectangle recYellow3 = new Rectangle(x * 3, y * 3 + 2, x, y * 2 - 4);
            g.FillRectangle(yellow, recYellow1);
            g.FillRectangle(yellow, recYellow2);
            g.FillRectangle(yellow, recYellow3);
            Pen gridPen = new Pen(Color.Gray, 2);
            //vẽ cột đứng
            for (int i = 8; i < width; i += x - 2)
            {
                g.DrawLine(gridPen, i, 8, i, height - 2);
            }
            //vẽ dòng ngang
        
            for (int i = 8; i < height; i += y - 2)
            {
                g.DrawLine(gridPen, 8, i, width - 2, i);
            }
            double[] coordinatesPoF = { 0, 0, 0 };
            double coordinatesCoF = CoF;
            //float[] DF = { 1, 500, 5000 };
            for (int i = 0; i < 3; i++)
            {
                if (DF[i] <= 3.00000006)
                {
                    coordinatesPoF[i] = 8+5*(y-2)-10;
                }
                else if (DF[i] <= 3.0000006)
                {
                    coordinatesPoF[i] = (y - 2) / (3.0000006 - 3.00000006) * (DF[i] - 3.00000006) + 8 + 5 * (y - 2);
                       // 8 + 5 * (y - 2) + ((3.0000006 - 3.00000006) / (y - 2)) * (coordinatesPoF[i] - 3.00000006);
                }
                else if (DF[i] <= 3.000006)
                {
                    coordinatesPoF[i] = (y - 2) / (3.000006 - 3.0000006) * (DF[i] - 3.0000006) + 8 + 4 * (y - 2);
                }
                else if (DF[i] <= 3.00006)
                {
                    coordinatesPoF[i] = (y - 2) / (3.00006 - 3.000006) * (DF[i] - 3.000006) + 8 + 3 * (y - 2);
                }
                else if (DF[i] <= 3.0006)
                {
                    coordinatesPoF[i] = (y - 2) / (3.0006 - 3.00006) * (DF[i] - 3.00006) + 8 + 2 * (y - 2);
                    //int df = (int)DF[i];
                    //string a = df.ToString();
                    //coordinatesPoF[i] = y - y * DF[i] / (float)Math.Pow(10,a.Length);
                }
                else if (DF[i] <= 3.006)
                {
                    coordinatesPoF[i] = (y - 2) / (3.006 - 3.0006) * (DF[i] - 3.0006) + 8 + 1 * (y - 2);
                }
                else
                {
                    coordinatesPoF[i] = 8;
                }
            }
            if (CoF <= 1000)
            {
                coordinatesCoF = 8+2;
            }
            else if (CoF <= 10000)
            {
                coordinatesCoF = 8 + (x - 2)/(10000 - 1000) * (CoF - 1000); 
            }
            else if (CoF <= 100000)
            {

                coordinatesCoF = 8 + 1 * (x - 2) + (x - 2)/(100000 - 10000)  * (CoF - 10000); 
            }
            else if (CoF <= 1000000)
            {

                coordinatesCoF = 8 + 2 * (x - 2) + ( (x - 2)/(1000000 - 100000) ) * (CoF - 100000); 
            }
            else if (CoF <= 10000000)
            {
                coordinatesCoF = 8 + 3 * (x - 2) + ((x - 2)/(10000000 - 1000000)) * (CoF - 1000000); 
            }
            else if (CoF <= 100000000)
	        {
                coordinatesCoF = 8 + 4 * (x - 2) + ( (x - 2)/(100000000 - 10000000) ) * (CoF - 10000000);
	        }
            else
            {
                coordinatesCoF = 8 * x + 5*(x-2)-2;
            }
            Image[] image = { Resource1.Square_icon, Resource1.Circle_icon, Resource1.Triangle2_icon};
            //coordinatesPoF[1] = 8;
            for (int i = 0; i < 3; i++)
            {
                g.DrawImage(image[i], (float)coordinatesCoF, (float)coordinatesPoF[i]);
            }
            //chu thich
            picChuThich.Image = new Bitmap(picChuThich.Width-1, picChuThich.Height-1);
            Graphics g1 = Graphics.FromImage(this.picChuThich.Image);
            //this.picChuThich.Image.setco
           // Icon my = new Icon(Resource1.Square_icon);
           // Resource1.Square_icon.SetPixel
            //Resource1.Square_icon.SetPixel(4,2,Color.Red);
            //Point p=
           //g1.DrawImage()
            //image[0].
            g1.DrawImage(Resource1.Square_icon,5,2);
            g1.DrawImage(Resource1.Triangle2_icon,5,58);
            g1.DrawImage(Resource1.Circle_icon, 5, 30);

        }
    }
}
