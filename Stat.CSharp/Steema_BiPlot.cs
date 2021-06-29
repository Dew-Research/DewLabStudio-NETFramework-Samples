using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Dew.Math.Units;
using Dew.Math;
using Dew.Stats;
using Dew.Stats.Units;
using Dew.Math.Editors;

namespace StatsMasterDemo
{
    public class Steema_BiPlot : StatsMasterDemo.BasicForm1
    {
        public Steema_BiPlot()
        {
            InitializeComponent();
            points1 = new Steema.TeeChart.Styles.Points(tChart1.Chart);
            points1.Title = "Scores";
            points1.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Diamond;
            
            biplot1 = new Dew.Stats.Tee.BiPlot(tChart1.Chart);
            biplot1.Title = "Coefficients";
            biplot1.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Circle;
            biplot1.Marks.Visible = true;
            biplot1.FilledArrows = true;
            biplot1.Marks.ShapeStyle = Steema.TeeChart.Drawing.TextShapeStyle.RoundRectangle;
        }

        private GroupBox groupBox1;
        private CheckBox checkBox1;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown1;
        private Label label2;
        private Label label1;
        private CheckBox checkBox2;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.tMtxPCA1 = new Dew.Stats.TMtxPCA(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // tChart1
            // 
            // 
            // 
            // 
            this.tChart1.Aspect.ElevationFloat = 345;
            this.tChart1.Aspect.RotationFloat = 345;
            this.tChart1.Aspect.View3D = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Automatic = true;
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Title.Caption = "Dimension 1";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Title.Font.Shadow.Visible = false;
            this.tChart1.Axes.Bottom.Title.Lines = new string[] {
        "Dimension 1"};
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Automatic = true;
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Automatic = true;
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Left.Automatic = true;
            // 
            // 
            // 
            this.tChart1.Axes.Left.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Left.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Left.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Left.Title.Caption = "Dimension 2";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Left.Title.Font.Shadow.Visible = false;
            this.tChart1.Axes.Left.Title.Lines = new string[] {
        "Dimension 2"};
            // 
            // 
            // 
            this.tChart1.Axes.Left.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Right.Automatic = true;
            // 
            // 
            // 
            this.tChart1.Axes.Right.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Right.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Right.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Right.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Right.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Top.Automatic = true;
            // 
            // 
            // 
            this.tChart1.Axes.Top.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Top.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Top.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Top.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Top.Title.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Footer.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Footer.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Header.Font.Shadow.Visible = false;
            this.tChart1.Header.Lines = new string[] {
        "Biplot example"};
            // 
            // 
            // 
            this.tChart1.Header.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Legend.Font.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Legend.Title.Font.Bold = true;
            // 
            // 
            // 
            this.tChart1.Legend.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Legend.Title.Pen.Visible = false;
            // 
            // 
            // 
            this.tChart1.Legend.Title.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Panel.Gradient.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tChart1.Panel.Gradient.Visible = true;
            // 
            // 
            // 
            this.tChart1.Panel.ImageBevel.Width = 1;
            // 
            // 
            // 
            this.tChart1.Panel.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.SubFooter.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.SubFooter.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.SubHeader.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.SubHeader.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Walls.Back.AutoHide = false;
            // 
            // 
            // 
            this.tChart1.Walls.Back.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Walls.Bottom.AutoHide = false;
            // 
            // 
            // 
            this.tChart1.Walls.Bottom.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Walls.Left.AutoHide = false;
            // 
            // 
            // 
            this.tChart1.Walls.Left.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Walls.Right.AutoHide = false;
            // 
            // 
            // 
            this.tChart1.Walls.Right.Shadow.Visible = false;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(12, 121);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "PDA data";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tMtxPCA1
            // 
            this.tMtxPCA1.AutoUpdate = false;
            this.tMtxPCA1.Dirty = false;
            this.tMtxPCA1.Name = "";
            this.tMtxPCA1.PCAMode = Dew.Stats.TPCAMode.PCACorrMat;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.numericUpDown2);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 163);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 128);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Biplot settings";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(80, 76);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(64, 20);
            this.numericUpDown2.TabIndex = 4;
            this.numericUpDown2.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(80, 51);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(64, 20);
            this.numericUpDown1.TabIndex = 3;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Arrow height";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Arrow width";
            // 
            // checkBox1
            // 
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(6, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(87, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Show arrows";
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(6, 102);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(87, 17);
            this.checkBox2.TabIndex = 5;
            this.checkBox2.Text = "Filled arrows";
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // Steema_BiPlot
            // 
            this.ClientSize = new System.Drawing.Size(672, 437);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Steema_BiPlot";
            this.Load += new System.EventHandler(this.Steema_BiPlot_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.tChart1, 0);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private Dew.Stats.TMtxPCA tMtxPCA1;

        private Steema.TeeChart.Styles.Points points1;
        private Dew.Stats.Tee.BiPlot biplot1;

        private void PopulateSeries()
        {
            tMtxPCA1.Recalc();
            points1.Clear();
            biplot1.Clear();
            biplot1.GetHorizAxis.Labels.Style = Steema.TeeChart.AxisLabelStyle.Value;
            // plot scores - regular point series
            for (int i = 0; i < tMtxPCA1.ZScores.Rows; i++)
                points1.Add(tMtxPCA1.ZScores.Values[i, 0], tMtxPCA1.ZScores.Values[i, 1]);
            // plot eigevectors (2d subspace)
            for (int i = 0; i < tMtxPCA1.PC.Cols; i++)
                biplot1.Add(tMtxPCA1.PC.Values[0,i], tMtxPCA1.PC.Values[1,i],i.ToString());
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            MtxVecEdit.ViewValues(tMtxPCA1.Data,"PCA data",true,false,true);
            PopulateSeries();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            biplot1.DrawArrows = checkBox1.Checked;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            biplot1.ArrowWidth = (int)numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            biplot1.ArrowHeight = (int)numericUpDown2.Value;
        }

        private void Steema_BiPlot_Load(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            Add("Biplots are statistical graphics that represent in the same plane both the variables "
                +" and the cases. Usually variables are represented by arrows, while points represent cases.");
            Add("In this example the famous Fisher Iris data is used in Principal Component Analysis.");

            // Fisher Iris data
            try
            {
                tMtxPCA1.Data.LoadFromFile(Utils.ReadDemoPath() + @"Data\FisherIris.mtx");
            }
            catch
            {
                tMtxPCA1.Data.Size(30, 4);
                tMtxPCA1.Data.RandGauss();
            }
            PopulateSeries();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            biplot1.FilledArrows = checkBox2.Checked;
        }
    }
}

