using System.Net;

namespace HospitalAppointmentSystem.WebApi.Models.ReturnModels
{
    public class ReturnModel<T>
    {
        public ReturnModel()
        {

        }

        public ReturnModel(bool success, string message, T data, HttpStatusCode code)
        {
            Success = success;
            Message = message;
            Data = data;
            Code = code;
        }

        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
        public HttpStatusCode Code { get; set; }
    }
}
