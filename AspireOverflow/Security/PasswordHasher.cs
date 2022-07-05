using Microsoft.AspNetCore.Identity;
using AspireOverflow.Models;
namespace AspireOverflow.Security{
public  class BCryptPasswordHasher<TUser> : IPasswordHasher<TUser> where TUser : User
{
    public  string HashPassword(TUser user, string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, 12);
    }
	
    public  PasswordVerificationResult VerifyHashedPassword(
      TUser user, string hashedPassword, string providedPassword)
    {
        var isValid = BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);

        if (isValid && BCrypt.Net.BCrypt.PasswordNeedsRehash(hashedPassword, 12))
        {
            return PasswordVerificationResult.SuccessRehashNeeded;
        }

        return isValid ? PasswordVerificationResult.Success : PasswordVerificationResult.Failed;
    }
}}