using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProiectMVP.Models;
using System.Windows.Input;
using ProiectMVP.Views.Elev.PageViews;

namespace ProiectMVP.ViewModels.PageViewModels.Student
{
	class NavigationVM : BaseViewModel
	{
		private object _currentView;

		public ICommand HomeCommand { get; set; }
		public ICommand SubjectCommand { get; set; }
		public ICommand GradeCommand { get; set; }
		public ICommand AbsenceCommand { get; set; }
		public ICommand SettingsCommand { get; set; }
		public ICommand AverageCommand { get; set; }
		public object CurrentView
		{
			get { return _currentView; }
			set { _currentView = value; OnPropertyChanged(); }
		}

		public NavigationVM()
		{
			HomeCommand = new RelayCommand(Home);
			SubjectCommand = new RelayCommand(Subject);
			GradeCommand = new RelayCommand(Grade);
			AbsenceCommand = new RelayCommand(Absence);
			SettingsCommand = new RelayCommand(Settings);
			AverageCommand = new RelayCommand(Average);
			CurrentView = new HomePageView();
		}

		private void Home(object parameter) => CurrentView = new HomePageView();
		private void Subject(object parameter) => CurrentView = new SubjectPageView();
		private void Grade(object parameter) => CurrentView = new GradePageView();
		private void Average(object parameter) => CurrentView = new AveragePageView();
		private void Absence(object parameter) => CurrentView = new AbsencePageView();
		private void Settings(object parameter) => CurrentView = new SettingsPageView();

	}
}
