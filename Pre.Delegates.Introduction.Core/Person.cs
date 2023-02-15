using System;
using System.Net;

namespace Pre.Delegates.Introduction.Core
{

    public delegate string PersonPrintFunction(Person p);

    public class Person
	{
        public Person()
        {

        }
        public Person(string firstName, string lastName, Address address)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentException($"'{nameof(firstName)}' cannot be null or empty.", nameof(firstName));
            }

            if (string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentException($"'{nameof(lastName)}' cannot be null or empty.", nameof(lastName));
            }

            if (address is null)
            {
                throw new ArgumentNullException(nameof(address));
            }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        public Address Address { get; set; }

        public DateTime? Dob { get; set; }

        public override string ToString()
        {
            return $"{FullName}: {Address}";
        }

        public string ToString(PersonPrintFunction customFunc)
        {
            return customFunc(this);
        }
    }
}

