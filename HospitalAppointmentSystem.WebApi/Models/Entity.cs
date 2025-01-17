﻿namespace HospitalAppointmentSystem.WebApi.Models;

public abstract class Entity<TId>
{
    public TId Id { get; set; }

    public DateTime CreatedDate { get; set; }

}
