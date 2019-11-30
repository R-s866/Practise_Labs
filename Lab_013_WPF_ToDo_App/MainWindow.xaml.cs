using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab_013_WPF_ToDo_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> taskDiscription = new List<string>();
        public List<Task> tasks = new List<Task>();
        public Task task;

        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }

        /*void Initialise()
        {
            using(var db = new TaskDbEntities2())
            {
                tasks = db.Tasks.ToList();
            }
            foreach(var item in tasks)
            {
                taskDiscription.Add($"{item.TaskDescription,-10}");
            }
        }*/
            
        void Initialise()
        {
            using (var db = new TaskDbEntities2()) 
            {
                tasks = db.Tasks.ToList();
            }

            ListViewMain.ItemsSource = tasks;
            ListViewMain.DisplayMemberPath = "TaskDescription";
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            task = (Task)ListViewMain.SelectedItem;
            if (task != null)
            {
                //ListViewMain = task.TaskId.ToString();
                //TextBoxDescription.Text = task.TaskDescription.ToString();

                //ButtonEdit.IsEnabled = true;
            }
        }

        /*private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonEdit.Content.ToString() == "Edit")
            {
                ButtonEdit.Content = "Save";
                TextBoxId.IsReadOnly = false;
                TextBoxDescription.IsReadOnly = false;
            }
            else if (ButtonEdit.Content.ToString() == "Save")
            {
                using (var db = new TaskDbEntities2())
                {
                    var taskToEdit = db.Tasks.Find(task.TaskId);
                    taskToEdit.TaskDescription = TextBoxDescription.Text;
                        int.TryParse(TextBoxCategoryId.Text,out int result);
                    taskToEdit.CategoryId = result;

                    db.SaveChanges();

                    ListBoxTask.ItemsSource = null;
                    tasks = db.Tasks.ToList();
                    ListBoxTask.ItemsSource = tasks;
                }

                ButtonEdit.Content = "Edit";
                TextBoxId.IsReadOnly = true;
                TextBoxDescription.IsReadOnly = true;
            }
        }*/
    }
}
