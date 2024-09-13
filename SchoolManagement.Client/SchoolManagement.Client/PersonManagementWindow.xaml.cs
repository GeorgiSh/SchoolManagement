using SchoolManagement.Client.PersonServiceReference;
using SchoolManagement.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace SchoolManagement.Client
{
    public partial class PersonManagementWindow : Window
    {
        private PersonServiceClient _personServiceClient;
        private ObservableCollection<Person> _persons;
        private int _selectedPersonId;

        public PersonManagementWindow()
        {
            InitializeComponent();
            _personServiceClient = new PersonServiceClient();
            LoadPersons();
        }

        // Method to load all persons
        private void LoadPersons()
        {
            try
            {
                var persons = _personServiceClient.GetAllPersons();
                _persons = new ObservableCollection<Person>(persons);
                dgPersons.ItemsSource = _persons;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading persons: {ex.Message}");
            }
        }

        // Add person method
        private void btnAddPerson_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var person = new Person
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    DateOfBirth = dpDateOfBirth.SelectedDate ?? DateTime.Now,
                    Email = txtEmail.Text,
                    PhoneNumber = txtPhoneNumber.Text,
                };

                _personServiceClient.AddPerson(person);
                MessageBox.Show("Person added successfully.");
                LoadPersons();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding person: {ex.Message}");
            }
        }

        // Update person method
        private void btnUpdatePerson_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_selectedPersonId > 0)
                {
                    var person = new Person
                    {
                        PersonId = _selectedPersonId,
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        DateOfBirth = dpDateOfBirth.SelectedDate ?? DateTime.Now,
                        Email = txtEmail.Text,
                        PhoneNumber = txtPhoneNumber.Text,
                    };

                    _personServiceClient.UpdatePerson(person);
                    MessageBox.Show("Person updated successfully.");
                    LoadPersons();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Please select a person to update.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating person: {ex.Message}");
            }
        }

        // Delete person method
        private void btnDeletePerson_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_selectedPersonId > 0)
                {
                    _personServiceClient.DeletePerson(_selectedPersonId);
                    MessageBox.Show("Person deleted successfully.");
                    LoadPersons();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Please select a person to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting person: {ex.Message}");
            }
        }

        // DataGrid selection changed event
        private void dgPersons_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dgPersons.SelectedItem is Person selectedPerson)
            {
                _selectedPersonId = selectedPerson.PersonId;
                txtFirstName.Text = selectedPerson.FirstName;
                txtLastName.Text = selectedPerson.LastName;
                dpDateOfBirth.SelectedDate = selectedPerson.DateOfBirth;
                txtEmail.Text = selectedPerson.Email;
                txtPhoneNumber.Text = selectedPerson.PhoneNumber;
            }
        }

        // Method to clear input fields
        private void ClearFields()
        {
            _selectedPersonId = 0;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            dpDateOfBirth.SelectedDate = null;
            txtEmail.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
        }
    }
}
