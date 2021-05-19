using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TCC.Data;
using TCC.Models;

namespace TCC.Controllers
{
    public class ClinicaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ClinicaController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View(_context.Clinicas.Include(c => c.ClinicaEndereco).ToList());
        }

        public IActionResult ClinicasParceiras()
        {
            return View(_context.Clinicas.Include(c => c.ClinicaEndereco).ToList());
        }

        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clinica = _context.Clinicas.Include(c => c.ClinicaEndereco).First(c => c.Id == id);
            if (clinica == null)
            {
                return NotFound();
            }


            return View(clinica);
        }

        [HttpPost]
        public IActionResult Editar(int id, Clinica model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            try
            {
                _context.Update(model);

                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClinicaExists(model.Id))
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

        public IActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clinica = _context.Clinicas.Include(c => c.ClinicaEndereco).First(c => c.Id == id);
            if (clinica == null)
            {
                return NotFound();
            }


            return View(clinica);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Clinica model, IFormFile imagem)
        {

            if(model == null)
            {
                return NotFound();
            }

            try
            {
                model.Id = 0;

                string nomeUnicoArquivo = UploadedFile(imagem);

                /*Clinica clinica = new Clinica
                {
                    ClinicaEndereco = model.ClinicaEndereco,
                    Descricao = model.Descricao,
                    Foto = nomeUnicoArquivo,
                    Nome = model.Nome,
                    Telefone = model.Telefone
                };*/
                model.Foto = nomeUnicoArquivo;

                _context.Clinicas.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Index", "Clinica");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public IActionResult Deletar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clinica = _context.Clinicas.Include(c => c.ClinicaEndereco).FirstOrDefault(m => m.Id == id);
            if (clinica == null)
            {
                return NotFound();
            }

            return View(clinica);
        }

        [HttpPost, ActionName("ConfirmarDelecao")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmarDelecao(int id)
        {
            var clinica = _context.Clinicas.Find(id);
            _context.Clinicas.Remove(clinica);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        private string UploadedFile(IFormFile imagem)
        {
            string nomeUnicoArquivo = null;
            if (imagem != null)
            {
                string pastaFotos = Path.Combine(_webHostEnvironment.WebRootPath, "Imagens/Clinicas");
                nomeUnicoArquivo = Guid.NewGuid().ToString() + "_" + imagem;
                string caminhoArquivo = Path.Combine(pastaFotos, nomeUnicoArquivo);
                using (var fileStream = new FileStream(caminhoArquivo, FileMode.Create))
                {
                    imagem.CopyTo(fileStream);
                }
            }
            return nomeUnicoArquivo;
        }

        private bool ClinicaExists(int id)
        {
            return _context.Clinicas.Any(e => e.Id == id);
        }
    }
}
