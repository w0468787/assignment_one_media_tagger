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

namespace assignment_one
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static RoutedCommand FileExplorerCommand = new RoutedCommand();
        public static RoutedCommand TrebleClefCommand = new RoutedCommand();
        public static RoutedCommand BlankPaperCommand = new RoutedCommand();

        public MainWindow()

        {
            InitializeComponent();
        }
        private void FileExplorerCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // Code to execute when the File Explorer command is executed
        }

        private void TrebleClefCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // Code to execute when the Treble Clef command is executed
        }

        private void BlankPaperCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // Code to execute when the Blank Paper command is executed
        }

        private void FileExplorer_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

        }
    }
}
