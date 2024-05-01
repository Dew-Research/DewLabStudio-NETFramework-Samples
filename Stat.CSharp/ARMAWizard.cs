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
        private GroupBox arimaGroup;
        private ComboBox arimaComboBox;
        private GroupBox groupBox10;
        private Label label10;
        private Button maCoeffButton;
        private Button arCoeffButton;
        private GroupBox groupBox11;
        private CheckBox checkBoxMLE;
        private GroupBox groupBox12;
        private NumericUpDown maUpDown;
        private Label label11;
        private NumericUpDown arUpDown;
        private Label label12;
        private GroupBox groupBox13;
        private CheckBox checkBoxIntegrate;
        private CheckBox checkBoxAddMean;
        private NumericUpDown numericUpDownACFLag;
        private Label label13;
        private NumericUpDown numericUpDownForNum;
        private Label label14;
        private GroupBox arGroup;
        private ComboBox arComboBox;
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
            Steema.TeeChart.Margins margins1 = new Steema.TeeChart.Margins();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ARMAWizard));
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
            this.arGroup = new System.Windows.Forms.GroupBox();
            this.arComboBox = new System.Windows.Forms.ComboBox();
            this.arimaGroup = new System.Windows.Forms.GroupBox();
            this.arimaComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.maCoeffButton = new System.Windows.Forms.Button();
            this.arCoeffButton = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.checkBoxMLE = new System.Windows.Forms.CheckBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.maUpDown = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.arUpDown = new System.Windows.Forms.NumericUpDown();
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
            this.wizardPageFormat.SuspendLayout();
            this.wizardPageTimeSeries.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDiff)).BeginInit();
            this.wizardPageModel.SuspendLayout();
            this.arGroup.SuspendLayout();
            this.arimaGroup.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arUpDown)).BeginInit();
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
            this.wizard.Controls.Add(this.wizardPageModel);
            this.wizard.Controls.Add(this.wizardPageTimeSeries);
            this.wizard.Controls.Add(this.wizardPageForecasts);
            this.wizard.Pages.AddRange(new Dew.Math.Controls.WizardPage[] {
            this.wizardPageTimeSeries,
            this.wizardPageModel,
            this.wizardPageForecasts});
            this.wizard.Size = new System.Drawing.Size(626, 471);
            this.wizard.AfterSwitchPages += new Dew.Math.Controls.Wizard.AfterSwitchPagesEventHandler(this.wizard_AfterSwitchPages);
            this.wizard.Controls.SetChildIndex(this.wizardPageForecasts, 0);
            this.wizard.Controls.SetChildIndex(this.wizardPageWelcome, 0);
            this.wizard.Controls.SetChildIndex(this.wizardPageFormat, 0);
            this.wizard.Controls.SetChildIndex(this.wizardPageReport, 0);
            this.wizard.Controls.SetChildIndex(this.wizardPageTimeSeries, 0);
            this.wizard.Controls.SetChildIndex(this.wizardPageModel, 0);
            // 
            // wizardPageReport
            // 
            this.wizardPageReport.Size = new System.Drawing.Size(626, 423);
            this.wizardPageReport.Title = "ARMA : Report";
            // 
            // richTextBox
            // 
            this.richTextBox.Size = new System.Drawing.Size(599, 284);
            // 
            // progressBar
            // 
            this.progressBar.Size = new System.Drawing.Size(545, 13);
            // 
            // wizardPageFormat
            // 
            this.wizardPageFormat.Description = "Define ARMA Report output options";
            this.wizardPageFormat.Size = new System.Drawing.Size(626, 423);
            this.wizardPageFormat.Title = "Step 4: Report options";
            // 
            // wizardPageWelcome
            // 
            this.wizardPageWelcome.Size = new System.Drawing.Size(626, 423);
            // 
            // textBoxAlpha
            // 
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
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Bottom.Labels.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChartData.Axes.Bottom.Labels.Brush.Color = System.Drawing.Color.White;
            this.tChartData.Axes.Bottom.Labels.Brush.Solid = true;
            this.tChartData.Axes.Bottom.Labels.Brush.Visible = true;
            // 
            // 
            // 
            this.tChartData.Axes.Bottom.Labels.Font.Bold = false;
            // 
            // 
            // 
            this.tChartData.Axes.Bottom.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChartData.Axes.Bottom.Labels.Font.Brush.Solid = true;
            this.tChartData.Axes.Bottom.Labels.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Bottom.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.Axes.Bottom.Labels.Font.Shadow.Brush.Solid = true;
            this.tChartData.Axes.Bottom.Labels.Font.Shadow.Brush.Visible = true;
            this.tChartData.Axes.Bottom.Labels.Font.Size = 9;
            this.tChartData.Axes.Bottom.Labels.Font.SizeFloat = 9F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Bottom.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChartData.Axes.Bottom.Labels.ImageBevel.Brush.Solid = true;
            this.tChartData.Axes.Bottom.Labels.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Bottom.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.Axes.Bottom.Labels.Shadow.Brush.Solid = true;
            this.tChartData.Axes.Bottom.Labels.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            this.tChartData.Axes.Bottom.Title.Angle = 0;
            // 
            // 
            // 
            this.tChartData.Axes.Bottom.Title.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChartData.Axes.Bottom.Title.Brush.Color = System.Drawing.Color.Silver;
            this.tChartData.Axes.Bottom.Title.Brush.Solid = true;
            this.tChartData.Axes.Bottom.Title.Brush.Visible = true;
            // 
            // 
            // 
            this.tChartData.Axes.Bottom.Title.Font.Bold = false;
            // 
            // 
            // 
            this.tChartData.Axes.Bottom.Title.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tChartData.Axes.Bottom.Title.Font.Brush.Solid = true;
            this.tChartData.Axes.Bottom.Title.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Bottom.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.Axes.Bottom.Title.Font.Shadow.Brush.Solid = true;
            this.tChartData.Axes.Bottom.Title.Font.Shadow.Brush.Visible = true;
            this.tChartData.Axes.Bottom.Title.Font.Size = 11;
            this.tChartData.Axes.Bottom.Title.Font.SizeFloat = 11F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Bottom.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChartData.Axes.Bottom.Title.ImageBevel.Brush.Solid = true;
            this.tChartData.Axes.Bottom.Title.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Bottom.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.Axes.Bottom.Title.Shadow.Brush.Solid = true;
            this.tChartData.Axes.Bottom.Title.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Depth.Labels.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChartData.Axes.Depth.Labels.Brush.Color = System.Drawing.Color.White;
            this.tChartData.Axes.Depth.Labels.Brush.Solid = true;
            this.tChartData.Axes.Depth.Labels.Brush.Visible = true;
            // 
            // 
            // 
            this.tChartData.Axes.Depth.Labels.Font.Bold = false;
            // 
            // 
            // 
            this.tChartData.Axes.Depth.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChartData.Axes.Depth.Labels.Font.Brush.Solid = true;
            this.tChartData.Axes.Depth.Labels.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Depth.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.Axes.Depth.Labels.Font.Shadow.Brush.Solid = true;
            this.tChartData.Axes.Depth.Labels.Font.Shadow.Brush.Visible = true;
            this.tChartData.Axes.Depth.Labels.Font.Size = 9;
            this.tChartData.Axes.Depth.Labels.Font.SizeFloat = 9F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Depth.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChartData.Axes.Depth.Labels.ImageBevel.Brush.Solid = true;
            this.tChartData.Axes.Depth.Labels.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Depth.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.Axes.Depth.Labels.Shadow.Brush.Solid = true;
            this.tChartData.Axes.Depth.Labels.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            this.tChartData.Axes.Depth.Title.Angle = 0;
            // 
            // 
            // 
            this.tChartData.Axes.Depth.Title.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChartData.Axes.Depth.Title.Brush.Color = System.Drawing.Color.Silver;
            this.tChartData.Axes.Depth.Title.Brush.Solid = true;
            this.tChartData.Axes.Depth.Title.Brush.Visible = true;
            // 
            // 
            // 
            this.tChartData.Axes.Depth.Title.Font.Bold = false;
            // 
            // 
            // 
            this.tChartData.Axes.Depth.Title.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tChartData.Axes.Depth.Title.Font.Brush.Solid = true;
            this.tChartData.Axes.Depth.Title.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Depth.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.Axes.Depth.Title.Font.Shadow.Brush.Solid = true;
            this.tChartData.Axes.Depth.Title.Font.Shadow.Brush.Visible = true;
            this.tChartData.Axes.Depth.Title.Font.Size = 11;
            this.tChartData.Axes.Depth.Title.Font.SizeFloat = 11F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Depth.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChartData.Axes.Depth.Title.ImageBevel.Brush.Solid = true;
            this.tChartData.Axes.Depth.Title.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Depth.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.Axes.Depth.Title.Shadow.Brush.Solid = true;
            this.tChartData.Axes.Depth.Title.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.DepthTop.Labels.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChartData.Axes.DepthTop.Labels.Brush.Color = System.Drawing.Color.White;
            this.tChartData.Axes.DepthTop.Labels.Brush.Solid = true;
            this.tChartData.Axes.DepthTop.Labels.Brush.Visible = true;
            // 
            // 
            // 
            this.tChartData.Axes.DepthTop.Labels.Font.Bold = false;
            // 
            // 
            // 
            this.tChartData.Axes.DepthTop.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChartData.Axes.DepthTop.Labels.Font.Brush.Solid = true;
            this.tChartData.Axes.DepthTop.Labels.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.DepthTop.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.Axes.DepthTop.Labels.Font.Shadow.Brush.Solid = true;
            this.tChartData.Axes.DepthTop.Labels.Font.Shadow.Brush.Visible = true;
            this.tChartData.Axes.DepthTop.Labels.Font.Size = 9;
            this.tChartData.Axes.DepthTop.Labels.Font.SizeFloat = 9F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.DepthTop.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChartData.Axes.DepthTop.Labels.ImageBevel.Brush.Solid = true;
            this.tChartData.Axes.DepthTop.Labels.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.DepthTop.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.Axes.DepthTop.Labels.Shadow.Brush.Solid = true;
            this.tChartData.Axes.DepthTop.Labels.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            this.tChartData.Axes.DepthTop.Title.Angle = 0;
            // 
            // 
            // 
            this.tChartData.Axes.DepthTop.Title.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChartData.Axes.DepthTop.Title.Brush.Color = System.Drawing.Color.Silver;
            this.tChartData.Axes.DepthTop.Title.Brush.Solid = true;
            this.tChartData.Axes.DepthTop.Title.Brush.Visible = true;
            // 
            // 
            // 
            this.tChartData.Axes.DepthTop.Title.Font.Bold = false;
            // 
            // 
            // 
            this.tChartData.Axes.DepthTop.Title.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tChartData.Axes.DepthTop.Title.Font.Brush.Solid = true;
            this.tChartData.Axes.DepthTop.Title.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.DepthTop.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.Axes.DepthTop.Title.Font.Shadow.Brush.Solid = true;
            this.tChartData.Axes.DepthTop.Title.Font.Shadow.Brush.Visible = true;
            this.tChartData.Axes.DepthTop.Title.Font.Size = 11;
            this.tChartData.Axes.DepthTop.Title.Font.SizeFloat = 11F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.DepthTop.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChartData.Axes.DepthTop.Title.ImageBevel.Brush.Solid = true;
            this.tChartData.Axes.DepthTop.Title.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.DepthTop.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.Axes.DepthTop.Title.Shadow.Brush.Solid = true;
            this.tChartData.Axes.DepthTop.Title.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Left.Labels.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChartData.Axes.Left.Labels.Brush.Color = System.Drawing.Color.White;
            this.tChartData.Axes.Left.Labels.Brush.Solid = true;
            this.tChartData.Axes.Left.Labels.Brush.Visible = true;
            // 
            // 
            // 
            this.tChartData.Axes.Left.Labels.Font.Bold = false;
            // 
            // 
            // 
            this.tChartData.Axes.Left.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChartData.Axes.Left.Labels.Font.Brush.Solid = true;
            this.tChartData.Axes.Left.Labels.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Left.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.Axes.Left.Labels.Font.Shadow.Brush.Solid = true;
            this.tChartData.Axes.Left.Labels.Font.Shadow.Brush.Visible = true;
            this.tChartData.Axes.Left.Labels.Font.Size = 9;
            this.tChartData.Axes.Left.Labels.Font.SizeFloat = 9F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Left.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChartData.Axes.Left.Labels.ImageBevel.Brush.Solid = true;
            this.tChartData.Axes.Left.Labels.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Left.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.Axes.Left.Labels.Shadow.Brush.Solid = true;
            this.tChartData.Axes.Left.Labels.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            this.tChartData.Axes.Left.Title.Angle = 90;
            // 
            // 
            // 
            this.tChartData.Axes.Left.Title.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChartData.Axes.Left.Title.Brush.Color = System.Drawing.Color.Silver;
            this.tChartData.Axes.Left.Title.Brush.Solid = true;
            this.tChartData.Axes.Left.Title.Brush.Visible = true;
            // 
            // 
            // 
            this.tChartData.Axes.Left.Title.Font.Bold = false;
            // 
            // 
            // 
            this.tChartData.Axes.Left.Title.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tChartData.Axes.Left.Title.Font.Brush.Solid = true;
            this.tChartData.Axes.Left.Title.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Left.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.Axes.Left.Title.Font.Shadow.Brush.Solid = true;
            this.tChartData.Axes.Left.Title.Font.Shadow.Brush.Visible = true;
            this.tChartData.Axes.Left.Title.Font.Size = 11;
            this.tChartData.Axes.Left.Title.Font.SizeFloat = 11F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Left.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChartData.Axes.Left.Title.ImageBevel.Brush.Solid = true;
            this.tChartData.Axes.Left.Title.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Left.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.Axes.Left.Title.Shadow.Brush.Solid = true;
            this.tChartData.Axes.Left.Title.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Right.Labels.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChartData.Axes.Right.Labels.Brush.Color = System.Drawing.Color.White;
            this.tChartData.Axes.Right.Labels.Brush.Solid = true;
            this.tChartData.Axes.Right.Labels.Brush.Visible = true;
            // 
            // 
            // 
            this.tChartData.Axes.Right.Labels.Font.Bold = false;
            // 
            // 
            // 
            this.tChartData.Axes.Right.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChartData.Axes.Right.Labels.Font.Brush.Solid = true;
            this.tChartData.Axes.Right.Labels.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Right.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.Axes.Right.Labels.Font.Shadow.Brush.Solid = true;
            this.tChartData.Axes.Right.Labels.Font.Shadow.Brush.Visible = true;
            this.tChartData.Axes.Right.Labels.Font.Size = 9;
            this.tChartData.Axes.Right.Labels.Font.SizeFloat = 9F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Right.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChartData.Axes.Right.Labels.ImageBevel.Brush.Solid = true;
            this.tChartData.Axes.Right.Labels.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Right.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.Axes.Right.Labels.Shadow.Brush.Solid = true;
            this.tChartData.Axes.Right.Labels.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            this.tChartData.Axes.Right.Title.Angle = 270;
            // 
            // 
            // 
            this.tChartData.Axes.Right.Title.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChartData.Axes.Right.Title.Brush.Color = System.Drawing.Color.Silver;
            this.tChartData.Axes.Right.Title.Brush.Solid = true;
            this.tChartData.Axes.Right.Title.Brush.Visible = true;
            // 
            // 
            // 
            this.tChartData.Axes.Right.Title.Font.Bold = false;
            // 
            // 
            // 
            this.tChartData.Axes.Right.Title.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tChartData.Axes.Right.Title.Font.Brush.Solid = true;
            this.tChartData.Axes.Right.Title.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Right.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.Axes.Right.Title.Font.Shadow.Brush.Solid = true;
            this.tChartData.Axes.Right.Title.Font.Shadow.Brush.Visible = true;
            this.tChartData.Axes.Right.Title.Font.Size = 11;
            this.tChartData.Axes.Right.Title.Font.SizeFloat = 11F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Right.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChartData.Axes.Right.Title.ImageBevel.Brush.Solid = true;
            this.tChartData.Axes.Right.Title.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Right.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.Axes.Right.Title.Shadow.Brush.Solid = true;
            this.tChartData.Axes.Right.Title.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Top.Labels.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChartData.Axes.Top.Labels.Brush.Color = System.Drawing.Color.White;
            this.tChartData.Axes.Top.Labels.Brush.Solid = true;
            this.tChartData.Axes.Top.Labels.Brush.Visible = true;
            // 
            // 
            // 
            this.tChartData.Axes.Top.Labels.Font.Bold = false;
            // 
            // 
            // 
            this.tChartData.Axes.Top.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChartData.Axes.Top.Labels.Font.Brush.Solid = true;
            this.tChartData.Axes.Top.Labels.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Top.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.Axes.Top.Labels.Font.Shadow.Brush.Solid = true;
            this.tChartData.Axes.Top.Labels.Font.Shadow.Brush.Visible = true;
            this.tChartData.Axes.Top.Labels.Font.Size = 9;
            this.tChartData.Axes.Top.Labels.Font.SizeFloat = 9F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Top.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChartData.Axes.Top.Labels.ImageBevel.Brush.Solid = true;
            this.tChartData.Axes.Top.Labels.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Top.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.Axes.Top.Labels.Shadow.Brush.Solid = true;
            this.tChartData.Axes.Top.Labels.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            this.tChartData.Axes.Top.Title.Angle = 0;
            // 
            // 
            // 
            this.tChartData.Axes.Top.Title.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChartData.Axes.Top.Title.Brush.Color = System.Drawing.Color.Silver;
            this.tChartData.Axes.Top.Title.Brush.Solid = true;
            this.tChartData.Axes.Top.Title.Brush.Visible = true;
            // 
            // 
            // 
            this.tChartData.Axes.Top.Title.Font.Bold = false;
            // 
            // 
            // 
            this.tChartData.Axes.Top.Title.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tChartData.Axes.Top.Title.Font.Brush.Solid = true;
            this.tChartData.Axes.Top.Title.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Top.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.Axes.Top.Title.Font.Shadow.Brush.Solid = true;
            this.tChartData.Axes.Top.Title.Font.Shadow.Brush.Visible = true;
            this.tChartData.Axes.Top.Title.Font.Size = 11;
            this.tChartData.Axes.Top.Title.Font.SizeFloat = 11F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Top.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChartData.Axes.Top.Title.ImageBevel.Brush.Solid = true;
            this.tChartData.Axes.Top.Title.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Top.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.Axes.Top.Title.Shadow.Brush.Solid = true;
            this.tChartData.Axes.Top.Title.Shadow.Brush.Visible = true;
            this.tChartData.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Footer.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChartData.Footer.Brush.Color = System.Drawing.Color.Silver;
            this.tChartData.Footer.Brush.Solid = true;
            this.tChartData.Footer.Brush.Visible = true;
            // 
            // 
            // 
            this.tChartData.Footer.Font.Bold = false;
            // 
            // 
            // 
            this.tChartData.Footer.Font.Brush.Color = System.Drawing.Color.Red;
            this.tChartData.Footer.Font.Brush.Solid = true;
            this.tChartData.Footer.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Footer.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.Footer.Font.Shadow.Brush.Solid = true;
            this.tChartData.Footer.Font.Shadow.Brush.Visible = true;
            this.tChartData.Footer.Font.Size = 8;
            this.tChartData.Footer.Font.SizeFloat = 8F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Footer.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChartData.Footer.ImageBevel.Brush.Solid = true;
            this.tChartData.Footer.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Footer.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.Footer.Shadow.Brush.Solid = true;
            this.tChartData.Footer.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Header.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChartData.Header.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tChartData.Header.Brush.Solid = true;
            this.tChartData.Header.Brush.Visible = true;
            // 
            // 
            // 
            this.tChartData.Header.Font.Bold = false;
            // 
            // 
            // 
            this.tChartData.Header.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChartData.Header.Font.Brush.Solid = true;
            this.tChartData.Header.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Header.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.Header.Font.Shadow.Brush.Solid = true;
            this.tChartData.Header.Font.Shadow.Brush.Visible = true;
            this.tChartData.Header.Font.Size = 12;
            this.tChartData.Header.Font.SizeFloat = 12F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Header.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChartData.Header.ImageBevel.Brush.Solid = true;
            this.tChartData.Header.ImageBevel.Brush.Visible = true;
            this.tChartData.Header.Lines = new string[] {
        "Transformed time series"};
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Header.Shadow.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.tChartData.Header.Shadow.Brush.Solid = true;
            this.tChartData.Header.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Legend.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChartData.Legend.Brush.Color = System.Drawing.Color.White;
            this.tChartData.Legend.Brush.Solid = true;
            this.tChartData.Legend.Brush.Visible = true;
            // 
            // 
            // 
            this.tChartData.Legend.Font.Bold = false;
            // 
            // 
            // 
            this.tChartData.Legend.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tChartData.Legend.Font.Brush.Solid = true;
            this.tChartData.Legend.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Legend.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.Legend.Font.Shadow.Brush.Solid = true;
            this.tChartData.Legend.Font.Shadow.Brush.Visible = true;
            this.tChartData.Legend.Font.Size = 9;
            this.tChartData.Legend.Font.SizeFloat = 9F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Legend.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChartData.Legend.ImageBevel.Brush.Solid = true;
            this.tChartData.Legend.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Legend.Shadow.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tChartData.Legend.Shadow.Brush.Solid = true;
            this.tChartData.Legend.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Legend.Symbol.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.Legend.Symbol.Shadow.Brush.Solid = true;
            this.tChartData.Legend.Symbol.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Legend.Title.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChartData.Legend.Title.Brush.Color = System.Drawing.Color.White;
            this.tChartData.Legend.Title.Brush.Solid = true;
            this.tChartData.Legend.Title.Brush.Visible = true;
            // 
            // 
            // 
            this.tChartData.Legend.Title.Font.Bold = true;
            // 
            // 
            // 
            this.tChartData.Legend.Title.Font.Brush.Color = System.Drawing.Color.Black;
            this.tChartData.Legend.Title.Font.Brush.Solid = true;
            this.tChartData.Legend.Title.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Legend.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.Legend.Title.Font.Shadow.Brush.Solid = true;
            this.tChartData.Legend.Title.Font.Shadow.Brush.Visible = true;
            this.tChartData.Legend.Title.Font.Size = 8;
            this.tChartData.Legend.Title.Font.SizeFloat = 8F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Legend.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChartData.Legend.Title.ImageBevel.Brush.Solid = true;
            this.tChartData.Legend.Title.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Legend.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.Legend.Title.Shadow.Brush.Solid = true;
            this.tChartData.Legend.Title.Shadow.Brush.Visible = true;
            this.tChartData.Legend.Visible = false;
            this.tChartData.Location = new System.Drawing.Point(385, 78);
            this.tChartData.Name = "tChartData";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Panel.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChartData.Panel.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tChartData.Panel.Brush.Solid = true;
            this.tChartData.Panel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Panel.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChartData.Panel.ImageBevel.Brush.Solid = true;
            this.tChartData.Panel.ImageBevel.Brush.Visible = true;
            this.tChartData.Panel.ImageBevel.Width = 1;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Panel.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.Panel.Shadow.Brush.Solid = true;
            this.tChartData.Panel.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            margins1.Bottom = 100;
            margins1.Left = 100;
            margins1.Right = 100;
            margins1.Top = 100;
            this.tChartData.Printer.Margins = margins1;
            this.tChartData.Series.Add(this.line1);
            this.tChartData.Size = new System.Drawing.Size(231, 337);
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.SubFooter.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChartData.SubFooter.Brush.Color = System.Drawing.Color.Silver;
            this.tChartData.SubFooter.Brush.Solid = true;
            this.tChartData.SubFooter.Brush.Visible = true;
            // 
            // 
            // 
            this.tChartData.SubFooter.Font.Bold = false;
            // 
            // 
            // 
            this.tChartData.SubFooter.Font.Brush.Color = System.Drawing.Color.Red;
            this.tChartData.SubFooter.Font.Brush.Solid = true;
            this.tChartData.SubFooter.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.SubFooter.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.SubFooter.Font.Shadow.Brush.Solid = true;
            this.tChartData.SubFooter.Font.Shadow.Brush.Visible = true;
            this.tChartData.SubFooter.Font.Size = 8;
            this.tChartData.SubFooter.Font.SizeFloat = 8F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.SubFooter.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChartData.SubFooter.ImageBevel.Brush.Solid = true;
            this.tChartData.SubFooter.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.SubFooter.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.SubFooter.Shadow.Brush.Solid = true;
            this.tChartData.SubFooter.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.SubHeader.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChartData.SubHeader.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tChartData.SubHeader.Brush.Solid = true;
            this.tChartData.SubHeader.Brush.Visible = true;
            // 
            // 
            // 
            this.tChartData.SubHeader.Font.Bold = false;
            // 
            // 
            // 
            this.tChartData.SubHeader.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChartData.SubHeader.Font.Brush.Solid = true;
            this.tChartData.SubHeader.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.SubHeader.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.SubHeader.Font.Shadow.Brush.Solid = true;
            this.tChartData.SubHeader.Font.Shadow.Brush.Visible = true;
            this.tChartData.SubHeader.Font.Size = 12;
            this.tChartData.SubHeader.Font.SizeFloat = 12F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.SubHeader.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChartData.SubHeader.ImageBevel.Brush.Solid = true;
            this.tChartData.SubHeader.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.SubHeader.Shadow.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.tChartData.SubHeader.Shadow.Brush.Solid = true;
            this.tChartData.SubHeader.Shadow.Brush.Visible = true;
            this.tChartData.TabIndex = 14;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Walls.Back.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChartData.Walls.Back.Brush.Color = System.Drawing.Color.Silver;
            this.tChartData.Walls.Back.Brush.Solid = true;
            this.tChartData.Walls.Back.Brush.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Walls.Back.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChartData.Walls.Back.ImageBevel.Brush.Solid = true;
            this.tChartData.Walls.Back.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Walls.Back.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.Walls.Back.Shadow.Brush.Solid = true;
            this.tChartData.Walls.Back.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Walls.Bottom.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChartData.Walls.Bottom.Brush.Color = System.Drawing.Color.White;
            this.tChartData.Walls.Bottom.Brush.Solid = true;
            this.tChartData.Walls.Bottom.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Walls.Bottom.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChartData.Walls.Bottom.ImageBevel.Brush.Solid = true;
            this.tChartData.Walls.Bottom.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Walls.Bottom.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.Walls.Bottom.Shadow.Brush.Solid = true;
            this.tChartData.Walls.Bottom.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Walls.Left.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChartData.Walls.Left.Brush.Color = System.Drawing.Color.LightYellow;
            this.tChartData.Walls.Left.Brush.Solid = true;
            this.tChartData.Walls.Left.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Walls.Left.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChartData.Walls.Left.ImageBevel.Brush.Solid = true;
            this.tChartData.Walls.Left.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Walls.Left.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.Walls.Left.Shadow.Brush.Solid = true;
            this.tChartData.Walls.Left.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Walls.Right.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChartData.Walls.Right.Brush.Color = System.Drawing.Color.LightYellow;
            this.tChartData.Walls.Right.Brush.Solid = true;
            this.tChartData.Walls.Right.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Walls.Right.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChartData.Walls.Right.ImageBevel.Brush.Solid = true;
            this.tChartData.Walls.Right.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Walls.Right.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChartData.Walls.Right.Shadow.Brush.Solid = true;
            this.tChartData.Walls.Right.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Zoom.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.tChartData.Zoom.Brush.Solid = true;
            this.tChartData.Zoom.Brush.Visible = false;
            this.tChartData.AfterDraw += new Steema.TeeChart.PaintChartEventHandler(this.tChartData_AfterDraw);
            this.tChartData.BeforeDrawSeries += new Steema.TeeChart.PaintChartEventHandler(this.tChartData_BeforeDrawSeries);
            // 
            // line1
            // 
            // 
            // 
            // 
            this.line1.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(153)))), ((int)(((byte)(214)))));
            this.line1.Brush.Solid = true;
            this.line1.Brush.Visible = true;
            this.line1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(153)))), ((int)(((byte)(214)))));
            this.line1.ColorEach = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.line1.Legend.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.line1.Legend.Brush.Color = System.Drawing.Color.White;
            this.line1.Legend.Brush.Solid = true;
            this.line1.Legend.Brush.Visible = true;
            // 
            // 
            // 
            this.line1.Legend.Font.Bold = false;
            // 
            // 
            // 
            this.line1.Legend.Font.Brush.Color = System.Drawing.Color.Black;
            this.line1.Legend.Font.Brush.Solid = true;
            this.line1.Legend.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.line1.Legend.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.line1.Legend.Font.Shadow.Brush.Solid = true;
            this.line1.Legend.Font.Shadow.Brush.Visible = true;
            this.line1.Legend.Font.Size = 8;
            this.line1.Legend.Font.SizeFloat = 8F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.line1.Legend.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.line1.Legend.ImageBevel.Brush.Solid = true;
            this.line1.Legend.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.line1.Legend.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.line1.Legend.Shadow.Brush.Solid = true;
            this.line1.Legend.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            this.line1.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(92)))), ((int)(((byte)(128)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.line1.Marks.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.line1.Marks.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.line1.Marks.Brush.Solid = true;
            this.line1.Marks.Brush.Visible = true;
            // 
            // 
            // 
            this.line1.Marks.Font.Bold = false;
            // 
            // 
            // 
            this.line1.Marks.Font.Brush.Color = System.Drawing.Color.Black;
            this.line1.Marks.Font.Brush.Solid = true;
            this.line1.Marks.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.line1.Marks.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.line1.Marks.Font.Shadow.Brush.Solid = true;
            this.line1.Marks.Font.Shadow.Brush.Visible = true;
            this.line1.Marks.Font.Size = 8;
            this.line1.Marks.Font.SizeFloat = 8F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.line1.Marks.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.line1.Marks.ImageBevel.Brush.Solid = true;
            this.line1.Marks.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.line1.Marks.Shadow.Brush.Color = System.Drawing.Color.Gray;
            this.line1.Marks.Shadow.Brush.Solid = true;
            this.line1.Marks.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.line1.Marks.Symbol.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.line1.Marks.Symbol.Brush.Color = System.Drawing.Color.White;
            this.line1.Marks.Symbol.Brush.Solid = true;
            this.line1.Marks.Symbol.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.line1.Marks.Symbol.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.line1.Marks.Symbol.ImageBevel.Brush.Solid = true;
            this.line1.Marks.Symbol.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.line1.Marks.Symbol.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.line1.Marks.Symbol.Shadow.Brush.Solid = true;
            this.line1.Marks.Symbol.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            this.line1.Marks.TailParams.CustomPointPos = ((System.Drawing.PointF)(resources.GetObject("resource.CustomPointPos")));
            this.line1.Marks.TailParams.Margin = 0F;
            this.line1.Marks.TailParams.PointerHeight = 8D;
            this.line1.Marks.TailParams.PointerWidth = 8D;
            this.line1.OriginalCursor = null;
            // 
            // 
            // 
            // 
            // 
            // 
            this.line1.Pointer.Brush.Color = System.Drawing.Color.Red;
            this.line1.Pointer.Brush.Solid = true;
            this.line1.Pointer.Brush.Visible = true;
            this.line1.Pointer.SizeDouble = 0D;
            this.line1.Pointer.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels;
            this.line1.Title = "line1";
            this.line1.UseExtendedNumRange = false;
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
            this.numericUpDownDiff.Maximum = new decimal(new int[] {
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
            this.label6.Size = new System.Drawing.Size(84, 13);
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
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 0;
            this.buttonLoad.Text = "&Load";
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // wizardPageModel
            // 
            this.wizardPageModel.Controls.Add(this.arGroup);
            this.wizardPageModel.Controls.Add(this.arimaGroup);
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
            // arGroup
            // 
            this.arGroup.Controls.Add(this.arComboBox);
            this.arGroup.Location = new System.Drawing.Point(232, 171);
            this.arGroup.Name = "arGroup";
            this.arGroup.Size = new System.Drawing.Size(164, 80);
            this.arGroup.TabIndex = 9;
            this.arGroup.TabStop = false;
            this.arGroup.Text = "Preliminary estimation";
            this.arGroup.Visible = false;
            // 
            // arComboBox
            // 
            this.arComboBox.Items.AddRange(new object[] {
            "Fixed",
            "Yule-Walker",
            "Burg"});
            this.arComboBox.Location = new System.Drawing.Point(6, 19);
            this.arComboBox.Name = "arComboBox";
            this.arComboBox.Size = new System.Drawing.Size(152, 21);
            this.arComboBox.TabIndex = 0;
            this.arComboBox.SelectedIndexChanged += new System.EventHandler(this.arComboBox_SelectedIndexChanged);
            // 
            // arimaGroup
            // 
            this.arimaGroup.Controls.Add(this.arimaComboBox);
            this.arimaGroup.Location = new System.Drawing.Point(232, 78);
            this.arimaGroup.Name = "arimaGroup";
            this.arimaGroup.Size = new System.Drawing.Size(164, 80);
            this.arimaGroup.TabIndex = 8;
            this.arimaGroup.TabStop = false;
            this.arimaGroup.Text = "Preliminary estimation";
            this.arimaGroup.Visible = false;
            // 
            // arimaComboBox
            // 
            this.arimaComboBox.Items.AddRange(new object[] {
            "User supplied",
            "Yule-Walker",
            "Burg",
            "Innovations",
            "Hannah-Rissanen"});
            this.arimaComboBox.Location = new System.Drawing.Point(6, 19);
            this.arimaComboBox.Name = "arimaComboBox";
            this.arimaComboBox.Size = new System.Drawing.Size(152, 21);
            this.arimaComboBox.TabIndex = 0;
            this.arimaComboBox.SelectedIndexChanged += new System.EventHandler(this.arimaComboBox_SelectedIndexChanged);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label10);
            this.groupBox10.Controls.Add(this.maCoeffButton);
            this.groupBox10.Controls.Add(this.arCoeffButton);
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
            // maCoeffButton
            // 
            this.maCoeffButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maCoeffButton.Location = new System.Drawing.Point(6, 48);
            this.maCoeffButton.Name = "maCoeffButton";
            this.maCoeffButton.Size = new System.Drawing.Size(95, 23);
            this.maCoeffButton.TabIndex = 1;
            this.maCoeffButton.Text = "MA coefficients";
            this.maCoeffButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // arCoeffButton
            // 
            this.arCoeffButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.arCoeffButton.Location = new System.Drawing.Point(6, 19);
            this.arCoeffButton.Name = "arCoeffButton";
            this.arCoeffButton.Size = new System.Drawing.Size(95, 23);
            this.arCoeffButton.TabIndex = 0;
            this.arCoeffButton.Text = "AR coefficients";
            this.arCoeffButton.Click += new System.EventHandler(this.button2_Click);
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
            this.checkBoxMLE.Checked = true;
            this.checkBoxMLE.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMLE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxMLE.Location = new System.Drawing.Point(9, 28);
            this.checkBoxMLE.Name = "checkBoxMLE";
            this.checkBoxMLE.Size = new System.Drawing.Size(151, 17);
            this.checkBoxMLE.TabIndex = 0;
            this.checkBoxMLE.Text = "Do MLE estimation";
            this.checkBoxMLE.CheckedChanged += new System.EventHandler(this.checkBoxMLE_CheckedChanged);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.maUpDown);
            this.groupBox12.Controls.Add(this.label11);
            this.groupBox12.Controls.Add(this.arUpDown);
            this.groupBox12.Controls.Add(this.label12);
            this.groupBox12.Location = new System.Drawing.Point(12, 78);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(200, 80);
            this.groupBox12.TabIndex = 5;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Order";
            // 
            // maUpDown
            // 
            this.maUpDown.Location = new System.Drawing.Point(62, 50);
            this.maUpDown.Name = "maUpDown";
            this.maUpDown.Size = new System.Drawing.Size(58, 20);
            this.maUpDown.TabIndex = 3;
            this.maUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maUpDown.ValueChanged += new System.EventHandler(this.maUpDown_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "MA order";
            // 
            // arUpDown
            // 
            this.arUpDown.Location = new System.Drawing.Point(61, 24);
            this.arUpDown.Name = "arUpDown";
            this.arUpDown.Size = new System.Drawing.Size(58, 20);
            this.arUpDown.TabIndex = 1;
            this.arUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.arUpDown.ValueChanged += new System.EventHandler(this.arUpDown_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
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
            this.numericUpDownACFLag.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDownACFLag.Name = "numericUpDownACFLag";
            this.numericUpDownACFLag.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownACFLag.TabIndex = 8;
            this.numericUpDownACFLag.Value = new decimal(new int[] {
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
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "ACF lag";
            // 
            // numericUpDownForNum
            // 
            this.numericUpDownForNum.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownForNum.Location = new System.Drawing.Point(90, 79);
            this.numericUpDownForNum.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numericUpDownForNum.Name = "numericUpDownForNum";
            this.numericUpDownForNum.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownForNum.TabIndex = 6;
            this.numericUpDownForNum.Value = new decimal(new int[] {
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
            this.label14.Size = new System.Drawing.Size(72, 13);
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
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "MA order";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
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
            this.wizardPageReport.PerformLayout();
            this.wizardPageFormat.ResumeLayout(false);
            this.wizardPageFormat.PerformLayout();
            this.wizardPageTimeSeries.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDiff)).EndInit();
            this.wizardPageModel.ResumeLayout(false);
            this.arGroup.ResumeLayout(false);
            this.arimaGroup.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arUpDown)).EndInit();
            this.wizardPageForecasts.ResumeLayout(false);
            this.wizardPageForecasts.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownACFLag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownForNum)).EndInit();
            this.groupBoxInitMA.ResumeLayout(false);
            this.groupBoxEditPhiTheta.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
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
            arGroup.Visible = ((p > 0) && (q == 0));
            arimaGroup.Visible = (q > 0);
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

            arUpDown_ValueChanged(sender, e);
            maUpDown_ValueChanged(sender, e);

            arComboBox.SelectedIndex = 1; //Yule-Walker
            arComboBox_SelectedIndexChanged(sender, e);

            arimaComboBox.SelectedIndex = 1; //Yule-Walker
            arimaComboBox_SelectedIndexChanged(sender, e);

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

        private void arUpDown_ValueChanged(object sender, EventArgs e)
        {
            p = (int)arUpDown.Value;
            phi.Length = p;
            phi.SetZero();

            phiInit.Size(phi);
            phiInit.SetZero();

            RefreshModelControls();
            RefreshWizardControls();
        }

        private void maUpDown_ValueChanged(object sender, EventArgs e)
        {
            q = (int)maUpDown.Value;
            theta.Length = q;

            thetaInit.Size(theta);
            thetaInit.SetZero();

            RefreshModelControls();
            RefreshWizardControls();
        }

        private void arimaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (arimaComboBox.SelectedIndex)
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

        private void checkBoxMLE_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void arComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (arComboBox.SelectedIndex)
            {
                case 0: 
                    armainit = TcfInitMethod.cfInitFixed; 
                    break;
                case 1: // Yule-Walker
                    armainit = TcfInitMethod.cfInitYW; 
                    break;
                case 2: // Burg
                    armainit = TcfInitMethod.cfInitBurg; 
                    break;
                default: // user supplied
                    armainit = TcfInitMethod.cfInitFixed; 
                    break;
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

