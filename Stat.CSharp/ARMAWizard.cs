using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Dew.Math;
using Dew.Math.Units;
using Dew.Stats;
using Dew.Stats.Units;
using Dew.Math.Editors;
using static Dew.Math.Tee.MtxVecTee;


namespace StatsMasterDemo
{
    public class ARMAWizard : StatsMasterDemo.BaseStatWizard
    {

        private Vector timeseries;
        private Vector data;
        private Vector residuals;
        private Vector forecasts;
        private Vector forecastsd;
        private Vector phi, phiInit;
        private Vector theta, thetaInit;
        private int p = 0;
        private int q = 0;
        private int d = 0;
        private int forper = 10;
        private int maxLag = -1;
        private double dMean;
        private double chartlcl, chartucl;
        private OpenFileDialog openFileDialog1;
        private Dew.Math.Controls.WizardPage wizardPageForecasts;
        private Dew.Math.Controls.WizardPage wizardPageModel;
        private Dew.Math.Controls.WizardPage wizardPageTimeSeries;
        private GroupBox groupBox5;
        private RadioButton radioButtonPACF;
        private RadioButton radioButtonACF;
        private RadioButton radioButtonTS;
        private GroupBox groupBox4;
        private Label labelTrStat;
        private GroupBox groupBox3;
        private Label labelUnTrStat;
        private Steema.TeeChart.TChart tChartData;
        private GroupBox groupBox6;
        private NumericUpDown numericUpDownDiff;
        private Label label6;
        private CheckBox checkBoxRemoveMean;
        private Button buttonLoad;
        private Steema.TeeChart.Styles.Line line1;
        private GroupBox groupBoxInitMA;
        private ComboBox comboBox2;
        private GroupBox groupBoxEditPhiTheta;
        private Label label8;
        private Button buttonEditMA;
        private Button buttonEditAR;
        private GroupBox groupBox7;
        private GroupBox groupBox8;
        private Label label7;
        private Label label9;
        private ComboBox comboBox1;
        private GroupBox groupBox9;
        private ComboBox comboBox3;
        private GroupBox groupBox10;
        private Label label10;
        private Button button1;
        private Button button2;
        private GroupBox groupBox11;
        private CheckBox checkBoxMLE;
        private GroupBox groupBox12;
        private NumericUpDown numericUpDown1;
        private Label label11;
        private NumericUpDown numericUpDown2;
        private Label label12;
        private GroupBox groupBox13;
        private CheckBox checkBoxIntegrate;
        private CheckBox checkBoxAddMean;
        private NumericUpDown numericUpDownACFLag;
        private Label label13;
        private NumericUpDown numericUpDownForNum;
        private Label label14;
        private GroupBox groupBox2;
        private ComboBox comboBox4;
        private TcfInitMethod armainit = TcfInitMethod.cfInitFixed;

        public ARMAWizard()
        {
            InitializeComponent();
            timeseries = new Vector(0);
            data = new Vector(0);
            residuals = new Vector(0);
            forecasts = new Vector(0);
            forecastsd = new Vector(0);
            phi = new Vector(0);
            theta = new Vector(0);

            phiInit = new Vector(0);
            thetaInit = new Vector(0);

            openFileDialog1.Filter = "vectors (*.vec)|*.vec";

            // Reposition ARMA wizard pages
            wizard.Pages.Remove(wizardPageTimeSeries);
            wizard.Pages.Remove(wizardPageModel);
            wizard.Pages.Remove(wizardPageForecasts);
            wizard.Pages.Insert(1, wizardPageForecasts);
            wizard.Pages.Insert(1, wizardPageModel);
            wizard.Pages.Insert(1, wizardPageTimeSeries);
        }
        #region Reports

        private void TextReport()
        {
            richTextBox.SuspendLayout();
            wizard.NextEnabled = false;
            wizard.BackEnabled = false;

            TransformTimeSeries();

            if (armainit == TcfInitMethod.cfInitFixed)
            {
                phi.Copy(phiInit);
                theta.Copy(thetaInit);
            }
            else
            {
                phi.Size(p);
                phi.SetZero();

                theta.Size(q);
                theta.SetZero();
            }

            this.Cursor = Cursors.WaitCursor;
            try
            {
                richTextBox.Clear();

                progressBar.Value = 0;
                InitEstimateReport();

                progressBar.Value = 40;
                if (checkBoxMLE.Checked) MLEReport();

                progressBar.Value = 70;
                ForecastReport();

                progressBar.Value = 100;
                richTextBox.SelectionStart = 0;
            }
            finally
            {
                wizard.BackEnabled = true;
                richTextBox.ResumeLayout();
                this.Cursor = Cursors.Default;
            }

        }

        /// <summary>
        /// Check if model is causal and invertible
        /// </summary>
        private string CausalReport()
        {
            string result = "";
            if (p > 0)
                if (StatTimeSerAnalysis.CheckARMACoeffs(phi, true)) result += "Model causal\n"; else result += "Model not causal\n";

            if (q > 0)
                if (StatTimeSerAnalysis.CheckARMACoeffs(theta, false)) result += "Model invertible\n"; else result += "Model not invertible\n";
            return result;
        }

        private string CoeffReport(Vector coeff, string ccaption)
        {
            string result = "";
            for (int i = 0; i < coeff.Length; i++)
                result += ccaption + "[" + (i + 1) + "]" + "\t" + Math387.FormatSample(FmtString, coeff.Values[i]) + "\n";
            return result;
        }

        private string CoeffReport(Vector coeff, Vector cstderr, string ccaption)
        {
            Vector tvals = new Vector(0);
            Vector pvals = new Vector(0);
            string result = "";

            // Calculate t values
            // This is the t-test value for testing the hypothesis that j = 0 versus 
            // the alternative that after removing the influence of all other X's. 
            // The degrees of freedom is equal to the N minus the number of model parameters and differences.
            tvals = coeff / cstderr;

            // calculate p values
            // The p-value is the probability that above T-statistic will take on a value 
            // at least as extreme as the actually observed value, assuming that the null hypothesis
            // is true (i.e., the regression estimate is equal to zero). If the p-value is less than
            // alpha, say 0.05, the null hypothesis is rejected. 
            // This p-value is for a two-tail test.
            int df = data.Length - p - q - d;
            Probabilities.StudentCDF(tvals, df, pvals);
            for (int i = 0; i < pvals.Length; i++)
                pvals.Values[i] = 2.0 * Math387.Min(pvals.Values[i], 1.0 - pvals.Values[i]);
            for (int i = 0; i < coeff.Length; i++)
            {
                result += ccaption + "[" + (i + 1) + "]" + "\t" + Math387.FormatSample(FmtString, coeff.Values[i]) + "\t";
                result += Math387.FormatSample(FmtString, cstderr.Values[i]) + "\t";
                result += Math387.FormatSample(FmtString, tvals.Values[i]) + "\t";
                result += Math387.FormatSample(FmtString, pvals.Values[i]) + "\n";
            }
            return result;
        }

