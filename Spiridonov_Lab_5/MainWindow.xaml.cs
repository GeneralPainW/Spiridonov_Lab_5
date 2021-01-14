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

namespace Spiridonov_Lab_5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>


    //public enum Facultys
    //{
    //    IVT, IKT, IB, KT, UTS, MT
    //}

    //public enum Courses
    //{
    //    First_course, Second_course, Third_course, Fourth_course, Fifth_course, Sixth_course
    //}

    //class Student
    //{
    //    private string m_LastName;
    //    public string LastName
    //    {
    //        set
    //        {
    //            if (LastName != "")
    //            {
    //                m_LastName = LastName;
    //            }
    //            else
    //            {
    //                throw new Exception("Неправильно введена фамилия");
    //            }
    //        }
    //        get
    //        {
    //            return m_LastName;
    //        }
    //    }
    //    private string m_FirstName;
    //    public string FirstName
    //    {
    //        set
    //        {
    //            if (FirstName != "")
    //            {
    //                m_FirstName = FirstName;
    //            }
    //            else
    //            {
    //                throw new Exception("Неправильно введено имя");
    //            }
    //        }
    //        get
    //        {
    //            return m_FirstName;
    //        }
    //    }
    //    private string m_MiddleName;
    //    public string MiddleName
    //    {
    //        set
    //        {
    //            if (MiddleName != "")
    //            {
    //                m_MiddleName = MiddleName;
    //            }
    //            else
    //            {
    //                throw new Exception("Неправильно введено отчество");
    //            }
    //        }
    //        get
    //        {
    //            return m_MiddleName;
    //        }
    //    }
    //    private int m_BirthDay;
    //    public int BirthDay
    //    {
    //        set
    //        {
    //            if (BirthDay != 0)
    //            {
    //                m_BirthDay = BirthDay;
    //            }
    //            else
    //            {
    //                throw new Exception("Неправильно введена дата рождения");
    //            }
    //        }
    //        get
    //        {
    //            return m_BirthDay;
    //        }
    //    }

    //    private string m_Address;
    //    public string Address
    //    {
    //        set
    //        {
    //            if (Address != "")
    //            {
    //                m_Address = Address;
    //            }
    //            else
    //            {
    //                throw new Exception("Неправильно введен адрес");
    //            }
    //        }
    //        get
    //        {
    //            return m_Address;
    //        }
    //    }
    //    private int m_TelNumber;
    //    public int TelNumber
    //    {
    //        set
    //        {
    //            if (TelNumber != 0)
    //            {
    //                m_TelNumber = TelNumber;
    //            }
    //        }
    //        get
    //        {
    //            return m_TelNumber;
    //        }
    //    }
    //    Facultys faculty;
    //    Courses course;

    class Student
    {
        private string m_lastname;
        private string m_firstname;
        private string m_middlename;
        private DateTime? m_birthday;
        private string m_address;
        private string m_telnumb;
        private string m_faculty;
        private int m_course;


        public Student(string lastname, string firstname, string middlename, DateTime? birthday, string address, string telnumb, string faculty, int course)
        {
            m_lastname = lastname;
            m_middlename = middlename;
            m_firstname = firstname;
            m_birthday = birthday;
            m_address = address;
            m_telnumb = telnumb;
            m_faculty = faculty;
            m_course = course;
        }

        public string lastName { get => m_lastname; set => m_lastname = value; }
        public string middleName { get => m_middlename; set => m_middlename = value; }

        public string firstName { get => m_firstname; set => m_firstname = value; }
        public DateTime? Birthday { get => m_birthday; }
        public string address { get => m_address; set => m_address = value; }
        public string telNumb
        {
            get => m_telnumb;
            set
            {
                foreach (char c in value)
                {
                    if (Char.IsLetter(c) || char.IsPunctuation(c))
                        throw new Exception("Неправильно набран номер");
                }
                m_telnumb = value;
            }
        }

        public string faculty { get => m_faculty; set => m_faculty = value; }
        public int course
        {
            get => m_course;
            set
            {
                if (value > 0 && value <= 6)
                    m_course = value;
                else
                    throw new Exception("Неправильно указан курс");
            }
        }
        public override string ToString()
        {
            return $"Студент: {lastName} {firstName[0]}. {middleName[0]}. Дата рождения: {Birthday?.ToString("dd.MM.yyyy")}\nОбучается на {course} курсе факультета {faculty}.";
        }

        public string info()
        {
            return $"{lastName} {firstName} {middleName}\n" +
                   $"Дата рождения: {Birthday?.ToString("dd.MM.yyyy")}\n" +
                   $"Обучается на {course}-м курсе факультета {faculty}\n" +
                   $"Проживает: {address}\n" +
                   $"Тел.: {telNumb}";
        }
    }

    public partial class MainWindow : Window
    {

        List<Student> students = new List<Student>();
        bool editMode = false;
        public MainWindow()
        {
            InitializeComponent();


            students.Add(new Student("Иванов", "Иван", "Иванович",
                                             new DateTime(1985, 10, 2), "г. Москва, г. Зеленоград, корп. 900",
                                             "+7 912 283 23 12", "ИВТ", 2));
            students.Add(new Student("Петров", "Петр", "Петрович",
                                             new DateTime(1995, 12, 20), "г. Москва, ул. Верхних Кочегаров, д. 10",
                                             "+7 912 548 11 12", "ИВТ", 3));
            students.Add(new Student("Сидоров", "Сидор", "Сидорович",
                                             new DateTime(2000, 1, 12), "г. Москва, г. Зеленоград, корп. 616",
                                             "+7 964 283 23 12", "ИВТ", 2));
            students.Add(new Student("Кузнецов", "Иван", "Геннадьевич",
                                             new DateTime(1998, 3, 7), "г. Клин, ул. Чайковского, д. 13",
                                             "+7 966 223 19 05", "УТС", 2));
            students.Add(new Student("Мурашов", "Алексей", "Васильевич",
                                             new DateTime(1985, 10, 2), "г. Москва, г. Зеленоград, корп. 2015",
                                             "+7 912 513 42 12", "УТС", 4));
            students.Add(new Student("Козырько", "Сергей", "Сергеевич",
                                             new DateTime(1985, 10, 2), "г. Москва, г. Зеленоград, корп. 1513",
                                             "+7 922 453 11 22", "ВТ", 2));
            students.Add(new Student("Творожина", "Юлия", "Петровна",
                                             new DateTime(1985, 10, 2), "г. Москва, г. Зеленоград, корп. 204",
                                             "+7 999 113 95 11", "ВТ", 2));
            updateListBox(students);

        }

        void updateListBox(List<Student> studs)
        {
            lsbxOutput.Items.Clear();
            foreach (var s in studs)
            {
                lsbxOutput.Items.Add(s);
            }
        }
        private void btnBirthdayFilter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int year = int.Parse(tbxBirthdayFilter.Text);
                updateListBox(students.Where(s => s.Birthday?.Year > year).ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnFacultyFilter_Click(object sender, RoutedEventArgs e)
        {
            updateListBox(students.Where(s => s.faculty == tbxFacultyFilter.Text).ToList());
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            Student stud = lsbxOutput.SelectedItem as Student;
            MessageBox.Show(stud.info(), "Информация о студенте", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (editMode == false)
                {
                    Student student = new Student(tbxLastName.Text,
                      tbxFirstName.Text,
                      tbxMiddleName.Text,
                      dpBirthday.SelectedDate,
                      tbxAddress.Text,
                      tbxTelNumber.Text,
                      tbxFaculty.Text,
                      int.Parse(tbxCourse.Text));
                    students.Add(student);
                }
                else
                {
                    Student student = lsbxOutput.SelectedItem as Student;
                    student.firstName = tbxFirstName.Text;
                    student.lastName = tbxLastName.Text;
                    student.middleName = tbxMiddleName.Text;
                    student.address = tbxAddress.Text;
                    student.telNumb = tbxTelNumber.Text;
                    student.course = int.Parse(tbxCourse.Text);
                    student.faculty = tbxFaculty.Text;
                    editMode = false;
                    btnAdd.Content = "Добавить";
                }
                updateListBox(students);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void lsbxOutput_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Student stud = lsbxOutput.SelectedItem as Student;
            tbxFirstName.Text = stud.firstName;
            tbxLastName.Text = stud.lastName;
            tbxMiddleName.Text = stud.middleName;
            tbxAddress.Text = stud.address;
            tbxTelNumber.Text = stud.telNumb;
            tbxCourse.Text = stud.course.ToString();
            tbxFaculty.Text = stud.faculty;
            btnAdd.Content = "Сохранить";
            editMode = true;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            updateListBox(students);
        }
    }
}
