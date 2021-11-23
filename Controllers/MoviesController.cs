using CinematicSuite.Data;
using CinematicSuite.Models.Settings;
using CinematicSuite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinematicSuite.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppSettings _appSettings;
        private readonly ApplicationDbContext _context;
        private readonly IImageService _imageService;
        private readonly IRemoteMovieService _tmdbMovieService;
        private readonly IDataMappingService _tmdbMappingService;

        public MoviesController(AppSettings appSettings, ApplicationDbContext context, IImageService imageService, IDataMappingService tmdbMappingService, IRemoteMovieService tmdbMovieService)
        {
            _appSettings = appSettings;
            _context = context;
            _imageService = imageService;
            _tmdbMappingService = tmdbMappingService;
            _tmdbMovieService = tmdbMovieService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
