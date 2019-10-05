using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Controls;
using AForge.Video.FFMPEG;
namespace coop_main
{
    public partial class CapturePhoto : Form
    {
        private FilterInfoCollection camAvailable;
        private VideoCaptureDevice camDevice;
        VideoCapabilities[] capability;
        public Bitmap capturedImage;
        public CapturePhoto()
        {
            InitializeComponent();
        }

        private void checkCamer() {
            camAvailable = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (camAvailable.Count == 0)
            {
                message mes = new message("There's no Web camera attached to your PC\n Please check your devices");
                mes.ShowDialog(this);
                mes.ShowInTaskbar = false;
            }
            else
            {
                int ind = 0;
                foreach (FilterInfo col in camAvailable)
                {
                    cmbDevList.Items.Add(col.Name);
                    ind++;
                }
            }
            camDevice = new VideoCaptureDevice();
        }

        void cam01(int a)
        {
            try
            {
                if (!camDevice.IsRunning)
                {
                    camDevice = new VideoCaptureDevice(camAvailable[a].MonikerString);
                    camDevice.VideoResolution = capability[cmbReso.SelectedIndex];
                    vspCam1.VideoSource = camDevice;
                    vspCam1.Start();
                }
                else
                {
                    vspCam1.SignalToStop();
                    vspCam1.WaitForStop();
                }
            }
            catch
            {
            }

        }

        private void cmbOneExt()
        {
            camDevice = new VideoCaptureDevice(camAvailable[cmbDevList.SelectedIndex].MonikerString);
            capability = camDevice.VideoCapabilities;
            cmbReso.Items.Clear();
            foreach (VideoCapabilities bi in capability)
            {
                cmbReso.Items.Add(string.Format("{0} x {1}", bi.FrameSize.Width, bi.FrameSize.Height));
            }
        }

        private void startCamera() { 
        
            if(cmbDevList.Items.Count >0){
                cmbDevList.SelectedIndex = 0;
                    if(cmbReso.Items.Count > 0){
                        cmbReso.SelectedIndex = 0;
                    }

                if (vspCam1.IsRunning)
                {
                    vspCam1.WaitForStop();
                }
                if (cmbReso.SelectedIndex != -1 && cmbDevList.SelectedIndex != -1)
                {
                    cam01(cmbDevList.SelectedIndex);
                }
            
            }
        }


        private void CapturePhoto_Load(object sender, EventArgs e)
        {
            checkCamer();


     
            startCamera();
        }

        private void btn_cap_Click(object sender, EventArgs e)
        {
            if (vspCam1.IsRunning)
            {
                Bitmap screenshot = vspCam1.GetCurrentVideoFrame();
                capturedImage = (Bitmap)screenshot.Clone();
                screenshot.Dispose();
                btn_cancel.PerformClick();
            }
            else {
                message mes = new message("There's no Web camera attached to your PC\n Please check your devices");
                mes.ShowDialog(this);
                mes.ShowInTaskbar = false;
            }
        }

        private void cmbDevList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbDevList.SelectedIndex != -1){
                cmbOneExt();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            if (vspCam1.IsRunning)
            {
                if (vspCam1.IsRunning) vspCam1.WaitForStop();
                this.Close();
            }
            else {
                this.Close();
            }
        }
    }
}
