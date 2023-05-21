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
using ProiectMVP.ViewModel;

namespace ProiectMVP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
	    public static MainWindow instance;
        public MainWindow()
        {
	        instance = this;
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

		private void ButtonLogin_Click(object sender, RoutedEventArgs e) {

		}
	}
}
