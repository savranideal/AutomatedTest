using ApplicationLibrary;
using ApplicationLibrary.Domain;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MovieManagement.Controllers;
using MovieManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MovieApp.UnitTests
{
    public class MoviesControllerTests
    {
        private readonly Mock<IMovieRepository> _mockRepo;
        private readonly MoviesController _controller;

        public MoviesControllerTests()
        {
            _mockRepo = new Mock<IMovieRepository>();
            _controller = new MoviesController(_mockRepo.Object);
        }

       /// <summary>
       /// Movie Index yüklendi mi?
       /// </summary>
        [Fact]
        public async Task Index_ActionExecutes_ReturnsViewForIndex()
        {
            var result = await _controller.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Index_ActionExecutes_ReturnsExactNumberOfMovies()
        {
            var movieList = new List<Movie>() { new Movie(), new Movie() };

            _mockRepo.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(movieList);

            var result = await _controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var viewModel = movieList.Adapt<IEnumerable<MovieViewModel>>();

            var viewModelResult = Assert.IsType<List<Movie>>(viewResult.Model);
            Assert.Equal(2, viewModelResult.Count);
            Assert.IsType(viewModel.GetType(), viewModelResult);
        }
        /// <summary>
        /// Movie Create Ekranı yüklendi mi
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Create_ActionExecutes_ReturnsViewForCreate()
        {
            var result = await _controller.Create();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Create_InvalidModelState_ReturnsView()
        {
            _controller.ModelState.AddModelError("Name", "Name is required");

            var movieViewModel = new MovieViewModel
            {
                Director = "Director",
                ImdbRating = 9,
                ReleasedYear = 2021
            };

            var result = await _controller.Create(movieViewModel);

            var viewResult = Assert.IsType<ViewResult>(result);
            var testMovie = Assert.IsType<Movie>(viewResult.Model);
            Assert.Equal(movieViewModel.ReleasedYear, testMovie.ReleasedYear);
            Assert.Equal(movieViewModel.Director, testMovie.Director);
            Assert.Equal(movieViewModel.ImdbRating, testMovie.ImdbRating);
        }

        [Fact]
        public async Task Create_InvalidModelState_CreateMovieNeverExecutes()
        {
            _controller.ModelState.AddModelError("Name", "Name is required");

            var moview = new MovieViewModel { ImdbRating = 34 };

            await _controller.Create(moview);

            _mockRepo.Verify(x => x.CreateMovieAsync(It.IsAny<Movie>()), Times.Never);
        }

        [Fact]
        public async Task Create_ModelStateValid_CreateMovieCalledOnce()
        {
            Movie mv = null;
            _mockRepo.Setup(r => r.CreateMovieAsync(It.IsAny<Movie>()))
                .Callback<Movie>(x => mv = x);

            var movie = new MovieViewModel
            {
                Name="Mock Movie",
                Director = "Director",
                ImdbRating = 9,
                ReleasedYear = 2021
            };

            await _controller.Create(movie);

            _mockRepo.Verify(x => x.CreateMovieAsync(It.IsAny<Movie>()), Times.Once);

            Assert.Equal(mv.Name, movie.Name);
            Assert.Equal(mv.Director, movie.Director);
            Assert.Equal(mv.ImdbRating, movie.ImdbRating);
            Assert.Equal(mv.ReleasedYear, movie.ReleasedYear);
        }

        [Fact]
        public async Task Create_ActionExecuted_RedirectsToIndexAction()
        {
            var movie = new MovieViewModel
            {
                Name = "Mock Movie",
                Director = "Director",
                ImdbRating = 9,
                ReleasedYear = 2021
            };

            var result = await _controller.Create(movie);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }
    }
}
