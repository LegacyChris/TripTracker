using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripTracker.BackService.Models
{
    public class Repository
    {

        private List<Trip> MyTrips = new List<Trip>
        {
            new Trip
            {
                Id = 1,
                Name = "App Modernization Conference",
                StartDate = new DateTime(2019, 10, 11),
                EndDate = new DateTime(2019, 10, 15)
            },
            new Trip
            {
                Id = 2,
                Name = "Priesthood Conference",
                StartDate = new DateTime(2019, 10, 6),
                EndDate = new DateTime(2019, 10, 10)
            },

            new Trip
            {
                Id = 3,
                Name = "National Youth Summit",
                StartDate = new DateTime(2019, 10, 21),
                EndDate = new DateTime(2019, 10, 25)
            }
        };
        public List<Trip> Get()
        {
            return MyTrips;
        }

        public Trip Get(int id)
        {
            return MyTrips.First(t => t.Id == id);
        }

        public void Add(Trip newTrip)
        {
            MyTrips.Add(newTrip);
        }

        public void Update(Trip tripToUpdate)
        {
            MyTrips.Remove(MyTrips.First(t => t.Id == tripToUpdate.Id));
            Add(tripToUpdate);
        }

        public void Remove (int id)
        {
            MyTrips.Remove(MyTrips.First(t => t.Id == id));
        }
    }
}
