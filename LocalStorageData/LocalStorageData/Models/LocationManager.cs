using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalStorageData.Models
{
    public class LocationManager
    {
        public LocationManager()
        {
            Countries.AddRange(new List<ViewModels.Location>()
            {
                new ViewModels.Location()
                {
                    Id=1,
                    Name="Turkey"
                },
                new ViewModels.Location()
                {
                    Id=2,
                    Name="United States"
                },
                new ViewModels.Location()
                {
                    Id=3,
                    Name="United Kingdom"
                }
            });
            Cities.AddRange(new List<ViewModels.Location>()
            {
                new ViewModels.Location()
                {
                    Id=1,
                    Name="Adana",
                    RelationId=1
                },
                new ViewModels.Location()
                {
                    Id=2,
                    Name="Ankara",
                    RelationId=1
                },
                new ViewModels.Location()
                {
                    Id=3,
                    Name="Istanbul",
                    RelationId=1
                },
                new ViewModels.Location()
                {
                    Id=4,
                    Name="Izmir",
                    RelationId=1
                },
                new ViewModels.Location()
                {
                    Id=5,
                    Name="New York",
                    RelationId=2
                },
                new ViewModels.Location()
                {
                    Id=6,
                    Name="Londra",
                    RelationId=3
                }
            });
        }

        private List<ViewModels.Location> countries = new List<ViewModels.Location>();

        public List<ViewModels.Location> Countries
        {
            get { return countries; }
            set { countries = value; }
        }

        private List<ViewModels.Location> cities = new List<ViewModels.Location>();

        public List<ViewModels.Location> Cities
        {
            get { return cities; }
            set { cities = value; }
        }
    }
}
