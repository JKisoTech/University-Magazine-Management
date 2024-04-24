using AutoMapper;
using BusinessLogicLayer.Mappers;
using BusinessLogicLayer.Services.ContributionService;
using BusinessLogicLayer.Services.FacultyService;
using BusinessLogicLayer.Services.StudentService;
using DataAccessLayer.Repositories.SystemRepo;
using BusinessLogicLayer.Services.SystemService;
using BusinessLogicLayer.Services.User;
using BusinessLogicLayer.Services.UsersService;
using DataAccessLayer.Data;
using DataAccessLayer.Repositories.ContributionRepo;
using DataAccessLayer.Repositories.FacultyRepo;
using DataAccessLayer.Repositories.StudentRepo;
using DataAccessLayer.Repositories.User;
using DataAccessLayer.Repositories.UsersRepo;
using Microsoft.EntityFrameworkCore;

namespace COMP1640_BE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add repository to the container.
          
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IFacultyRepository, FacultyRepository>();
            builder.Services.AddScoped<IContributionRepository, ContributionRepository>();
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<ISystemPRepository, SystemPRepository>();

            // Add services to the container.
      
            builder.Services.AddScoped<IUserServices, UserServices>();
            builder.Services.AddScoped<IFacultyServices, FacultyServices>();
            builder.Services.AddScoped<IContributionServices, ContributionServices>();
            builder.Services.AddScoped<IStudentServices, StudentServices>();
            builder.Services.AddScoped<ISystemPServices, SystemPServices>();




            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddDbContext<UniMagDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("UniMagConnectionString"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost4200",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200")
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseCors("AllowLocalhost4200");
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

