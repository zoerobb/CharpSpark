using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResuMeta.Models;
using ResuMeta.DAL.Abstract;
using Microsoft.AspNetCore.Identity;
using ResuMeta.ViewModels;
using System.Linq;
using ResuMeta.Services.Concrete;
using ResuMeta.Services.Abstract;

namespace ResuMeta.Controllers;

public class ResumeController : Controller
{
    private readonly ILogger<ResumeController> _logger;
    private readonly IRepository<UserInfo> _userInfo;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IRepository<Resume> _resumeRepository;
    private readonly IResumeService _resumeService;

    public ResumeController(
        ILogger<ResumeController> logger,
        IRepository<UserInfo> userInfo,
        UserManager<IdentityUser> userManager,
        IRepository<Resume> resumeRepo,
        IResumeService resumeService
        )
    {
        _logger = logger;
        _userInfo = userInfo;
        _userManager = userManager;
        _resumeRepository = resumeRepo;
        _resumeService = resumeService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult CreateResume()
    {
        string id = _userManager.GetUserId(User)!;
        if (id == null)
        {
            return RedirectToAction("Index", "Home");
        }
        UserVM userVM = new UserVM(); 
        userVM.UserId = _userInfo.GetAll().Where(x => x.AspnetIdentityId == id).FirstOrDefault()!.Id;
        return View(userVM);
    }

    public IActionResult YourDashboard()
    {
        return View();
    }

    [HttpGet("Resume/ViewResume/{resumeId}")]
    public IActionResult ViewResume(int resumeId)
    {
        string id = _userManager.GetUserId(User)!;
        if (id == null)
        {
            return RedirectToAction("Index", "Home");
        }
        UserInfo currUser = _userInfo.GetAll().Where(x => x.AspnetIdentityId == id).FirstOrDefault()!;
        Resume userResume = _resumeRepository.GetAll().Where(x => x.Id == resumeId).FirstOrDefault()!;
        if (userResume == null)
        {
            return RedirectToAction("Index", "Home");
        }
        if (userResume.UserInfoId != currUser.Id)
        {
            return RedirectToAction("Index", "Home");
        }
        IdentityUser idUser = _userManager.FindByIdAsync(id).Result!;
        string email = _userManager.GetEmailAsync(idUser).Result!;
        ResumeVM resumeVM = _resumeService.GetResume(resumeId, email!);
        return View(resumeVM);
    }

    [HttpGet("Resume/YourResume/{resumeId}")]
    public IActionResult YourResume(int resumeId)
    {
        string id = _userManager.GetUserId(User)!;
        if (id == null)
        {
            return RedirectToAction("Index", "Home");
        }
        UserInfo currUser = _userInfo.GetAll().Where(x => x.AspnetIdentityId == id).FirstOrDefault()!;
        Resume userResume = _resumeRepository.GetAll().Where(x => x.Id == resumeId).FirstOrDefault()!;
        if (userResume == null)
        {
            return RedirectToAction("Index", "Home");
        }
        if (userResume.UserInfoId != currUser.Id)
        {
            return RedirectToAction("Index", "Home");
        }
        ResumeVM resumeVM = _resumeService.GetResumeHtml(resumeId);
        return View(resumeVM);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
