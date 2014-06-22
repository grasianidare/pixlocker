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
		private int lastPixelX;
		private int lastPixelY;
		
		struct MyPoint
		{
			public int x;
			public int y;

			public bool IsValid()
			{
				return ((x >= 0) && (y >= 0) && (x <= (SystemInformation.VirtualScreen.Width -1)) && (y <= (SystemInformation.VirtualScreen.Height -1)));
			}
		}
		
		
		//private IniParser ini;
		//INI consts....
		private const string AppTitle = "PixLocker.NET";
		private const string IniConf = "CONF";
		private const string IniAlways = "ALWAYSONTOP";

		
		private bool mouseLocked;
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
			this.KeyPreview = true; //so the F2 key work
			mouseLocked = false; //is the mouse location locked?
			lbF2.Text = "F2 to " + (mouseLocked ? "un" : "") + "lock";
			
			/* //testing ini files - .net don't like ini files :(
			string lol = System.IO.Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				AppTitle + ".ini");
			
			ini = new IniParser(lol);
			*/
			
			nudMedia.Maximum = SystemInformation.VirtualScreen.Height;
			lastPixelX = SystemInformation.VirtualScreen.Width -1;
			lastPixelY = SystemInformation.VirtualScreen.Height -1;
			
			
			/* //trying to read app.settings...
		<add key="AlwaysOnTop" value="true" />
		<add key="MediaPixel" value="true" />
		<add key="MediaRadius" value="2" />			 
			 */
			
			
			
			
		}
		
		private bool PXisValid(Point px)
		{
			return this.PXisValid(px.X, px.Y);
		}

		private bool PXisValid(int pxX, int pxY)
		{
			return ((pxX >= 0) && (pxX < lastPixelX) && (pxY >= 0) && (pxY < lastPixelY));
		}
		
		private Color SeaOfPixels(Point position, int radius)
		{
			int length = (radius * 2) + 1; //yeah, I know, but Murphy...
			MyPoint[,] squared = new MyPoint[length, length];
			Color[,] rainbow = new Color[length, length];
			int qtd = 0;
			int x0 = position.X - radius;
			int y0 = position.Y - radius;
			
			//for (int row = (position.X - length); row <= (position.X + length); row++)
			for (int row = 0; row < length; row++)
			{
				for (int col = 0; col < length; col++)
				{
					if (PXisValid(x0+row, y0+col))
					{
						qtd++;
						rainbow[row,col] = WinPixel.GetPixelColor(x0+row, y0+col);
					}
				}
			}
			
			//calculating media...
			int myR = 0;
			int myG = 0;
			int myB = 0;
				
			float myHu = 0;
			float mySa = 0;
			float myBr = 0;
			for (int row = 0; row < length; row++)
			{
				for (int col = 0; col < length; col++)
				{
					myR += rainbow[row,col].R;
					myG += rainbow[row,col].G;
					myB += rainbow[row,col].B;
						
					myHu += rainbow[row,col].GetHue();
					mySa += rainbow[row,col].GetSaturation();
					myBr += rainbow[row,col].GetBrightness();
				}
			}
			
			int meR = Convert.ToInt32(myR / qtd);
			int meG = Convert.ToInt32(myG / qtd);
			int meB = Convert.ToInt32(myB / qtd);
				
			return Color.FromArgb(255, meR, meG, meB);
			
		}
		
		void TmGOGOGOTick(object sender, System.EventArgs e)
		{
			//current mouse position
			Point rato = (mouseLocked ? freezedMouse : System.Windows.Forms.Cursor.Position);
			//color to show on the panel preview
			Color pxCor;
			
			if (cbMedia.Checked)
			{
				pxCor = this.SeaOfPixels(rato, Convert.ToInt32(nudMedia.Value));
				#region OldCode
				/*
				//distance
				int dist = Convert.ToInt32(nudMedia.Value);
				
				MyPoint[] pontos = new MyPoint[9];
				pontos[0].x = rato.X-dist;
				pontos[0].y = rato.Y-dist;
				
				pontos[1].x = rato.X;
				pontos[1].y = rato.Y-dist;
				
				pontos[2].x = rato.X+dist;
				pontos[2].y = rato.Y-dist;	
				
				pontos[3].x = rato.X-dist;
				pontos[3].y = rato.Y;
				
				pontos[4].x = rato.X;
				pontos[4].y = rato.Y;
				
				pontos[5].x = rato.X+dist;
				pontos[5].y = rato.Y;
				
				pontos[6].x = rato.X-dist;
				pontos[6].y = rato.Y+dist;
				
				pontos[7].x = rato.X;
				pontos[7].y = rato.Y+dist;
				
				pontos[8].x = rato.X+dist;
				pontos[8].y = rato.Y+dist;
				
				int qtd = 0;
				foreach(MyPoint p in pontos)
				{
					if (p.IsValid())
						qtd++;
				}
				
				Color[] paleta = new Color[9];
				for(int i = 0; i < 9; i++)
				{
					if (pontos[i].IsValid())
						paleta[i] = WinPixel.GetPixelColor(pontos[i].x, pontos[i].y);
				}
				
				int myR = 0;
				int myG = 0;
				int myB = 0;
				
				float myHu = 0;
				float mySa = 0;
				float myBr = 0;
				for(int i = 0; i < 9; i++)
				{
					if (pontos[i].IsValid())
					{
						myR += paleta[i].R;
						myG += paleta[i].G;
						myB += paleta[i].B;
						
						myHu += paleta[i].GetHue();
						mySa += paleta[i].GetSaturation();
						myBr += paleta[i].GetBrightness();
					}
				}

				int meR = Convert.ToInt32(myR / qtd);
				int meG = Convert.ToInt32(myG / qtd);
				int meB = Convert.ToInt32(myB / qtd);
				
				pxCor = Color.FromArgb(255, meR, meG, meB);
				*/
				#endregion
			}
			else
			{
			 	pxCor = WinPixel.GetPixelColor(rato.X, rato.Y);
			}
			
			//writing the labels....
			pnColor.BackColor = pxCor;
			pnRed.Width = Convert.ToInt32(pxCor.R);
			pnGreen.Width = Convert.ToInt32(pxCor.G);
			pnBlue.Width = Convert.ToInt32(pxCor.B);
				

			lbHue.Text = pxCor.GetHue().ToString("N3");  
			lbLuminance.Text = pxCor.GetBrightness().ToString("N3");  
			lbSaturation.Text = pxCor.GetSaturation().ToString("N3");
				
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
			lbF2.Text = "F2 to " + (mouseLocked ? "un" : "") + "lock";		
		}
	}
}
