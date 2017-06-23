using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVisitor.Models
{
    public  class Country
    {
        public bool Active { get; set; }

        public string AlternativeName { get; set; }

        public string CodeThreeLetters { get; set; }

        public string CodeTwoLetters { get; set; }

        public Guid ID { get; set; }

        public bool IsEUMember { get; set; }

        public bool IsVisaRequired { get; set; }

        public string NameCitizenships { get; set; }

        public string NameNational { get; set; }

        public string NameNationalAlternative { get; set; }

    }
}
