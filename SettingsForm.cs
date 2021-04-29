using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace KeyCast
{
    public partial class SettingsForm : Form
    {
        private bool loading;
        private string ver;

        public event Action On_SettingsApplied;

        public SettingsForm()
        {
            loading = true;
            InitializeComponent();
            LoadSettings();

            shrinkHistory.Checked = true;
            shrinkHistory.Enabled = false;


            ver = $"{Application.ProductVersion.Split('.')[0]}.{Application.ProductVersion.Split('.')[1]}";
            this.Text = $"{Application.ProductName} {ver}";
        }

        private void LoadSettings()
        {
            fontDialog1.Font = Properties.Settings.Default.FontStyle;
            fontDialog1.Color = Properties.Settings.Default.FontColor;

            fadeDelay.Value = Properties.Settings.Default.HistoryDelay;
            historySteps.Value = Properties.Settings.Default.HistorySteps;
            shrinkHistory.Checked = Properties.Settings.Default.HistoryShrink;

            hasBackColor.Checked = Properties.Settings.Default.UseBackColor;
            colorDialog1.Color = Properties.Settings.Default.BackColor;

            OpacityBar.Value = Properties.Settings.Default.Opacity;
            OpacityLabel.Text = $"Opacity: {OpacityBar.Value}%";


            int x = Properties.Settings.Default.WindowLocation.X;
            int y = Properties.Settings.Default.WindowLocation.Y;
            locationLabel.Text = $"StartUp Location: {x},{y}";


        }

        private void okButton_Click(object sender, EventArgs e)
        {
            SaveSettings();
            this.Close();
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.FontStyle = fontDialog1.Font;
            Properties.Settings.Default.FontColor = fontDialog1.Color;

            Properties.Settings.Default.HistoryDelay = (int)fadeDelay.Value;
            Properties.Settings.Default.HistorySteps = (int)historySteps.Value;
            Properties.Settings.Default.HistoryShrink = shrinkHistory.Checked;
            Properties.Settings.Default.UseBackColor = hasBackColor.Checked;
            Properties.Settings.Default.BackColor = colorDialog1.Color;

            Properties.Settings.Default.Opacity = OpacityBar.Value;

            Properties.Settings.Default.Save();

            On_SettingsApplied?.Invoke();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                fontDialog1.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Try again with a True Type Font", "Invalid Font", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fontDialog1.ShowDialog();
            }
        }

        private void hasBackColor_CheckedChanged(object sender, EventArgs e)
        {
            if (loading)
            {
                loading = false;
                return;
            }
            if (((CheckBox)sender).Checked)
            {
                colorDialog1.ShowDialog();
            }

        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://panettonegames.com/");
        }

        private void OpacityBar_Scroll(object sender, EventArgs e)
        {
            OpacityLabel.Text = $"Opacity: {OpacityBar.Value}%";
        }

        private void ShowMoveTip(object sender, EventArgs e)
        {
            locationTip.SetToolTip(locationLabel, "To set location, Hover on the Keys Text & Drag it");
        }

        private void RunStartup_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            RunAtStartup(((CheckBox)sender).Checked);
        }

        private static void RunAtStartup(bool status)
        {
            RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (status)

                reg.SetValue(Application.ProductName, Application.ExecutablePath);
            else
                reg.DeleteValue(Application.ProductName);

        }
    }
}
