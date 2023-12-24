using System;
using System.Windows.Forms;

namespace LightWeightPlayer
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // link 1
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://www.youtube.com/channel/UC3haRZzqQnB_xOcz7MNxC_Q",
                UseShellExecute = true
            });
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
