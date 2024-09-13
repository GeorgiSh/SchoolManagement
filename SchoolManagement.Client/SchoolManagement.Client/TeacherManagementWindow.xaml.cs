using SchoolManagement.Client.TeacherServiceReference;
using SchoolManagement.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace SchoolManagement.Client
{
    public partial class TeacherManagementWindow : Window
    {
        private TeacherServiceClient _teacherServiceClient;
        private ObservableCollection<Teacher> _teachers;
        private int _selectedTeacherId;

        public TeacherManagementWindow()
        {
            InitializeComponent();
            _teacherServiceClient = new TeacherServiceClient();
            LoadTeachers();
        }

        // Method to load all teachers
        private void LoadTeachers()
        {
            try
            {
                var teachers = _teacherServiceClient.GetAllTeachers();
                _teachers = new ObservableCollection<Teacher>(teachers);
                dgTeachers.ItemsSource = _teachers;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading teachers: {ex.Message}");
            }
        }

        // Add teacher method
        private void btnAddTeacher_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var teacher = new Teacher
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    DateOfBirth = dpDateOfBirth.SelectedDate ?? DateTime.Now,
                    Email = txtEmail.Text,
                    PhoneNumber = txtPhoneNumber.Text,
                    HireDate = dpHireDate.SelectedDate ?? DateTime.Now,
                    Department = txtDepartment.Text,
                    SubjectSpecialization = txtSubjectSpecialization.Text
                };

                _teacherServiceClient.AddTeacher(teacher);
                MessageBox.Show("Teacher added successfully.");
                LoadTeachers();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding teacher: {ex.Message}");
            }
        }

        // Update teacher method
        private void btnUpdateTeacher_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_selectedTeacherId > 0)
                {
                    var teacher = new Teacher
                    {
                        PersonId = _selectedTeacherId,
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        DateOfBirth = dpDateOfBirth.SelectedDate ?? DateTime.Now,
                        Email = txtEmail.Text,
                        PhoneNumber = txtPhoneNumber.Text,
                        HireDate = dpHireDate.SelectedDate ?? DateTime.Now,
                        Department = txtDepartment.Text,
                        SubjectSpecialization = txtSubjectSpecialization.Text
                    };

                    _teacherServiceClient.UpdateTeacher(teacher);
                    MessageBox.Show("Teacher updated successfully.");
                    LoadTeachers();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Please select a teacher to update.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating teacher: {ex.Message}");
            }
        }

        // Delete teacher method
        private void btnDeleteTeacher_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_selectedTeacherId > 0)
                {
                    _teacherServiceClient.DeleteTeacher(_selectedTeacherId);
                    MessageBox.Show("Teacher deleted successfully.");
                    LoadTeachers();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Please select a teacher to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting teacher: {ex.Message}");
            }
        }

        // DataGrid selection changed event
        private void dgTeachers_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dgTeachers.SelectedItem is Teacher selectedTeacher)
            {
                _selectedTeacherId = selectedTeacher.PersonId;
                txtFirstName.Text = selectedTeacher.FirstName;
                txtLastName.Text = selectedTeacher.LastName;
                dpDateOfBirth.SelectedDate = selectedTeacher.DateOfBirth;
                txtEmail.Text = selectedTeacher.Email;
                txtPhoneNumber.Text = selectedTeacher.PhoneNumber;
                dpHireDate.SelectedDate = selectedTeacher.HireDate;
                txtDepartment.Text = selectedTeacher.Department;
                txtSubjectSpecialization.Text = selectedTeacher.SubjectSpecialization;
            }
        }

        // Method to clear input fields
        private void ClearFields()
        {
            _selectedTeacherId = 0;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            dpDateOfBirth.SelectedDate = null;
            txtEmail.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            dpHireDate.SelectedDate = null;
            txtDepartment.Text = string.Empty;
            txtSubjectSpecialization.Text = string.Empty;
        }
    }
}
