using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Test.Models
{
    public class User
    {
        public string id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string avatar { get; set; }
    }

    public class Data
    {
        public List<User> data { get; set; }
    }
    // https://stackoverflow.com/questions/39084684/deserialize-json-object-does-not-work helped me with this
}
