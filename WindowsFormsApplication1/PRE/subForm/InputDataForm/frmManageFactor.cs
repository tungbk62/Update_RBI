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
    public partial class frmManageFactor : Form
    {
        public float Fms = 0;
        public float score = 0;
        public frmManageFactor()
        {
            InitializeComponent();
           
        }

        private void btnNext_1_Click(object sender, EventArgs e)
        {
            tabControlMF.SelectedTabPage = tabsafety;
        }
        private void tinhtoan()
        {
            CheckBox[] boxes = new CheckBox[267];
            int[] num = { 10, 2, 2, 2, 2, 2, 10, 15, 10, 5, 5, 5, 5, 2, 2, 2, 10, 3, 3, 3, 5, 10, 8, 4, 4, 1, 1, 1, 1, 1, 1, 5, 8, 10, 5, 1, 1, 1, 1, 1, 2, 2, 2, 2,
                2,2,2,3,3,3,3,3,8,3,3,10,12,10,5,9,5,4,4,4,4,5,4,5,3,3,3,3,3,10,5,10,5,2,2,2,2,2,2,2,2,3,4,3,10,10,11,6,3,0,8,4,2,0,2,2,2,2,2,2,2,2,2,2,10,1,1,1,1,1,
                10,10,7,4,2,0,10,5,4,4,10,10,3,3,3,3,3,3,10,7,3,0,10,5,0,10,7,5,3,0,4,4,4,5,5,5,5,2,2,2,2,2,2,1,2,2,5,5,1,1,3,1,1,2,2,2,3,2,5,3,2,3,3,5,1,2,3,2,5,3,2,
                5,5,3,1,1,1,1,1,1,1,1,1,1,1,1,1,5,5,10,10,10,5,5,5,5,5,5,10,5,2,2,2,2,2,2,2,2,2,2,2,5,2,2,2,5,2,10,10,5,3,3,2,2,2,2,2,2,2,2,2,2,2,5,10,5,6,6,3,3,3,2,2,2,2,
                9,9,10,10,7,0,10,5,5,10};
            #region checkbox met vcc
            boxes[0] = checkleader_1;
            boxes[1] = checkleader_2;
            boxes[2] = checkleader_3;
            boxes[3] = checkleader_4;
            boxes[4] = checkleader_5;
            boxes[5] = checkleader_6;
            boxes[6] = checkleader_7;
            boxes[7] = checkleader_8;
            boxes[8] = checkleader_9;
            boxes[9] = checkleader_10;
            boxes[10] = checksafety_1;
            boxes[11] = checksafety_2;
            boxes[12] = checksafety_3;
            boxes[13] = checksafety_4;
            boxes[14] = checksafety_5;
            boxes[15] = checksafety_6;
            boxes[16] = checksafety_7;
            boxes[17] = checksafety_8;
            boxes[18] = checksafety_9;
            boxes[19] = checksafety_10;
            boxes[20] = checksafety_11;
            boxes[21] = checksafety_12;
            boxes[22] = checksafety_13;
            boxes[23] = checksafety_14;
            boxes[24] = checksafety_15;
            boxes[25] = checksafety_16;
            boxes[26] = checksafety_17;
            boxes[27] = checksafety_18;
            boxes[28] = checksafety_19;
            boxes[29] = checksafety_20;
            boxes[30] = checkBox1;
            boxes[31] = checkBox2;
            boxes[32] = checkBox3;
            boxes[33] = checkBox4;
            boxes[34] = checkBox5;
            boxes[35] = checkBox6;
            boxes[36] = checkBox7;
            boxes[37] = checkBox8;
            boxes[38] = checkBox9;
            boxes[39] = checkBox10;
            boxes[40] = checkBox11;
            boxes[41] = checkBox12;
            boxes[42] = checkBox13;
            boxes[43] = checkBox14;
            boxes[44] = checkBox15;
            boxes[45] = checkBox16;
            boxes[46] = checkBox17;
            boxes[47] = checkBox18;
            boxes[48] = checkBox19;
            boxes[49] = checkBox20;
            boxes[50] = checkBox21;
            boxes[51] = checkBox22;
            boxes[52] = checkBox23;
            boxes[53] = checkBox24;
            boxes[54] = checkBox25;
            boxes[55] = checkBox26;
            boxes[56] = checkBox27;
            boxes[57] = checkBox28;
            boxes[58] = checkBox29;
            boxes[59] = checkBox30;
            boxes[60] = checkBox31;
            boxes[61] = checkBox32;
            boxes[62] = checkBox33;
            boxes[63] = checkBox34;
            boxes[64] = checkBox35;
            boxes[65] = checkBox36;
            boxes[66] = checkBox37;
            boxes[67] = checkBox38;
            boxes[68] = checkBox39;
            boxes[69] = checkBox40;
            boxes[70] = checkBox41;
            boxes[71] = checkBox42;
            boxes[72] = checkBox43;
            boxes[73] = checkBox44;
            boxes[74] = checkBox45;
            boxes[75] = checkBox46;
            boxes[76] = checkBox47;
            boxes[77] = checkBox48;
            boxes[78] = checkBox49;
            boxes[79] = checkBox50;
            boxes[80] = checkBox51;
            boxes[81] = checkBox52;
            boxes[82] = checkBox53;
            boxes[83] = checkBox54;
            boxes[84] = checkBox55;
            boxes[85] = checkBox56;
            boxes[86] = checkBox57;
            boxes[87] = checkBox58;
            boxes[88] = checkBox59;
            boxes[89] = checkBox60;
            boxes[90] = checkBox61;
            boxes[91] = checkBox62;
            boxes[92] = checkBox63;
            boxes[93] = checkBox64;
            boxes[94] = checkBox65;
            boxes[95] = checkBox66;
            boxes[96] = checkBox67;
            boxes[97] = checkBox68;
            boxes[98] = checkBox69;
            boxes[99] = checkBox70;
            boxes[100] = checkBox71;
            boxes[101] = checkBox72;
            boxes[102] = checkBox73;
            boxes[103] = checkBox74;
            boxes[104] = checkBox75;
            boxes[105] = checkBox76;            
            boxes[106] = checkBox77;
            boxes[107] = checkBox78;
            boxes[108] = checkBox79;
            boxes[109] = checkBox80;
            boxes[110] = checkBox81;
            boxes[111] = checkBox82;
            boxes[112] = checkBox83;
            boxes[113] = checkBox84;
            boxes[114] = checkBox85;
            boxes[115] = checkBox86;
            boxes[116] = checkBox87;
            boxes[117] = checkBox88;
            boxes[118] = checkBox89;
            boxes[119] = checkBox90;
            boxes[120] = checkBox91;
            boxes[121] = checkBox92;
            boxes[122] = checkBox93;
            boxes[123] = checkBox94;
            boxes[124] = checkBox95;
            boxes[125] = checkBox96;
            boxes[126] = checkBox97;
            boxes[127] = checkBox98;
            boxes[128] = checkBox99;
            boxes[129] = checkBox100;
            boxes[130] = checkBox101;
            boxes[131] = checkBox102;
            boxes[132] = checkBox103;
            boxes[133] = checkBox104;
            boxes[134] = checkBox105;
            boxes[135] = checkBox106;
            boxes[136] = checkBox107;
            boxes[137] = checkBox108;
            boxes[138] = checkBox109;
            boxes[139] = checkBox110;
            boxes[140] = checkBox111;
            boxes[141] = checkBox112;
            boxes[142] = checkBox113;
            boxes[143] = checkBox114;
            boxes[144] = checkBox115;
            boxes[145] = checkBox116;
            boxes[146] = checkBox117;
            boxes[147] = checkBox118;
            boxes[148] = checkBox119;
            boxes[149] = checkBox120;
            boxes[150] = checkBox121;
            boxes[151] = checkBox122;
            boxes[152] = checkBox123;
            boxes[153] = checkBox124;
            boxes[154] = checkBox125;
            boxes[155] = checkBox126;
            boxes[156] = checkBox127;
            boxes[157] = checkBox128;
            boxes[158] = checkBox129;
            boxes[159] = checkBox130;
            boxes[160] = checkBox131;
            boxes[161] = checkBox132;
            boxes[162] = checkBox133;
            boxes[163] = checkBox134;
            boxes[164] = checkBox135;
            boxes[165] = checkBox136;
            boxes[166] = checkBox137;
            boxes[167] = checkBox138;
            boxes[168] = checkBox139;
            boxes[169] = checkBox140;
            boxes[170] = checkBox141;
            boxes[171] = checkBox142;
            boxes[172] = checkBox143;
            boxes[173] = checkBox144;
            boxes[174] = checkBox145;
            boxes[175] = checkBox146;
            boxes[176] = checkBox147;
            boxes[177] = checkBox148;
            boxes[178] = checkBox149;
            boxes[179] = checkBox150;
            boxes[180] = checkBox151;
            boxes[181] = checkBox152;
            boxes[182] = checkBox153;
            boxes[183] = checkBox154;
            boxes[184] = checkBox155;
            boxes[185] = checkBox156;
            boxes[186] = checkBox157;
            boxes[187] = checkBox158;
            boxes[188] = checkBox159;
            boxes[189] = checkBox160;
            boxes[190] = checkBox161;
            boxes[191] = checkBox162;
            boxes[192] = checkBox163;
            boxes[193] = checkBox164;
            boxes[194] = checkBox165;
            boxes[195] = checkBox166;
            boxes[196] = checkBox167;
            boxes[197] = checkBox168;
            boxes[198] = checkBox169;
            boxes[199] = checkBox170;
            boxes[200] = checkBox171;
            boxes[201] = checkBox172;
            boxes[202] = checkBox173;
            boxes[203] = checkBox174;
            boxes[204] = checkBox175;
            boxes[205] = checkBox176;
            boxes[206] = checkBox177;
            boxes[207] = checkBox178;
            boxes[208] = checkBox179;
            boxes[209] = checkBox180;
            boxes[210] = checkBox181;
            boxes[211] = checkBox182;
            boxes[212] = checkBox183;
            boxes[213] = checkBox184;
            boxes[214] = checkBox185;
            boxes[215] = checkBox186;
            boxes[216] = checkBox187;
            boxes[217] = checkBox188;
            boxes[218] = checkBox189;
            boxes[219] = checkBox190;
            boxes[220] = checkBox191;
            boxes[221] = checkBox192;
            boxes[222] = checkBox193;
            boxes[223] = checkBox194;
            boxes[224] = checkBox195;
            boxes[225] = checkBox196;
            boxes[226] = checkBox197;
            boxes[227] = checkBox198;
            boxes[228] = checkBox199;
            boxes[229] = checkBox200;
            boxes[230] = checkBox201;
            boxes[231] = checkBox202;
            boxes[232] = checkBox203;
            boxes[233] = checkBox204;
            boxes[234] = checkBox205;
            boxes[235] = checkBox206;
            boxes[236] = checkBox207;
            boxes[237] = checkBox208;
            boxes[238] = checkBox209;
            boxes[239] = checkBox210;
            boxes[240] = checkBox211;
            boxes[241] = checkBox212;
            boxes[242] = checkBox213;
            boxes[243] = checkBox214;
            boxes[244] = checkBox215;
            boxes[245] = checkBox216;
            boxes[246] = checkBox217;
            boxes[247] = checkBox218;
            boxes[248] = checkBox219;
            boxes[249] = checkBox220;
            boxes[250] = checkBox221;
            boxes[251] = checkBox222;
            boxes[252] = checkBox223;
            boxes[253] = checkBox224;
            boxes[254] = checkBox225;
            boxes[255] = checkBox226;
            boxes[256] = checkBox227;
            boxes[257] = checkBox228;
            boxes[258] = checkBox229;
            boxes[259] = checkBox230;
            boxes[260] = checkBox231;
            boxes[261] = checkBox232;
            boxes[262] = checkBox233;
            boxes[263] = checkBox234;
            boxes[264] = checkBox235;
            boxes[265] = checkBox236;
            boxes[266] = checkBox237;
            #endregion
            for (int i = 0; i < 4; i++)
            {
                if (boxes[i].Checked) {
                    score += num[i];
                }

            }
            float Pscore = score / 10;
            Fms = (float)Math.Pow(10, (-0.02 * Pscore + 1));
        }
        private void btnNext_2_Click(object sender, EventArgs e)
        {
            tabControlMF.SelectedTabPage = tabhazzard;
        }

        private void btnBack_1_Click(object sender, EventArgs e)
        {
            tabControlMF.SelectedTabPage = tableader;
        }

        private void btnNext_3_Click(object sender, EventArgs e)
        {
            tabControlMF.SelectedTabPage = tabhazzard_2;
        }

        private void btnBack_2_Click(object sender, EventArgs e)
        {
            tabControlMF.SelectedTabPage = tabsafety;
        }

        private void btnNext_4_Click(object sender, EventArgs e)
        {
            tabControlMF.SelectedTabPage = tabchange;
        }

        private void btnBack_3_Click(object sender, EventArgs e)
        {
            tabControlMF.SelectedTabPage = tabhazzard;
        }

        private void btnNext_5_Click(object sender, EventArgs e)
        {
            tabControlMF.SelectedTabPage = taboperating;
        }

        private void btnBack_4_Click(object sender, EventArgs e)
        {
            tabControlMF.SelectedTabPage = tabhazzard_2;
        }

        private void btnNext_6_Click(object sender, EventArgs e)
        {
            tabControlMF.SelectedTabPage = tabwork;
        }

        private void btnBack_5_Click(object sender, EventArgs e)
        {
            tabControlMF.SelectedTabPage = tabchange;
        }

        private void btnNext_7_Click(object sender, EventArgs e)
        {
            tabControlMF.SelectedTabPage = tabword2;
        }

        private void btnBack_6_Click(object sender, EventArgs e)
        {
            tabControlMF.SelectedTabPage = taboperating;
        }

        private void btnNext_8_Click(object sender, EventArgs e)
        {
            tabControlMF.SelectedTabPage = tabtraining;
        }

        private void btnBack_7_Click(object sender, EventArgs e)
        {
            tabControlMF.SelectedTabPage = tabwork;
        }

        private void btnNext_9_Click(object sender, EventArgs e)
        {
            tabControlMF.SelectedTabPage = tabtraining2;
        }

        private void btnBack_8_Click(object sender, EventArgs e)
        {
            tabControlMF.SelectedTabPage = tabword2;
        }

        private void btnNext_10_Click(object sender, EventArgs e)
        {
            tabControlMF.SelectedTabPage = tabmechanical;
        }

        private void btnBack_9_Click(object sender, EventArgs e)
        {
            tabControlMF.SelectedTabPage = tabtraining;
        }

        private void btnNext_11_Click(object sender, EventArgs e)
        {
            tabControlMF.SelectedTabPage = tabmechanical2;
        }

        private void btnBack_10_Click(object sender, EventArgs e)
        {
            tabControlMF.SelectedTabPage = tabtraining2;
        }

        private void btnNext_12_Click(object sender, EventArgs e)
        {
            tabControlMF.SelectedTabPage = tabmechanical3;
        }

        private void btnBack_11_Click(object sender, EventArgs e)
        {
            tabControlMF.SelectedTabPage = tabmechanical;
        }

        private void btnNext_13_Click(object sender, EventArgs e)
        {
            tabControlMF.SelectedTabPage = tabstartup;
        }

        private void btnBack_12_Click(object sender, EventArgs e)
        {
            tabControlMF.SelectedTabPage = tabmechanical2;
        }

        private void btnNext_14_Click(object sender, EventArgs e)
        {
            tabControlMF.SelectedTabPage = tabemergency;
        }

        private void btnBack_13_Click(object sender, EventArgs e)
        {
            tabControlMF.SelectedTabPage = tabmechanical3;
        }

        private void btnNext_15_Click(object sender, EventArgs e)
        {
            tabControlMF.SelectedTabPage = tabincident;
        }

        private void btnBack_14_Click(object sender, EventArgs e)
        {
            tabControlMF.SelectedTabPage = tabstartup;
        }

        private void btnNext_16_Click(object sender, EventArgs e)
        {
            tabControlMF.SelectedTabPage = tabcontractors;
        }

        private void btnBack_15_Click(object sender, EventArgs e)
        {
            tabControlMF.SelectedTabPage = tabemergency;
        }

        private void btnNext_17_Click(object sender, EventArgs e)
        {
            tabControlMF.SelectedTabPage = tabsystem;
        }

        private void btnBack_16_Click(object sender, EventArgs e)
        {
            tabControlMF.SelectedTabPage = tabincident;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            tinhtoan();
            this.Close();
        }
        private void btnBack_17_Click(object sender, EventArgs e)
        {
            tabControlMF.SelectedTabPage = tabcontractors;
        }
    }
}
