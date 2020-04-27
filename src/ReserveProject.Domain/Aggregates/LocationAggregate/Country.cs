using System;
using ReserveProject.Domain.Shared.Abstract;

namespace ReserveProject.Domain.Aggregates.Location
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public Country()
        {
        }

        public static Country Create(string name, string countryCode)
        {
            var country = new Country()
            {
                Name = name,
                CountryCode = countryCode
            };

            return country;
        }
        public void Update(string name, string countryCode)
        {
            Name = name;
            CountryCode = countryCode;
        }
    }
    public class State : BaseEntity
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public State()
        {
        }

        public static State Create(string name, int countryId)
        {
            var state = new State()
            {
                Name = name,
                CountryId = countryId
            };

            return state;
        }
        public void Update(string name, int countryId)
        {
            Name = name;
            CountryId = countryId;
        }
    }
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public int StateId { get; set; }
        public virtual State State { get; set; }
        public City()
        {
        }
        public static City Create(string name, int stateId)
        {
            var city = new City()
            {
                Name = name,
                StateId = stateId
            };

            return city;
        }
        public void Update(string name, int stateId)
        {
            Name = name;
            StateId = stateId;
        }
    }
}
