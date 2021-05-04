using System;
using System.IdentityModel.Tokens.Jwt; // para gerar o token
using System.Security.Claims; //para deixar as informações disponíveis para o controllers
using System.Text; //para encodificaro token
using Microsoft.IdentityModel.Tokens;
using backend.Domains.Models;


namespace backend.Services
{
    public static class TokenService
    {
         public static string GenerateToken(User user){
             //gera o token
             var tokenHandler = new JwtSecurityTokenHandler();
             var key = Encoding.ASCII.GetBytes(Settings.Secret);
             var tokenDescriptor = new SecurityTokenDescriptor()
             {
                 Subject = new ClaimsIdentity(new Claim[]{
                     new Claim(ClaimTypes.Name, user.Name.ToString()),
                     new Claim(ClaimTypes.NameIdentifier, user.Cpf.ToString()),
                     new Claim(ClaimTypes.Email, user.Email.ToString())
                 }),
                 Expires = DateTime.UtcNow.AddHours(2),
                 SigningCredentials = 
                    new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature
                    )
             };

             var token = tokenHandler.CreateToken(tokenDescriptor);

             return tokenHandler.WriteToken(token);
         }
    }
}