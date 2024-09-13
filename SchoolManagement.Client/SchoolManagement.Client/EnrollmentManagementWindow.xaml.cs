using SchoolManagement.Client.EnrollmentServiceReference;
using SchoolManagement.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace SchoolManagement.Client
{
    public partial class EnrollmentManagementWindow : Window
    {
        private EnrollmentServiceClient _enrollmentServiceClient;
        private ObservableCollection<Enrollment> _enrollments;
        private int _selectedEnrollmentId;

        public EnrollmentManagementWindow()
        {
            InitializeComponent();
            _enrollmentServiceClient = new EnrollmentServiceClient();
            LoadEnrollments();
        }

        // Method to load all enrollments
        private void LoadEnrollments()
        {
            try
            {
                var enrollments = _enrollmentServiceClient.GetAllEnrollments();
                _enrollments = new ObservableCollection<Enrollment>(enrollments);
                dgEnrollments.ItemsSource = _enrollments;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading enrollments: {ex.Message}");
            }
        }

        // Add enrollment method
        private void btnAddEnrollment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var enrollment = new Enrollment
                {
                    StudentId = int.Parse(txtStudentId.Text),
                    ClassId = int.Parse(txtClassId.Text),
                    Grade = txtGrade.Text
                };

                _enrollmentServiceClient.AddEnrollment(enrollment);
                MessageBox.Show("Enrollment added successfully.");
                LoadEnrollments();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding enrollment: {ex.Message}");
            }
        }

        // Update enrollment method
        private void btnUpdateEnrollment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_selectedEnrollmentId > 0)
                {
                    var enrollment = new Enrollment
                    {
                        EnrollmentId = _selectedEnrollmentId,
                        StudentId = int.Parse(txtStudentId.Text),
                        ClassId = int.Parse(txtClassId.Text),
                        Grade = txtGrade.Text
                    };

                    _enrollmentServiceClient.UpdateEnrollment(enrollment);
                    MessageBox.Show("Enrollment updated successfully.");
                    LoadEnrollments();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Please select an enrollment to update.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating enrollment: {ex.Message}");
            }
        }

        // Delete enrollment method
        private void btnDeleteEnrollment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_selectedEnrollmentId > 0)
                {
                    _enrollmentServiceClient.DeleteEnrollment(_selectedEnrollmentId);
                    MessageBox.Show("Enrollment deleted successfully.");
                    LoadEnrollments();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Please select an enrollment to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting enrollment: {ex.Message}");
            }
        }

        // DataGrid selection changed event
        private void dgEnrollments_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dgEnrollments.SelectedItem is Enrollment selectedEnrollment)
            {
                _selectedEnrollmentId = selectedEnrollment.EnrollmentId;
                txtStudentId.Text = selectedEnrollment.StudentId.ToString();
                txtClassId.Text = selectedEnrollment.ClassId.ToString();
                txtGrade.Text = selectedEnrollment.Grade;
            }
        }

        // Method to clear input fields
        private void ClearFields()
        {
            _selectedEnrollmentId = 0;
            txtStudentId.Text = string.Empty;
            txtClassId.Text = string.Empty;
            txtGrade.Text = string.Empty;
        }
    }
}
