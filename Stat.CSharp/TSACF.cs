using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Dew.Math;
using Dew.Math.Units;
using Dew.Stats.Units;
using Dew.Math.Editors;
using static Dew.Math.Tee.TeeChart;

namespace StatsMasterDemo
{
    public class TSACF : StatsMasterDemo.BasicForm1
    {

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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Title.Font.Shadow.Visible = false;
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
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Left.Title.Font.Shadow.Visible = false;
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
        "TeeChart"};
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
            this.tChart1.Legend.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Panel.Gradient.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
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
            this.tChart1.AfterDraw += new Steema.TeeChart.PaintChartEventHandler(this.tChart1_AfterDraw);
            this.tChart1.BeforeDrawSeries += new Steema.TeeChart.PaintChartEventHandler(this.tChart1_BeforeDrawSeries);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(12, 121);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Edit data";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(12, 164);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 72);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Plot";
            // 
            // radioButton4
            // 
            this.radioButton4.Location = new System.Drawing.Point(74, 42);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(72, 17);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "PACF plot";
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(74, 19);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(65, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "ACF plot";
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(6, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(63, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Lag plot";
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(48, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Data";
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 252);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Lag";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(40, 250);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(60, 20);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 293);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Signif level (alpha)";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 309);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(88, 20);
            this.textBox1.TabIndex = 9;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // TSACF
            // 
            this.ClientSize = new System.Drawing.Size(672, 437);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "TSACF";
            this.Load += new System.EventHandler(this.TSACF_Load);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.numericUpDown1, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.tChart1, 0);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        
        public TSACF()
        {
            InitializeComponent();
            timeseries = new Vector(0);
            vacf = new Vector(0);
            vpacf = new Vector(0);
        }


        private Vector timeseries;
        private Vector vacf, vpacf;
        private double alpha = 0.05;
        private int chartindex;

        /// <summary>
        /// Generate specific chart, depending on index parameter
        /// </summary>
        private void GenerateChart(int index)
        {
            alpha = Convert.ToDouble(textBox1.Text); // for acf and pacf plots
            chartindex = index;

            tChart1.Series.Clear();
            tChart1.Axes.Bottom.Visible = true;
            TVec dx = null;
            TVec dy = null;
            switch (index)
            {
                case 0: // data plot
                    {
                        tChart1.Series.Add(new Steema.TeeChart.Styles.Line());
                        tChart1.Header.Text = "Data set";
                        tChart1.Axes.Left.Title.Text = "Y";
                        tChart1.Axes.Bottom.Title.Text = "";
                        tChart1.Axes.Left.Automatic = true;
                        dy = timeseries;
                    }; break;
                case 1: // lag plot
                    {
                        tChart1.Series.Add(new Steema.TeeChart.Styles.Points());
                        tChart1.Header.Text = "Lag plot";
                        tChart1.Axes.Left.Title.Text = "Y[i]";
                        tChart1.Axes.Bottom.Title.Text = "Y[i-1]";
                        tChart1.Axes.Left.Automatic = true;
                        vacf.Length = timeseries.Length -1;
                        vpacf.Length = timeseries.Length -1;
                        vacf.Copy(timeseries,0,0,vacf.Length);
                        vpacf.Copy(timeseries,1,0,vpacf.Length);
                        dx = vacf;
                        dy = vpacf;
                    }; break;
                case 2: // acf plot
                    {
                        StatTimeSerAnalysis.ACF(timeseries,vacf,(int)numericUpDown1.Value);
                        tChart1.Axes.Bottom.Visible = false;
                        tChart1.Series.Add(new Steema.TeeChart.Styles.Line());
                        tChart1.Header.Text = "Autocorellation plot";
                        tChart1.Axes.Left.Title.Text = "acf";
                        tChart1.Axes.Bottom.Title.Text = "lag";
                        tChart1.Axes.Left.Automatic = false;
                        tChart1.Axes.Left.SetMinMax(-1.0,1.0);
                        dy = vacf;
                    }; break;

                case 3: // pacf plot
                    {
                        StatTimeSerAnalysis.ACF(timeseries, vacf, (int)numericUpDown1.Value);
                        StatTimeSerAnalysis.PACF(vacf, vpacf);
                        tChart1.Axes.Bottom.Visible = false;
                        tChart1.Series.Add(new Steema.TeeChart.Styles.Line());
                        tChart1.Header.Text = "Partial autocorellation plot";
                        tChart1.Axes.Left.Title.Text = "pacf";
                        tChart1.Axes.Bottom.Title.Text = "lag";
                        tChart1.Axes.Left.Automatic = false;
                        tChart1.Axes.Left.SetMinMax(-1.0, 1.0);
                        dy = vpacf;
                    }; break;
            }

            if (dy != null)
            {
                if (dx != null) DrawValues(dx, dy, tChart1.Series[0], false);
                else DrawValues(dy, tChart1.Series[0], 0, 1, false);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MtxVecEdit.ViewValues(timeseries, "Time series", true, false, true);
        }

        private void TSACF_Load(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            Add("Data set in this example was collected by H. S. Lew of NIST in 1969 to measure "
                + "steel-concrete beam deflections. The response variable is the deflection of a "
                + "beam from the center point.\n");
            Add("In this example several plot techniques are used to check if sample data is "
                + "randomly distributed.");
            Add("[1] Data plot indicates indicates that the data do not have any significant "
                + "shifts in location or scale over time.");
            Add("[2] The lag plot shows that the data are not random. The lag plot further "
                + "indicates the presence of a few outliers.");
            Add("[3] When the randomness assumption is thus seriously violated, the histogram "
                + "can be ignored since determining the distribution of the data is only "
                + "meaningful when the data are random.");
            Add("[4] The autocorrelation plot shows a distinct cyclic pattern. As with the "
                +"lag plot, this suggests a sinusoidal model.");

            textBox1.Text = alpha.ToString("0.000");
            try
            {
                timeseries.LoadFromFile(Utils.ReadDemoPath() + @"Data\beam_deflection.vec");
            }
            catch
            {
                timeseries.Length = 200;
                timeseries.RandGauss();
            }
            numericUpDown1.Maximum = timeseries.Length;
            numericUpDown1.Value = timeseries.Length / 2;
            radioButton1.Checked = true;
            GenerateChart(0);

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (radioButton2.Checked) GenerateChart(1);
                else if (radioButton3.Checked) GenerateChart(2);
                else if (radioButton4.Checked) GenerateChart(3);
                else GenerateChart(0);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void tChart1_BeforeDrawSeries(object sender, Steema.TeeChart.Drawing.Graphics3D g)
        {
            if (!tChart1.Axes.Bottom.Visible)
            {
                int ypos = tChart1.Axes.Left.CalcYPosValue(0.0);
                tChart1.Axes.Bottom.Draw(ypos+5,ypos+15,ypos,true);
            }
        }

        private void tChart1_AfterDraw(object sender, Steema.TeeChart.Drawing.Graphics3D g)
        {
            if ((chartindex == 2) || (chartindex == 3))
            {
                double ci = (1.0-alpha);
                int ub, lb;
                if (chartindex == 2) // acf
                {
                    lb = tChart1.Axes.Left.CalcYPosValue(-Probabilities.NormalCDF(ci, 0, 1));
                    ub = tChart1.Axes.Left.CalcYPosValue(Probabilities.NormalCDF(ci, 0, 1));
                }
                else // pacf
                {
                    lb = tChart1.Axes.Left.CalcYPosValue(-2.0/Math.Sqrt(timeseries.Length));
                    ub = tChart1.Axes.Left.CalcYPosValue(2.0 / Math.Sqrt(timeseries.Length));
                }
                Rectangle r = tChart1.Chart.ChartRect;
                g.ClipRectangle(r);
                g.Pen.Color = Color.Blue;
                g.Font.Color = Color.Black;
                g.Line(r.Left,ub,r.Right,ub);
                g.Line(r.Left,lb,r.Right,lb);
                g.TextOut(r.Left+100,ub+2,ci.ToString("0.00%")+" confidence interval");
                g.TextOut(r.Left+100,lb-12,ci.ToString("0.00%")+" confidence interval");
                g.UnClip();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if ((chartindex == 2) || (chartindex == 3))
            {
                GenerateChart(chartindex);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if ((chartindex == 2) || (chartindex == 3))
            {
                GenerateChart(chartindex);
            }
        }
    }
}

