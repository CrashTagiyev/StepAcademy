using STepAcademyDB.Context;
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
using STepAcademyDB.Models;
using Microsoft.EntityFrameworkCore;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add_Student(object sender, RoutedEventArgs e)
        {
            try
            {

                using (StepAcademyContext context = new StepAcademyContext())
                {
                    context.Students.Add(new Student()
                    {
                        Firstname = Student_Firstname_TBox.Text,
                        Lastname = Student_Lastname_TBox.Text,
                        Birthday = DateTime.Now,
                        GroupId = Convert.ToInt32(Student_GroupId_TBox.Text),
                    });
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Remove_Student(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StepAcademyContext context = new StepAcademyContext())
                {
                    if (context.Students.Any(s => s.Id == Convert.ToInt32(Id_Remove_Student.Text)))
                    {

                        context.Students.Where(s => s.Id == Convert.ToInt32(Id_Remove_Student.Text)).ExecuteDelete<Student>();
                        context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Id did not found");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Add_Group(object sender, RoutedEventArgs e)
        {
            try
            {

                using (StepAcademyContext context = new())
                {
                    context.Groups.Add(new Group() { GroupName = Group_Name_TBox.Text });
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Remove_Group(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StepAcademyContext context=new())
                {

                    context.Groups.Where(g => g.Id == Convert.ToInt32(Id_Remove_Group.Text)).ExecuteDelete();
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Remove_Teacher(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StepAcademyContext context = new())
                {

                    context.Teachers.Where(g => g.Id == Convert.ToInt32(Id_Remove_Teacher.Text)).ExecuteDelete();
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Add_Teacher(object sender, RoutedEventArgs e)
        {
            try
            {

                using (StepAcademyContext context = new StepAcademyContext())
                {
                    context.Students.Add(new Student()
                    {
                        Firstname = Teacher_Firstname_TBox.Text,
                        Lastname = Teacher_Lastname_TBox.Text,
                        Birthday = DateTime.Now,
                        GroupId = Convert.ToInt32(Teacher_GroupId_TBox.Text),
                    });
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
