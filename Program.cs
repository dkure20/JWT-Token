using System;
using System.ComponentModel.DataAnnotations;
using JWTLibrary;
public class Program
{
    public static void Main()
    {
        JWTGenerator generator = new JWTGenerator();
        var payload = new Dictionary<string, object>
        {
            { "sub", "1234567890" },
            { "name", "John Doe" },
            {"expireDate", DateTime.Now.AddMinutes(10) }
        };
        var secretKey = "your-secret-key";
        var jwtToken = generator.Generate(payload, secretKey);
        Console.WriteLine(jwtToken);
        string generatedToken = "eyJhbGciOiJIUzI1NiIsInRvayI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiYWRtaW4iOnRydWUsImV4cGlyZURhdGUiOiIyMDIzLTA2LTE0VDE4OjMzOjMyLjUyMzQxNzgrMDQ6MDAifQ.25e28570a3402fd6f1d80fdb40cf9fdafbe55792eb42a751661cb09efa241581";
        JWTValidator validator = new JWTValidator();
        Dictionary<string, Object> res = validator.ValidateJWT(generatedToken, secretKey);
        Console.WriteLine(res);

    }

}
