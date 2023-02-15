using System;
namespace Pre.Delegates.Introduction.Core
{
	public class Address
	{

        public string Street { get; }
        public string HouseNr { get; }
        public string City { get; }

        public Address(string street, string houseNr, string city)
        {
            if (string.IsNullOrWhiteSpace(street))
            {
                throw new ArgumentException("Street is required");
            }

            if (string.IsNullOrWhiteSpace(houseNr))
            {
                throw new ArgumentException("HouseNr is required");
            }

            if (string.IsNullOrWhiteSpace(city))
            {
                throw new ArgumentException("City is required");
            }

            Street = street;
            HouseNr = houseNr;
            City = city;
        }

        public override string ToString()
        {
            return $"{Street} {HouseNr}, {City}";
        }
    }
}

