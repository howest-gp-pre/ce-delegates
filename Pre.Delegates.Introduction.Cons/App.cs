using System;
using Pre.Delegates.Introduction.Core;

namespace Pre.Delegates.Introduction.Cons
{

	public delegate bool FilterFunction(string text);
	public delegate bool SecondFilter(string text, int length);


	public class App
	{

		PersonPrintFunction firstNamePrinter = p => p.FirstName;
		PersonPrintFunction fullNamePrinter = p => p.FullName;
		PersonPrintFunction fullPrinter = p => p.ToString();

        public const int NumberOfPeople = 32;

		FilterFunction filterContainsA = text => text.ToLower().Contains("a");
		FilterFunction filterContainsB = text => text.ToLower().Contains("b");

		public FilterFunction FilterOnLetter(string letter)
		{
			return text => text.ToLower().Contains(letter);
        }

		SecondFilter secondFilter = (text, size) => text.Length > size;

		public bool FilterOnLength(string text, int length)
		{
			return text.Length > 4;
		}


        public App()
		{
		}

		public List<string> FilterList(List<string> names, FilterFunction func)
		{
            List<string> filtered = new List<string>();
            foreach (string name in names)
            {
                if (func.Invoke(name))
                {
                    filtered.Add(name);
                }
            }

			return filtered;
        }


		public void RunFiltered()
		{
            List<string> names =
                new List<string>() { "Alice", "Bob", "Carol", "Dave", "Eve", "Frank" };

            List<string> filtered = FilterList(names, text => text.ToLower().Contains("b"));
            PrintList(filtered);
        }

		public void Run()
		{
			List<Person> people = new List<Person>();

			for (int i=0; i < NumberOfPeople; i++)
			{
				Person p = new Person(
					Faker.NameFaker.FirstName(),
					Faker.NameFaker.LastName(),
					new Address(
						Faker.LocationFaker.Street(),
						Faker.LocationFaker.StreetNumber().ToString(),
						Faker.LocationFaker.City()
						)
					);

				people.Add(p);
			}

			foreach (Person p in people)
			{
				Console.WriteLine(p.ToString(fullNamePrinter));
			}

		}



		public void PrintList(List<string> myList)
		{
			foreach(string element in myList)
			{
				Console.WriteLine(element);
			}
		}
	}
}

