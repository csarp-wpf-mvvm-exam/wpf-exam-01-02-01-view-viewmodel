﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Kreta.HttpService.Services;
using Kreta.Shared.Responses;
using Kreta.Desktop.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Kreta.Shared.Models.SchoolCitizens;
using Kreta.Shared.Models;

namespace Kreta.Desktop.ViewModels.SchoolCitizens
{
    public partial class StudentViewModel : BaseViewModel
    {        
        private readonly IStudentService? _studentService;
        private readonly IEducationLevelService? _educationLevelService;

        [ObservableProperty]
        private ObservableCollection<Student> _students = new();


        [ObservableProperty]
        private Student _selectedStudent;

        [ObservableProperty]
        private ObservableCollection<EducationLevel> _educationLevels = new();
      
        public StudentViewModel()
        {
            _selectedStudent = new Student();
        }

        public StudentViewModel(IStudentService? studentService, IEducationLevelService? educationLevelService)
        {
            _selectedStudent = new Student();
            _studentService = studentService;
            _educationLevelService = educationLevelService;
        }

        public async override Task InitializeAsync()
        {
            await UpdateView();
        }


        [RelayCommand]
        private async Task DoRemove(Student studentToDelete)
        {
            if (_studentService is not null)
            {
                ControllerResponse result = await _studentService.DeleteAsync(studentToDelete.Id);
                if (result.IsSuccess)
                {
                    await UpdateView();
                }
            }
        }

        [RelayCommand]
        private void DoNewStudent()
        {
            SelectedStudent = new Student();
        }

        private async Task UpdateView()
        {
            if (_educationLevelService is not null)
            {
                List<EducationLevel> educationLevels = await _educationLevelService.SelectAllAsync();
                EducationLevels = new ObservableCollection<EducationLevel>(educationLevels);
            }
            if (_studentService is not null)
            { 
                List<Student> students = await _studentService.SelectAllAsync();
                Students = new ObservableCollection<Student>(students);
            }
        }

    }
}
