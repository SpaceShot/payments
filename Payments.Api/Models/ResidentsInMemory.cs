using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Payments.Api.Models
{
    public class ResidentsInMemory : IResidents
    {
        private ConcurrentBag<Residence> _residents;

        public ResidentsInMemory()
        {
             if (_residents == null)
            {
                FillResidentsBag();
            }
        }

        public IEnumerable<Residence> Get()
        {
            return _residents;
        }

        public Residence Get(int id)
        {
            return _residents.SingleOrDefault(r => r.Id == id);
        }

        private void FillResidentsBag()
        {
            _residents = new ConcurrentBag<Residence>();

            _residents.Add(new Residence
            {
                Id = 2732,
                Homeowner = new Homeowner
                {
                    Name = "Mike and Leann Cordenoy",
                    Address = "2732 N Barley Sheaf Road",
                    City = "Coatesville",
                    State = "PA",
                    Zip = "19320"
                }
            });

            _residents.Add(new Residence
            {
                Id = 2734,
                Homeowner = new Homeowner
                {
                    Name = "Cory and Francine Goodman",
                    Address = "2734 N Barley Sheaf Road",
                    City = "Coatesville",
                    State = "PA",
                    Zip = "19320"
                }
            });

            _residents.Add(new Residence
            {
                Id = 2719,
                Homeowner = new Homeowner
                {
                    Name = "Jack Movelle",
                    Address = "21482 Avenida Modellandro",
                    City = "San Dimas",
                    State = "CA",
                    Zip = "91573"
                }
            });

            _residents.Add(new Residence
            {
                Id = 2714,
                Homeowner = new Homeowner
                {
                    Name = "Jim Mentle and Melissa Sass",
                    Address = "2714 N Barley Sheaf Road",
                    City = "Coatesville",
                    State = "PA",
                    Zip = "19320"
                }
            });
        }
    }
}