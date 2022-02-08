using System;
using System.Collections.Generic;

namespace Lab_2
{
    class Person : IDateAndCopy, IComparable, IComparer<Person>
    {
        protected string firstName;
        protected string secondName;
        protected DateTime dateOfBirth;
        public string GetFirstName { get { return firstName; } set { firstName = value; }  }
        public string GetSecondName { get { return secondName; } set { secondName = value; } }
        public DateTime GetDateOfBirth { get { return dateOfBirth; } set { dateOfBirth = value; } }
        public Person() { firstName = "Ivan"; secondName = "Petrov"; dateOfBirth = new DateTime(2015, 01,10); }
        public Person(string firstName, string secondName, DateTime dateOfBirth) { this.firstName = firstName; this.secondName = secondName; this.dateOfBirth = dateOfBirth; }
        public virtual string ToShortString() { return firstName + " " + secondName; }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            Person person = (Person)obj;
            return (this.firstName == person.firstName) && (this.secondName == person.secondName) && (this.dateOfBirth == person.dateOfBirth);
        }
        public static bool operator == (Person p1, Person p2)
        {
            bool result = false;
            if (p1.firstName.Equals(p2.firstName))
                if (p1.secondName.Equals(p2.secondName))
                    if (p1.dateOfBirth.Equals(p2.dateOfBirth))
                        result = true;
            return result;
        }
        public static bool operator != (Person p1, Person p2)
        {
            bool result = true;
            if (p1.firstName.Equals(p2.firstName))
                if (p1.secondName.Equals(p2.secondName))
                    if (p1.dateOfBirth.Equals(p2.dateOfBirth))
                        result = false;
            return result;
         }
        public override string ToString()
        {
            return firstName + " " + secondName + " " + dateOfBirth.ToShortDateString();
        }
        public override int GetHashCode()
        {
            return (firstName, secondName, dateOfBirth).GetHashCode();
        }
        public virtual object DeepCopy() 
        {
            Person person = new Person(firstName, secondName,dateOfBirth);
            return person;
        }
        public int Compare(Person firstPerson, Person secondPerson)
        {
            if (firstPerson.dateOfBirth.Year < secondPerson.dateOfBirth.Year)
                return 1;
            if (firstPerson.dateOfBirth.Year > secondPerson.dateOfBirth.Year)
                return -1;
            else return 0;
        }

        public int CompareTo(object obj)
        {
            Person tempPerson = (Person)obj;
            if (tempPerson != null)
                return this.secondName.CompareTo(tempPerson.secondName);
            else
                throw new Exception("Не возможно сравнить 2 объекта");
        }
        DateTime IDateAndCopy.Date { get; set; }
    }
}
