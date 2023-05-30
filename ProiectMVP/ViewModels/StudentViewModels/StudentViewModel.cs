using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using ProiectMVP.Data;
using ProiectMVP.Models;
using ProiectMVP.Views;

namespace ProiectMVP.ViewModels.StudentViewModels;

public class StudentViewModel : BaseViewModel
{
    protected AppDbContext _dbContext;

    private User _loggedInUser;
    public User LoggedInUser
    {
        get => _loggedInUser;
        set
        {
            _loggedInUser = value;
            OnPropertyChanged(nameof(LoggedInUser));
        }
    }

    private List<StudyMaterial> _studyMaterials;
    public List<StudyMaterial> StudyMaterials
    {
        get => _studyMaterials;
        set
        {
            _studyMaterials = value;
            OnPropertyChanged(nameof(StudyMaterials));
        }
    }

    private StudyMaterial? _selectedStudyMaterial;
    public StudyMaterial? SelectedStudyMaterial
    {
        get => _selectedStudyMaterial;
        set
        {
            _selectedStudyMaterial = value;
            OnPropertyChanged(nameof(SelectedStudyMaterial));
            OnPropertyChanged(nameof(IsStudyMaterialSelected));
        }
    }

    public bool IsStudyMaterialSelected => this.SelectedStudyMaterial != null;

    private List<Grade> _grades;
    public List<Grade> Grades
    {
        get => _grades;
        set
        {
            _grades = value;
            OnPropertyChanged(nameof(Grades));
        }
    }

    private List<Average> _gradeAverages;
    public List<Average> GradeAverages
    {
        get => _gradeAverages;
        set
        {
            _gradeAverages = value;
            OnPropertyChanged(nameof(GradeAverages));
        }
    }

    private List<Absence> _absences;
    public List<Absence> Absences
    {
        get => _absences;
        set
        {
            _absences = value;
            OnPropertyChanged(nameof(Absences));
        }
    }

    public ICommand LogOutCommand => new RelayCommand(LogOut);
    public ICommand ReloadCommand => new RelayCommand(Reload);
    public ICommand DownloadMaterialCommand => new RelayCommand(DownloadMaterial, CanActivateDownloadMaterialCommand);

    private void LoadData()
    {
        this.StudyMaterials = this._dbContext.GroupCourses
            .Where(gc => gc.GroupId == this.LoggedInUser.Student.GroupId)
            .Include(gc => gc.Course)
            .SelectMany(gc => gc.Course.StudyMaterials)
            .ToList();

        this.Grades = this._dbContext.Grades
            .Where(g => g.StudentId == this.LoggedInUser.Student.Id)
            .Include(g => g.Course)
            .ToList();
        
        this.GradeAverages = this._dbContext.Averages
            .Where(a => a.StudentId == this.LoggedInUser.Student.Id)
            .Include(a => a.Course)
            .ToList();

        this.Absences = this._dbContext.Absences
            .Where(a => a.StudentId == this.LoggedInUser.Student.Id)
            .Include(a => a.Course)
            .ToList();
    }

    public StudentViewModel(AppDbContext dbContext, User user)
    {
        this._dbContext = dbContext;
        this.LoggedInUser = user;
        this.LoadData();
    }

    public void LogOut(object paramater)
    {
        var mainView = new AuthenticationView(this._dbContext);
        mainView.Show();
        Application.Current.MainWindow.Close();
        Application.Current.MainWindow = mainView;
    }

    public void Reload(object parameter)
    {
        LoadData();
    }

    public bool CanActivateDownloadMaterialCommand(object parameter) => this.SelectedStudyMaterial != null;

    public void DownloadMaterial(object parameter)
    {
        if (SelectedStudyMaterial == null) return;

        var saveFileDialog = new Microsoft.Win32.SaveFileDialog
        {
            FileName = SelectedStudyMaterial.Name,
            DefaultExt = SelectedStudyMaterial.Extension,
            Filter = $"Material files (*{SelectedStudyMaterial.Extension})|*{SelectedStudyMaterial.Extension}"
        };
        
        if (saveFileDialog.ShowDialog() == true)
        {
            var filePath = saveFileDialog.FileName;
            System.IO.File.WriteAllBytes(filePath, SelectedStudyMaterial.Content);
        }
    }
}