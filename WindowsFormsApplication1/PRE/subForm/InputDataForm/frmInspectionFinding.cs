using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;

namespace RBI.PRE.subForm.InputDataForm
{
    public partial class frmInspectionFinding : RibbonForm
    {
        public String InsFinding = "";
        public frmInspectionFinding(String InspectionFinding)
        {
           
            InitializeComponent();
            richEditControl.Text = InspectionFinding;
            InitSkinGallery();
            InitializeRichEditControl();
            ribbonControl.SelectedPage = fileRibbonPage1;
        }
        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rgbiSkins, true);
        }

        void InitializeRichEditControl()
        {

        }

        private void CancelItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void OKItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            InsFinding = richEditControl.Text;
            this.Close();
        }
    }
}
