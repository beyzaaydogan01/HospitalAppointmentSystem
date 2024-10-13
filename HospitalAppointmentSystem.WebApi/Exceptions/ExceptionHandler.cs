using HospitalAppointmentSystem.WebApi.Models.ReturnModels;
using System.Net;

namespace HospitalAppointmentSystem.WebApi.Exceptions
{
    public class ExceptionHandler
    {
       public ReturnModel<T> ReturnModelOfException<T>(Exception ex)
        {
            if (ex.GetType() == typeof(NotFoundException))
            {
                return new ReturnModel<T>
                {
                    Data = default,
                    Message = ex.Message,
                    Success = false,
                    Code = HttpStatusCode.NotFound
                };
            }

            if (ex.GetType() == typeof(ValidationException))
            {
                return new ReturnModel<T>
                {
                    Data = default,
                    Message = ex.Message,
                    Success = false,
                    Code = HttpStatusCode.BadRequest
                };
            }
            if (ex.GetType() == typeof(InvalidAppointmentDateException))
            {
                return new ReturnModel<T>
                {
                    Data = default,
                    Message = ex.Message,
                    Success = false,
                    Code = HttpStatusCode.BadRequest
                };
            }
            return new ReturnModel<T>
            {
                Data = default,
                Message = ex.Message,
                Success = false,
                Code = HttpStatusCode.InternalServerError
            };
        }
    }
}
