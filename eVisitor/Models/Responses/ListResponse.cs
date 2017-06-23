using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVisitor.Models.Responses
{
    public class ListResponse<T> 
    {
         public List<T> Records { get; set; }
    }
}
