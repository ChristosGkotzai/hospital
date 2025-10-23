using hospital.Data;
using hospital.Repo.Implement.Rep;
using hospital.Repos.Interface.Per;
using hospital.Repos.Interface.Doc;
using hospital.Repo.Implement.Doc;
using hospital.Services.Implement.Doc;
using hospital.Services.Implement.IDocService;
using Microsoft.EntityFrameworkCore;
using hospital.Services.Interface.IPatientService;
using hospital.Services.Implement.Pat;
using hospital.Repos.Interface.Pat;
using hospital.Repo.Implement.Pat;
using hospital.Repos.Interface.Appo;
using hospital.Repo.Implement.Appo;
using hospital.Services.Interface.IAppoint;
using hospital.Services.Implement.Appo;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPrescriptionRepo, PrescriptionRepo>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IPatientRepo, PatientRepo>();
builder.Services.AddScoped<IDoctorRepo, DoctorRepo>();
builder.Services.AddScoped<IAppointmentRepo, AppointmentRepo>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();

