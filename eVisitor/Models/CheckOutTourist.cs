using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVisitor.Models
{
    public class CheckOutTourist
    {
        public Guid ID { get; set; }

      
        public Guid? TTPayerID { get; set; }
     
        public string CheckOutDate { get; set; }

        public string CheckOutTime { get; set; }
    }
}
