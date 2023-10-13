using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace assignment_one
{
    public class CustomCommands
    {
        public static readonly RoutedUICommand OpenMp3Command = new RoutedUICommand("Open MP3", "OpenMp3", typeof(CustomCommands));
        public static readonly RoutedUICommand PlayMediaCommand = new RoutedUICommand("Play", "Play", typeof(MainWindow));
        public static readonly RoutedUICommand PauseMediaCommand = new RoutedUICommand("Pause", "Pause", typeof(MainWindow));
        public static readonly RoutedUICommand StopMediaCommand = new RoutedUICommand("Stop", "Stop", typeof(MainWindow));
        public static readonly RoutedUICommand TagMp3Command=new RoutedUICommand("Tag MP3","TagMp3",typeof(CustomCommands));
        public static readonly RoutedUICommand SaveMediaTagsCommand = new RoutedUICommand("Save Media Tags", "SaveMediaTags", typeof(CustomCommands));

    }
}

