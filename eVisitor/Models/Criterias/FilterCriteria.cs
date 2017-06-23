using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVisitor.Models.Criterias
{
    public enum Operation
    {


        Equal,
        NotEqual,
        Greater,
        GreaterEqual,
        Less,
        LessEqual,
        StartsWith,
        Contains,
        DateIn
    }

    public class Criteria
    {
        public int Psize { get; set; }

        public int Page { get; set; }

        public List<FilterCriteria> Filters { get; set; }

        public string Sort { get; set; }

    }

    public class FilterCriteria
    {
        public string Property { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Operation Operation { get; set; }

        public string Value { get; set; }

    }
}
