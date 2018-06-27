using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SoboruApi.Models;

namespace SoboruApi.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly SoboruContext _context;

        public UsuarioController(SoboruContext context)
        {
            _context = context;
        }
    }
}