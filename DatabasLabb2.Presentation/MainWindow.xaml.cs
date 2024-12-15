using DatabasLabb2.Infrastructure.Data.Model;
using DatabasLabb2.Presentation.Dialogs;
using DatabasLabb2.Presentation.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DatabasLabb2.Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel() { EditBook = OpenEditBookWindow };
        }

        private void OpenEditBookWindow(object obj)
        {
            
                var window = new EditBookWindow();
                window.ShowDialog();
            
        }
    }
}