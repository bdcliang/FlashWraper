using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace FlashWraper
{
    public class ShockwaveFlash:UserControl
    {
        public ShockwaveFlash()
        {
            InitializeComponent();
        }
        AxShockwaveFlashObjects.AxShockwaveFlash flash;
        void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShockwaveFlash));
            this.flash = new AxShockwaveFlashObjects.AxShockwaveFlash();
            ((System.ComponentModel.ISupportInitialize)(this.flash)).BeginInit();
            this.SuspendLayout();
            // 
            // flash
            // 
            this.flash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flash.Enabled = true;
            this.flash.Location = new System.Drawing.Point(0, 0);
            this.flash.Name = "flash";
            this.flash.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("flash.OcxState")));
            this.flash.Size = new System.Drawing.Size(244, 200);
            this.flash.TabIndex = 0;
            // 
            // ShockwaveFlash
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.flash);
            this.Name = "ShockwaveFlash";
            this.Size = new System.Drawing.Size(244, 200);
            ((System.ComponentModel.ISupportInitialize)(this.flash)).EndInit();
            this.ResumeLayout(false);

        }


        public event EventHandler<FlashEventArgs> FlashCall;
        public AxShockwaveFlashObjects.AxShockwaveFlash Default { get { return flash; } }
        public void LoadMovie(string path)
        {
            this.flash.ScaleMode = 2;
            flash.Stop();
            flash.Movie = path;
            flash.Play();
        }
        public void CallFunction(string request)
        {
            flash.CallFunction(request);            
        }


        public void CallDefaultFunction(string name,string value)
        {
            string request = "<invoke name=\"" + name + "\" returntype=\"xml\"><arguments><string>" + value + "</string></arguments></invoke>";
            CallFunction(request);
        }       
        private void Flash_FlashCall(object sender, AxShockwaveFlashObjects._IShockwaveFlashEvents_FlashCallEvent e)
        {
            FlashCall?.Invoke(this, new FlashEventArgs(e.request));
        }
    }

    public class FlashEventArgs:EventArgs
    {
        public string Raw { get; set; }
        public string Value { get; set; }
        public FlashEventArgs(string request)
        {
            Raw = request;
            XmlDocument document = new XmlDocument();
            document.LoadXml(request);
            XmlNodeList list = document.GetElementsByTagName("arguments");
            if (list.Count > 0)
             Value = list[0].InnerText; 
            else
                Value = null;
        }
    }
}
