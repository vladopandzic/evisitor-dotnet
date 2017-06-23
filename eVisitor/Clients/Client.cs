using eVisitor.Core;
using eVisitor.Models;
using eVisitor.Models.Criterias;
using eVisitor.Models.Responses;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace eVisitor
{
    static class ClientExtensions
    {
        public static void appendLoginCookies(this RestRequest countriesRequest, Authentication authentication, ref Dictionary<string, string> LoginCookies)
        {

            foreach (var cookie in LoginCookies)
            {
                countriesRequest.AddCookie(cookie.Key, cookie.Value);
            }
            if (LoginCookies == null || LoginCookies.Count() == 0)
            {
                var cookies = new Client(authentication).Authenticate();
                LoginCookies = new Dictionary<string, string>();
                if (cookies != null)
                {
                    foreach (var cookie in cookies)
                    {

                        if (!LoginCookies.ContainsKey(cookie.Name))
                            LoginCookies.Add(cookie.Name, cookie.Value);

                    }
                    foreach (var cookie in LoginCookies)
                    {
                        countriesRequest.AddCookie(cookie.Key, cookie.Value);
                    }

                }
            }
        }
    }
    public class Client
    {
        public Authentication Auth { get; set; }

        public Dictionary<string, string> LoginCookies = new Dictionary<string, string>();

        public Client(Authentication auth)
        {
            this.Auth = auth;
        }

        public IEnumerable<RestResponseCookie> Authenticate()
        {

            var loginRequest = new RestRequest
            {
                Method = Method.POST,
                Resource = Constants.LoginResource,
                RequestFormat = DataFormat.Json
            };

            loginRequest.AddBody(new { UserName = this.Auth.Username, Password = this.Auth.Password, PersistCookie = false });



            var restClient = new RestClient(Constants.LoginUrl);
            var response = restClient.Execute(loginRequest);

            return response.Content == "true" ? response.Cookies : null;

        }
        public EVisitorResponse<CountriesResponse> Countries()
        {

            var countriesRequest = new RestRequest
            {
                Method = Method.GET,
                Resource = Constants.CountriesResource,
                RequestFormat = DataFormat.Json
            };
            countriesRequest.appendLoginCookies(this.Auth, ref this.LoginCookies);

            var restClient = new RestClient(Constants.BaseUrl);
            IRestResponse response = restClient.Execute(countriesRequest);
            return HandleResponse<CountriesResponse>(response);

        }

        public EVisitorResponse<T> HandleResponse<T>(IRestResponse response)
        {
            if (response == null)
            {
                return new EVisitorResponse<T>(default(T), new ErrorMessage("Auth error", "Greška eVisitor authorizacije.Korisničko ime, lozinka ili šifra objekta nisu dobro uneseni"), HttpStatusCode.Unauthorized);
            }
            else if (response.StatusCode != HttpStatusCode.OK)
            {

                RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer();
                try
                {
                    var error = deserial.Deserialize<ErrorMessage>(response);
                    return new EVisitorResponse<T>(default(T), new ErrorMessage(error.SystemMessage, error.UserMessage), response.StatusCode);
                }
                catch (Exception) {
                    var error = new ErrorMessage("DESERIALIZATION_EXCEPTION!", "DESERIALIZATION_EXCEPTION");
                    return new EVisitorResponse<T>(default(T), new ErrorMessage(error.SystemMessage,error.UserMessage), response.StatusCode);
                }
              

            }
            else if (response.StatusCode == HttpStatusCode.OK)
            {
                RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer();
                var deserialResponse = deserial.Deserialize<T>(response);
                return new EVisitorResponse<T>(deserialResponse, null, response.StatusCode);
            }

            return new EVisitorResponse<T>(default(T), null, response.StatusCode);
        }

        public EVisitorResponse<CitiesResponse> Cities(Criteria criteria)
        {

            var filtersSufix = criteria.Filters != null && criteria.Filters.Count > 0 ? "filters=" + Newtonsoft.Json.JsonConvert.SerializeObject(criteria.Filters) : "";
            var countriesRequest = new RestRequest
            {
                Method = Method.GET,
                Resource = "SettlementLookup/?" + filtersSufix,
                RequestFormat = DataFormat.Json
            };
            countriesRequest.appendLoginCookies(this.Auth, ref this.LoginCookies);


            var restClient = new RestClient(Constants.BaseUrl);
            IRestResponse response = restClient.Execute(countriesRequest);

            return HandleResponse<CitiesResponse>(response);
        }
        public EVisitorResponse<DocumentTypesResponse> DocumentTypes()
        {

            var countriesRequest = new RestRequest
            {
                Method = Method.GET,
                Resource = "DocumentTtypeLookup/",
                RequestFormat = DataFormat.Json
            };
            countriesRequest.appendLoginCookies(this.Auth, ref this.LoginCookies);


            var restClient = new RestClient(Constants.BaseUrl);
            IRestResponse response = restClient.Execute(countriesRequest);

            return HandleResponse<DocumentTypesResponse>(response);

        }
        public EVisitorResponse<VisaTypesResponse> VisaTypes()
        {

            var countriesRequest = new RestRequest
            {
                Method = Method.GET,
                Resource = "VisaTypeLookup/",
                RequestFormat = DataFormat.Json
            };
            countriesRequest.appendLoginCookies(this.Auth, ref this.LoginCookies);


            var restClient = new RestClient(Constants.BaseUrl);
            IRestResponse response = restClient.Execute(countriesRequest);

            return HandleResponse<VisaTypesResponse>(response);

        }
        public EVisitorResponse<BorderCrossingsResponse> BorderCrossings()
        {

            var countriesRequest = new RestRequest
            {
                Method = Method.GET,
                Resource = "BorderCrossingHRlookup/",
                RequestFormat = DataFormat.Json
            };
            countriesRequest.appendLoginCookies(this.Auth, ref this.LoginCookies);


            var restClient = new RestClient(Constants.BaseUrl);
            IRestResponse response = restClient.Execute(countriesRequest);

            return HandleResponse<BorderCrossingsResponse>(response);
        }
        public EVisitorResponse<TouristTaxCategoryResponse> TouristTaxCategories()
        {

            var countriesRequest = new RestRequest
            {
                Method = Method.GET,
                Resource = "TTPaymentCategoryLookup/",
                RequestFormat = DataFormat.Json
            };
            countriesRequest.appendLoginCookies(this.Auth, ref this.LoginCookies);


            var restClient = new RestClient(Constants.BaseUrl);
            IRestResponse response = restClient.Execute(countriesRequest);

            return HandleResponse<TouristTaxCategoryResponse>(response);
        }
        public EVisitorResponse<ArrivalOrganizationsResponse> ArrivalOrganizations(Authentication auth)
        {

            var countriesRequest = new RestRequest
            {
                Method = Method.GET,
                Resource = "ArrivalOrganisationLookup/",
                RequestFormat = DataFormat.Json
            };
            countriesRequest.appendLoginCookies(this.Auth, ref this.LoginCookies);


            var restClient = new RestClient(Constants.BaseUrl);
            IRestResponse response = restClient.Execute(countriesRequest);

            return HandleResponse<ArrivalOrganizationsResponse>(response);
        }
        public EVisitorResponse<OfferedServiceResponse> OfferedServiceResponse()
        {

            var countriesRequest = new RestRequest
            {
                Method = Method.GET,
                Resource = "OfferedServiceTypeLookup/",
                RequestFormat = DataFormat.Json
            };
            countriesRequest.appendLoginCookies(this.Auth, ref this.LoginCookies);


            var restClient = new RestClient(Constants.BaseUrl);
            IRestResponse response = restClient.Execute(countriesRequest);

            return HandleResponse<OfferedServiceResponse>(response);
        }
        public EVisitorResponse<ListOfTouristsResponse> ListOfTourists(Criteria criteria)
        {

            var filtersSufix = criteria.Filters != null && criteria.Filters.Count > 0 ? "filters=" + Newtonsoft.Json.JsonConvert.SerializeObject(criteria.Filters) : "";
            var listOfTouristsRequest = new RestRequest
            {
                Method = Method.GET,
                Resource = "ListOfTourists/?" + filtersSufix,
                RequestFormat = DataFormat.Json
            };
            listOfTouristsRequest.appendLoginCookies(this.Auth, ref this.LoginCookies);

            var restClient = new RestClient(Constants.BaseUrl);
            IRestResponse response = restClient.Execute(listOfTouristsRequest);

            return HandleResponse<ListOfTouristsResponse>(response);
        }

        public EVisitorResponse<Guid> CheckInTourist(CheckInTourist tourist)
        {

            var countriesRequest = new RestRequest
            {
                Method = Method.POST,
                Resource = "CheckInTourist/",
                RequestFormat = DataFormat.Json
            };

            countriesRequest.appendLoginCookies(this.Auth, ref this.LoginCookies);
            countriesRequest.AddBody(tourist);

            var restClient = new RestClient(Constants.BaseUrl);
            IRestResponse response = restClient.Execute(countriesRequest);

            return HandleResponse<Guid>(response);
        }


        public IRestResponse CheckOutTourist(CheckOutTourist tourist)
        {


            var countriesRequest = new RestRequest
            {
                Method = Method.POST,
                Resource = "CheckOutTourist/",
                RequestFormat = DataFormat.Json
            };

            countriesRequest.appendLoginCookies(this.Auth, ref this.LoginCookies);
            countriesRequest.AddBody(tourist);

            var restClient = new RestClient(Constants.BaseUrl);
            IRestResponse response = restClient.Execute(countriesRequest);

            return response;


        }
    }
}
