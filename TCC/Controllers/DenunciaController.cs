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
    public class DenunciaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DenunciaController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _webHostEnvironment = hostEnvironment;
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
                Denuncia denuncia = new Denuncia
                {
                    Descricao = model.Descricao,
                    Status = "Pendente",
                    Foto = nomeUnicoArquivo,
                    DenunciaEndereco = model.DenunciaEndereco,
                    DataRealizada = DateTime.Today,
                };

                _context.Denuncias.Add(denuncia);
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
    }
}
