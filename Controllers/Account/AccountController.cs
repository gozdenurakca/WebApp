using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportSchoolProject;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class AccountController : Controller
{
    private readonly ApplicationDbContext _context;

    public AccountController(ApplicationDbContext context)
    {
        _context = context;
    }

    private bool VerifyPasswordHash(string password, string storedHash)
    {
        var passwordHasher = new PasswordHasher<User>();
        var result = passwordHasher.VerifyHashedPassword(null, storedHash, password);
        return result == PasswordVerificationResult.Success;
    }

    public async Task<IActionResult> Login(string username, string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            ModelState.AddModelError("", "Kullanıcı adı ve şifre gereklidir.");
            return View();
        }

        // Kullanıcıyı veritabanından getir
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        
        if (user == null || !VerifyPasswordHash(password, user.PasswordHash))
        {
            ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
            return View();
        }

        // Kullanıcı doğrulandı, session'a UserID kaydedilebilir
        HttpContext.Session.SetInt32("UserID", Convert.ToInt32(user.Id));

        // Kullanıcı tipine göre yönlendirme yap
        if (user.UserType == "MajorAdmin")
        {
            return RedirectToAction("MajorAdminDashboard", "MajorAdmin");
        }
        else if (user.UserType == "BranchAdmin")
        {
            return RedirectToAction("BranchAdminDashboard", "BranchAdmin");
        }

        // Diğer türler için yönlendirme yapılabilir
        return RedirectToAction("Index", "Home");
    }
}