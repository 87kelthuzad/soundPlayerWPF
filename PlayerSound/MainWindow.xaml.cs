using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
///using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Windows.Threading;
using System.Runtime.InteropServices;

namespace PlayerSound
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private MediaPlayer mediaPlayer = new MediaPlayer();


        public MainWindow()
        {
            InitializeComponent();


            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void list_Click(object sender, RoutedEventArgs e)
        {
            var window = new Window1();
            window.Show();
        }

        private void openFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            /// OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.AddExtension = true;
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3| All files (*.*)|*.*";
           // openFileDialog.ShowDialog();
            ///try { MediaPlayer.Source = new Uri(openFileDialog.FileName); }
            //catch { new NullReferenceException("Error"); }

            if (openFileDialog.ShowDialog() == true )
            {
                mediaPlayer.Open(new Uri(openFileDialog.FileName));
                //mediaPlayer.Play();
                
            }
        }
        void timer_Tick(object sender, EventArgs e)
        {
            if (mediaPlayer.Source != null)
                Status.Content = String.Format("{0} / {1}", mediaPlayer.Position.ToString(@"mm\:ss"), mediaPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
            else
               Status.Content = "No file selected...";
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Play();
            ///MediaElement.Play();
        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }

        private void pause_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }

        private void mute_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Volume = 0;
            mute.Content = "Mute";
        }

        private void volume_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Volume += 2;
            mute.Content = "Listen";
        }
    }

   

}
