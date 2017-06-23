using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVisitor.Models
{
    public class DocumentTtype
    {
        public bool Active { get; set; }

        public Guid ID { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public int Sequence { get; set; }

        public string CodeMI { get; set; }
    }
}
