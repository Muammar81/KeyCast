using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KeyCast
{
    public partial class Form1 : Form
    {
        private KeyHook _listener;
        private string currentKey;
        private string lastKey;
        private bool closedFromNotify;
        private int XCount = 1;
        private int MaxHistoryLines;
        private List<String> Lines;
        private string currentLine;
        private string lastLine;


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

            Lines = new List<string>(4);
        }


        public void LoadSettings()
        {
            keyPressed.ForeColor = Properties.Settings.Default.FontColor;
            keyPressed.Font = Properties.Settings.Default.FontStyle;

            keyPressed.BackColor = Properties.Settings.Default.UseBackColor ?
                Properties.Settings.Default.BackColor : Color.Transparent;



            MaxHistoryLines = Properties.Settings.Default.HistorySteps;


        }

        private void LoadLocation()
        {
            this.Location = Properties.Settings.Default.WindowLocation;
        }

        ~Form1()
        {
            _listener.UnHookKeyboard();
        }

        void _listener_OnKeyPressed(object sender, KeyPressedArgs e)
        {
            currentKey = e.KeyPressed.GetChar();
            if (Lines.Count > 4)
                Lines.RemoveAt(0);

            Lines.Add(currentKey);



            currentLine = Lines[Lines.Count - 1];

            if (Lines.Count > 1)
                lastLine = Lines[Lines.Count - 2];
            else lastLine = String.Empty;


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



        private Action Handle_SettingsApplied()
        {
            LoadSettings();
            return null;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e) => ShowSettings();

        private void ShowSettings()
        {
            SettingsForm s = new SettingsForm();
            s.SettingsApplied += Handle_SettingsApplied();
            s.Show();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start("www.panettonegames.com");

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e) => ShowSettings();

        private void keyPressed_DoubleClick(object sender, EventArgs e)
        {
            ShowSettings();
        }
    }
}
