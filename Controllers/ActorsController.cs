using CinematicSuite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinematicSuite.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IRemoteMovieService _tmdbMovieSevice;
        private readonly IDataMappingService _mappingSevice;

        public ActorsController(IRemoteMovieService tmdbMovieSevice, IDataMappingService mappingSevice)
        {
            _tmdbMovieSevice = tmdbMovieSevice;
            _mappingSevice = mappingSevice;
        }

        public async Task<IActionResult> Details(int id)
        {
            var actor = await _tmdbMovieSevice.ActorDetailAsync(id);
            actor = _mappingSevice.MapActorDetail(actor);
            return View(actor);
        }
        
    }
}
