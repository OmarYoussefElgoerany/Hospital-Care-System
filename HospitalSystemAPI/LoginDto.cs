using HospitalCareSystem.BL;
using Microsoft.AspNetCore.Mvc;

namespace HospitalSystemAPI
{
    public class LoginDto
    {
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
    }
}