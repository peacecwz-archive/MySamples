using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalStorageData.ViewModels
{
    public class User
    {
        public Guid Id { get; set; }
        public string NameSurname { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string Job { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public DateTime SaveDate { get; set; }
    }
}
