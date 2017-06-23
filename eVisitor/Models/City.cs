using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVisitor.Models
{
    public class City
    {
      

        public bool Active { get; set; }

        public string Name { get; set; }

        public Guid CityMunicipalityHrID { get; set; }

        public string ZIPCode { get; set; }

        public Guid ID { get; set; }

        public bool HasZones { get; set; }
    }
}
