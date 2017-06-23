using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVisitor.Models
{
    public class ErrorMessage
    {
        public ErrorMessage(string systemMessage,string userMessage)
        {
            this.SystemMessage = systemMessage;
            this.UserMessage = userMessage;
                
        }
        public string SystemMessage { get; set; }

        public string UserMessage { get; set; }
    }
}
