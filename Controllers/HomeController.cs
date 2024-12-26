using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SportSchoolProject.Models;

namespace SportSchoolProject.Controllers;

public class HomeController : Controller
{
    public IActionResult Error()
    {
        return RedirectToAction("MajorAdminDashboard", "MajorAdmin");  // Veya uygun olan sayfa
   
    }
}