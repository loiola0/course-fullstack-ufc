using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using backend.Domains.Models;
using backend.Domains.Services;
using backend.Extensions;
using backend.Resources;


namespace backend.Controllers
{
    [AllowAnonymous]
    [Route("/api/[controller]")]
    public class AuthenticationController
    {
        
    }
}