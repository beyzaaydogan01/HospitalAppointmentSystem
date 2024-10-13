using HospitalAppointmentSystem.WebApi.Models;

namespace HospitalAppointmentSystem.WebApi.Repository.Abstracts;

public interface IRepository<TEntiy, TId>
{
    TEntiy? Add(TEntiy entity);
    TEntiy? Update(TEntiy entity);
    TEntiy? Remove(TEntiy entity);
    List<TEntiy> GetAll();
    TEntiy? GetById(TId id);
}
