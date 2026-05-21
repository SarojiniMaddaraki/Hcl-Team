using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using PatientPortalAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// AutoMapper
builder.Services.AddAutoMapper(typeof(PatientPortalAPI.Mapping.MappingProfile));

// FluentValidation - register validators from this assembly
// Requires FluentValidation.AspNetCore package in the project
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<PatientPortalAPI.Validators.PatientValidator>();

// Repositories
builder.Services.AddScoped<PatientPortalAPI.Repositories.Interfaces.IPatientRepository, PatientPortalAPI.Repositories.Implementations.PatientRepository>();
builder.Services.AddScoped<PatientPortalAPI.Repositories.Interfaces.IMedicalRecordRepository, PatientPortalAPI.Repositories.Implementations.MedicalRecordRepository>();
builder.Services.AddScoped<PatientPortalAPI.Repositories.Interfaces.IPrescriptionRepository, PatientPortalAPI.Repositories.Implementations.PrescriptionRepository>();
builder.Services.AddScoped<PatientPortalAPI.Repositories.Interfaces.ILabResultRepository, PatientPortalAPI.Repositories.Implementations.LabResultRepository>();
builder.Services.AddScoped<PatientPortalAPI.Repositories.Interfaces.IVitalsRepository, PatientPortalAPI.Repositories.Implementations.VitalsRepository>();
builder.Services.AddScoped<PatientPortalAPI.Repositories.Interfaces.IInvoiceRepository, PatientPortalAPI.Repositories.Implementations.InvoiceRepository>();

// Services
builder.Services.AddScoped<PatientPortalAPI.Services.Interfaces.IPatientService, PatientPortalAPI.Services.Implementations.PatientService>();
builder.Services.AddScoped<PatientPortalAPI.Services.Interfaces.IMedicalRecordService, PatientPortalAPI.Services.Implementations.MedicalRecordService>();
builder.Services.AddScoped<PatientPortalAPI.Services.Interfaces.IPrescriptionService, PatientPortalAPI.Services.Implementations.PrescriptionService>();
builder.Services.AddScoped<PatientPortalAPI.Services.Interfaces.ILabResultService, PatientPortalAPI.Services.Implementations.LabResultService>();
builder.Services.AddScoped<PatientPortalAPI.Services.Interfaces.IVitalsService, PatientPortalAPI.Services.Implementations.VitalsService>();
builder.Services.AddScoped<PatientPortalAPI.Services.Interfaces.IInvoiceService, PatientPortalAPI.Services.Implementations.InvoiceService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
