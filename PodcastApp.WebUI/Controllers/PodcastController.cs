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
    public class PodcastController : Controller
    {
        private readonly ILogger<PodcastController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        public PodcastController(ILogger<PodcastController> logger, IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            ViewBag.PodcastList = _unitOfWork.Podcasts.GetAllWithCategory().Result.ToList();
            return View();
        }

        public IActionResult Add()
        {
            ViewBag.CategoriesList = _unitOfWork.Categories.GetAll().Result.ToList().Select(x=> new SelectListItem { Value = x.Id.ToString() , Text = x.Name}).ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAsync(PodcastViewModel podcastVM)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                await _unitOfWork.Podcasts.Add(new Podcast { Name = podcastVM.Name, Description = podcastVM.Description , CategoryId = podcastVM.CategoryId, UserId = user.Id});
                var result = _unitOfWork.Complete();
                ViewBag.ResultStatus = "success";
                return View("Add");
            }
            ViewBag.ResultStatus = "fail";
            ViewBag.CategoriesList = _unitOfWork.Categories.GetAll().Result.ToList().Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList();
            return View(podcastVM);
        }
    }
}
