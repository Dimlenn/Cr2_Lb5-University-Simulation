using Lab5;
using System.Diagnostics;


int.TryParse(Console.ReadLine(),out int N);

LinkedList<Student> students = new LinkedList<Student>();
Student student = new Student();
University university = new University();

for  (int i = 0; i < 5; i++)
{
    university.GraduateStudents(students);

    foreach (Student stud in students)
    {
        stud.IncreaceCourseNumber(stud);
    }

    int year = 2020 + i;
    DateTime dateTime = new DateTime(year, 1, 1);

    for (int j = 0; j < N; j++)
    {
        students.AddLast(student.CreateStudent(dateTime));
    }
}

int count = 0;
foreach (Student stud in students)
{
    count++;
    Console.WriteLine(stud.BirthDate);
}
Console.WriteLine(count);

Console.WriteLine(student.FindOldestStudent(students));

LinkedList<Student> gifteds = new LinkedList<Student>();
DateOnly oldestDate = student.FindOldestStudent(students);
foreach (Student stud in students)
{
    if (stud.Course == 2 && stud.BirthDate > oldestDate)
    {
        gifteds.AddLast(stud);
    }
}

foreach (Student stud in gifteds)
{
    Console.WriteLine(stud.BirthDate);
}