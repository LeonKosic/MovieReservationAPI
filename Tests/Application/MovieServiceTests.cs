using AutoMapper;
using Domain.Interfaces.IRepositories;
using Moq;
using MovieReservationAPI.Models;
using MovieReservationAPI.Models.Entities;
using MovieReservationAPI.Services;

namespace Tests.Application
{

    public class MovieServiceTests
    {
        private readonly MovieService _mov;
        private readonly Mock<IMovieRepository> _movieRepositoryMock = new Mock<IMovieRepository>();
        private readonly Mock<IMapper> _mapper = new Mock<IMapper>();

        public MovieServiceTests()
        {
            _mov = new MovieService(_movieRepositoryMock.Object, _mapper.Object);
        }
        [Fact]
        public async Task GetTest()
        {

            _movieRepositoryMock.Setup(x => x.Get()).ReturnsAsync(MoviesData);
            //todo 
        }

        public static ICollection<Movie> MoviesData =>
            [
                    new (){Id=0,Name="Test1",Description= "TestTest", Duration="12",ReleaseDate= DateOnly.FromDateTime(DateTime.Now)},
                    new (){Id=1,Name= "Ime", Description="Opis",Duration= "20", ReleaseDate=DateOnly.FromDateTime(DateTime.Now.AddDays(1)) }   
            ];
        public static ICollection<MovieDTO> movieDTOs =>
            [
                new () { Id = 0, Name = "Test1", Description = "TestTest", Duration = "12", ReleaseDate = DateOnly.FromDateTime(DateTime.Now) },
                new () {Id=1,Name= "Ime", Description="Opis",Duration= "20", ReleaseDate=DateOnly.FromDateTime(DateTime.Now.AddDays(1)) }
            ];
    }
}