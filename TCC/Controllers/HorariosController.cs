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

        public void Cadastrar(AgendaCastramovel model)
        {
            Horarios hora = new Horarios();
            hora.Dia = model.Data;
            hora.Id = 0;
            hora.Disponivel = true;
            int con = 1;
            int time = 8;

            for (int cont = 0; cont <= 17; cont++)
            {
                if(time != 12)
                {
                    if ((con % 2) == 0)
                    {
                        hora.Horario = time + ":30";
                        time++;
                    }
                    else
                    {
                        hora.Horario = time + ":00";
                    }

                }else
                {
                    time++;
                    con++;
                }

                _context.Horarios.Add(hora);

                con++;
            }

            _context.SaveChanges();

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
