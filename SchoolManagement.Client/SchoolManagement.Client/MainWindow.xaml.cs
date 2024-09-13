using System.Windows;

namespace SchoolManagement.Client
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Event handler to open the Student Management Window
        private void ManageStudents_Click(object sender, RoutedEventArgs e)
        {
            var studentManagementWindow = new StudentManagementWindow();
            studentManagementWindow.Show();
        }

        // Event handler to open the Teacher Management Window
        private void ManageTeachers_Click(object sender, RoutedEventArgs e)
        {
            var teacherManagementWindow = new TeacherManagementWindow();
            teacherManagementWindow.Show();
        }

        // Event handler to open the Class Management Window
        private void ManageClasses_Click(object sender, RoutedEventArgs e)
        {
            var classManagementWindow = new ClassManagementWindow();
            classManagementWindow.Show();
        }

        // Event handler to open the Person Management Window
        private void ManagePersons_Click(object sender, RoutedEventArgs e)
        {
            var personManagementWindow = new PersonManagementWindow();
            personManagementWindow.Show();
        }

        // Event handler to open the Enrollment Management Window
        private void ManageEnrollments_Click(object sender, RoutedEventArgs e)
        {
            var enrollmentManagementWindow = new EnrollmentManagementWindow();
            enrollmentManagementWindow.Show();
        }
    }
}
