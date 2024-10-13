using HospitalAppointmentSystem.WebApi.Contexts;
using HospitalAppointmentSystem.WebApi.Exceptions;
using HospitalAppointmentSystem.WebApi.Repository.Concretes;
using HospitalAppointmentSystem.WebApi.Service.Abstracts;
using HospitalAppointmentSystem.WebApi.Service.Concretes;
using HospitalAppointmentSystem.WebApi.Service.Mappers;
using HospitalAppointmentSystem.WebApi.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<MsSqlContext>();
builder.Services.AddScoped<DoctorRepository>();
builder.Services.AddScoped<ExceptionHandler>();
builder.Services.AddScoped<AppointmentRepository>();
builder.Services.AddScoped<AppointmentMapper>();
builder.Services.AddScoped<AppointmentValidation>();
builder.Services.AddScoped<PatientRepository>();
builder.Services.AddScoped<PatientMapper>();
builder.Services.AddScoped<DoctorMapper>();
builder.Services.AddScoped<IAppointmentService,AppointmentService>();
builder.Services.AddScoped<IDoctorService,DoctorService>();
builder.Services.AddScoped<IPatientService,PatientService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
