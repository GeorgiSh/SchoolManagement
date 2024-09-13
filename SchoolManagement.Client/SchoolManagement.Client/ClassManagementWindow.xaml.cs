using SchoolManagement.Client.ClassServiceReference;
using SchoolManagement.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace SchoolManagement.Client
{
    public partial class ClassManagementWindow : Window
    {
        private ClassServiceClient _classServiceClient;
        private ObservableCollection<Class> _classes;
        private int _selectedClassId;

        public ClassManagementWindow()
        {
            InitializeComponent();
            _classServiceClient = new ClassServiceClient();
            LoadClasses();
        }

        // Method to load all classes
        private void LoadClasses()
        {
            try
            {
                var classes = _classServiceClient.GetAllClasses();
                _classes = new ObservableCollection<Class>(classes);
                dgClasses.ItemsSource = _classes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading classes: {ex.Message}");
            }
        }

        // Add class method
        private void btnAddClass_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newClass = new Class
                {
                    ClassName = txtClassName.Text,
                    ClassDescription = txtClassDescription.Text,
                    TeacherId = int.TryParse(txtTeacherId.Text, out int teacherId) ? teacherId : (int?)null
                };

                _classServiceClient.AddClass(newClass);
                MessageBox.Show("Class added successfully.");
                LoadClasses();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding class: {ex.Message}");
            }
        }

        // Update class method
        private void btnUpdateClass_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_selectedClassId > 0)
                {
                    var updatedClass = new Class
                    {
                        ClassId = _selectedClassId,
                        ClassName = txtClassName.Text,
                        ClassDescription = txtClassDescription.Text,
                        TeacherId = int.TryParse(txtTeacherId.Text, out int teacherId) ? teacherId : (int?)null
                    };

                    _classServiceClient.UpdateClass(updatedClass);
                    MessageBox.Show("Class updated successfully.");
                    LoadClasses();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Please select a class to update.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating class: {ex.Message}");
            }
        }

        // Delete class method
        private void btnDeleteClass_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_selectedClassId > 0)
                {
                    _classServiceClient.DeleteClass(_selectedClassId);
                    MessageBox.Show("Class deleted successfully.");
                    LoadClasses();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Please select a class to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting class: {ex.Message}");
            }
        }

        // DataGrid selection changed event
        private void dgClasses_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dgClasses.SelectedItem is Class selectedClass)
            {
                _selectedClassId = selectedClass.ClassId;
                txtClassName.Text = selectedClass.ClassName;
                txtClassDescription.Text = selectedClass.ClassDescription;
                txtTeacherId.Text = selectedClass.TeacherId.ToString();
            }
        }

        // Method to clear input fields
        private void ClearFields()
        {
            _selectedClassId = 0;
            txtClassName.Text = string.Empty;
            txtClassDescription.Text = string.Empty;
            txtTeacherId.Text = string.Empty;
        }
    }
}
