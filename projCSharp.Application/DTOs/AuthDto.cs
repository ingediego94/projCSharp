using System.Runtime.InteropServices.JavaScript;
using projCSharp.Domain.Enums;

namespace projCSharp.Application.DTOs;

// Info requested in Register:
public class RegisterDto
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string NumDoc { get; set; }
    
    public string Email { get; set; }
    public string Password { get; set; }
    
    public int RoleId { get; set; }
}


// Response once you has registered:
public class UserRegisterResponseDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    public string LastName { get; set; }
    public string NumDoc { get; set; }
    
    public string Email { get; set; }
    public  int Role {get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}


// Response when you login:
public class UserAuthResponseDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    public string LastName { get; set; }
    public string NumDoc { get; set; }
    public string Email { get; set; }
    
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    
    public int Role { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}


// Login
public class LoginDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}


// To Refresh
public class RefreshDto
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
}


// To Revoke
public class RevoqueTokenDto
{
    public string Email { get; set; }
}