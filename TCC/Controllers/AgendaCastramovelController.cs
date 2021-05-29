using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.Data;
using TCC.Models;

namespace TCC.Controllers
{
    public class AgendaCastramovelController : Controller
    {
        private readonly ApplicationDbContext _context;

        private HorariosController hora;

        public AgendaCastramovelController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult CadastrarEmMassa()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarEmMassa(AgendaCastramovel model, DateTime dataInicial, DateTime dataFinal)
        {
            DateTime data = dataInicial;
            while (data <= dataFinal)
            {
                model.Id = 0;
                model.Data = data;
                hora.Cadastrar(model);
                _context.AgendasCastramovel.Add(model);
                data = data.AddDays(1);
                _context.SaveChanges();
            }

            return View();
        }


        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(AgendaCastramovel model)
        {
            if(model == null)
            {
                return NotFound();
            }
            model.Id = 0;
            hora.Cadastrar(model);
            
            _context.AgendasCastramovel.Add(model);
            _context.SaveChanges();

            return View();
        }


        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AgendaCastramovel agenda = _context.AgendasCastramovel.Include(a => a.Data).First(a => a.Id == id);
            if (agenda == null)
            {
                return NotFound();
            }

            return View(agenda);

        }

        [HttpPost]
        public IActionResult Editar(int id, AgendaCastramovel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            try
            {
                AgendaCastramovel agenda = _context.AgendasCastramovel.Find(id);


                agenda = model;
                
                _context.AgendasCastramovel.Update(agenda);

                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgendaCastramovelExists(model.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

                return RedirectToAction(nameof(Index));
        }

        private bool AgendaCastramovelExists(int id)
        {
            return _context.AgendasCastramovel.Any(e => e.Id == id);
        }

    }
}
