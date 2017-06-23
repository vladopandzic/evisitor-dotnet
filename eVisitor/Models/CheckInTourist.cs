using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVisitor.Models
{
 
        public class CheckInTourist
        {
          
            public Guid? ID;

        
            public Guid? TTPayerID;


       
            public string AccommodationUnitType;

         
            public string ArrivalOrganisation;

          
            public string Citizenship;


        
            public string CityOfBirth;


          
            public string CityOfResidence;

         

            public string CountryOfBirth;

  

            public string CountryOfResidence;



            public string DateOfBirth;


   
            public string DocumentNumber { get; set; }

            public string DocumentType { get; set; }


            public string Facility { get; set; }


            public string ForeseenStayUntil { get; set; }

 
            public string Gender { get; set; }


            public bool IsTTFlatRatePaymentVacationHome { get; set; }



            public string OfferedServiceType { get; set; }




            public string ResidenceAddress { get; set; }


            public string StayFrom { get; set; }


            public string TimeEstimatedStayUntil { get; set; }


            public string TimeStayFrom { get; set; }

            public string TouristEmail { get; set; }


            public string TouristMiddleName { get; set; }


            public string TouristName { get; set; }

            public string TouristSurname { get; set; }

            public string TouristTelephone { get; set; }

      
            public string TTPaymentCategory { get; set; }
        }

        public class CheckInTouristUpdate
        {

            public Guid? ID;


            public Guid? TTPayerID;


            public string AccommodationUnitType;

            public string ArrivalOrganisation;

            public string Citizenship;


            public string CityOfBirth;



            public string CityOfResidence;



            public string CountryOfBirth;


            public string CountryOfResidence;


            public string DateOfBirth;

            public string DocumentNumber { get; set; }

            public string DocumentType { get; set; }

            public string Facility { get; set; }


            public string ForeseenStayUntil { get; set; }

            public string Gender { get; set; }


            public bool IsTTFlatRatePaymentVacationHome { get; set; }


            public string OfferedServiceType { get; set; }


            public string ResidenceAddress { get; set; }




            public string TimeEstimatedStayUntil { get; set; }



            public string TouristEmail { get; set; }


            public string TouristMiddleName { get; set; }


            public string TouristName { get; set; }


            public string TouristSurname { get; set; }

            public string TouristTelephone { get; set; }


            public string TTPaymentCategory { get; set; }
        }
    
}
