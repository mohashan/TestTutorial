using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Domain
{
    public class Person
    {
        public string FirstName { get; set; }    
        public string LastName { get; set; }

        public string FullName => $"{FirstName}, {LastName}";
    }

    public class Teacher : Person
    {

    }

    public class Student : Person
    {

    }

    public class PersonFactory
    {
        public static Person GetPersonByType(PersonType personType)
        {
            return personType == PersonType.Student ? new Student() : new Teacher();
        }
    }

    public enum PersonType
    {
        Student,
        Teacher
    }
}
