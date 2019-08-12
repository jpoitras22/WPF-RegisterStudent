using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFRegisterStudent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Course choice;
        int courseHours = 0;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Course course1 = new Course("IT 145");
            Course course2 = new Course("IT 200");
            Course course3 = new Course("IT 201");
            Course course4 = new Course("IT 270");
            Course course5 = new Course("IT 315");
            Course course6 = new Course("IT 328");
            Course course7 = new Course("IT 330");


            comboBox.Items.Add(course1);
            comboBox.Items.Add(course2);
            comboBox.Items.Add(course3);
            comboBox.Items.Add(course4);
            comboBox.Items.Add(course5);
            comboBox.Items.Add(course6);
            comboBox.Items.Add(course7);


            textBox.Text = "";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool registerValidate = false;
                String hoursString = "";
                String courseName = "";

                choice = (Course)(comboBox.SelectedItem);
                registerValidate = choice.IsRegisteredAlready();
                courseName = Convert.ToString(choice.getName());

                if (courseHours >= 9)
                {
                    label3.Foreground = Brushes.Red;
                    label3.Content = "You cannot register for more than 9 credit hours";
                }

                else if (registerValidate == false)
                {
                    choice.SetToRegistered();
                    listBox.Items.Add(choice);
                    courseHours += 3;
                    hoursString = Convert.ToString(courseHours);
                    textBox.Text = hoursString;
                    label3.Foreground = Brushes.Black;
                    label3.Content = "Registration confirmed for " + courseName;
                }

                else if (registerValidate == true)
                {
                    label3.Foreground = Brushes.Red;
                    label3.Content = "You are already registered for " + courseName;
                }

            }
            catch (NullReferenceException)
            {
                label3.Foreground = Brushes.Red;
                label3.Content = "No selection made. Please make a selection";
            }

        }


    }
}
