using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace assignment_one
{
    /// <summary>
    /// Interaction logic for MediaTagger.xaml
    /// </summary>
    public partial class MediaTagger : UserControl
    {
        TagLib.File currentFile;
        private DispatcherTimer timer;
        private TimeSpan TotalTime;

         public MediaTagger()
        {
            InitializeComponent();
            
            this.DataContext = this;
        }
        private void MediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {


            // Check if the media finished calculating its total time
            if (myMediaElement.Source != null && myMediaElement.NaturalDuration.HasTimeSpan)
            {
                // Set the maximum value of the slider to the total time of the media in seconds
                mediaProgressBar.Maximum = myMediaElement.NaturalDuration.TimeSpan.TotalSeconds;

                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += (s, args) =>
                {
                    // Update slider position based on media element's position
                    mediaProgressBar.Value = myMediaElement.Position.TotalSeconds;
                };

                // Start the timer
                timer.Start();
            }
            else
            {
                MessageBox.Show("Error: Media duration not available.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine($"Media opened. Duration: {myMediaElement.NaturalDuration.TimeSpan}");
            }
        }

        private void mediaProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Update TextBlock with the current position of the Slider in hh:mm:ss format
            int currentPositionInSeconds = (int)mediaProgressBar.Value;
            TimeSpan currentPosition = TimeSpan.FromSeconds(currentPositionInSeconds);
            timeDisplay.Text = $"{currentPosition.Hours:D2}:{currentPosition.Minutes:D2}:{currentPosition.Seconds:D2}";
        }

        private void MediaElement_Unloaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
