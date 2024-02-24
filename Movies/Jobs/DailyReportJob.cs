using Microsoft.Extensions.Hosting;
using Movies.BL;
using Movies.DTO;
using Movies.Entity;
using Movies.InterfaceRepo;
using Movies.Repository.QueryRepository;
using Movies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Jobs
{
    public class DailyReportJob : BackgroundService
    {
        private IPersonQueryRepository personRepo;
        private IRoleQueryRepository roleRepo;
        private IMoviePersonMappingQueryRepository mappingRepo;
        private IMovieQueryRepository movieRepo;
        private IGenreQueryRepository genreRepo;
        private IReportService reportService;
        private DateTime LastDailyReportDate;
        public const int JobWaitTime = 30 * 60000; //30 minutes
        public DailyReportJob(IReportService _report)
        {
            personRepo = new PersonQueryRepository();
            roleRepo = new RoleQueryRepository();
            mappingRepo = new MoviePersonMappingQueryRepository();
            movieRepo = new MovieQueryRepository();
            genreRepo = new GenreQueryRepository();
            reportService = _report;
            LastDailyReportDate = DBEntity.RecentDailyReportDate;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                DateTime currentDate = DateTime.Now;

                if (LastDailyReportDate.Date < currentDate.Date) //Checks if the job had already ran today 
                {
                    DailyReportDTO report = new DailyReportDTO();
                    GetActorMovieCountList(report);
                    GetMovieGenreCountList(report);
                    reportService.PublishDailyReport(report);
                    DBEntity.RecentDailyReportDate = LastDailyReportDate = currentDate;
                }
                await Task.Delay(JobWaitTime);  //Job will run again only after 30 mins
            }
        }

        /// <summary>
        /// set Actors with count of movies
        /// </summary>
        /// <param name="report"></param>
        private void GetActorMovieCountList(DailyReportDTO report)
        {
            int actorRoleID = roleRepo.GetRoleIDByName(Constants.Actor);
            var personList = personRepo.GetPersonList();
            var movieMappingList = mappingRepo.GetMoviePersonMappingList();
            //Here we will get the every actor with the count of the movies acted.
            var actorsList = (from m in movieMappingList
                              join p in personList on m.PersonID equals p.ID
                              where m.RoleID == actorRoleID
                              select p.Name)
                              .GroupBy(x => x, (x, grp) => (x, grp.Count())).ToList();
            report.ActorMovieCountList = new List<ActorMovieCountDTO>();
            foreach (var actor in actorsList)
            {
                ActorMovieCountDTO dto = new ActorMovieCountDTO();
                dto.ActorName = actor.Item1;
                dto.MovieCount = actor.Item2;
                report.ActorMovieCountList.Add(dto);
            }
        }

        /// <summary>
        /// Set i) Total genre count of all the movies
        /// ii) Movie count by genres
        /// </summary>
        /// <param name="report"></param>
        private void GetMovieGenreCountList(DailyReportDTO report)
        {
            List<MovieEntity> movieList = movieRepo.GetMovieList(); 
            Dictionary<int, int> movieDict = new Dictionary<int, int>();
            foreach (var movie in movieList) //Looping all the movies
            {
                //As the genreIDs are commaseperated, its splitted here and added to an array
                string[] genreIDs = movie.GenreIDs.Split(','); 

                //Increasing the count of the genre for the genres for wwhich the movies is associated.
                foreach (string genre in genreIDs)
                {
                    int id = Convert.ToInt32(genre);
                    if (!movieDict.ContainsKey(id))
                        movieDict.Add(id, 1);
                    else
                        movieDict[id]++;
                }
            }
            report.GenreCount = movieDict.Count;
            report.MovieGenreCount = new List<MovieGenreCountDTO>();

            var genreList = genreRepo.GetGenreList();
            //As in the movie dictionary, we have only the henre id, not the genre name.
            //So, we are getting the genre name based on the id and assigning it to the response dto.
            foreach (var movie in movieDict)
            {
                MovieGenreCountDTO dto = new MovieGenreCountDTO();
                dto.Genre = genreList.Where(i => i.ID == movie.Key).Select(i => i.Name).FirstOrDefault();
                if (dto.Genre == null)
                    continue;
                dto.MovieCount = movie.Value;
                report.MovieGenreCount.Add(dto);
            }

        }
    }
}
