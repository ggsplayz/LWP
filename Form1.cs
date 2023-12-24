// Before reading the code, have in mind that this was one of my first c#/WinForms app so its a pretty messy code.

using System;
using NAudio.Wave;
using System.ComponentModel;
using System.Windows.Forms;

namespace LightWeightPlayer
{

    public partial class Form1 : Form
    {
        private IWavePlayer waveOutDevice;
        private AudioFileReader audioFileReader;
        private OpenFileDialog openFileDialog;
        private bool isPaused = false;


        public Form1()
        {
            InitializeComponent();
            vol.Minimum = 0;
            vol.Maximum = 100;
            waveOutDevice = new WaveOut();
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de audio|*.wav;*.mp3;*.m4a;"; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (waveOutDevice != null)
            {
                waveOutDevice.Stop();
                waveOutDevice.Dispose();
            }

            if (audioFileReader != null)
            {
                audioFileReader.Dispose();
            }

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }


        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (waveOutDevice != null && audioFileReader != null && !isPaused)
            {
                waveOutDevice.Pause();
                isPaused = true;
            }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (waveOutDevice != null && audioFileReader != null && isPaused)
            {
                waveOutDevice.Play();
                isPaused = false;
            }
        }

        private void AbrirArchivoDeAudio(string filePath)
        {
            if (waveOutDevice != null)
            {
                waveOutDevice.Stop();
                waveOutDevice.Dispose();
            }

            if (audioFileReader != null)
            {
                audioFileReader.Dispose();
            }

            audioFileReader = new AudioFileReader(filePath);
            waveOutDevice = new WaveOut();
            waveOutDevice.Init(audioFileReader);
            waveOutDevice.Play();
        }

        private void stopToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos de audio|*.wav;*.mp3;*.ogg"; 

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (waveOutDevice != null && waveOutDevice.PlaybackState == PlaybackState.Playing)
                    {
                        waveOutDevice.Stop();
                        waveOutDevice.Dispose();
                    }
                    audioFileReader = new AudioFileReader(openFileDialog.FileName);
                    waveOutDevice = new WaveOut();
                    waveOutDevice.Init(audioFileReader);
                    audioFileReader = new AudioFileReader(openFileDialog.FileName);
                    
                    isPaused = false;
                    lblNombreArchivo.Text = System.IO.Path.GetFileName(openFileDialog.FileName);
                    string rutaCancion = System.IO.Path.GetFullPath(openFileDialog.FileName);
                    waveOutDevice.Play();
                }

            }

         }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Reanuda la reproducción si está en pausa
            if (waveOutDevice != null && audioFileReader != null && isPaused)
            {
                waveOutDevice.Play();
                isPaused = false;
            }
            else
            {
                waveOutDevice.Pause();
                isPaused = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            waveOutDevice.Stop();
            waveOutDevice.Dispose();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            // Ajusta el volumen en función de la posición del TrackBar
            if (waveOutDevice != null)
            {
                float volumen = (float)vol.Value / 100.0f;
                waveOutDevice.Volume = volumen;
            }
        }

        private void ControlsBox_Enter(object sender, EventArgs e)
        {

        }

        private void secretToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
