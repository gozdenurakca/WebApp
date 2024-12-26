using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

public class MajorAdminController : Controller
{
    
    private readonly UserManager<User> _userManager;

    
    private readonly PasswordHasher<User> _passwordHasher;
    private readonly IConfiguration _configuration;

    public MajorAdminController(PasswordHasher<User> passwordHasher, IConfiguration configuration)
    {
        _passwordHasher = passwordHasher;
        _configuration = configuration;
        

    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string username, string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            ModelState.AddModelError("", "Kullanıcı adı ve şifre gereklidir.");
            return View();
        }

        using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            await connection.OpenAsync();

            string query = @"
                SELECT UserID, Password, UserType
                FROM Users
                WHERE Username = @Username";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", username);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        string storedPasswordHash = reader.GetString(1);
                        var result = _passwordHasher.VerifyHashedPassword(new User(), storedPasswordHash, password);
                        
                        if (result == PasswordVerificationResult.Success)
                        {
                            // Doğru şifre
                            int userId = reader.GetInt32(0);
                            string userType = reader.GetString(2);

                            // Session'a UserID ve UserType kaydet
                            HttpContext.Session.SetInt32("UserID", userId);
                            HttpContext.Session.SetString("UserType", userType);

                            // Kullanıcı türüne göre yönlendirme yap
                            if (userType == "MajorAdmin")
                            {
                                return RedirectToAction("MajorAdminDashboard", "MajorAdmin");
                            }
                            else if (userType == "BranchAdmin")
                            {
                                return RedirectToAction("BranchAdminDashboard", "BranchAdmin");
                            }

                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
                    }
                }
            }
        }

        return View();
    }

    public IActionResult MajorAdminDashboard()
    {
        // MajorAdmin paneli için işlemler
        return View();
    }

    public IActionResult Logout()
    {
        // Oturumu sonlandır
        HttpContext.Session.Clear();
        return RedirectToAction("Login", "Account");
    }
}
