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
    /// Interaction logic for EditGroupView.xaml
    /// </summary>
    public partial class EditGroupView : Window
    {
        public static EditGroupView instance;

        public EditGroupView()
        {
            instance = this;
            InitializeComponent();
            DataContext = new EditGroupViewModel();
        }
    }
}
