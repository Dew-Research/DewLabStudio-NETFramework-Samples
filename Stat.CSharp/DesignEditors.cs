using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Dew.Stats.Units;
using Dew.Stats;

namespace StatsMasterDemo
{
    public class DesignEditors : StatsMasterDemo.BasicForm2
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        public DesignEditors()
        {
            InitializeComponent();
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void DesignRegEditor_Load(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            Add("Designtime editors\n");
            Add("Some components also include easy-to-use designtime and runtime editor. "
                + "At runtime editors can be invoked with a simple StatToolsDialogs.ShowDialog "
                + "routine call.");
            Add("In this example tMtxMulLinReg and tMtxHypothesisTest components are pre-loaded "
                + "with test data.");
            // prepared data ... to be loaded here
            try
            {
                tMtxMulLinReg1.Y.LoadFromFile("MulLinReg_Y.vec");
                tMtxMulLinReg1.A.LoadFromFile("MulLinReg_A.mtx");
            }
            catch
            {
                tMtxMulLinReg1.Y.Size(6);
                tMtxMulLinReg1.Y.RandGauss();
                tMtxMulLinReg1.A.Size(6, 4);
                tMtxMulLinReg1.A.RandGauss(3, 2);
            }

            tMtxHypothesisTest1.DataVec1.SetIt(new double[] { 1, 2, 5, 11, 12, 13 });
            tMtxHypothesisTest1.DataVec2.SetIt(new double[] { 5, 6, 7, 8, 9, 10});
            tMtxHypothesisTest1.HypothesisMethod = THypothesisMethod.hmTTest2Pooled;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StatToolsDialogs.ShowDialog(tMtxMulLinReg1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StatToolsDialogs.ShowDialog(tMtxHypothesisTest1);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tMtxMulLinReg1 = new Dew.Stats.TMtxMulLinReg(this.components);
            this.tMtxHypothesisTest1 = new Dew.Stats.TMtxHypothesisTest(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            // 
            // tMtxMulLinReg1
            // 
            this.tMtxMulLinReg1.Alpha = 0.05;
            this.tMtxMulLinReg1.AutoUpdate = false;
            this.tMtxMulLinReg1.Constant = true;
            this.tMtxMulLinReg1.Dirty = false;
            this.tMtxMulLinReg1.Name = "";
            this.tMtxMulLinReg1.Tag = null;
            this.tMtxMulLinReg1.UseWeights = false;
            // 
            // tMtxHypothesisTest1
            // 
            this.tMtxHypothesisTest1.Alpha = 0.05;
            this.tMtxHypothesisTest1.AutoUpdate = false;
            this.tMtxHypothesisTest1.Dirty = false;
            this.tMtxHypothesisTest1.HypothesisMethod = Dew.Stats.THypothesisMethod.hmZTest;
            this.tMtxHypothesisTest1.HypothesisType = Dew.Stats.THypothesisType.htTwoTailed;
            this.tMtxHypothesisTest1.Mean = 0;
            this.tMtxHypothesisTest1.Name = "";
            this.tMtxHypothesisTest1.Sigma = 1;
            this.tMtxHypothesisTest1.Tag = null;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(232, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Show tMtxMulLinReg editor";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 58);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(232, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Show tMtxHypothesisTest editor";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // DesignEditors
            // 
            this.ClientSize = new System.Drawing.Size(472, 445);
            this.Name = "DesignEditors";
            this.Load += new System.EventHandler(this.DesignRegEditor_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Dew.Stats.TMtxMulLinReg tMtxMulLinReg1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private Dew.Stats.TMtxHypothesisTest tMtxHypothesisTest1;


    }
}

