using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

public class AccountController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IPasswordHasher<User> _passwordHasher;


    public AccountController(UserManager<User> userManager, SignInManager<User> signInManager,
        IConfiguration configuration, IPasswordHasher<User> passwordHasher)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
        _passwordHasher = passwordHasher;



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
                        var user = new User(); // Create an instance of User class

                        // Verify the password hash
                        var result = _passwordHasher.VerifyHashedPassword(user, storedPasswordHash, password);

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
}

   
