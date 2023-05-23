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
using ProiectMVP.Data;
using ProiectMVP.ViewModels;

namespace ProiectMVP.Views
{
    /// <summary>
    /// Interaction logic for AuthenticationView.xaml
    /// </summary>
    public partial class AuthenticationView : Window
    {
	    public static AuthenticationView instance;

        public AuthenticationView(AppDbContext dbContext)
        {
	        instance = this;
            InitializeComponent();
            DataContext = new AuthenticationViewModel(dbContext);
        }

	}
}
