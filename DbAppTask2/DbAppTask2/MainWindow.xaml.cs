using DbAppTask2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace DbAppTask2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        RegContext db;
        public MainWindow()
        {
            InitializeComponent();

            db = new RegContext();
            db.dbprojects.Load(); // загружаем данные
            employeesGrid.ItemsSource = db.dbprojects.Local.ToBindingList(); // устанавливаем привязку к кэшу

            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (employeesGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < employeesGrid.SelectedItems.Count; i++)
                {
                    Registration employee = employeesGrid.SelectedItems[i] as Registration;
                    if (employee != null)
                    {
                        db.dbprojects.Remove(employee);
                    }
                }
            }
            db.SaveChanges();
        }

        private void submitNewEmployee(object sender, RoutedEventArgs e)
        {
            bool success = true;
            try
            {
                Registration newEmp = new Registration();
                this.DataContext = newEmp;

                if (FullName.Text.Length < 255 && FullName.Text.Length > 5)
                {
                    newEmp.FullName = FullName.Text;
                }
                else
                {
                    success = false;
                    MessageBox.Show("Full Name must be more than 5 characters and mustn't exceed 255 characters  and must contain only latin alphabet.");
                }

                if (Int32.TryParse(Age.Text, out int val))
                {
                    if (val >= 15 && val < 100)
                    {
                        newEmp.Age = val;
                    }
                    else
                    {
                        success = false;
                        MessageBox.Show("Age must be 15<x<100");
                    }

                }
                else
                {
                    success = false;
                    MessageBox.Show("Correct the Age field");
                }

                newEmp.Position = Position.Text;
                newEmp.Gender = Gender.Text;

                if (IsMarriedCB.IsChecked.Equals(true))
                {
                    newEmp.Married = true;
                }
                else
                {
                    newEmp.Married = false;
                }

                if (success == true)
                {
                    db.dbprojects.Add(newEmp);
                    db.SaveChanges();
                    MessageBox.Show("You have successfully registered!");
                    FullName.Text = "";
                    Age.Text = "";
                }
                else
                {
                    MessageBox.Show("ERROR! Check your input, please");
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }

        }
    }
}
