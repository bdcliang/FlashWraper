using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
       // AxShockwaveFlashObjects.AxShockwaveFlash flash;
        public Form1()
        {
            InitializeComponent();
            //flash = new AxShockwaveFlashObjects.AxShockwaveFlash();
            //((System.ComponentModel.ISupportInitialize)(flash)).BeginInit();
            //this.Controls.Add(flash);
            
            //((System.ComponentModel.ISupportInitialize)(flash)).EndInit();
            string path = Application.StartupPath + "\\video.swf";
            shockwaveFlash1.LoadMovie(path);
        }
    }
}
