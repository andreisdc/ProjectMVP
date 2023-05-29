﻿using System;
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
using ProiectMVP.Models;
using ProiectMVP.ViewModels.TeacherViewModels;

namespace ProiectMVP.Views.TeacherViews
{
    /// <summary>
    /// Interaction logic for TeacherView.xaml
    /// </summary>
    public partial class TeacherView : Window
	{
        public static TeacherView instance;

		public TeacherView(AppDbContext dbContext, User user)
		{
            instance = this;
            InitializeComponent();
            DataContext = new TeacherViewModel(dbContext, user);
		}
	}
}
