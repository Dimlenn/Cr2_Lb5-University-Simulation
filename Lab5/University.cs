using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class University
    {
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
    }
}
