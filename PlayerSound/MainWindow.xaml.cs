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
//using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Windows.Threading;
using System.Runtime.InteropServices;
using System.IO;

namespace PlayerSound
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private MediaPlayer mediaPlayer = new MediaPlayer();
        private string mediaPath;

        public MainWindow()
        {
            InitializeComponent();
            //List<string> safePlayList = new List<string>();
            


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
            OpenFileDialog openFile = new OpenFileDialog();
            /// OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.AddExtension = true;
            openFile.DefaultExt = ".mp3";
            openFile.Filter = "MP3 files (*.mp3)|*.mp3| All files (*.*)|*.*";
            openFile.Multiselect = true;
           // openFileDialog.ShowDialog();
            ///try { MediaPlayer.Source = new Uri(openFileDialog.FileName); }
            //catch { new NullReferenceException("Error"); }
            
            if (openFile.ShowDialog() == true )
            {
                //mediaPlayer.Open(new Uri(openFile.FileName));
                //MediaPlayer.Source = new Uri(openFile.SafeFileName);
                for (int i = 0; i < openFile.FileNames.Length; ++i)
                {
                    playListMp3.Items.Add(openFile.FileNames[i].ToString());
                }
                
                //mediaPlayer.Play()
                //playListMp3.Items.Add();
            }

        }
        void timer_Tick(object sender, EventArgs e)
        {
            if (mediaPlayer.Source != null) { }
            // Status.Content = String.Format("{0} / {1}", mediaPlayer.Position.ToString(@"mm\:ss"), mediaPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
            else
                Status.Content = "No file selected...";
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            //mediaPlayer.Play();
            ///MediaElement.Play();
            mediaPlayer.Stop();
            //string mediaPath = ((ListBoxItem)playListMp3.SelectedValue).Content.ToString();
            mediaPath = playListMp3.SelectedItem.ToString();
            mediaPlayer.Open(new Uri(mediaPath));
            mediaPlayer.Play();
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

        private void playListMp3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }

   

}
