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

        [HttpPost]
        public IActionResult Cadastrar(Agendamento model)
        {
            //_context.Entidade.Tolist(); #getAll;
            int result = VerificaHorario(model);

            if (result == 1)
            {
                return View("Horario ocupado");
            }

            if (model == null)
            {
                return NotFound();
            }
            model.Id = 0;

            _context.Agendamentos.Add(model);
            _context.SaveChanges();

            return View();
        }

        public IActionResult Editar(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Agendamento agendamento = _context.Agendamentos.Include(a => a.Horario).First(a => a.Id == id);
            if (agendamento == null)
            {
                return NotFound();
            }

            return View(agendamento);
        }

        [HttpPost]
        public IActionResult Editar(int id, Agendamento model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            try
            {
                Agendamento agendamento = _context.Agendamentos.Find(id);
                agendamento = model;

                _context.Agendamentos.Update(agendamento);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgendamentoExists(model.Id))
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

        private bool AgendamentoExists(int id)
        {
            return _context.Agendamentos.Any(e => e.Id == id);
        }

        private int VerificaHorario (Agendamento model)
        {
            List<Agendamento> lista = _context.Agendamentos.ToList();

            foreach (Agendamento agendamento in lista){
                
                if(model.Horario == agendamento.Horario)
                {
                    return 1;
                }
            }

            return 0;
        }
    }
}
