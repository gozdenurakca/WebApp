using Microsoft.AspNetCore.Identity;
using SportSchoolProject.Models;  // User modelinin bulunduğu namespace

public class UserService
{
    private readonly PasswordHasher<User> _passwordHasher;

    public UserService()
    {
        _passwordHasher = new PasswordHasher<User>();
    }

    public string HashPassword(string password)
    {
        var user = new User();  // Şifreyi hash'lemek için bir User objesi oluşturuluyor
        string hashedPassword = _passwordHasher.HashPassword(user, password);  // Şifreyi hash'liyoruz
        return hashedPassword;  // Hash'lenmiş şifreyi döndürüyoruz
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        var user = new User();  // Şifreyi doğrulamak için bir User objesi oluşturuluyor
        var result = _passwordHasher.VerifyHashedPassword(user, hashedPassword, password);  // Şifreyi doğruluyoruz
        return result == PasswordVerificationResult.Success;  // Eğer doğrulama başarılıysa true döneriz
    }
}