        private void InitEstimateReport()
        {
            int innoLag;

            richTextBox.SelectionFont = new Font(richTextBox.SelectionFont.FontFamily, 10, FontStyle.Underline);
            richTextBox.SelectedText = "Preliminary estimates for coefficients\n\n";

            if (maxLag < 0)
            {
                innoLag = (int)Math387.Ceil(10 * Math.Log10(data.Length));
            }
            else
            {
                innoLag = maxLag;
            }

            Vector d1 = new Vector(0);
            Vector d2 = new Vector(0);
            if (p > 0)
            {
                d1.Size(phi);
                d1.SetZero();
            }
            if (q > 0)
            {
                d2.Size(theta);
                d2.SetZero();
            }

            double estvar = 1.0;
            double zval = Probabilities.NormalCDFInv(1.0 - 0.5 * Alpha, 0, 1);
            // Retrieve coefficients
            switch (armainit)
            {
                case TcfInitMethod.cfInitYW:
                    {
                        StatTimeSerAnalysis.ARYuleWalkerFit(data, phi, out estvar, d1);
                        richTextBox.SelectedText = "Method used: Yule-Walker\n";
                    }; break;
                case TcfInitMethod.cfInitBurg:
                    {
                        StatTimeSerAnalysis.ARBurgFit(data, phi, out estvar, d1); 
                        richTextBox.SelectedText = "Method used: Burg\n";
                    }; break;
                case TcfInitMethod.cfInitInno:
                    {
                        if (p == 0) StatTimeSerAnalysis.ARMAInnovationsFit(data, theta, out estvar, d2, innoLag);
                        else StatTimeSerAnalysis.ARMAInnovationsFit(data, phi, theta, out estvar, d1, d2, innoLag);
                        richTextBox.SelectedText = "Method used: Innovations with " + innoLag.ToString() + " lags\n";
                    }; break;
                case TcfInitMethod.cfInitHannah:
                    {
                        StatTimeSerAnalysis.ARMAHannahFit(data, phi, theta, out estvar);
                        richTextBox.SelectedText = "Method used: Hannah\n";
                    }; break;
            }
            if (armainit != TcfInitMethod.cfInitFixed)
            {
                richTextBox.SelectedText = "Estimated WN variance: " + Math387.FormatSample(FmtString, estvar) + "\n";
            }

            richTextBox.SelectedText = CausalReport() + "\n";

            SetupTabs(richTextBox, 5);
            richTextBox.SelectedText = "Model coefficients:\n";
            richTextBox.SelectionColor = Color.Blue;
            richTextBox.SelectedText = "Coefficient\tCoefficient\tStandard\tT-value\tP-value\nname\testimate\terror\tHo:Coef.=0\t\n";
            if (p > 0) richTextBox.SelectedText = CoeffReport(phi, d1, "AR");
            if (q > 0) richTextBox.SelectedText = CoeffReport(theta, d2, "MA");
            richTextBox.SelectedText = "\n";
        }

        private void MLEReport()
        {
            richTextBox.SelectionFont = new Font(richTextBox.SelectionFont.FontFamily, 10, FontStyle.Underline);
            richTextBox.SelectedText = "MLE estimates for coefficients\n\n";
            double mle = 0.0;
            string st = "";

            // estimate by using initial value from InitEstimateReport() routine 
            int iters = StatTimeSerAnalysis.ARMAMLE(data, phi, theta, residuals, out mle, out dMean);

            st = "Number of iterations needed: " + iters.ToString() + "\n";
            st += "-2log(likelihood): " + Math387.FormatSample(FmtString, mle) + "\n";
            st += CausalReport() + "\n";
            richTextBox.SelectedText = st;

            SetupTabs(richTextBox, 2);
            richTextBox.SelectedText = "Model coefficients:\n";
            richTextBox.SelectionColor = Color.Blue;
            richTextBox.SelectedText = "Coefficient\tCoefficient\n";
            if (p > 0) richTextBox.SelectedText = CoeffReport(phi, "AR");
            if (q > 0) richTextBox.SelectedText = CoeffReport(theta, "MA");
            richTextBox.SelectedText = "\n";
        }

