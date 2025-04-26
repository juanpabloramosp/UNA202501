namespace FrontEnd.Helpers.Interfaces
{
    public interface IServiceHelper
    {
         HttpClient HttpClient { get; }  

        HttpResponseMessage GetResponseMessage(string url);
        HttpResponseMessage Post(string url, object data);
        HttpResponseMessage Put(string url, object data);
        HttpResponseMessage Delete(string url);

    }
}
