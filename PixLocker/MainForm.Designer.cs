/*
 * Created by SharpDevelop.
 * User: graco
 * Date: 6/15/2014
 * Time: 6:55 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace PixLocker
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.pnColor = new System.Windows.Forms.Panel();
			this.pnRed = new System.Windows.Forms.Panel();
			this.pnGreen = new System.Windows.Forms.Panel();
			this.pnBlue = new System.Windows.Forms.Panel();
			this.tmGOGOGO = new System.Windows.Forms.Timer(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lbLuminance = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.lbSaturation = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.lbHue = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lbBlue = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.lbGreen = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.lbRed = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.cbAlways = new System.Windows.Forms.CheckBox();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnColor
			// 
			this.pnColor.BackColor = System.Drawing.Color.Gray;
			resources.ApplyResources(this.pnColor, "pnColor");
			this.pnColor.Name = "pnColor";
			// 
			// pnRed
			// 
			this.pnRed.BackColor = System.Drawing.Color.Red;
			this.pnRed.ForeColor = System.Drawing.Color.Red;
			resources.ApplyResources(this.pnRed, "pnRed");
			this.pnRed.Name = "pnRed";
			// 
			// pnGreen
			// 
			this.pnGreen.BackColor = System.Drawing.Color.Green;
			this.pnGreen.ForeColor = System.Drawing.Color.Green;
			resources.ApplyResources(this.pnGreen, "pnGreen");
			this.pnGreen.Name = "pnGreen";
			// 
			// pnBlue
			// 
			this.pnBlue.BackColor = System.Drawing.Color.Blue;
			this.pnBlue.ForeColor = System.Drawing.Color.Blue;
			resources.ApplyResources(this.pnBlue, "pnBlue");
			this.pnBlue.Name = "pnBlue";
			// 
			// tmGOGOGO
			// 
			this.tmGOGOGO.Enabled = true;
			this.tmGOGOGO.Interval = 10;
			this.tmGOGOGO.Tick += new System.EventHandler(this.TmGOGOGOTick);
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			resources.ApplyResources(this.tabControl1, "tabControl1");
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.Controls.Add(this.groupBox1);
			resources.ApplyResources(this.tabPage1, "tabPage1");
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lbLuminance);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.lbSaturation);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.lbHue);
			this.groupBox2.Controls.Add(this.label13);
			resources.ApplyResources(this.groupBox2, "groupBox2");
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.TabStop = false;
			// 
			// lbLuminance
			// 
			resources.ApplyResources(this.lbLuminance, "lbLuminance");
			this.lbLuminance.Name = "lbLuminance";
			// 
			// label9
			// 
			resources.ApplyResources(this.label9, "label9");
			this.label9.Name = "label9";
			// 
			// lbSaturation
			// 
			resources.ApplyResources(this.lbSaturation, "lbSaturation");
			this.lbSaturation.Name = "lbSaturation";
			// 
			// label11
			// 
			resources.ApplyResources(this.label11, "label11");
			this.label11.Name = "label11";
			// 
			// lbHue
			// 
			resources.ApplyResources(this.lbHue, "lbHue");
			this.lbHue.Name = "lbHue";
			// 
			// label13
			// 
			resources.ApplyResources(this.label13, "label13");
			this.label13.Name = "label13";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lbBlue);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.lbGreen);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.lbRed);
			this.groupBox1.Controls.Add(this.label2);
			resources.ApplyResources(this.groupBox1, "groupBox1");
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.TabStop = false;
			// 
			// lbBlue
			// 
			resources.ApplyResources(this.lbBlue, "lbBlue");
			this.lbBlue.Name = "lbBlue";
			// 
			// label7
			// 
			resources.ApplyResources(this.label7, "label7");
			this.label7.Name = "label7";
			// 
			// lbGreen
			// 
			resources.ApplyResources(this.lbGreen, "lbGreen");
			this.lbGreen.Name = "lbGreen";
			// 
			// label5
			// 
			resources.ApplyResources(this.label5, "label5");
			this.label5.Name = "label5";
			// 
			// lbRed
			// 
			resources.ApplyResources(this.lbRed, "lbRed");
			this.lbRed.Name = "lbRed";
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.cbAlways);
			resources.ApplyResources(this.tabPage2, "tabPage2");
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// tabPage3
			// 
			resources.ApplyResources(this.tabPage3, "tabPage3");
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// cbAlways
			// 
			resources.ApplyResources(this.cbAlways, "cbAlways");
			this.cbAlways.Name = "cbAlways";
			this.cbAlways.UseVisualStyleBackColor = true;
			this.cbAlways.CheckedChanged += new System.EventHandler(this.CbAlwaysCheckedChanged);
			// 
			// MainForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pnBlue);
			this.Controls.Add(this.pnGreen);
			this.Controls.Add(this.pnRed);
			this.Controls.Add(this.pnColor);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.CheckBox cbAlways;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lbLuminance;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label lbSaturation;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label lbHue;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lbBlue;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lbGreen;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lbRed;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Timer tmGOGOGO;
		private System.Windows.Forms.Panel pnColor;
		private System.Windows.Forms.Panel pnRed;
		private System.Windows.Forms.Panel pnGreen;
		private System.Windows.Forms.Panel pnBlue;
	}
}
