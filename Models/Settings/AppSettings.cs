using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinematicSuite.Models.Settings
{
    public class AppSettings
    {
        public CinematicSuiteSettings CinematicSuiteSettings { get; set; }
        public TMDBSettings TMDBSettings { get; set; }
    }
}
