using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        public CategoryController(ILogger<CategoryController> logger, IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAsync(CategoryViewModel categoryVM)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                await _unitOfWork.Categories.Add( new Category { Name = categoryVM.Name, Description = categoryVM.Description,UserId = user.Id });
                var result =  _unitOfWork.Complete();
                ViewBag.ResultStatus = "success";
                return View("Add");
            }
            ViewBag.ResultStatus = "fail";
            return View(categoryVM);
        }
    }
}
