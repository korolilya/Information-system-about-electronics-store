using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Information_system_in_electronics_store
{
    [DataContract]
    public class Country
    {
        private string _name;

        [DataMember]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Country(string name)
        {
            _name = name;
        }

       // public string Inf
       // {
          //  get { return $"{_name}"; }
       // }
    }
}
