using Lab5;
using System.Diagnostics;


int.TryParse(Console.ReadLine(),out int N);

LinkedList<Student> university = new LinkedList<Student>();
Student student = new Student();

for  (int i = 0; i < 5; i++)
{
    student.GraduateStudents(university);

    foreach (Student stud in university)
    {
        stud.ChangeCourseNumber();
    }

    int year = 2020 + i;
    DateTime dateTime = new DateTime(year, 1, 1);

    for (int j = 0; j < N; j++)
    {
        university.AddLast(student.CreateStudent(dateTime));
    }
}

int count = 0;
foreach (Student stud in university)
{
    count++;
    Console.WriteLine(stud.BirthDate);
}
Console.WriteLine(count);

Console.WriteLine(student.FindOldestStudent(university));

LinkedList<Student> gifteds = new LinkedList<Student>();
DateOnly oldestDate = student.FindOldestStudent(university);
foreach (Student stud in university)
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