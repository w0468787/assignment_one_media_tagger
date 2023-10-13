using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
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
using TagLib;

namespace assignment_one
{
    /// <summary>
    /// Interaction logic for MediaTagger.xaml
    /// </summary>
    public partial class MediaTagger : UserControl
    {
        TagLib.File currentFile;

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
                // Get the file path of the opened media element
                string filePath = myMediaElement.Source.LocalPath;

                this.currentFile = TagLib.File.Create(filePath);
                // Set the maximum value of the slider to the total time of the media in seconds
                mediaProgressBar.Maximum = myMediaElement.NaturalDuration.TimeSpan.TotalSeconds;
                if (currentFile.Tag.Pictures.Length > 0)
                {
                    
                }

                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += (s, args) =>
                {
                    //NOT WORKING slider wont visually update
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

        private void AlbumCover_MouseLeftDown(object sender, MouseButtonEventArgs e)
        {
            // When the image is clicked, make the tag editor menu visible
            tagBanner.Visibility = Visibility.Visible;
            tagEditorMenu.Visibility= Visibility.Visible;
        }

        private void MediaElement_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        //currentFile gets set above when media is opened but its not saved (always null on save button clicked)
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Ensure currentFile is not null
            if (this.currentFile != null)
            {
                // Update tags from TextBox values
                currentFile.Tag.Title = titleLabel.Text;
                currentFile.Tag.Album = albumLabel.Text;

                // Parse release date and update the Year tag
                if (UInt32.TryParse(releaseDateLabel.Text, out uint releaseYear))
                {
                    currentFile.Tag.Year = releaseYear;
                }
                else
                {
                    // Handle invalid release date input
                    MessageBox.Show("Invalid release date input!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Save changes to the file
                currentFile.Save();

                // Hide the tag editor menu after saving
                tagEditorMenu.Visibility = Visibility.Collapsed;
            }
            else
            {
                // Handle null currentFile or currentFile.Tag
                MessageBox.Show("Error: File or tags not available.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void showEditorMenu()
        {
            tagEditorMenu.Visibility = Visibility.Visible;
        }
    }
}
