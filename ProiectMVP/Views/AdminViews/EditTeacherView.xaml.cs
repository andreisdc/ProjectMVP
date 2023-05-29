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
using System.Windows.Shapes;
using ProiectMVP.ViewModels.AdminViewModels;

namespace ProiectMVP.Views.AdminViews
{
    /// <summary>
    /// Interaction logic for EditTeacherView.xaml
    /// </summary>
    public partial class EditTeacherView : Window
    {
        public static EditTeacherView instance;

        public EditTeacherView()
        {
            instance = this;
            InitializeComponent();
            DataContext = new EditTeacherViewModel();
        }
    }
}
