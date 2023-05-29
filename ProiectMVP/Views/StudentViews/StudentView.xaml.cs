using ProiectMVP.Models;
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
using ProiectMVP.Data;
using ProiectMVP.ViewModels.StudentViewModels;

namespace ProiectMVP.Views.StudentViews
{
    /// <summary>
    /// Interaction logic for StudentView.xaml
    /// </summary>
    public partial class StudentView : Window
	{
		public static StudentView instance;

        public StudentView(AppDbContext dbContext, User user)
		{
			instance = this;
			InitializeComponent();
            DataContext = new StudentViewModel(dbContext, user);
        }
	}
}
