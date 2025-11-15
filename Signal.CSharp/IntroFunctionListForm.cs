using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace DSPDemo
{
	public class IntroFunctionListForm : DSPDemo.BasicForm3
	{
		private System.ComponentModel.IContainer components = null;

		public IntroFunctionListForm()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			richTextBox1.LoadFile( Dew.Demo.Utils.SourcePath() + @"\Data\Routines.rtf");
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Size = new System.Drawing.Size(612, 422);
            // 
            // IntroFunctionListForm
            // 
            this.ClientSize = new System.Drawing.Size(612, 422);
            this.Name = "IntroFunctionListForm";
            this.ResumeLayout(false);

		}
		#endregion
	}
}

