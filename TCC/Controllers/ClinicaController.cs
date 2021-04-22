using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(Clinica model, IFormFile imagem)
        {
            try
            {
                string nomeUnicoArquivo = UploadedFile(imagem);
                Clinica clinica = new Clinica
                {
                    ClinicaEndereco = model.ClinicaEndereco,
                    Descicao = model.Descicao,
                    Foto = nomeUnicoArquivo,
                    Nome = model.Nome,
                    Telefone = model.Telefone
                };

                _context.Clinicas.Add(clinica);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return View();
            }
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
    }
}
