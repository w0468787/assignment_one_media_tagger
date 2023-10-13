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

            this.DataContext=this;
        }
        private void MediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {


            // Check if the media finished calculating its total time
            
                // Get the file path of the opened media element
                string filePath = myMediaElement.Source.LocalPath;

                currentFile = TagLib.File.Create(filePath);
               
        }
        private void mediaProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tagEditorMenu.Visibility = Visibility.Visible;
        }

        
        //currentFile gets set above when media is opened but its not saved (always null on save button clicked)
        public void saveTags()
        {
            string filePath = myMediaElement.Source.LocalPath;
            currentFile = TagLib.File.Create(filePath);
            // Ensure currentFile is not null
            if (this.currentFile != null)
            {
                if (myMediaElement != null && myMediaElement.Source != null && myMediaElement.CanPause)
                {
                    myMediaElement.Pause();
                    myMediaElement.Close();
                }
                
                //UI PROBLEM always updates to xaml text value and not typed value
                // Update tags from TextBox values
                currentFile.Tag.Title = titleLabel.Text;
                currentFile.Tag.Performers = new[] { performerLabel.Text }; // Assuming Performers is an array
                currentFile.Tag.Album = albumLabel.Text;

                // Parse release date and update the Year tag
                string temp = releaseDateLabel.Text;
                try
                {
                    uint releaseYear = UInt32.Parse(temp);
                        currentFile.Tag.Year = releaseYear;
                }
                catch (FormatException)
                {
                    // Handle parsing failure (invalid format)
                    MessageBox.Show("Invalid release date input! Please enter a valid numeric year.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
               
                // Save changes to the file
                currentFile.Save();
                MessageBox.Show("Tag Updates Saved","Message",MessageBoxButton.OK);

                // Close the current file and release resources
                currentFile.Dispose();
                currentFile = null;

                // Stop and close the media element if it's playing
                if (myMediaElement != null && myMediaElement.Source != null)
                {
                    myMediaElement.Stop();
                    myMediaElement.Close();
                }

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
           string filePath = myMediaElement.Source.LocalPath;
           currentFile = TagLib.File.Create(filePath);
            //setup the menu with file tags in the boxes
            // Check and set the Album tag
            if (!string.IsNullOrEmpty(currentFile.Tag.Album))
            {
                albumLabel.Text = currentFile.Tag.Album;
            }
            else
            {
                albumLabel.Text = "Unknown Album";
            }

            // Check and set the Performers tag
            if (currentFile.Tag.Performers != null && currentFile.Tag.Performers.Length > 0)
            {
                performerLabel.Text = string.Join(", ", currentFile.Tag.Performers);
            }
            else
            {
                performerLabel.Text = "Unknown Performer";
            }

            // Check and set the Year tag
            if (currentFile.Tag.Year > 0)
            {
                releaseDateLabel.Text = currentFile.Tag.Year.ToString();
            }
            else
            {
                releaseDateLabel.Text = "Unknown Year";
            }

            // Check and set the Title tag
            if (!string.IsNullOrEmpty(currentFile.Tag.Title))
            {
                titleLabel.Text = currentFile.Tag.Title;
            }
            else
            {
                titleLabel.Text = "Unknown Title";
            }

            tagEditorMenu.Visibility = Visibility.Visible;
            //tagEditorMenu.IsVisible = true;
        }
        public string getTagsAsString()
        {
            string tagsString = "";

            if (currentFile != null && currentFile.Tag != null)
            {
                tagsString += $"Title: {currentFile.Tag.Title}\n";
                tagsString += $"Album: {currentFile.Tag.Album}\n";
                tagsString += $"Performers: {string.Join(", ", currentFile.Tag.Performers)}\n";
                tagsString += $"Year: {currentFile.Tag.Year}\n";
                tagsString += $"Genres: {string.Join(", ", currentFile.Tag.Genres)}\n";

                // Add more tags as needed
            }
            else
            {
                tagsString = "Tags not available.";
            }

            return tagsString;
        }
    }
}
