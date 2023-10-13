using Microsoft.Win32;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace assignment_one
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Instantiate the MediaTagger user control
        MediaTagger mediaTagger = new MediaTagger();

        public MainWindow()
        {
            InitializeComponent();

            CommandBindings.Add(new CommandBinding(CustomCommands.OpenMp3Command, OpenMp3Command_Executed, OpenMp3Command_CanExecute));
            CommandBindings.Add(new CommandBinding(CustomCommands.PlayMediaCommand, PlayCommand_Executed, PlayCommand_CanExecute));
            CommandBindings.Add(new CommandBinding(CustomCommands.PauseMediaCommand, PauseCommand_Executed, PauseCommand_CanExecute));
            CommandBindings.Add(new CommandBinding(CustomCommands.StopMediaCommand, StopCommand_Executed, StopCommand_CanExecute));
            CommandBindings.Add(new CommandBinding(CustomCommands.TagMp3Command, TagMp3Command_Executed, TagMp3Command_CanExecute));
            CommandBindings.Add(new CommandBinding(CustomCommands.SaveMediaTagsCommand, SaveMediaTagsCommand_Executed, SaveMediaTagsCommand_CanExecute));


        }
        private void OpenMp3Command_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3";
            try
            {
                if (openFileDialog.ShowDialog() == true)
                {
                    // Handle the selected MP3 file path (open it, process it, etc.)
                    string selectedFilePath = openFileDialog.FileName;

                    // Set the source of media element and play it
                    mediaTagger.myMediaElement.Source = new Uri(selectedFilePath);
                    mediaTagger.myMediaElement.Play();

                }
            }
            catch (Exception ex)
            {
                // Handle exceptions show an error message to the user
                MessageBox.Show($"Error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OpenMp3Command_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true; // Enable the command always
        }

        private void PlayCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // Handle Play command here
            try
            {
                mediaTagger.myMediaElement.Play();
            }
            catch (Exception ex)
            {
                //show an error message to the user
                MessageBox.Show($"Error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PlayCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            //execute if the user controls mediaElement is not null and has a source 
            e.CanExecute = mediaTagger.myMediaElement != null && mediaTagger.myMediaElement.Source != null;
        }


        private void PauseCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                mediaTagger.myMediaElement.Pause();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        //pause can execute if mediaElement has a source and is playing
        private void PauseCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = mediaTagger.myMediaElement != null && mediaTagger.myMediaElement.Source != null && mediaTagger.myMediaElement.CanPause;
        }

        private void StopCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // calls built in media element command
            mediaTagger.myMediaElement.Stop();
        }

        private void StopCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

            e.CanExecute = mediaTagger.myMediaElement != null && mediaTagger.myMediaElement.Source != null;
        }

        //not working tried both a new method and mediaTagger.TagEditorMenu.visibility=visibility.visible;
        private void TagMp3Command_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            mediaTagger.showEditorMenu();

            //testing text box to try and display tag elements because of extreme UI difficulty
            tagTester.Text = mediaTagger.getTagsAsString();

        }


        private void TagMp3Command_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = mediaTagger.myMediaElement != null && mediaTagger.myMediaElement.Source != null;
        }

        //have user control button subscribed to this save event
        private void SaveMediaTagsCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            mediaTagger.saveTags();
        }

        private void SaveMediaTagsCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // Can execute
            e.CanExecute = true;
        }
    }
}
