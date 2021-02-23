using ApplicationLibrary;
using ApplicationLibrary.Domain;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository _repo;

        public MoviesController(IMovieRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _repo.GetAllAsync();
            var viewModel=movies.Adapt<List<MovieViewModel>>();

            return View(viewModel);
        }



        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieViewModel movie)
        {
            if (!ModelState.IsValid)
            {
                return View(movie);
            } 
            var movieEntity = movie.Adapt<Movie>();
            await _repo.CreateMovieAsync(movieEntity);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
