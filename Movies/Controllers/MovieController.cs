using Microsoft.AspNetCore.Mvc;
using Movies.BL;
using Movies.DTO;
using Movies.InterfaceBL;
using Movies.Jobs;
using Movies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieBL movieBL;
        private readonly ILoggerService logger;
        public MovieController(IMovieBL _movieBL, ILoggerService _logger)
        {
            movieBL = _movieBL;
            logger = _logger;
        }

        [HttpGet]
        [RouteAttribute("GetMovieDetails")]
        public MovieResponseDTO Get(string name)
        {
            try
            {
                return movieBL.GetMovieByName(name);
            }
            catch(Exception ex)
            {
                logger.LogError(ex);
                string message = "An error has raised. Try after some time or contact customer support";
                throw new Exception(message);
            }
        }

    }
}
