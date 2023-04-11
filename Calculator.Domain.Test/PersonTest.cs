using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Domain.Test
{
    public class PersonTest
    {
        [Fact]
        public void fullName_contains_colen()
        {
            // Arrange
            Person person = new();

            // Act
            person.FirstName = "Moha";
            person.LastName = "Shan";

            // Assert
            Assert.Contains(", ", person.FullName);
        }

        [Fact]
        public void get_student_by_personfactory()
        {
            // Arrange
            Person studentPerson = PersonFactory.GetPersonByType(PersonType.Student);

            // Act

            // Assert
            Assert.IsType<Student>(studentPerson);
        }

        [Fact]
        public void is_student_a_person()
        {
            // Arrange
            Person studentPerson = PersonFactory.GetPersonByType(PersonType.Student);

            // Act

            // Assert
            Assert.IsAssignableFrom<Person>(studentPerson);
        }
    }
}
