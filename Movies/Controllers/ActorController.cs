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
    public class ActorController : ControllerBase
    {
        private readonly IActorBL actorBL;
        private readonly ILoggerService logger;
        public ActorController(IActorBL _actorBL, ILoggerService _logger)
        {
            actorBL = _actorBL;
            logger = _logger;
        }
        [HttpGet]
        [RouteAttribute("GetMovies")]
        public ActorMovieResponseDTO Get(string name)
        {
            try
            {
                return actorBL.GetMovieDetails(name);
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
