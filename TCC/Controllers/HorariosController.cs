using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.Data;
using TCC.Models;

namespace TCC.Controllers
{
    public class HorariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HorariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public Boolean verificaHorario(Agendamento model)
        {
            List<Horarios> horarios = _context.Horarios.ToList();

            foreach(Horarios hora in horarios)
            {
                if(model.Horarios.Horario == hora.Horario)
                {
                    return object.Equals(hora.Disponivel, true);
                }
            }

            return false;
        }
    }
}
