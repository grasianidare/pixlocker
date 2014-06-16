/*
 * Created by SharpDevelop.
 * User: graco
 * Date: 6/15/2014
 * Time: 6:55 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PixLocker
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void MainFormLoad(object sender, System.EventArgs e)
		{
			label1.Visible =false;
			
		}
		void TmGOGOGOTick(object sender, System.EventArgs e)
		{
			Point rato = System.Windows.Forms.Cursor.Position;
			
			
			Color pxCor = WinPixel.GetPixelColor(rato.X, rato.Y);

			
			pnColor.BackColor = pxCor;
			pnRed.Width = Convert.ToInt32(pxCor.R);
			pnGreen.Width = Convert.ToInt32(pxCor.G);
			pnBlue.Width = Convert.ToInt32(pxCor.B);
			
			
			
			lbHue.Text = pxCor.GetHue().ToString("N5");  //Math.Truncate(pxCor.GetHue()).ToString();
			lbLuminance.Text = pxCor.GetBrightness().ToString("N5");  //Math.Truncate(pxCor.GetBrightness()).ToString();
			lbSaturation.Text = pxCor.GetSaturation().ToString("N5");  //Math.Truncate(pxCor.GetSaturation()).ToString();
			
			lbRed.Text = pxCor.R.ToString();
			lbGreen.Text = pxCor.G.ToString();
			lbBlue.Text = pxCor.B.ToString();
			

			
		}
	}
}
