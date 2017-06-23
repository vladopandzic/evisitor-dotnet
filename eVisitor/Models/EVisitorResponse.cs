using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace eVisitor.Models
{
    public class EVisitorResponse<T>
    {
        public EVisitorResponse(T data, ErrorMessage error, HttpStatusCode statusCode)
        {
            this.Data = data;
            this.Error = error;
            this.StatusCode = statusCode;
        }
        public System.Net.HttpStatusCode StatusCode { get; set; }

        public ErrorMessage Error { get; set; }

        public T Data { get; set; }
    }
}
