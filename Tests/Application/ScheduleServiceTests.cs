using AutoMapper;
using Domain.Interfaces.IRepositories;
using Moq;
using MovieReservationAPI.Models.Entities;
using MovieReservationAPI.Models;
using MovieReservationAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleReservationAPI.Services;

namespace Tests.Application
{ 
    
    public class ScheduleServiceTests
    {
        private readonly ScheduleService _service;
        private readonly Mock<IScheduleRepository> _repositoryMock = new Mock<IScheduleRepository>();
        private readonly Mock<IMapper> _mapper = new Mock<IMapper>();
        
        public ScheduleServiceTests()
        {

            _service = new ScheduleService(_repositoryMock.Object, _mapper.Object);
        }
        public async Task GetTest()
        {

            _repositoryMock.Setup(x => x.Get()).ReturnsAsync(Entities);
            //todo 
        }

        public static ICollection<Schedule> Entities =>
            [
                    new (){Id=0,Start=DateOnly.FromDateTime(DateTime.Now),End= DateOnly.FromDateTime(DateTime.Now), },
                    new (){Id=1,Name= "Ime", Description="Opis",Duration= "20", ReleaseDate=DateOnly.FromDateTime(DateTime.Now.AddDays(1)) }
            ];
        public static ICollection<ScheduleDTO> Dtos =>
            [
                new () { Id = 0, Name = "Test1", Description = "TestTest", Duration = "12", ReleaseDate = DateOnly.FromDateTime(DateTime.Now) },
                new () {Id=1,Name= "Ime", Description="Opis",Duration= "20", ReleaseDate=DateOnly.FromDateTime(DateTime.Now.AddDays(1)) }
            ];
    }
}



