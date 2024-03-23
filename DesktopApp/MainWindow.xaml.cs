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

namespace DesktopApp;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public string LinkStatusImageSource { get; set; } = "/Assets/database-check.png";
    public MainWindow()
    {
        InitializeComponent();
        SearchBox.Text = LinkStatusImageSource;
        LinkStatusIcon.Source = new BitmapImage(new Uri(@"/Assets/database-slash.png", UriKind.Relative));
    }
}