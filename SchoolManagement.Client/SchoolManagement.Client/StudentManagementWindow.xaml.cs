using SchoolManagement.Client.StudentServiceReference;
using SchoolManagement.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace SchoolManagement.Client
{
    public partial class StudentManagementWindow : Window
    {
        private StudentServiceClient _studentServiceClient;
        private ObservableCollection<Student> _students;
        private int _selectedStudentId;

        public StudentManagementWindow()
        {
            InitializeComponent();
            _studentServiceClient = new StudentServiceClient();
            LoadStudents();
        }

        // Method to load all students
        private void LoadStudents()
        {
            try
            {
                var students = _studentServiceClient.GetAllStudents();
                _students = new ObservableCollection<Student>(students);
                dgStudents.ItemsSource = _students;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading students: {ex.Message}");
            }
        }

        // Add student method
        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var student = new Student
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    DateOfBirth = dpDateOfBirth.SelectedDate ?? DateTime.Now,
                    Email = txtEmail.Text,
                    PhoneNumber = txtPhoneNumber.Text,
                    EnrollmentDate = dpEnrollmentDate.SelectedDate ?? DateTime.Now,
                    Major = txtMajor.Text
                };

                _studentServiceClient.AddStudent(student);
                MessageBox.Show("Student added successfully.");
                LoadStudents();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding student: {ex.Message}");
            }
        }

        // Update student method
        private void btnUpdateStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_selectedStudentId > 0)
                {
                    var student = new Student
                    {
                        PersonId = _selectedStudentId,
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        DateOfBirth = dpDateOfBirth.SelectedDate ?? DateTime.Now,
                        Email = txtEmail.Text,
                        PhoneNumber = txtPhoneNumber.Text,
                        EnrollmentDate = dpEnrollmentDate.SelectedDate ?? DateTime.Now,
                        Major = txtMajor.Text
                    };

                    _studentServiceClient.UpdateStudent(student);
                    MessageBox.Show("Student updated successfully.");
                    LoadStudents();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Please select a student to update.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating student: {ex.Message}");
            }
        }

        // Delete student method
        private void btnDeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_selectedStudentId > 0)
                {
                    _studentServiceClient.DeleteStudent(_selectedStudentId);
                    MessageBox.Show("Student deleted successfully.");
                    LoadStudents();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Please select a student to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting student: {ex.Message}");
            }
        }

        // DataGrid selection changed event
        private void dgStudents_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dgStudents.SelectedItem is Student selectedStudent)
            {
                _selectedStudentId = selectedStudent.PersonId;
                txtFirstName.Text = selectedStudent.FirstName;
                txtLastName.Text = selectedStudent.LastName;
                dpDateOfBirth.SelectedDate = selectedStudent.DateOfBirth;
                txtEmail.Text = selectedStudent.Email;
                txtPhoneNumber.Text = selectedStudent.PhoneNumber;
                dpEnrollmentDate.SelectedDate = selectedStudent.EnrollmentDate;
                txtMajor.Text = selectedStudent.Major;
            }
        }

        // Method to clear input fields
        private void ClearFields()
        {
            _selectedStudentId = 0;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            dpDateOfBirth.SelectedDate = null;
            txtEmail.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            dpEnrollmentDate.SelectedDate = null;
            txtMajor.Text = string.Empty;
        }
    }
}
