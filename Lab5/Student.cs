using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Lab5
{
    struct GroupName
    {
        string[] allowableNames = { "БИСТ", "БИВТ", "БПИ" };
        public string name = null;
        string number;
        public GroupName(string name, int number)
        {
            if (allowableNames.Contains(name))
            {
                this.name = name;
            }
            this.number = Convert.ToString(number);
        }
        public string GetName()
        {
            if (name == null || number == null)
            {
                string noGroup = "отсутствует";
                return noGroup;
            }
            string groupName = $"{name}-{number}";
            return groupName;
        }

    }
    internal class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Sex { get; set; }
        public DateOnly BirthDate { get; set; }
        public GroupName GroupName { get; set; }
        public Dictionary<string, int> ExamResults = new Dictionary<string, int>()
        {
            { "Math", 0},
            { "Info", 0},
            { "Russ", 0}
        };

        public int course;
        public int Course
        {
            get { return course; }
            set { if (value > 0 && value < 5) course = value; }
        }


        Random random = new Random();
        private string CreateFirstNameMale()
        {
            string[] maleNames = { "Иван", "Анатолий", "Дмитрий", "Константин", "Александр", "Василий", "Денис" };
            int index = random.Next(maleNames.Length);
            return maleNames[index];
        }
        private string CreateFirstNameFemale()
        {
            string[] femaleNames = { "Екатирина", "Елизавета", "Анна", "Ольга", "Мария", "Таисия", "София" };
            int index = random.Next(femaleNames.Length);
            return femaleNames[index];
        }
        private string CreateLastNameMale()
        {
            string[] maleNames = { "Меленцов", "Кузнецов", "Малашенко", "Шланчак", "Васильев", "Шалырин", "Рябичев" };
            int index = random.Next(maleNames.Length);
            return maleNames[index];
        }
        private string CreateLastNameFemale()
        {
            string[] femaleNames = { "Меленцова", "Кузнецова", "Малашенко", "Шланчак", "Васильева", "Шалырина", "Рябичева" };
            int index = random.Next(femaleNames.Length);
            return femaleNames[index];
        }
        private string CreatePatronimicMale()
        {
            string[] malePatronimic = { "Андреевич", "Валерьевич", "Аркадьевич", "Константинович", "Николаевич", "Владимирович" };
            int index = random.Next(malePatronimic.Length);
            return malePatronimic[index];
        }
        private string CreatePatronimicFemale()
        {
            string[] femalePatronimic = { "Андреевна", "Валерьевна", "Аркадьевна", "Константиновна", "Николаевна", "Владимировна" };
            int index = random.Next(femalePatronimic.Length);
            return femalePatronimic[index];
        }
        private string CreateSex()
        {
            string[] sex = { "МУЖ", "ЖЕН" };
            int index = random.Next(sex.Length);
            return sex[index];
        }
        private DateTime RandomDateTime(DateTime dateNow)
        {
            int yearMin = dateNow.Year - 20;
            var startDate = new DateTime(yearMin, 1, 1);
            int buffer = 2 * 265;
            var newDate = startDate.AddDays(random.Next(buffer));
            return newDate;
        }
        private DateOnly CreateDateOnly(DateTime year)
        {
            DateTime randomDate = RandomDateTime(year);
            return DateOnly.FromDateTime(randomDate);
        }
        private GroupName CreateGroupName(int year)
        {
            string[] groupNames = { "БИСТ", "БИВТ", "БПИ" };
            string groupName = groupNames[random.Next(groupNames.Length)];

            string sYear = Convert.ToString(year);
            sYear = sYear.Substring(2);

            int groupNumber = Convert.ToInt32(sYear);
            GroupName group = new GroupName(groupName, groupNumber);

            return group;
        }
        private Dictionary<string, int> GreateExamResults(Dictionary<string, int> ExamResults)
        {
            ExamResults["Math"] = random.Next(55, 100);
            ExamResults["Info"] = random.Next(55, 100);
            ExamResults["Russ"] = random.Next(55, 100);

            return ExamResults;
        }
        private int CreateCourseNumder()
        {
            int number = 1;
            return number;
        }
        public void ChangeCourseNumber()
        {
            this.Course += 1;
        }
        public void GraduateStudents(LinkedList<Student> university)
        {
            LinkedListNode<Student> currentNode = university.First;

            if (currentNode != null)
            {
                Student student = currentNode.Value;
                while (student.Course == 4)
                {
                    LinkedListNode<Student> temp = currentNode;
                    currentNode = currentNode.Next;
                    university.Remove(temp);
                    student = currentNode.Value;
                }
                    
            }
        }
        public Student CreateStudent(DateTime year)
        {
            Student student = new Student();
            student.Sex = CreateSex();

            if (student.Sex == "МУЖ")
            {
                student.FirstName = CreateFirstNameMale();
                student.LastName = CreateLastNameMale();
                student.Patronymic = CreatePatronimicMale();
            }
            else if (student.Sex == "ЖЕН")
            {
                student.FirstName = CreateFirstNameFemale();
                student.LastName = CreateLastNameFemale();
                student.Patronymic = CreatePatronimicFemale();
            }

            student.BirthDate = CreateDateOnly(year);
            student.GroupName = CreateGroupName(year.Year);
            student.Course = CreateCourseNumder();
            GreateExamResults(student.ExamResults);

            return student;
        }

        public DateOnly FindOldestStudent(LinkedList<Student> university)
        {
            LinkedListNode<Student> currentNode = university.Last;

            if (currentNode != null)
            {
                Student student = currentNode.Value;
                DateOnly oldestDate = student.BirthDate;
                while (student.Course == 1)
                {
                    if (oldestDate > student.BirthDate)
                    {
                        oldestDate = student.BirthDate;
                    }
                    if (currentNode == null)
                        break;
                    student = currentNode.Value;
                    currentNode = currentNode.Previous;
                }
                return oldestDate;
            }
            DateOnly date = new DateOnly(0, 0, 0000);
            return date;
        }
    }
}