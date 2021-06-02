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
    public class DenunciaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DenunciaController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _webHostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View(_context.Denuncias.Include(c => c.DenunciaEndereco).ToList());
        }

        public IActionResult EditarStatus(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var denuncia = _context.Denuncias.Include(c => c.DenunciaEndereco).First(c => c.Id == id);            
            if (denuncia == null)
            {
                return NotFound();
            }
            

            return View(denuncia);
        }

        [HttpPost]
        public IActionResult EditarStatus(int id, Denuncia model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            try
            {
                var denuncia = _context.Denuncias.Find(id);
                denuncia.Status = model.Status;
                _context.Update(denuncia);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DenunciaExists(model.Id))
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

            var denuncia = _context.Denuncias.Include(c => c.DenunciaEndereco).First(c => c.Id == id);
            if (denuncia == null)
            {
                return NotFound();
            }


            return View(denuncia);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(Denuncia model, IFormFile imagem)
        {
            try
            {
                
                string nomeUnicoArquivo = UploadedFile(imagem);
                model.Status = "Pendente";
                model.Foto = nomeUnicoArquivo;
                model.DataRealizada = DateTime.Today;

                _context.Denuncias.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            catch(Exception ex)
            {
                return View();
            }            
        }

        private string UploadedFile(IFormFile imagem)
        {
            string nomeUnicoArquivo = null;
            if (imagem != null)
            {
                string pastaFotos = Path.Combine(_webHostEnvironment.WebRootPath, "Imagens/Denuncias");
                nomeUnicoArquivo = Guid.NewGuid().ToString() + "_" + imagem;
                string caminhoArquivo = Path.Combine(pastaFotos, nomeUnicoArquivo);
                using (var fileStream = new FileStream(caminhoArquivo, FileMode.Create))
                {
                    imagem.CopyTo(fileStream);
                }
            }
            return nomeUnicoArquivo;
        }


        private bool DenunciaExists(int id)
        {
            return _context.Denuncias.Any(e => e.Id == id);
        }
    }
}
