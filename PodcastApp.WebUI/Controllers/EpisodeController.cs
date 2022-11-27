using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using PodcastApp.Domain.Interfaces;
using PodcastApp.Domain.Models;
using PodcastApp.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PodcastApp.WebUI.Controllers
{
    public class EpisodeController : Controller
    {
        private readonly ILogger<EpisodeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        public EpisodeController(ILogger<EpisodeController> logger, IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Add(int podcastId)
        {
            // check if user is authorized to add episodes to the podcast with Id = podcastId
            // TODO: check if user is authorized to add episodes to the podcast with Id = podcastId
            var isAuthorized = true;
            if (!isAuthorized)
            {
                return BadRequest();
            }
            var podcastObj = _unitOfWork.Podcasts.Get(podcastId).Result;
            ViewBag.PodcastName = podcastObj.Name;
            ViewBag.PodcastId = podcastObj.Id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAsync(EpisodeViewModel episodeVM)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                await _unitOfWork.Episodes.Add(new Episode { Name = episodeVM.Name, Description = episodeVM.Description, PodcastId = episodeVM.PodcastId, UserId = user.Id });
                var result = _unitOfWork.Complete();
                ViewBag.ResultStatus = "success";
                return View("Add");
            }
            ViewBag.ResultStatus = "fail";
            //ViewBag.CategoriesList = _unitOfWork.Categories.GetAll().Result.ToList().Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList();
            return View(episodeVM);
        }
    }
}
