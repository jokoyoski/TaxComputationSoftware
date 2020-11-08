using System.Net;

namespace TaxComputationAPI.Helpers.Response
{
    public class Response<T> where T:  class 
    {
        public string ResponseDescription {get;set;}

         public string Code {get;set;}

         public HttpStatusCode ResponseCode { get; set; }

         public T Values {get;set;}
    }
}