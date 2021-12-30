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
using static Dew.Math.Tee.MtxVecTee;

namespace StatsMasterDemo
{
    public class RModels : StatsMasterDemo.BasicForm1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RModels));
            this.points1 = new Steema.TeeChart.Styles.Points();
            this.line1 = new Steema.TeeChart.Styles.Line();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(672, 126);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Size = new System.Drawing.Size(672, 126);
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
        "Fitting models"};
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
            this.tChart1.Location = new System.Drawing.Point(282, 132);
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Panel.Gradient.SigmaFocus = 0.471F;
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
            this.tChart1.Series.Add(this.points1);
            this.tChart1.Series.Add(this.line1);
            this.tChart1.Size = new System.Drawing.Size(378, 166);
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
            // points1
            // 
            // 
            // 
            // 
            this.points1.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(77)))), ((int)(((byte)(0)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.points1.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.points1.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.points1.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.points1.Marks.Callout.Distance = 0;
            this.points1.Marks.Callout.Draw3D = false;
            this.points1.Marks.Callout.Length = 0;
            this.points1.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            // 
            // 
            // 
            this.points1.Marks.Font.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.points1.Pointer.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.points1.Pointer.Brush.ForegroundColor = System.Drawing.Color.Empty;
            this.points1.Pointer.Dark3D = false;
            this.points1.Pointer.Draw3D = false;
            this.points1.Pointer.HorizSize = 3;
            // 
            // 
            // 
            this.points1.Pointer.Pen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(77)))), ((int)(((byte)(0)))));
            this.points1.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Circle;
            this.points1.Pointer.VertSize = 3;
            this.points1.Pointer.Visible = true;
            this.points1.Title = "Data";
            // 
            // 
            // 
            this.points1.XValues.DataMember = "X";
            this.points1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.points1.YValues.DataMember = "Y";
            // 
            // line1
            // 
            // 
            // 
            // 
            this.line1.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.line1.ClickableLine = false;
            this.line1.ColorEachLine = false;
            this.line1.Dark3D = false;
            // 
            // 
            // 
            this.line1.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.line1.LinePen.Width = 2;
            // 
            // 
            // 
            // 
            // 
            // 
            this.line1.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.line1.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.line1.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.line1.Marks.Callout.Distance = 0;
            this.line1.Marks.Callout.Draw3D = false;
            this.line1.Marks.Callout.Length = 10;
            this.line1.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            // 
            // 
            // 
            this.line1.Marks.Font.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.line1.Pointer.Brush.Color = System.Drawing.Color.Green;
            this.line1.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.line1.Title = "Fitted";
            // 
            // 
            // 
            this.line1.XValues.DataMember = "X";
            this.line1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.line1.YValues.DataMember = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Fitted model";
            // 
            // comboBox1
            // 
            this.comboBox1.Items.AddRange(new object[] {
            "Simple exponential",
            "Simple linear",
            "Simple power",
            "Polynomial",
            "Rational",
            "Logistic",
            "Natural logarithm"});
            this.comboBox1.Location = new System.Drawing.Point(15, 160);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(165, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richTextBox2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.richTextBox2.Location = new System.Drawing.Point(0, 304);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(672, 133);
            this.richTextBox2.TabIndex = 6;
            this.richTextBox2.Text = "";
            // 
            // radioButton1
            // 
            this.radioButton1.Checked = true;
            this.radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton1.Location = new System.Drawing.Point(15, 201);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(66, 17);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Plot data";
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton2.Location = new System.Drawing.Point(15, 224);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(86, 17);
            this.radioButton2.TabIndex = 8;
            this.radioButton2.Text = "Plot residuals";
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(15, 258);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "X";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(82, 258);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(61, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Y";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // RModels
            // 
            this.ClientSize = new System.Drawing.Size(672, 437);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.comboBox1);
            this.Name = "RModels";
            this.Text = "Regression models";
            this.Load += new System.EventHandler(this.RModels_Load);
            this.Controls.SetChildIndex(this.comboBox1, 0);
            this.Controls.SetChildIndex(this.richTextBox2, 0);
            this.Controls.SetChildIndex(this.radioButton2, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.radioButton1, 0);
            this.Controls.SetChildIndex(this.tChart1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Steema.TeeChart.Styles.Points points1;
        private Steema.TeeChart.Styles.Line line1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;

        public RModels()
        {
            InitializeComponent();
            x = new Vector(0);
            y = new Vector(0);
            b = new Vector(0);
            yhat = new Vector(0);
            residuals = new Vector(0);
        }

        private Vector b, x, y, yhat, residuals;

        private void DoRegression(int index)
        {
            string st = "";
            switch (index)
            {
                // simple exponential model
                case 0: {
                    RegModels.ExpFit(b, x, y, null);
                    RegModels.ExpEval(b, x, yhat);
                    st = "y(x)= " + b.Values[0].ToString("(0.00)") + " * exp[" + b.Values[1].ToString("(0.00)") + " * x]\r\n\r\n";
                }; break;
                // simple linear model
                case 1: {
                    RegModels.LineFit(b, x, y, null);
                    RegModels.LineEval(b, x, yhat);
                    st = "y(x)=" + b.Values[0].ToString("(0.00)") + " + " + b.Values[1].ToString("(0.00)") + " * x\r\n\r\n";
                }; break;
                // simple power model
                case 2: {
                    RegModels.PowerFit(b, x, y, null);
                    RegModels.PowerEval(b, x, yhat);
                    st = "y(x)=" + b.Values[0].ToString("(0.00)") + " * x^[" + b.Values[1].ToString("(0.00)") + "]\r\n\r\n";
                }; break;
                // polynomial model
                case 3: {
                    int polydeg = Convert.ToInt16(InputBox.ShowInputBox("Polynomial fit","Enter polynomial degree","2"));
                    Polynoms.PolyFit(x, y, polydeg, b, null);
                    Polynoms.PolyEval(x, b, yhat);
                    st = "y(x)=";
                    for (int i=0; i<polydeg; i++)
                        st += b.Values[i].ToString("(0.00)")+"*x^"+(polydeg-i)+" + ";
                    st += b.Values[polydeg].ToString("(0.00)") + "\r\n\r\n";
                }; break;
                // rational function
                case 4: {
                    int nom = Convert.ToInt16(InputBox.ShowInputBox("Rational function fit", "Enter nominator polynomial degree", "2"));
                    int denom = Convert.ToInt16(InputBox.ShowInputBox("Rational function fit", "Enter denominator polynomial degree", "4"));
                    RegModels.FracFit(b, x, y, nom, denom, true, null);
                    RegModels.FracEval(b, x, yhat, nom, true);
                    st =  "\t";
                    for (int i=nom; i>0; i--)
                        st +=  b.Values[i].ToString("(0.00)")+" *x^"+i+" + ";
                    st += b.Values[0].ToString("(0.00)")+"\n";
                    st += "y(x)= -------------------------------------------------------\n\t";
                    if (denom>0)
                    {
                        for (int i=denom+nom; i>nom; i--)
                            st += b.Values[i].ToString("(0.00)")+" *x^"+(i-nom)+" + ";
                    } else st += " + ";
                    st += "(1.0)\r\n\r\n";
                }; break;
                // logistic model with constant term
                case 5: {
                    RegModels.LogisticFit(b, x, y, true, null);
                    RegModels.LogisticEval(b, x, yhat, true);
                    st =  "\t\t\t" + b.Values[1].ToString("(0.00)") + " - " + b.Values[0].ToString("(0.00)") + "\n";
                    st += "y(x)= " + b.Values[0].ToString("(0.00)") + " + ----------------------------------\n";
                    st += "\t\t\t 1.0 + exp[-" + b.Values[2].ToString("(0.00)") + " * x +" + b.Values[3].ToString("(0.00)") + "]\r\n\r\n";
                }; break;
                case 6:
                    RegModels.LnFit(b, x, y, null);
                    RegModels.LnEval(b, x, yhat);
                    st = "y(x)= " + b.Values[0].ToString("0.00") + " + " + b.Values[1].ToString("0.00") + "*Ln[x]\r\n\r\n";
                    break;
            }

            // Calculate residuals and RSS
            residuals.Sub(y, yhat);
            double RSS = residuals.SumOfSquares();
            st += "RSS=" + RSS.ToString("0.000");
            richTextBox2.Text = st;
        }
        private void PlotChart(bool plotres)
        {
			if (plotres) // plot residuals
            {
                points1.Active = false;
                DrawValues(x, residuals, line1, false);
            }
            else
            {
                points1.Active = true;
                DrawValues(x, y, points1, false);
                DrawValues(x, yhat, line1, false);
            }
        }
        
        private void RModels_Load(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            Add("Statistics includes several basic fitting models. The following "
                +"\"linear\" models are supported:\n");
            richTextBox1.SelectionBullet = true;
            richTextBox1.SelectionIndent = 10;
            Add("Simple exponential model : y=a*Exp[b*x]");
            Add("Simple linear mode : y=k*x+n');");
            Add("Simple power model: y=a*x^b");
            Add("Simple polynomial model : y=a[n]*x^n + a[n-1]*x^(n-1) + ... + a[1]*x + a[0]");
            Add("Rational function model: y=(p0 + p1.x + p2.x^2 + ...)/(1 + q1.x + q2.x^2 + ...)");
            Add("Logistic function model: y=A+(B-A)/(1+Exp(-a*x+b))");
            Add("Natural logarithm model: y=a+b*Ln(x)");
            richTextBox1.SelectionBullet = false;
            richTextBox1.SelectionIndent = 0;
            Add("These models are located in RegModels unit. You can easily add new models. "
                +"Using Stats Master routines you can construct new models.");
            Add("Click on \"X\" and \"Y\" buttons to change x and y values respectively.");
            Add("If you cannot linearize your model, you can try using tMtxNonLinReg component and "
                +"calculate model parameters by using several optimization methods (Marquardt, "
                +"several Quasi-Newton methods, Simplex, ...");

            try
            {
                x.LoadFromFile(Utils.ReadDemoPath() + @"Data\Fit_X.VEC");
                y.LoadFromFile(Utils.ReadDemoPath() + @"Data\Fit_Y.VEC");
            }
            catch
            {
                x.Size(20);
                y.Size(x);
                x.Ramp(0.3,0.1);
                y.RandUniform(0.1, 10);
            }
            comboBox1.SelectedIndex = 0;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoRegression(comboBox1.SelectedIndex);
            PlotChart(radioButton2.Checked);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            PlotChart(!radioButton1.Checked);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            PlotChart(radioButton2.Checked);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MtxVecEdit.ViewValues(x, "X values", true, false, true);
            DoRegression(comboBox1.SelectedIndex);
            PlotChart(radioButton2.Checked);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MtxVecEdit.ViewValues(y, "Y values", true, false, true);
            DoRegression(comboBox1.SelectedIndex);
            PlotChart(radioButton2.Checked);

        }
    }
}

