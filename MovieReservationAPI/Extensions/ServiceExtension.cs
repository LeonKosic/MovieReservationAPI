using AutoMapper;
using Domain.Interfaces.IRepositories;
using Infrastructure.Repositories;
using MovieReservationAPI.Interfaces.IServices;
using MovieReservationAPI.Models;
using MovieReservationAPI.Models.Entities;
using MovieReservationAPI.Services;
using ScheduleReservationAPI.Services;

namespace MovieReservationAPI.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddConfig (this IServiceCollection services, IConfiguration config)
        {
            return services;
        }

        public static IServiceCollection AddDependencyGroup(this IServiceCollection services)
        {
            return services.AddServices().AddRepositories().AddMapper();
        }
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.CreateMap<Movie, MovieDTO>();
                cfg.CreateMap<MovieDTO,Movie>();
                cfg.CreateMap<Seat, SeatDTO>();
                cfg.CreateMap<SeatDTO, Seat>();
                cfg.CreateMap<Theater,TheaterDTO>();
                cfg.CreateMap<TheaterDTO,Theater>();
                cfg.CreateMap<Ticket,TicketDTO>();
                cfg.CreateMap<TicketDTO,Ticket>();
                cfg.CreateMap<Schedule, ScheduleDTO>();
                cfg.CreateMap<ScheduleDTO, Schedule>();
            });
            services.AddSingleton<IMapper>(c=>configuration.CreateMapper());
            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IMoviesService, MoviesService>();
            services.AddScoped<ISchedulesService, SchedulesService>();
            services.AddScoped<ITicketsService, TicketsService>();
            services.AddScoped<ISeatsService, SeatsService>();
            services.AddScoped<ITheatersService, TheatersService>();
            return services;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IScheduleRepository, ScheduleRepository>();
            services.AddTransient<ITicketRepository, TicketRepository>();
            services.AddTransient<ISeatRepository, SeatRepository>();
            services.AddTransient<ITheaterRepository, TheaterRepository>();
            return services;
        }
    }
}
