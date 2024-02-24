using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.DTO;
using Movies.InterfaceBL;
using Movies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreBL genreBL;
        private readonly ILoggerService logger;
        public GenreController(IGenreBL _genreBL, ILoggerService _logger)
        {
            genreBL = _genreBL;
            logger = _logger;
        }
        [HttpGet]
        [RouteAttribute("GetMovies")]
        public GenreMovieResponseDTO Get(string genre)
        {
            try
            {
                return genreBL.GetMovies(genre);
            }
            catch (Exception ex)
            {
                logger.LogError(ex);
                string message = "An error has raised. Try after some time or contact customer support";
                throw new Exception(message);
            }
        }
    }
}
