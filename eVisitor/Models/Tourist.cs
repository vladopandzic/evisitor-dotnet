using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVisitor.Models
{
    public class Tourist
    {
        public Guid ID { get; set; }

        public string Address { get; set; }

        public string ApplicationNumber { get; set; }
        public string CardNumber { get; set; }

        public bool CheckedOutTourist { get; set; }

        public string Citizenship { get; set; }

        public string DatePlaceOfBirth { get; set; }

        public string DatePlaceOfEntryInRC { get; set; }

        public DateTime DateTimeOfArrival { get; set; }

        public DateTime DateTimeOfDeparture { get; set; }


        public Guid FacilityID { get; set; }

        public string FacilityName { get; set; }

        public DateTime ForeseenStayUntil { get; set; }

        public string Gender { get; set; }


        public string Note { get; set; }

        public DateTime PermitOfStayDate { get; set; }

        public Guid SettlementHrID { get; set; }

        public DateTime StayFrom { get; set; }

        public string SurnameAndName { get; set; }

        public string TouristCheckedOutString { get; set; }

        public string TravelDocumentTypeNumber { get; set; }

        public Guid TTPayerID { get; set; }


    }
}
