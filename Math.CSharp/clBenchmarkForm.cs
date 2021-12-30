using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Dew.Math;
using Dew.Math.Units;

namespace MtxVecDemo
{
    public partial class clBenchmarkForm : Form
    {
        int VectorLen;
        Dew.Math.TOpenCLDevice selectedDevice;
        TOpenCLPlatformList clPlatforms;

        public clBenchmarkForm()
        {
            InitializeComponent();
            clPlatforms = clMtxVec.clPlatform();
        }

        private void clBenchmarkForm_Load(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "The platform list shows the Open CL drivers  " +
                                        "available on your computer. If you dont have a AMD or Nvidia GPU "
            + "you can still install Intel or Open CL drivers which "
            + "run on the CPU alone. Note that GPU device speed is sensitive "
            + "to vector lengths which are not divisable by 4. "
            + "Intel drivers require at least SSE4.x (Core 2) capable hardware. "
            + "Presence of Intel drivers also slows down the start of the "
            + "application by 20seconds. \n"
            + "Select various functions and see how they perform in compare to "
            + "intel IPP (MtxVec) and native C# code. Dont forget however "
            + "that data also needs to be copied to GPU and back and this is "
            + "currently still fairly slow.\n"
            + "If the same graphics card is used also for display next to its OpenCL purpose "
            + "the performance degradation of Open CL code can be substantial. This depends largely also "
            + "on the amount of total memory allocated on the GPU by the Open CL library.\n";

        //Main form requires:
        //protected override void Dispose( bool disposing )
		//{
        //    clMtxVec.clPlatform.Free();

            int i;
            i = (int)(sizeof(double) * 8);            

            floatPrecisionBox.SelectedIndex = 0;
            cpuFloatPrecisionLabel.Text = "CPU (MtxVec) float precision: " + i.ToString() + "bit";
            //    ReportMemoryLeaksOnShutDown = True;

            for (i = 0; i < clPlatforms.Count; i++)
            {
                platformListBox.Items.Add(clPlatforms[i].Name);
            }

            platformListBox.SelectedIndex = 0;

            deviceListBox.Items.Clear();

            for (i = 0; i < clPlatforms[0].Count; i++)
            {
                deviceListBox.Items.Add(clPlatforms[0][i].Name);
            }

            deviceListBox.SelectedIndex = 0;

            MessageBox.Show("When loading the first time, the Open CL drivers need to recompile the source code."
                      + "This may take a minute or longer. If you have Intel Open CL drivers installed they "
                      + "add 20s delay regardless, if the program is precompiled.");

            this.Cursor = Cursors.WaitCursor;
            //    clPlatform.SaveDefaultToRes("C:\CommonObjects\Dew MtxVec.NET\");
            clPlatforms.LoadProgramsForDevices(false, false, true, false, false);
            this.Cursor = Cursors.Default;
            functionBox.SelectedIndex = 0;

            VectorLen = (int)Math.Round(Math387.Exp2(19));
            vectorLengthBox.Text = VectorLen.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int CacheLength;

            VectorLen = Convert.ToInt32(vectorLengthBox.Text);
            CacheLength = VectorLen;
            if (complexBox.Checked) CacheLength = CacheLength * 2;
            if (floatPrecisionBox.SelectedIndex > 0) CacheLength = CacheLength * 2;

            clPlatforms.UnMarkThreads();
            selectedDevice = clPlatforms[platformListBox.SelectedIndex][deviceListBox.SelectedIndex];
            selectedDevice.Cache.SetCacheSize(12, CacheLength, 12, 12, 12);
            selectedDevice.CommandQueue[0].MarkThread(); //UserThread := GetCurrentThreadID;
            DoCompute();

        }        
        private void platformListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
              int i;
              TStringList DeviceList = new TStringList();

              for (i = 0; i < clPlatforms[platformListBox.SelectedIndex].Count; i++)  {
                     DeviceList.Add(clPlatforms[platformListBox.SelectedIndex][i].Name);
              }

              deviceListBox.Items.Clear();
              for (i = 0; i < DeviceList.Count; i++)
              {
                   deviceListBox.Items.Add(DeviceList[i]);
              }
              deviceListBox.SelectedIndex = 0;
        }

