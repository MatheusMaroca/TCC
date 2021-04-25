using Microsoft.AspNetCore.Mvc;
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
                _context.AgendasCastramovel.Add(model);
                data = data.AddDays(1);
            }
            _context.SaveChanges();

            return View();
        }

        [HttpPatch]
        public IActionResult Editar(int id, AgendaCastramovel model)
        {
            AgendaCastramovel agenda = _context.AgendasCastramovel.Find(id);

            agenda.Data = model.Data;
            agenda.Bairro = model.Bairro;
            agenda.CidadeDistrito = model.CidadeDistrito;
            agenda.Numero = model.Numero;
            agenda.Regiao = model.Regiao;
            agenda.Rua = model.Rua;

            _context.AgendasCastramovel.Update(agenda);

            return View();
        }

    }
}