        private void ForecastReport()
        {
            richTextBox.SelectionFont = new Font(richTextBox.SelectionFont.FontFamily, 10, FontStyle.Underline);
            richTextBox.SelectedText = "Forecasting " + forper.ToString() + " points\n\n";
            this.Cursor = Cursors.WaitCursor;
            int endperiod;
            string st = "";
            try
            {
                StatTimeSerAnalysis.ARMAForecast(data, phi, theta, residuals, forper, dMean, forecasts, forecastsd);

                // integrate, if required
                if ((d > 0) && (checkBoxIntegrate.Checked))
                {
                    Vector v0 = new Vector(0);
                    // setup initial values for integration
                    StatTimeSerAnalysis.TimeSeriesIntInit(timeseries, v0, d, true);
                    // integrate d times
                    forecasts.Integrate(v0);
                    endperiod = data.Length + d - 1;
                }
                else endperiod = data.Length - 1;

                SetupTabs(richTextBox, 3);
                richTextBox.SelectionColor = Color.Blue;
                richTextBox.SelectedText = "Period\tForecast\tForecast std.dev\n";
                for (int i = 1; i <= forper; i++)
                {
                    st += i + endperiod + "\t" + Math387.FormatSample(FmtString, forecasts.Values[i - 1]) + "\t";
                    st += Math387.FormatSample(FmtString, forecastsd.Values[i - 1]) + "\n";
                }
                richTextBox.SelectedText = st + "\n";

                // Forecasts chart
                int offset;
                Chart.Series.Clear();
                Chart.Aspect.View3D = false;
                Chart.Legend.Visible = false;
                Chart.Axes.Left.Automatic = true;
                Vector v1 = new Vector(0);
                Vector v2 = new Vector(0);
                Chart.Axes.Bottom.Visible = true;
                Chart.Legend.Visible = true;
                // original time series
                Chart.Series.Add(new Steema.TeeChart.Styles.Line());
                Chart.Series[0].Title = "Time series";
                // forecasts
                Chart.Series.Add(new Steema.TeeChart.Styles.Line());
                Chart.Series[1].Title = "Forecasts";
                // ucl,lcl
                Chart.Series.Add(new Steema.TeeChart.Styles.Line());
                Chart.Series.Add(new Steema.TeeChart.Styles.Line());
                Chart.Series[2].Title = "CI";
                Chart.Series[2].Color = Color.Black;
                Chart.Series[3].Color = Color.Black;
                Chart.Series[3].Legend.Visible = false;
                v1.Copy(data);

                // integrate, if required
                if ((d > 0) && (checkBoxIntegrate.Checked))
                {
                    StatTimeSerAnalysis.TimeSeriesIntInit(timeseries, v2, d, false);
                    v1.Integrate(v2);
                    DrawValues(v1, Chart.Series[0], d, 1, false);
                    offset = v1.Length + d;
                }
                else
                {
                    DrawValues(v1, Chart.Series[0], 0, 1, false);
                    offset = v1.Length;
                }
                // forecasts
                DrawValues(forecasts, Chart.Series[1], offset, 1, false);
                v1.Size(forecasts);
                v2.Size(v1);
                // 1.0-Alpha CI
                for (int i = 0; i < v1.Length; i++)
                {
                    v1.Values[i] = Probabilities.NormalCDFInv(0.5 *Alpha, forecasts.Values[i], forecastsd.Values[i]);
                    v2.Values[i] = Probabilities.NormalCDFInv(1.0 - 0.5 * Alpha, forecasts.Values[i], forecastsd.Values[i]);
                }
                DrawValues(v1, Chart.Series[2], offset, 1, false);
                DrawValues(v2, Chart.Series[3], offset, 1, false);
                Chart.Header.Text = "Forecasting up to " + forecasts.Length.ToString() + " points.";
                CopyToRichBox(richTextBox);
                richTextBox.SelectedText = "\n";


            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        #endregion

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
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.wizardPageTimeSeries = new Dew.Math.Controls.WizardPage();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.radioButtonPACF = new System.Windows.Forms.RadioButton();
			this.radioButtonACF = new System.Windows.Forms.RadioButton();
			this.radioButtonTS = new System.Windows.Forms.RadioButton();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.labelTrStat = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.labelUnTrStat = new System.Windows.Forms.Label();
			this.tChartData = new Steema.TeeChart.TChart();
			this.line1 = new Steema.TeeChart.Styles.Line();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.numericUpDownDiff = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.checkBoxRemoveMean = new System.Windows.Forms.CheckBox();
			this.buttonLoad = new System.Windows.Forms.Button();
			this.wizardPageModel = new Dew.Math.Controls.WizardPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.comboBox4 = new System.Windows.Forms.ComboBox();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.label10 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox11 = new System.Windows.Forms.GroupBox();
			this.checkBoxMLE = new System.Windows.Forms.CheckBox();
			this.groupBox12 = new System.Windows.Forms.GroupBox();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label11 = new System.Windows.Forms.Label();
			this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			this.label12 = new System.Windows.Forms.Label();
			this.wizardPageForecasts = new Dew.Math.Controls.WizardPage();
			this.groupBox13 = new System.Windows.Forms.GroupBox();
			this.checkBoxIntegrate = new System.Windows.Forms.CheckBox();
			this.checkBoxAddMean = new System.Windows.Forms.CheckBox();
			this.numericUpDownACFLag = new System.Windows.Forms.NumericUpDown();
			this.label13 = new System.Windows.Forms.Label();
			this.numericUpDownForNum = new System.Windows.Forms.NumericUpDown();
			this.label14 = new System.Windows.Forms.Label();
			this.groupBoxInitMA = new System.Windows.Forms.GroupBox();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.groupBoxEditPhiTheta = new System.Windows.Forms.GroupBox();
			this.label8 = new System.Windows.Forms.Label();
			this.buttonEditMA = new System.Windows.Forms.Button();
			this.buttonEditAR = new System.Windows.Forms.Button();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.wizard.SuspendLayout();
			this.wizardPageReport.SuspendLayout();
			this.wizardPageTimeSeries.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownDiff)).BeginInit();
			this.wizardPageModel.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.groupBox10.SuspendLayout();
			this.groupBox11.SuspendLayout();
			this.groupBox12.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
			this.wizardPageForecasts.SuspendLayout();
			this.groupBox13.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownACFLag)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownForNum)).BeginInit();
			this.groupBoxInitMA.SuspendLayout();
			this.groupBoxEditPhiTheta.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.SuspendLayout();
			// 
			// wizard
			// 
			this.wizard.Controls.Add(this.wizardPageTimeSeries);
			this.wizard.Controls.Add(this.wizardPageModel);
			this.wizard.Controls.Add(this.wizardPageForecasts);
			this.wizard.Name = "wizard";
			this.wizard.Pages.AddRange(new Dew.Math.Controls.WizardPage[] {
																			  this.wizardPageTimeSeries,
																			  this.wizardPageModel,
																			  this.wizardPageForecasts});
			this.wizard.Size = new System.Drawing.Size(626, 471);
			this.wizard.AfterSwitchPages += new Dew.Math.Controls.Wizard.AfterSwitchPagesEventHandler(this.wizard_AfterSwitchPages);
			this.wizard.Controls.SetChildIndex(this.wizardPageWelcome, 0);
			this.wizard.Controls.SetChildIndex(this.wizardPageFormat, 0);
			this.wizard.Controls.SetChildIndex(this.wizardPageReport, 0);
			this.wizard.Controls.SetChildIndex(this.wizardPageForecasts, 0);
			this.wizard.Controls.SetChildIndex(this.wizardPageModel, 0);
			this.wizard.Controls.SetChildIndex(this.wizardPageTimeSeries, 0);
			// 
			// wizardPageReport
			// 
			this.wizardPageReport.Name = "wizardPageReport";
			this.wizardPageReport.Size = new System.Drawing.Size(626, 431);
			this.wizardPageReport.Title = "ARMA : Report";
			// 
			// richTextBox
			// 
			this.richTextBox.Name = "richTextBox";
			this.richTextBox.Size = new System.Drawing.Size(599, 292);
			// 
			// progressBar
			// 
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(545, 13);
			// 
			// wizardPageFormat
			// 
			this.wizardPageFormat.Description = "Define ARMA Report output options";
			this.wizardPageFormat.Name = "wizardPageFormat";
			this.wizardPageFormat.Size = new System.Drawing.Size(626, 431);
			this.wizardPageFormat.Title = "Step 4: Report options";
			// 
			// wizardPageWelcome
			// 
			this.wizardPageWelcome.Name = "wizardPageWelcome";
			// 
			// textBoxAlpha
			// 
			this.textBoxAlpha.Name = "textBoxAlpha";
			this.textBoxAlpha.TextChanged += new System.EventHandler(this.textBoxAlpha_TextChanged);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// wizardPageTimeSeries
			// 
			this.wizardPageTimeSeries.Controls.Add(this.groupBox5);
			this.wizardPageTimeSeries.Controls.Add(this.groupBox4);
			this.wizardPageTimeSeries.Controls.Add(this.groupBox3);
			this.wizardPageTimeSeries.Controls.Add(this.tChartData);
			this.wizardPageTimeSeries.Controls.Add(this.groupBox6);
			this.wizardPageTimeSeries.Description = "Define transformation applied to time series prior to ARMA";
			this.wizardPageTimeSeries.Location = new System.Drawing.Point(0, 0);
			this.wizardPageTimeSeries.Name = "wizardPageTimeSeries";
			this.wizardPageTimeSeries.Size = new System.Drawing.Size(626, 423);
			this.wizardPageTimeSeries.TabIndex = 13;
			this.wizardPageTimeSeries.Title = "Step 1: Define time series";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.radioButtonPACF);
			this.groupBox5.Controls.Add(this.radioButtonACF);
			this.groupBox5.Controls.Add(this.radioButtonTS);
			this.groupBox5.Location = new System.Drawing.Point(199, 83);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(178, 95);
			this.groupBox5.TabIndex = 17;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Plot";
			// 
			// radioButtonPACF
			// 
			this.radioButtonPACF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.radioButtonPACF.Location = new System.Drawing.Point(11, 66);
			this.radioButtonPACF.Name = "radioButtonPACF";
			this.radioButtonPACF.Size = new System.Drawing.Size(139, 17);
			this.radioButtonPACF.TabIndex = 2;
			this.radioButtonPACF.Text = "Time series PACF";
			this.radioButtonPACF.CheckedChanged += new System.EventHandler(this.radioButtonTS_CheckedChanged);
			// 
			// radioButtonACF
			// 
			this.radioButtonACF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.radioButtonACF.Location = new System.Drawing.Point(11, 43);
			this.radioButtonACF.Name = "radioButtonACF";
			this.radioButtonACF.Size = new System.Drawing.Size(139, 17);
			this.radioButtonACF.TabIndex = 1;
			this.radioButtonACF.Text = "Time series ACF";
			this.radioButtonACF.CheckedChanged += new System.EventHandler(this.radioButtonTS_CheckedChanged);
			// 
			// radioButtonTS
			// 
			this.radioButtonTS.Checked = true;
			this.radioButtonTS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.radioButtonTS.Location = new System.Drawing.Point(11, 20);
			this.radioButtonTS.Name = "radioButtonTS";
			this.radioButtonTS.Size = new System.Drawing.Size(139, 17);
			this.radioButtonTS.TabIndex = 0;
			this.radioButtonTS.TabStop = true;
			this.radioButtonTS.Text = "Time series";
			this.radioButtonTS.CheckedChanged += new System.EventHandler(this.radioButtonTS_CheckedChanged);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.labelTrStat);
			this.groupBox4.Location = new System.Drawing.Point(196, 201);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(183, 95);
			this.groupBox4.TabIndex = 16;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Transformed series statistics";
			// 
			// labelTrStat
			// 
			this.labelTrStat.Location = new System.Drawing.Point(11, 27);
			this.labelTrStat.Name = "labelTrStat";
			this.labelTrStat.Size = new System.Drawing.Size(157, 58);
			this.labelTrStat.TabIndex = 0;
			this.labelTrStat.Text = "label2";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.labelUnTrStat);
			this.groupBox3.Location = new System.Drawing.Point(10, 201);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(183, 94);
			this.groupBox3.TabIndex = 15;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Untransformed series statistics";
			// 
			// labelUnTrStat
			// 
			this.labelUnTrStat.Location = new System.Drawing.Point(8, 21);
			this.labelUnTrStat.Name = "labelUnTrStat";
			this.labelUnTrStat.Size = new System.Drawing.Size(168, 57);
			this.labelUnTrStat.TabIndex = 0;
			this.labelUnTrStat.Text = "label2";
			// 
			// tChartData
			// 
			this.tChartData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			// 
			// tChartData.Aspect
			// 
			this.tChartData.Aspect.ElevationFloat = 345;
			this.tChartData.Aspect.RotationFloat = 345;
			this.tChartData.Aspect.View3D = false;
			// 
			// tChartData.Axes
			// 
			// 
			// tChartData.Axes.Bottom
			// 
			this.tChartData.Axes.Bottom.Automatic = true;
			// 
			// tChartData.Axes.Bottom.Grid
			// 
			this.tChartData.Axes.Bottom.Grid.ZPosition = 0;
			// 
			// tChartData.Axes.Bottom.Labels
			// 
			// 
			// tChartData.Axes.Bottom.Labels.Font
			// 
			// 
			// tChartData.Axes.Bottom.Labels.Font.Shadow
			// 
			this.tChartData.Axes.Bottom.Labels.Font.Shadow.Visible = false;
			// 
			// tChartData.Axes.Bottom.Labels.Shadow
			// 
			this.tChartData.Axes.Bottom.Labels.Shadow.Visible = false;
			// 
			// tChartData.Axes.Bottom.Title
			// 
			// 
			// tChartData.Axes.Bottom.Title.Font
			// 
			// 
			// tChartData.Axes.Bottom.Title.Font.Shadow
			// 
			this.tChartData.Axes.Bottom.Title.Font.Shadow.Visible = false;
			// 
			// tChartData.Axes.Bottom.Title.Shadow
			// 
			this.tChartData.Axes.Bottom.Title.Shadow.Visible = false;
			// 
			// tChartData.Axes.Depth
			// 
			this.tChartData.Axes.Depth.Automatic = true;
			// 
			// tChartData.Axes.Depth.Grid
			// 
			this.tChartData.Axes.Depth.Grid.ZPosition = 0;
			// 
			// tChartData.Axes.Depth.Labels
			// 
			// 
			// tChartData.Axes.Depth.Labels.Font
			// 
			// 
			// tChartData.Axes.Depth.Labels.Font.Shadow
			// 
			this.tChartData.Axes.Depth.Labels.Font.Shadow.Visible = false;
			// 
			// tChartData.Axes.Depth.Labels.Shadow
			// 
			this.tChartData.Axes.Depth.Labels.Shadow.Visible = false;
			// 
			// tChartData.Axes.Depth.Title
			// 
			// 
			// tChartData.Axes.Depth.Title.Font
			// 
			// 
			// tChartData.Axes.Depth.Title.Font.Shadow
			// 
			this.tChartData.Axes.Depth.Title.Font.Shadow.Visible = false;
			// 
			// tChartData.Axes.Depth.Title.Shadow
			// 
			this.tChartData.Axes.Depth.Title.Shadow.Visible = false;
			// 
			// tChartData.Axes.DepthTop
			// 
			this.tChartData.Axes.DepthTop.Automatic = true;
			// 
			// tChartData.Axes.DepthTop.Grid
			// 
			this.tChartData.Axes.DepthTop.Grid.ZPosition = 0;
			// 
			// tChartData.Axes.DepthTop.Labels
			// 
			// 
			// tChartData.Axes.DepthTop.Labels.Font
			// 
			// 
			// tChartData.Axes.DepthTop.Labels.Font.Shadow
			// 
			this.tChartData.Axes.DepthTop.Labels.Font.Shadow.Visible = false;
			// 
			// tChartData.Axes.DepthTop.Labels.Shadow
			// 
			this.tChartData.Axes.DepthTop.Labels.Shadow.Visible = false;
			// 
			// tChartData.Axes.DepthTop.Title
			// 
			// 
			// tChartData.Axes.DepthTop.Title.Font
			// 
			// 
			// tChartData.Axes.DepthTop.Title.Font.Shadow
			// 
			this.tChartData.Axes.DepthTop.Title.Font.Shadow.Visible = false;
			// 
			// tChartData.Axes.DepthTop.Title.Shadow
			// 
			this.tChartData.Axes.DepthTop.Title.Shadow.Visible = false;
			// 
			// tChartData.Axes.Left
			// 
			this.tChartData.Axes.Left.Automatic = true;
			// 
			// tChartData.Axes.Left.Grid
			// 
			this.tChartData.Axes.Left.Grid.ZPosition = 0;
			// 
			// tChartData.Axes.Left.Labels
			// 
			// 
			// tChartData.Axes.Left.Labels.Font
			// 
			// 
			// tChartData.Axes.Left.Labels.Font.Shadow
			// 
			this.tChartData.Axes.Left.Labels.Font.Shadow.Visible = false;
			// 
			// tChartData.Axes.Left.Labels.Shadow
			// 
			this.tChartData.Axes.Left.Labels.Shadow.Visible = false;
			// 
			// tChartData.Axes.Left.Title
			// 
			// 
			// tChartData.Axes.Left.Title.Font
			// 
			// 
			// tChartData.Axes.Left.Title.Font.Shadow
			// 
			this.tChartData.Axes.Left.Title.Font.Shadow.Visible = false;
			// 
			// tChartData.Axes.Left.Title.Shadow
			// 
			this.tChartData.Axes.Left.Title.Shadow.Visible = false;
			// 
			// tChartData.Axes.Right
			// 
			this.tChartData.Axes.Right.Automatic = true;
			// 
			// tChartData.Axes.Right.Grid
			// 
			this.tChartData.Axes.Right.Grid.ZPosition = 0;
			// 
			// tChartData.Axes.Right.Labels
			// 
			// 
			// tChartData.Axes.Right.Labels.Font
			// 
			// 
			// tChartData.Axes.Right.Labels.Font.Shadow
			// 
			this.tChartData.Axes.Right.Labels.Font.Shadow.Visible = false;
			// 
			// tChartData.Axes.Right.Labels.Shadow
			// 
			this.tChartData.Axes.Right.Labels.Shadow.Visible = false;
			// 
			// tChartData.Axes.Right.Title
			// 
			// 
			// tChartData.Axes.Right.Title.Font
			// 
			// 
			// tChartData.Axes.Right.Title.Font.Shadow
			// 
			this.tChartData.Axes.Right.Title.Font.Shadow.Visible = false;
			// 
			// tChartData.Axes.Right.Title.Shadow
			// 
			this.tChartData.Axes.Right.Title.Shadow.Visible = false;
			// 
			// tChartData.Axes.Top
			// 
			this.tChartData.Axes.Top.Automatic = true;
			// 
			// tChartData.Axes.Top.Grid
			// 
			this.tChartData.Axes.Top.Grid.ZPosition = 0;
			// 
			// tChartData.Axes.Top.Labels
			// 
			// 
			// tChartData.Axes.Top.Labels.Font
			// 
			// 
			// tChartData.Axes.Top.Labels.Font.Shadow
			// 
			this.tChartData.Axes.Top.Labels.Font.Shadow.Visible = false;
			// 
			// tChartData.Axes.Top.Labels.Shadow
			// 
			this.tChartData.Axes.Top.Labels.Shadow.Visible = false;
			// 
			// tChartData.Axes.Top.Title
			// 
			// 
			// tChartData.Axes.Top.Title.Font
			// 
			// 
			// tChartData.Axes.Top.Title.Font.Shadow
			// 
			this.tChartData.Axes.Top.Title.Font.Shadow.Visible = false;
			// 
			// tChartData.Axes.Top.Title.Shadow
			// 
			this.tChartData.Axes.Top.Title.Shadow.Visible = false;
			this.tChartData.BackColor = System.Drawing.Color.Transparent;
			// 
			// tChartData.Footer
			// 
			// 
			// tChartData.Footer.Font
			// 
			// 
			// tChartData.Footer.Font.Shadow
			// 
			this.tChartData.Footer.Font.Shadow.Visible = false;
			// 
			// tChartData.Footer.Shadow
			// 
			this.tChartData.Footer.Shadow.Visible = false;
			// 
			// tChartData.Header
			// 
			// 
			// tChartData.Header.Font
			// 
			// 
			// tChartData.Header.Font.Shadow
			// 
			this.tChartData.Header.Font.Shadow.Visible = false;
			this.tChartData.Header.Lines = new string[] {
															"Transformed time series"};
			// 
			// tChartData.Header.Shadow
			// 
			this.tChartData.Header.Shadow.Visible = false;
			// 
			// tChartData.Legend
			// 
			// 
			// tChartData.Legend.Font
			// 
			// 
			// tChartData.Legend.Font.Shadow
			// 
			this.tChartData.Legend.Font.Shadow.Visible = false;
			// 
			// tChartData.Legend.Title
			// 
			// 
			// tChartData.Legend.Title.Font
			// 
			this.tChartData.Legend.Title.Font.Bold = true;
			// 
			// tChartData.Legend.Title.Font.Shadow
			// 
			this.tChartData.Legend.Title.Font.Shadow.Visible = false;
			// 
			// tChartData.Legend.Title.Pen
			// 
			this.tChartData.Legend.Title.Pen.Visible = false;
			// 
			// tChartData.Legend.Title.Shadow
			// 
			this.tChartData.Legend.Title.Shadow.Visible = false;
			this.tChartData.Legend.Visible = false;
			this.tChartData.Location = new System.Drawing.Point(385, 78);
			this.tChartData.Name = "tChartData";
			// 
			// tChartData.Panel
			// 
			// 
			// tChartData.Panel.Brush
			// 
			this.tChartData.Panel.Brush.Color = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			// 
			// tChartData.Panel.ImageBevel
			// 
			this.tChartData.Panel.ImageBevel.Width = 1;
			// 
			// tChartData.Panel.Shadow
			// 
			this.tChartData.Panel.Shadow.Visible = false;
			this.tChartData.Series.Add(this.line1);
			this.tChartData.Size = new System.Drawing.Size(231, 337);
			// 
			// tChartData.SubFooter
			// 
			// 
			// tChartData.SubFooter.Font
			// 
			// 
			// tChartData.SubFooter.Font.Shadow
			// 
			this.tChartData.SubFooter.Font.Shadow.Visible = false;
			// 
			// tChartData.SubFooter.Shadow
			// 
			this.tChartData.SubFooter.Shadow.Visible = false;
			// 
			// tChartData.SubHeader
			// 
			// 
			// tChartData.SubHeader.Font
			// 
			// 
			// tChartData.SubHeader.Font.Shadow
			// 
			this.tChartData.SubHeader.Font.Shadow.Visible = false;
			// 
			// tChartData.SubHeader.Shadow
			// 
			this.tChartData.SubHeader.Shadow.Visible = false;
			this.tChartData.TabIndex = 14;
			// 
			// tChartData.Walls
			// 
			// 
			// tChartData.Walls.Back
			// 
			this.tChartData.Walls.Back.AutoHide = false;
			// 
			// tChartData.Walls.Back.Shadow
			// 
			this.tChartData.Walls.Back.Shadow.Visible = false;
			// 
			// tChartData.Walls.Bottom
			// 
			this.tChartData.Walls.Bottom.AutoHide = false;
			// 
			// tChartData.Walls.Bottom.Shadow
			// 
			this.tChartData.Walls.Bottom.Shadow.Visible = false;
			// 
			// tChartData.Walls.Left
			// 
			this.tChartData.Walls.Left.AutoHide = false;
			// 
			// tChartData.Walls.Left.Shadow
			// 
			this.tChartData.Walls.Left.Shadow.Visible = false;
			// 
			// tChartData.Walls.Right
			// 
			this.tChartData.Walls.Right.AutoHide = false;
			// 
			// tChartData.Walls.Right.Shadow
			// 
			this.tChartData.Walls.Right.Shadow.Visible = false;
			this.tChartData.AfterDraw += new Steema.TeeChart.PaintChartEventHandler(this.tChartData_AfterDraw);
			this.tChartData.BeforeDrawSeries += new Steema.TeeChart.PaintChartEventHandler(this.tChartData_BeforeDrawSeries);
			// 
			// line1
			// 
			// 
			// line1.Brush
			// 
			this.line1.Brush.Color = System.Drawing.Color.Red;
			// 
			// line1.LinePen
			// 
			this.line1.LinePen.Color = System.Drawing.Color.FromArgb(((System.Byte)(153)), ((System.Byte)(0)), ((System.Byte)(0)));
			// 
			// line1.Marks
			// 
			// 
			// line1.Marks.Callout
			// 
			this.line1.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
			this.line1.Marks.Callout.ArrowHeadSize = 8;
			// 
			// line1.Marks.Callout.Brush
			// 
			this.line1.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
			this.line1.Marks.Callout.Distance = 0;
			this.line1.Marks.Callout.Draw3D = false;
			this.line1.Marks.Callout.Length = 10;
			this.line1.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
			// 
			// line1.Marks.Font
			// 
			// 
			// line1.Marks.Font.Shadow
			// 
			this.line1.Marks.Font.Shadow.Visible = false;
			// 
			// line1.Pointer
			// 
			// 
			// line1.Pointer.Brush
			// 
			this.line1.Pointer.Brush.Color = System.Drawing.Color.Red;
			this.line1.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
			this.line1.Title = "line1";
			// 
			// line1.XValues
			// 
			this.line1.XValues.DataMember = "X";
			this.line1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
			// 
			// line1.YValues
			// 
			this.line1.YValues.DataMember = "Y";
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.numericUpDownDiff);
			this.groupBox6.Controls.Add(this.label6);
			this.groupBox6.Controls.Add(this.checkBoxRemoveMean);
			this.groupBox6.Controls.Add(this.buttonLoad);
			this.groupBox6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox6.Location = new System.Drawing.Point(12, 78);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(183, 100);
			this.groupBox6.TabIndex = 12;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Time series";
			// 
			// numericUpDownDiff
			// 
			this.numericUpDownDiff.Location = new System.Drawing.Point(104, 66);
			this.numericUpDownDiff.Maximum = new System.Decimal(new int[] {
																			  10,
																			  0,
																			  0,
																			  0});
			this.numericUpDownDiff.Name = "numericUpDownDiff";
			this.numericUpDownDiff.Size = new System.Drawing.Size(43, 20);
			this.numericUpDownDiff.TabIndex = 3;
			this.numericUpDownDiff.ValueChanged += new System.EventHandler(this.numericUpDownDiff_ValueChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 68);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(85, 16);
			this.label6.TabIndex = 2;
			this.label6.Text = "# of differencing";
			// 
			// checkBoxRemoveMean
			// 
			this.checkBoxRemoveMean.Checked = true;
			this.checkBoxRemoveMean.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxRemoveMean.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkBoxRemoveMean.Location = new System.Drawing.Point(8, 48);
			this.checkBoxRemoveMean.Name = "checkBoxRemoveMean";
			this.checkBoxRemoveMean.Size = new System.Drawing.Size(104, 17);
			this.checkBoxRemoveMean.TabIndex = 1;
			this.checkBoxRemoveMean.Text = "Remove mean";
			this.checkBoxRemoveMean.CheckedChanged += new System.EventHandler(this.checkBoxRemoveMean_CheckedChanged);
			// 
			// buttonLoad
			// 
			this.buttonLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonLoad.Location = new System.Drawing.Point(6, 19);
			this.buttonLoad.Name = "buttonLoad";
			this.buttonLoad.TabIndex = 0;
			this.buttonLoad.Text = "&Load";
			this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
			// 
			// wizardPageModel
			// 
			this.wizardPageModel.Controls.Add(this.groupBox2);
			this.wizardPageModel.Controls.Add(this.groupBox9);
			this.wizardPageModel.Controls.Add(this.groupBox10);
			this.wizardPageModel.Controls.Add(this.groupBox11);
			this.wizardPageModel.Controls.Add(this.groupBox12);
			this.wizardPageModel.Description = "Define ARMA model settings";
			this.wizardPageModel.Location = new System.Drawing.Point(0, 0);
			this.wizardPageModel.Name = "wizardPageModel";
			this.wizardPageModel.Size = new System.Drawing.Size(626, 423);
			this.wizardPageModel.TabIndex = 14;
			this.wizardPageModel.Title = "Step 2: ARMA model";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.comboBox4);
			this.groupBox2.Location = new System.Drawing.Point(232, 78);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(164, 80);
			this.groupBox2.TabIndex = 9;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Preliminary estimation";
			this.groupBox2.Visible = false;
			// 
			// comboBox4
			// 
			this.comboBox4.Items.AddRange(new object[] {
														   "Yule-Walker",
														   "Burg",
														   "Fixed"});
			this.comboBox4.Location = new System.Drawing.Point(6, 19);
			this.comboBox4.Name = "comboBox4";
			this.comboBox4.Size = new System.Drawing.Size(152, 21);
			this.comboBox4.TabIndex = 0;
			this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.comboBox3);
			this.groupBox9.Location = new System.Drawing.Point(232, 78);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(164, 80);
			this.groupBox9.TabIndex = 8;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Preliminary estimation";
			this.groupBox9.Visible = false;
			// 
			// comboBox3
			// 
			this.comboBox3.Items.AddRange(new object[] { "User supplied", "Yule-Walker", "Burg", "Innovations", "Hannah-Rissanen" });
            this.comboBox3.Location = new System.Drawing.Point(6, 19);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(152, 21);
			this.comboBox3.TabIndex = 0;
			this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            this.comboBox3.SelectedIndex = 1;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label10);
			this.groupBox10.Controls.Add(this.button1);
			this.groupBox10.Controls.Add(this.button2);
			this.groupBox10.Location = new System.Drawing.Point(422, 78);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new System.Drawing.Size(194, 80);
			this.groupBox10.TabIndex = 7;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "Initial values";
			this.groupBox10.Visible = false;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(107, 22);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(77, 50);
			this.label10.TabIndex = 6;
			this.label10.Text = "label10";
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Location = new System.Drawing.Point(6, 48);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(95, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "MA coefficients";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Location = new System.Drawing.Point(6, 19);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(95, 23);
			this.button2.TabIndex = 0;
			this.button2.Text = "AR coefficients";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// groupBox11
			// 
			this.groupBox11.Controls.Add(this.checkBoxMLE);
			this.groupBox11.Location = new System.Drawing.Point(12, 179);
			this.groupBox11.Name = "groupBox11";
			this.groupBox11.Size = new System.Drawing.Size(200, 72);
			this.groupBox11.TabIndex = 6;
			this.groupBox11.TabStop = false;
			this.groupBox11.Text = "Estimation";
			// 
			// checkBoxMLE
			// 
			this.checkBoxMLE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkBoxMLE.Location = new System.Drawing.Point(9, 28);
			this.checkBoxMLE.Name = "checkBoxMLE";
			this.checkBoxMLE.Size = new System.Drawing.Size(151, 17);
			this.checkBoxMLE.TabIndex = 0;
			this.checkBoxMLE.Text = "Do MLE estimation";
			this.checkBoxMLE.Checked = true;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.numericUpDown1);
			this.groupBox12.Controls.Add(this.label11);
			this.groupBox12.Controls.Add(this.numericUpDown2);
			this.groupBox12.Controls.Add(this.label12);
			this.groupBox12.Location = new System.Drawing.Point(12, 78);
			this.groupBox12.Name = "groupBox12";
			this.groupBox12.Size = new System.Drawing.Size(200, 80);
			this.groupBox12.TabIndex = 5;
			this.groupBox12.TabStop = false;
			this.groupBox12.Text = "Order";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(62, 50);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(58, 20);
			this.numericUpDown1.TabIndex = 3;
			this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
			this.numericUpDown1.Value = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(6, 52);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(51, 16);
			this.label11.TabIndex = 2;
			this.label11.Text = "MA order";
			// 
			// numericUpDown2
			// 
			this.numericUpDown2.Location = new System.Drawing.Point(61, 24);
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new System.Drawing.Size(58, 20);
			this.numericUpDown2.TabIndex = 1;
			this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            this.numericUpDown2.Value = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(6, 26);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(49, 16);
			this.label12.TabIndex = 0;
			this.label12.Text = "AR order";
			// 
			// wizardPageForecasts
			// 
			this.wizardPageForecasts.Controls.Add(this.groupBox13);
			this.wizardPageForecasts.Controls.Add(this.numericUpDownACFLag);
			this.wizardPageForecasts.Controls.Add(this.label13);
			this.wizardPageForecasts.Controls.Add(this.numericUpDownForNum);
			this.wizardPageForecasts.Controls.Add(this.label14);
			this.wizardPageForecasts.Description = "Define forecasts options";
			this.wizardPageForecasts.Location = new System.Drawing.Point(0, 0);
			this.wizardPageForecasts.Name = "wizardPageForecasts";
			this.wizardPageForecasts.Size = new System.Drawing.Size(626, 423);
			this.wizardPageForecasts.TabIndex = 15;
			this.wizardPageForecasts.Title = "Step 3: Forecasts";
			// 
			// groupBox13
			// 
			this.groupBox13.Controls.Add(this.checkBoxIntegrate);
			this.groupBox13.Controls.Add(this.checkBoxAddMean);
			this.groupBox13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox13.Location = new System.Drawing.Point(15, 153);
			this.groupBox13.Name = "groupBox13";
			this.groupBox13.Size = new System.Drawing.Size(209, 86);
			this.groupBox13.TabIndex = 9;
			this.groupBox13.TabStop = false;
			this.groupBox13.Text = "Transformation";
			// 
			// checkBoxIntegrate
			// 
			this.checkBoxIntegrate.Checked = true;
			this.checkBoxIntegrate.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxIntegrate.Enabled = false;
			this.checkBoxIntegrate.Location = new System.Drawing.Point(6, 52);
			this.checkBoxIntegrate.Name = "checkBoxIntegrate";
			this.checkBoxIntegrate.Size = new System.Drawing.Size(186, 17);
			this.checkBoxIntegrate.TabIndex = 1;
			this.checkBoxIntegrate.Text = "Forecast the undifferenced data";
			// 
			// checkBoxAddMean
			// 
			this.checkBoxAddMean.Checked = true;
			this.checkBoxAddMean.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxAddMean.Location = new System.Drawing.Point(6, 29);
			this.checkBoxAddMean.Name = "checkBoxAddMean";
			this.checkBoxAddMean.Size = new System.Drawing.Size(146, 17);
			this.checkBoxAddMean.TabIndex = 0;
			this.checkBoxAddMean.Text = "Add mean to forecasts";
			// 
			// numericUpDownACFLag
			// 
			this.numericUpDownACFLag.Location = new System.Drawing.Point(90, 112);
			this.numericUpDownACFLag.Minimum = new System.Decimal(new int[] {
																				1,
																				0,
																				0,
																				-2147483648});
			this.numericUpDownACFLag.Name = "numericUpDownACFLag";
			this.numericUpDownACFLag.Size = new System.Drawing.Size(50, 20);
			this.numericUpDownACFLag.TabIndex = 8;
			this.numericUpDownACFLag.Value = new System.Decimal(new int[] {
																			  1,
																			  0,
																			  0,
																			  -2147483648});
			this.numericUpDownACFLag.ValueChanged += new System.EventHandler(this.numericUpDownACFLag_ValueChanged);
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(40, 112);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(45, 16);
			this.label13.TabIndex = 7;
			this.label13.Text = "ACF lag";
			// 
			// numericUpDownForNum
			// 
			this.numericUpDownForNum.Increment = new System.Decimal(new int[] {
																				  10,
																				  0,
																				  0,
																				  0});
			this.numericUpDownForNum.Location = new System.Drawing.Point(90, 79);
			this.numericUpDownForNum.Maximum = new System.Decimal(new int[] {
																				150,
																				0,
																				0,
																				0});
			this.numericUpDownForNum.Name = "numericUpDownForNum";
			this.numericUpDownForNum.Size = new System.Drawing.Size(50, 20);
			this.numericUpDownForNum.TabIndex = 6;
			this.numericUpDownForNum.Value = new System.Decimal(new int[] {
																			  10,
																			  0,
																			  0,
																			  0});
			this.numericUpDownForNum.ValueChanged += new System.EventHandler(this.numericUpDownForNum_ValueChanged);
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(12, 81);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(72, 16);
			this.label14.TabIndex = 5;
			this.label14.Text = "# of forecasts";
			// 
			// groupBoxInitMA
			// 
			this.groupBoxInitMA.Controls.Add(this.comboBox2);
			this.groupBoxInitMA.Location = new System.Drawing.Point(218, 17);
			this.groupBoxInitMA.Name = "groupBoxInitMA";
			this.groupBoxInitMA.Size = new System.Drawing.Size(164, 80);
			this.groupBoxInitMA.TabIndex = 4;
			this.groupBoxInitMA.TabStop = false;
			this.groupBoxInitMA.Text = "Preliminary estimation";
			this.groupBoxInitMA.Visible = false;
			// 
			// comboBox2
			// 
			this.comboBox2.Items.AddRange(new object[] {
														   "Innovations",
														   "User supplied"});
			this.comboBox2.Location = new System.Drawing.Point(6, 19);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(152, 21);
			this.comboBox2.TabIndex = 0;
			// 
			// groupBoxEditPhiTheta
			// 
			this.groupBoxEditPhiTheta.Controls.Add(this.label8);
			this.groupBoxEditPhiTheta.Controls.Add(this.buttonEditMA);
			this.groupBoxEditPhiTheta.Controls.Add(this.buttonEditAR);
			this.groupBoxEditPhiTheta.Location = new System.Drawing.Point(418, 17);
			this.groupBoxEditPhiTheta.Name = "groupBoxEditPhiTheta";
			this.groupBoxEditPhiTheta.Size = new System.Drawing.Size(194, 80);
			this.groupBoxEditPhiTheta.TabIndex = 2;
			this.groupBoxEditPhiTheta.TabStop = false;
			this.groupBoxEditPhiTheta.Text = "Initial values";
			this.groupBoxEditPhiTheta.Visible = false;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(107, 22);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(77, 50);
			this.label8.TabIndex = 6;
			this.label8.Text = "label8";
			// 
			// buttonEditMA
			// 
			this.buttonEditMA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonEditMA.Location = new System.Drawing.Point(6, 48);
			this.buttonEditMA.Name = "buttonEditMA";
			this.buttonEditMA.Size = new System.Drawing.Size(95, 23);
			this.buttonEditMA.TabIndex = 1;
			this.buttonEditMA.Text = "MA coefficients";
			// 
			// buttonEditAR
			// 
			this.buttonEditAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonEditAR.Location = new System.Drawing.Point(6, 19);
			this.buttonEditAR.Name = "buttonEditAR";
			this.buttonEditAR.Size = new System.Drawing.Size(95, 23);
			this.buttonEditAR.TabIndex = 0;
			this.buttonEditAR.Text = "AR coefficients";
			// 
			// groupBox7
			// 
			this.groupBox7.Location = new System.Drawing.Point(8, 118);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(200, 72);
			this.groupBox7.TabIndex = 1;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Estimation";
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.label7);
			this.groupBox8.Controls.Add(this.label9);
			this.groupBox8.Location = new System.Drawing.Point(8, 17);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(200, 80);
			this.groupBox8.TabIndex = 0;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Order";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 52);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(51, 16);
			this.label7.TabIndex = 2;
			this.label7.Text = "MA order";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(6, 26);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(49, 16);
			this.label9.TabIndex = 0;
			this.label9.Text = "AR order";
			// 
			// comboBox1
			// 
			this.comboBox1.Items.AddRange(new object[] {
														   "Yule-Walker",
														   "Burg",
														   "User supplied"});
			this.comboBox1.Location = new System.Drawing.Point(6, 19);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(152, 21);
			this.comboBox1.TabIndex = 0;
			// 
			// ARMAWizard
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(626, 471);
			this.Name = "ARMAWizard";
			this.Load += new System.EventHandler(this.ARMAWizard_Load);
			this.wizard.ResumeLayout(false);
			this.wizardPageReport.ResumeLayout(false);
			this.wizardPageTimeSeries.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownDiff)).EndInit();
			this.wizardPageModel.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox9.ResumeLayout(false);
			this.groupBox10.ResumeLayout(false);
			this.groupBox11.ResumeLayout(false);
			this.groupBox12.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
			this.wizardPageForecasts.ResumeLayout(false);
			this.groupBox13.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownACFLag)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownForNum)).EndInit();
			this.groupBoxInitMA.ResumeLayout(false);
			this.groupBoxEditPhiTheta.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			this.ResumeLayout(false);

		}

        #endregion


        public TVec TimeSeries
        {
            get { return (TVec)timeseries; }
        }

        private int InnoLag(int maxlag)
        {
            if (maxlag < 0) return (int) Math387.Ceil(10 * Math.Log10(data.Length));
            else return maxlag;
        }

        #region GUI
        private void RefreshChart()
        {
            // recalculate lb and ub for acf and pacf chart
            if (!radioButtonTS.Checked)
            {
                chartucl = Probabilities.NormalCDFInv(1.0 - 0.5 * Alpha, 0, 1) / Math.Sqrt(data.Length);
                chartlcl = -chartucl;
            }
            tChartData.Series.Clear();
            tChartData.Legend.Visible = false;
            tChartData.Axes.Bottom.Visible = false;
            tChartData.Axes.Left.Automatic = true;
            tChartData.Axes.Bottom.Automatic = true;
            Vector v1 = new Vector(0);
            Vector v2 = new Vector(0);

            tChartData.Series.Add(new Steema.TeeChart.Styles.Line(tChartData.Chart));

            if (radioButtonTS.Checked) // time series
            {
                tChartData.Axes.Bottom.Visible = true;
                tChartData.Header.Text = "Transformed time series";
                DrawValues(data, tChartData.Series[0], 0, 1, false);
            }
            else if (radioButtonACF.Checked) // acf
            {
                tChartData.Axes.Left.SetMinMax(-1, 1);
                tChartData.Axes.Bottom.AutomaticMinimum = false;
                tChartData.Axes.Bottom.Minimum = -1;
                tChartData.Header.Text = "Transformed time series ACF";
                StatTimeSerAnalysis.ACF(data, v1, -1);
                DrawValues(v1, tChartData.Series[0], 0, 1, false);
            }
            else if (radioButtonPACF.Checked) // pacf
            {
                tChartData.Axes.Left.SetMinMax(-1, 1);
                tChartData.Axes.Bottom.AutomaticMinimum = false;
                tChartData.Axes.Bottom.Minimum = -1;
                tChartData.Header.Text = "Transformed time series PACF";
                StatTimeSerAnalysis.ACF(data, v1, -1);
                StatTimeSerAnalysis.PACF(v1, v2);
                DrawValues(v2, tChartData.Series[0], 0, 1, false);
            }
        }

        /// <summary>
        /// Collects time series and transformed time series statistics
        /// </summary>
        private void InfoReport()
        {
            double sd = timeseries.StdDev();
            string st = "";
            st = "size:\t" + timeseries.Length.ToString() + "\n";
            st += "mean:\t" + Math387.FormatSample(FmtString, timeseries.Mean()) + "\n";
            st += "std.dev:\t" + Math387.FormatSample(FmtString, sd) + "\n";
            st += "variance:\t" + Math387.FormatSample(FmtString, sd * sd) + "\n";
            labelUnTrStat.Text = st;

            TransformTimeSeries();
            numericUpDownACFLag.Maximum = data.Length - 2;
            // transformed series ...
            sd = data.StdDev();
            st = "size:\t" + data.Length.ToString() + "\n";
            st += "mean:\t" + Math387.FormatSample(FmtString, data.Mean()) + "\n";
            st += "std.dev:\t" + Math387.FormatSample(FmtString, sd) + "\n";
            st += "variance:\t" + Math387.FormatSample(FmtString, sd * sd) + "\n";
            labelTrStat.Text = st;
            // draw transformed time series
            RefreshChart();
        }

        private void RefreshModelControls()
        {
            groupBox2.Visible = ((p > 0) && (q == 0));
            groupBox9.Visible = (q > 0);
            groupBox10.Visible = (armainit == TcfInitMethod.cfInitFixed) && ((p > 0) || (q > 0));
            label10.Visible = (armainit == TcfInitMethod.cfInitFixed) && ((p > 0) || (q > 0));
            if (label10.Visible)
            {
                string st = "Model:\n";
                if (p > 0)
                    if (StatTimeSerAnalysis.CheckARMACoeffs(phi, true)) st += "causal\n"; else st += "NOT causal\n";
                if (q > 0)
                    if (StatTimeSerAnalysis.CheckARMACoeffs(theta, false)) st += "invertible"; else st += "NOT invertible";

                label10.Text = st;
            }
        }

        private void RefreshWizardControls()
        {
            if (wizard.SelectedPage == wizardPageTimeSeries) wizard.NextEnabled = timeseries.Length > 0;
            else if (wizard.SelectedPage == wizardPageModel) wizard.NextEnabled = (p > 0) || (q > 0);
        }

        #endregion

        #region Calculations

        private void TransformTimeSeries()
        {
            data.Copy(timeseries);
            // differenciate, if needed
            if (d > 0)
                for (int i = 1; i <= d; i++) data.Difference(1);
            dMean = data.Mean();
            // remove mean, if specified
            //if (checkBoxRemoveMean.Checked) data -= dMean;
        }

        #endregion

        private void wizard_AfterSwitchPages(object sender, Dew.Math.Controls.Wizard.AfterSwitchPagesEventArgs e)
        {
            Dew.Math.Controls.WizardPage newpage = wizard.Pages[e.NewIndex];
            if (newpage == wizardPageReport)
            {
                TextReport();
                wizard.CancelEnabled = false;
            }
            else if (newpage == wizardPageTimeSeries)
            {
                wizard.NextEnabled = timeseries.Length > 0;
            }
            else if (newpage == wizardPageModel)
            {
                wizard.NextEnabled = (p > 0) || (q > 0);
            }
            else wizard.CancelEnabled = true;

        }

        private void ARMAWizard_Load(object sender, EventArgs e)
        {
            wizardPageWelcome.Description = "The ARMA/ARIMA forecasting is often used to forecast time series "
                + "of medium (N over 50) to long lengths.  It requires the forecaster to be highly trained "
                + "in selecting the appropriate model.\n\n"
                + "ARMA Wizard performs the following steps:\n\n"
                + "+ Checks if time series is \"aproximately\" stationary. If this is "
                + "not the case, it tries using differencing operator to make it stationary.\n"
                + "+ Removes mean from transformed stationary time series.\n"
                + "+ Selects appropriate AR and MA degrees.\n"
                + "+ If needed, calculates initial estimates for ARMA model by using "
                + "Yule-Walker, Burg, Innovations or Hannah-Rissanen algorithm.\n"
                + "+ Uses MLE to estimate \"best\" coefficients for ARMA model.\n"
                + "+ Forecasts time series values by using calculated ARMA model coefficients.\n";

            // user supplied
            comboBox3.SelectedIndex = comboBox3.Items.Count - 1;
            comboBox4.SelectedIndex = comboBox4.Items.Count - 1;
            InfoReport();

        }

        private void checkBoxRemoveMean_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxAddMean.Enabled = checkBoxRemoveMean.Checked;
            InfoReport();
        }

        private void numericUpDownDiff_ValueChanged(object sender, EventArgs e)
        {
            d = (int)numericUpDownDiff.Value;
            checkBoxIntegrate.Enabled = (d > 0);
            InfoReport();
        }

        private void radioButtonTS_CheckedChanged(object sender, EventArgs e)
        {
            RefreshChart();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                timeseries.LoadFromFile(openFileDialog1.FileName);
                timeseries.Caption = openFileDialog1.FileName;
                RefreshWizardControls();
                InfoReport();
            }
        }

        private void tChartData_BeforeDrawSeries(object sender, Steema.TeeChart.Drawing.Graphics3D g)
        {
            if (!tChartData.Axes.Bottom.Visible)
            {
                int ypos = tChartData.Axes.Left.CalcYPosValue(0.0);
                tChartData.Axes.Bottom.Draw(ypos + 10, ypos + 15, ypos, false);
            }
        }

        private void tChartData_AfterDraw(object sender, Steema.TeeChart.Drawing.Graphics3D g)
        {
            if (!radioButtonTS.Checked) // acf or pacf
            {
                Rectangle r = tChartData.Chart.ChartRect;
                int ypos = tChartData.Axes.Left.CalcYPosValue(chartucl);
                g.Pen.Style = System.Drawing.Drawing2D.DashStyle.Dot;
                g.Pen.Width = 2;
                g.Pen.Color = Color.Blue;
                g.ClipRectangle(r);
                g.Line(r.Left, ypos, r.Right, ypos);
                g.Font.Bold = true;
                g.Font.Color = Color.Blue;
                g.TextOut(r.Right - 80, ypos - 15, Math387.FormatSample("0.00%", 100.0 * (1.0 - Alpha)) + " CI");
                ypos = tChartData.Axes.Left.CalcYPosValue(chartlcl);
                g.Line(r.Left, ypos, r.Right, ypos);
                g.TextOut(r.Right - 80, ypos, Math387.FormatSample("0.00%", 100.0 * (1.0 - Alpha)) + " CI");
                g.UnClip();
            }
        }

        private void textBoxAlpha_TextChanged(object sender, EventArgs e)
        {
            RefreshChart();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            p = (int)numericUpDown2.Value;
            phi.Length = p;
            phi.SetZero();

            phiInit.Size(phi);
            phiInit.SetZero();

            RefreshModelControls();
            RefreshWizardControls();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            q = (int)numericUpDown1.Value;
            theta.Length = q;

            thetaInit.Size(theta);
            thetaInit.SetZero();

            RefreshModelControls();
            RefreshWizardControls();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox3.SelectedIndex)
            {
                case 0:
                    armainit = TcfInitMethod.cfInitFixed; break;
                case 1:
                    armainit = TcfInitMethod.cfInitYW; break;
                case 2:
                    armainit = TcfInitMethod.cfInitBurg; break;
                case 3: // Innovations
                    armainit = TcfInitMethod.cfInitInno; break;
                case 4:
                    armainit = TcfInitMethod.cfInitHannah; break;
                default: // user supplied
                    armainit = TcfInitMethod.cfInitFixed; break;
            }
            RefreshModelControls();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MtxVecEdit.ViewValues(phiInit, "AR coefficients", true, false, true);
            RefreshModelControls();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MtxVecEdit.ViewValues(thetaInit, "MA coefficients", true, false, true);
            RefreshModelControls();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox4.SelectedIndex)
            {
                case 0: // Yule-Walker
                    armainit = TcfInitMethod.cfInitYW; break;
                case 1: // Burg
                    armainit = TcfInitMethod.cfInitBurg; break;
                default: // user supplied
                    armainit = TcfInitMethod.cfInitFixed; break;
            }
            RefreshModelControls();
        }

        private void numericUpDownForNum_ValueChanged(object sender, EventArgs e)
        {
            forper = (int)numericUpDownForNum.Value;
        }

        private void numericUpDownACFLag_ValueChanged(object sender, EventArgs e)
        {
            maxLag = (int)numericUpDownACFLag.Value;
        }
    }
}

