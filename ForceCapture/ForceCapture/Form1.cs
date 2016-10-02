using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Imaging;

namespace ForceCapture
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ImageFormat img;
        Bitmap bt;
        Graphics screenShot;
      
        

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            
            
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.Hide();
                Thread.Sleep(500);
                bt = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
                screenShot = Graphics.FromImage(bt);
                screenShot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
                switch (saveFileDialog1.FilterIndex)
                {
                    case 0: img = ImageFormat.Bmp; break;
                    case 1: img = ImageFormat.Png; break;
                    case 2: img = ImageFormat.Jpeg; break;
                }
                bt.Save(saveFileDialog1.FileName, img);
                this.Show();
            }
        }

       
    }
}
