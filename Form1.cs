using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace KeyCast
{
    public partial class Form1 : Form
    {
        private KeyHook _listener;
        private DateTime lastTriggered;
        private string currentKey;
        private string lastKey;
        private bool closedFromNotify;
        private int XCount = 1;
        private int MaxHistoryLines;
        private List<String> Lines;
        private List<String> CastLines;
        private string currentLine;
        private string lastLine;
        private StringBuilder sb;
        private string ver;
        private SettingsForm s;
        private Double delayBetweenStrokes = 0.1f;

        //draw String
        [DllImport("User32.dll")] public static extern IntPtr GetDC(IntPtr hwnd);
        [DllImport("User32.dll")] public static extern void ReleaseDC(IntPtr dc);

        public Form1()
        {
            InitializeComponent();
            _listener = new KeyHook();
            _listener.OnKeyPressed += _listener_OnKeyPressed;
            _listener.HookKeyboard();

            MakeTransparent(true);
            lastKey = String.Empty;

            LoadLocation();
            LoadSettings();


            sb = new StringBuilder();

            ver = $"{Application.ProductVersion.Split('.')[0]}.{Application.ProductVersion.Split('.')[1]}";
            ShowBalloon();
        }


        private void ShowBalloon()
        {

            notifyIcon1.ShowBalloonTip(2000, $"{Application.ProductName} {ver}", "Edit Settings Here or Right Click on the Keys Text", ToolTipIcon.Info);
        }

        public void LoadSettings()
        {
            keyPressed.ForeColor = Properties.Settings.Default.FontColor;
            keyPressed.Font = Properties.Settings.Default.FontStyle;

            keyPressed.BackColor = Properties.Settings.Default.UseBackColor ?
                Properties.Settings.Default.BackColor : Color.Transparent;

            this.Opacity = (double)(Properties.Settings.Default.Opacity / (double)100);

            // this.AutoSizeMode = Properties.Settings.Default.HistoryShrink ? AutoSizeMode.GrowAndShrink : AutoSizeMode.GrowOnly;

            MaxHistoryLines = Properties.Settings.Default.HistorySteps;
            Lines = new List<string>(MaxHistoryLines);
            CastLines = new List<string>(MaxHistoryLines);

            clearTimer.Interval = Properties.Settings.Default.HistoryDelay * 1000;
            clearTimer.Start();
        }

        private void LoadLocation()
        {
            this.Location = Properties.Settings.Default.WindowLocation;
        }

        ~Form1()
        {
            _listener.UnHookKeyboard();
            s.On_SettingsApplied -= ApplySettings;
            notifyIcon1.Dispose();
        }

        void _listener_OnKeyPressed(object sender, KeyPressedArgs e)
        {
            currentKey = e.KeyPressed.GetChar();
            if (Lines.Count > MaxHistoryLines)
                Lines.RemoveAt(0);

            Lines.Add(currentKey);


            currentLine = Lines[Lines.Count - 1];

            if (Lines.Count > 1)
                lastLine = Lines[Lines.Count - 2];
            else lastLine = String.Empty;


            //limit screen
            if (CastLines.Count > MaxHistoryLines && currentLine != lastLine)
                CastLines.RemoveAt(0);

            // ---------------





            if (IsSpecial(lastLine) && currentLine != lastLine)
            {
                //Remove Left & Right from keys
                lastLine = lastLine.Replace("Left", String.Empty);
                lastLine = lastLine.Replace("Right", String.Empty);

                if (CastLines.Count > 0)
                    CastLines[CastLines.Count - 1] = $"{lastLine} + {currentLine}";
                //keyPressed.Text = String.Join(Environment.NewLine, CastLines);
            }

            else
            {

                if (currentLine == lastLine)
                {



                    //if(IsSpecial(lastLine))
                    //if (IsSpecial(Lines[Lines.Count - 2]))
                    //   CastLines[CastLines.Count - 1] = $"{Lines[Lines.Count - 2]} + {currentLine} x {++XCount}";
                    //else
                    if (CastLines.Count > 0)
                    {
                        if ((DateTime.Now >= lastTriggered.AddSeconds(delayBetweenStrokes)))
                            CastLines[CastLines.Count - 1] = $"{currentLine} x {++XCount}";
                        lastTriggered = DateTime.Now;
                    }
                }
                else
                {
                    XCount = 1;
                    CastLines.Add(currentLine);
                }
            }



            keyPressed.Text = String.Join(Environment.NewLine, CastLines);



            /*

            ////
            if (currentLine == lastLine)
            {
                if (Lines.Count > 0)
                    Lines.RemoveAt(Lines.Count - 1);
                
                if (Lines.Count > 0)
                {
                    //Lines[Lines.Count - 1] = $"{currentLine} x {++XCount}";


                    keyPressed.Text = $"{String.Join(Environment.NewLine, Lines)}" +
                        $"{Environment.NewLine}" +
                        $"{currentLine} x {++XCount}";

                }
                //keyPressed.Text = keyPressed.Text = String.Join(Environment.NewLine, Lines);
                return;
            }
            else
                XCount = 1;



            if (lastLine.ToUpper().Contains("CTRL") ||
                lastLine.ToUpper().Contains("SHIFT") ||
                lastLine.ToUpper().Contains("ALT"))
            {
                Lines[Lines.Count - 1] = ($"{lastLine} + {currentLine}");
                keyPressed.Text = keyPressed.Text = String.Join(Environment.NewLine, Lines);
            }
            else
            {
                //Lines.Add($"{currentLine}");
                keyPressed.Text = keyPressed.Text = String.Join(Environment.NewLine, Lines);
            }



            */











            /* if (currentKey == lastKey)
             {

                 keyPressed.Text = $"{currentKey} x {++XCount}";
                 return;
             }
             else
                 XCount = 1;


             Lines
             if (lastKey.ToUpper().Contains("CTRL") ||
                 lastKey.ToUpper().Contains("SHIFT") ||
                 lastKey.ToUpper().Contains("ALT"))
             {
                 keyPressed.Text = $"{lastKey} + {currentKey}";
             }
             else
             {

                 keyPressed.Text = currentKey;
             }


             lastKey = currentKey;*/





        }

        private bool IsSpecial(string lastLine)
        {
            return
                lastLine.ToUpper().Contains("CTRL") ||
                lastLine.ToUpper().Contains("SHIFT") ||
                lastLine.ToUpper().Contains("ALT");
        }

        void MakeTransparent(bool Visibility)
        {
            Color chromaKey = Color.FromArgb(0, 0, 1);

            this.TransparencyKey = chromaKey;
            this.BackColor = Visibility ? chromaKey : Color.LightSlateGray;
            this.FormBorderStyle = Visibility ? FormBorderStyle.None : FormBorderStyle.FixedDialog;
        }



        protected override void OnPaint(PaintEventArgs e)
        {
            //e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
            //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveLocation();
            closedFromNotify = true;
            Application.Exit();
        }

        private void SaveLocation()
        {
            Properties.Settings.Default.WindowLocation = this.Location;
            Properties.Settings.Default.Save();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closedFromNotify)
                e.Cancel = true;
        }


        #region move with mouse

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;



        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();


        private void keyPressed_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        #endregion





        private void toolStripMenuItem2_Click(object sender, EventArgs e) => ShowSettings();

        private void ShowSettings()
        {
            s = new SettingsForm();
            s.On_SettingsApplied += ApplySettings;
            s.Show();
        }

        private void ApplySettings()
        {
            LoadSettings();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start("www.panettonegames.com");

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e) => ShowSettings();

        private void keyPressed_DoubleClick(object sender, EventArgs e)
        {
            ShowSettings();
        }

        private void clearTimer_Tick(object sender, EventArgs e)
        {
            if (CastLines.Count > 0)
            {
                CastLines.RemoveAt(0);
                keyPressed.Text = String.Join(Environment.NewLine, CastLines);
            }
        }
    }
}
