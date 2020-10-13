namespace TaxComputationAPI.Helpers.Response
{
    public class Response<T> where T:  class 
    {
        public string ResponseDescription {get;set;}

         public string ResponseCode {get;set;}

         public T values {get;set;}
    }
}