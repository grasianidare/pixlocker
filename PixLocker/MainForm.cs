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
using System.Diagnostics;

namespace PixLocker
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private bool mouseLocked;
		private const string AppTitle = "PixLocker.NET";
		
		private Point freezedMouse;
		
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
		
		private Color GetRgb(double r, double g, double b)
        {
            return Color.FromArgb(255, (byte)(r * 255.0), (byte)(g * 255.0), (byte)(b * 255.0));
        }
		
		private Color ColorfromLum(float lum)
		{
			double h = 0;
			double s = 0;
			double v = lum;
			
            int hi = (int)Math.Floor(h / 60.0) % 6;
            double f = (h / 60.0) - Math.Floor(h / 60.0);

            double p = v * (1.0 - s);
            double q = v * (1.0 - (f * s));
            double t = v * (1.0 - ((1.0 - f) * s));

            Color ret;

            switch (hi)
            {
                case 0:
                    ret = GetRgb(v, t, p);
                    break;
                case 1:
                    ret = GetRgb(q, v, p);
                    break;
                case 2:
                    ret = GetRgb(p, v, t);
                    break;
                case 3:
                    ret = GetRgb(p, q, v);
                    break;
                case 4:
                    ret = GetRgb(t, p, v);
                    break;
                case 5:
                    ret = GetRgb(v, p, q);
                    break;
                default:
                    ret = Color.FromArgb(0xFF, 0x00, 0x00, 0x00);
                    break;
            }
            return ret;
			
		}
		
		void MainFormLoad(object sender, System.EventArgs e)
		{
			this.KeyPreview = true;
			mouseLocked = false;
		}
		void TmGOGOGOTick(object sender, System.EventArgs e)
		{
			Point rato = (mouseLocked ? freezedMouse : System.Windows.Forms.Cursor.Position);
			
			
			Color pxCor = WinPixel.GetPixelColor(rato.X, rato.Y);

			
			pnColor.BackColor = pxCor;
			pnRed.Width = Convert.ToInt32(pxCor.R);
			pnGreen.Width = Convert.ToInt32(pxCor.G);
			pnBlue.Width = Convert.ToInt32(pxCor.B);
			
			
			
			lbHue.Text = pxCor.GetHue().ToString("N3");  //Math.Truncate(pxCor.GetHue()).ToString();
			lbLuminance.Text = pxCor.GetBrightness().ToString("N3");  //Math.Truncate(pxCor.GetBrightness()).ToString();
			lbSaturation.Text = pxCor.GetSaturation().ToString("N3");  //Math.Truncate(pxCor.GetSaturation()).ToString();
			
			lbRed.Text = pxCor.R.ToString();
			lbGreen.Text = pxCor.G.ToString();
			lbBlue.Text = pxCor.B.ToString();
			
			
			pnControl.BackColor = this.ColorfromLum(pxCor.GetBrightness());

			
		}
		void CbAlwaysCheckedChanged(object sender, System.EventArgs e)
		{
			this.TopMost = cbAlways.Checked;
		}
		void LinkLabel1LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://github.com/grasianidare/pixlocker");
		}
		void MainFormKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F2)
			{
				mouseLocked = !mouseLocked;
				freezedMouse = System.Windows.Forms.Cursor.Position;
			}
			
			this.Text = (mouseLocked ? "[!]" : "") + AppTitle;
					
		}
	}
}
