using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.Data;

namespace TCC.Controllers
{
    public class AgendamentoController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AgendamentoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Termos()
        {
            return View();
        }

        public IActionResult Cadastrar()
        {
            return View();
        }
    }
}