        private void DoCompute()
        {
                Vector B,C, R;
                int i, k, IterCount;
                double aTime, bTime;
                double ScalarB;
                TOpenCLVector clB, clC, clA, clD;
                double a;
                TCplx ac;

                B = new Vector(0);
                C = new Vector(0);
                R = new Vector(0);
                this.Cursor = Cursors.WaitCursor;
                clMtxVec.CreateIt(out clB,out clC);
                clMtxVec.CreateIt(out clA, out clD);
                try
                {                    
                    clC.FloatPrecision = (TclFloatPrecision) floatPrecisionBox.SelectedIndex;
                    clB.FloatPrecision = clC.FloatPrecision;

                    a = 1;
                    ScalarB = 1.02;
                    memo.Clear();

                    memo.AppendText("Vector length = " + Convert.ToString(VectorLen) + "\n");
                    memo.AppendText("Float size = " + Convert.ToString((sizeof(double)) + " bytes") + "\n");

                    IterCount = 1;
                    switch (functionBox.SelectedIndex)
                    {
                        case 0: IterCount = 1096;
                                break;
                        case 1: IterCount = 64;
                                break;
                        case 2: IterCount = 32;
                                break;
                        case 3: IterCount = 32;
                                break;
                    }

                    B.Size(VectorLen, complexBox.Checked);
                    B.SetVal(ScalarB);
                    C.Size(VectorLen, complexBox.Checked);
                    C.SetVal(1);

                    //warm up the cache
                    B.Copy(C);
                    C.Copy(B);

                    Math387.StartTimer();
                    B.Copy(C);
                    C.Copy(B);
                    aTime = Math387.StopTimer();
                    memo.AppendText("Copy CPU->CPU (2x) = " + Math387.FormatSample("0.00us",aTime*1000*1000) + "\n");

                    B.SetVal(ScalarB);
                    C.SetVal(1);

                    Math387.StartTimer();
                    clC.Copy(C);
                    clB.Copy(B);
                    aTime = Math387.StopTimer();
                    memo.AppendText("Copy CPU->GPU (2x) = " + Math387.FormatSample("0.00us", aTime * 1000 * 1000) + "\n");

                    Math387.StartTimer();
                    for (i = 0; i < IterCount; i++)
                    {
                         switch (functionBox.SelectedIndex)
                         {
                         case 0: clC.Mul(clB);
                                 break;  
                         case 1: clA.Sin(clB);
                                 clD.Sin(clC);
                                 clC.Add(clA, clD);                
                                 break;
                         case 2: clA.Sqr(clB);
                                 clC.Mul(clA, -0.5 * a);
                                 clC.Exp();
                                 clD.Mul(clA, clC);
                                 clC.Mul(clD, Math.Sqrt(4 * a /(2*Math387.PI)) * a);

                                 //C = Math.Sqrt(4 * a / (2 * Math387.PI)) * a * MtxExpr.Sqr(B) * MtxExpr.Exp(-0.5 * a * MtxExpr.Sqr(B));
                                 break;
                         case 3: if (!clB.Complex) { ScalarB = clB.Mean(); } else { ScalarB = clB.Meanc().Re; };
                                 break;
                         }
                    }
                    clC.CopyTo(R); //from GPU to CPU
                    aTime = Math387.StopTimer();
                    memo.AppendText("");
                    memo.AppendText("Open CL timings:+ \n");
                    memo.AppendText("\n");
                    memo.AppendText("Function kernel (1x)  = " + Math387.FormatSample("0.00us", aTime * 1000 * 1000 / IterCount) + ", TotalTime = " + Math387.FormatSample("0.000s", aTime) + "\n");

                    B.SetVal(ScalarB);
                    C.SetVal(1);

                    Math387.StartTimer();
                    for (i = 0; i < IterCount; i++)
                    {
                         switch (functionBox.SelectedIndex)
                         {
                         case 0: C = C * B;
                                 break;
                         case 1: C = MtxExpr.Sin(C) + MtxExpr.Sin(B);
                                 break;
                         case 2: C = Math.Sqrt(4 * a /(2*Math387.PI)) * a * MtxExpr.Sqr(B) * MtxExpr.Exp(-0.5 * a * MtxExpr.Sqr(B));
                                 break;
                         case 3: if (!B.Complex) { a = B.Mean(); } else { a = B.Meanc().Re; };
                                 break;
                         }
                    }
                    bTime = Math387.StopTimer();

                    memo.AppendText("\n");
                    memo.AppendText("Intel IPP timings:\n");
                    memo.AppendText("\n");
                    memo.AppendText("IPP (1x) = " + Math387.FormatSample("0.00us", bTime * 1000 * 1000 / IterCount) + ", TotalTime = " + Math387.FormatSample("0.000s", bTime) + "\n");
                    memo.AppendText("Ratio OpenCL/IPP = " + Math387.FormatSample("0.00x", bTime / aTime) + "\n");
                    memo.AppendText("Ratio OpenCL/(Threaded IPP) = " + Math387.FormatSample("0.00x", bTime / (aTime * MtxVec.Controller.CpuCores * 0.9)) + "\n");
                    memo.AppendText("Time/element = " + Math387.FormatSample("0.000ns", bTime * (1000000.0 / IterCount) * (1000.0 / VectorLen)) + "\n");

                    switch (functionBox.SelectedIndex) 
                    {
                        case 0:
                        case 1:
                        case 2: if (!R.IsEqual(C, 0.01, TCompare.cmpRelative)) Math387.ERaise("CPU and GPU results not equal!");
                        //    3: if not Equal(ScalarB, a, 0.001) then ERaise("GPU results more accurate!");
                            break;
                    }


                    B.SetVal(ScalarB);
                    C.SetVal(1);

                    Math387.StartTimer();
                    for (i = 0; i < (IterCount/4); i++)
                    {
                         a = 0;
                         ac = "0";
                         if (complexBox.Checked)
                         {
                             switch (functionBox.SelectedIndex)
                             {
                             case 0: for (k = 0; k < C.Length; k++) C.CValues[k] = C.CValues[k] * B.CValues[k];
                                     break;
                             case 1: for (k = 0; k < C.Length; k++) C.CValues[k] = Math387.Sin(C.CValues[k]) + Math387.Sin(B.CValues[k]);
                                     break;
                             case 2: for (k = 0; k < C.Length; k++) C.CValues[k] = Math.Sqrt(4 * a /(2*Math387.PI)) * a * Math387.CSqr(B.CValues[k]) * Math387.Exp(-0.5 * a * Math387.CSqr(B.CValues[k]));
                                     break;
                             case 3: for (k = 0; k < C.Length; k++) ac = ac  + C.CValues[k];
                                     break;
                             }
         
                        } 
                        else
                        {
                             switch (functionBox.SelectedIndex)
                             {
                             case 0: for (k = 0; k < C.Length; k++) C.Values[k] = C.Values[k] * B.Values[k];
                                     break;
                             case 1: for (k = 0; k < C.Length; k++) C.Values[k] = Math.Sin(C.Values[k]) + Math.Sin(B.Values[k]);
                                     break;
                             case 2: for (k = 0; k < C.Length; k++) C.Values[k] = Math.Sqrt(4 * a /(2*Math387.PI)) * a * (B.Values[k]*B.Values[k]) * Math.Exp(-0.5 * a * (B.Values[k]*B.Values[k]));
                                     break;
                             case 3: for (k = 0; k < C.Length; k++) a = a  + C.Values[k];
                                     break;
                             }
                         }
                    }
                    bTime = Math387.StopTimer()*4; //simulate longer running time

                    memo.AppendText("\n");
                    memo.AppendText("C# timings:\n");
                    memo.AppendText("\n");
                    memo.AppendText("C# (1x) = " + Math387.FormatSample("0.00us", bTime * 1000 * 1000 / IterCount) + ", TotalTime = " + Math387.FormatSample("0.000s", bTime) + "\n");
                    memo.AppendText("Ratio OpenCL/C# = " + Math387.FormatSample("0.00x", bTime / aTime) + "\n");
                    memo.AppendText("Ratio OpenCL/(Threaded C#)  = " + Math387.FormatSample("0.00x", bTime / (aTime * MtxVec.Controller.CpuCores * 0.9)) + "\n");
                    memo.AppendText("Time/element = " + Math387.FormatSample("0.000ns", bTime * (1000000.0 / IterCount) * (1000.0 / VectorLen)) + "\n");
                }
                finally
                {
                    clMtxVec.FreeIt(ref clA, ref clB, ref clC, ref clD);
                    this.Cursor = Cursors.Default;
                }
         }
         
    }
}
