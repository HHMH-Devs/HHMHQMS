/******************************************************* 

  TestSigCapt.cs
  
  Displays a form with a button to start signature capture
  The captured signature is encoded in an image file which is displayed on the form
  
  Copyright (c) 2020 Wacom Co. Ltd. All rights reserved.
  
********************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using FlSigCaptLib;
using FLSIGCTLLib;

namespace TestSigCapt
{
    public partial class TestSigCapt : Form
    {
        public TestSigCapt()
        {
            InitializeComponent();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            print("btnSign was pressed");
            SigCtl sigCtl = new SigCtl();
            sigCtl.Licence = "eyJhbGciOiJSUzUxMiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJMTVMiLCJleHAiOjE2NjU1NDU2MTMsImlhdCI6MTY1NzU5NjgxMywic2VhdHMiOjAsInJpZ2h0cyI6WyJTSUdfU0RLX0NPUkUiLCJUT1VDSF9TSUdOQVRVUkVfRU5BQkxFRCIsIlNJR0NBUFRYX0FDQ0VTUyIsIlNJR19TREtfSVNPIiwiU0lHX1NES19FTkNSWVBUSU9OIl0sImRldmljZXMiOltdLCJ0eXBlIjoiZXZhbCIsImxpY19uYW1lIjoiV2Fjb21fSW5rX1NES19mb3Jfc2lnbmF0dXJlIiwid2Fjb21faWQiOiJlNGFiZDRlY2RlZWM0ZWVhODkwNWZmM2Y5MzdjZDk3YiIsImxpY191aWQiOiI0ZDQzZGFhNS1kZGUwLTRhYTktYjZkMC05MmNjMGEyNjQxZTYiLCJhcHBzX3dpbmRvd3MiOltdLCJhcHBzX2lvcyI6W10sImFwcHNfYW5kcm9pZCI6W10sIm1hY2hpbmVfaWRzIjpbXX0.mF98U-sUXdvru2kO0AQ-eV183wDcPjozPNSY9bZ_su0NF4OraEgJ9ekJDHM7w6nwO9p4kpGn31mgmPX9wT8bRYTp2qA-smZ2bVPxugBy7WgGoJeJecwvZ9Nu6h99RuX_X0IqvmhWgOJdwYET22wW4W0BL9IFuOcvLHqy8HcJnxV1gUgukywjJYOqjBu7ZMxJVIkEWKSBFSHDSvxPwIVZZjUW3pFELBI6KxAvS4X9FO2km1El4vESDBahrB-0JubvGMx1Lpol2Tb2hxARa7ocwnPYzTnTd_2iXsTjBJrbN8V351-mWYX_-RytbF0n7X82QqarUDxtnXaEeJXOtdOtuw";
            DynamicCapture dc = new DynamicCaptureClass();
            DynamicCaptureResult res = dc.Capture(sigCtl, "Who", "Why", null, null);
            if (res == DynamicCaptureResult.DynCaptOK)
            {
                print("signature captured successfully");
                SigObj sigObj = (SigObj)sigCtl.Signature;
                sigObj.set_ExtraData("AdditionalData", "C# test: Additional data");
                String filename = "sig1.png";
                try
                {
                    sigObj.RenderBitmap(filename, 200, 150, "image/png", 0.5f, 0xff0000, 0xffffff, 10.0f, 10.0f, RBFlags.RenderOutputFilename | RBFlags.RenderColor32BPP | RBFlags.RenderEncodeData);

                    using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
                    {
                        sigImage.Image = System.Drawing.Image.FromStream(fs);
                        fs.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
            }
            else
            {
                print("Signature capture error res=" + (int)res + "  ( " + res + " )");
                switch (res)
                {
                    case DynamicCaptureResult.DynCaptCancel: print("signature cancelled"); break;
                    case DynamicCaptureResult.DynCaptError: print("no capture service available"); break;
                    case DynamicCaptureResult.DynCaptPadError: print("signing device error"); break;
                    default: print("Unexpected error code "); break;
                }
            }
        }
        private void print(string txt)
        {
            txtDisplay.Text += txt + "\r\n";
            txtDisplay.SelectionStart = txtDisplay.TextLength;
            txtDisplay.ScrollToCaret();
        }

    }
}

