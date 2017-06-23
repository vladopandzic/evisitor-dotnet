using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVisitor.Models
{
    public class TouristTaxCategory
    {
        public bool Active { get; set; }

        public string Code { get; set; }

        public string CodeNames { get; set; }

        public Guid ID { get; set; }

        public string Name { get; set; }
    }
}
