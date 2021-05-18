using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using TCC.Data;
using TCC.Extensions;
using TCC.Models;

namespace TCC.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _context;

        public RegisterModel(
            UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "{0} - Campo requerido")]
            [MinLength(5, ErrorMessage = "O campo deve conter ao menos 5 caracteres.")]
            [MaxLength(100, ErrorMessage = "O campo deve conter no máximo 100 caracteres.")]
            [Display(Name = "Nome Completo")]
            public string Name { get; set; }

            [Required(ErrorMessage = "{0} - Campo requerido")]
            [StringLength(14, MinimumLength = 13, ErrorMessage = "Informe o telefone corretamente.")]
            [Display(Name = "Celular/Telefone")]
            public string Phone { get; set; }

            [Required(ErrorMessage = "{0} - Campo requerido")]
            [EmailAddress(ErrorMessage = "Email inválido")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "{0} - Campo requerido")]
            [EmailAddress(ErrorMessage = "Email inválido")]
            [Display(Name = "Confirmar email")]
            [Compare("Email", ErrorMessage = "Os emails não conferem.")]
            public string ConfirmEmail { get; set; }

            [Required(ErrorMessage = "{0} - Campo requerido")]
            [StringLength(100, ErrorMessage = "A {0} tem que ter no mínimo {2} caracteres", MinimumLength = 8)]
            [DataType(DataType.Password)]
            [Display(Name = "Senha")]
            public string Password { get; set; }

            [Required(ErrorMessage = "{0} - Campo requerido")]
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "As senha não conferem.")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "{0} - Campo requerido")]
            [CustomValidationCPF(ErrorMessage = "CPF inválido")]
            [Display(Name = "Cpf")]
            public string Cpf { get; set; }

            [Required(ErrorMessage = "{0} - Campo requerido")]
            [Display(Name = "Rg")]
            [MinLength(7, ErrorMessage = "O campo deve conter ao menos 7 caracteres.")]
            [MaxLength(14, ErrorMessage = "O campo deve conter no máximo 14 caracteres.")]
            public string Rg { get; set; }

            [Required(ErrorMessage = "{0} - Campo requerido")]
            [Display(Name = "Cidade/Distrito")]
            public string CidadeDistrito { get; set; }

            [Required(ErrorMessage = "{0} - Campo requerido")]
            [Display(Name = "Região")]
            public string Regiao { get; set; }

            [Required(ErrorMessage = "{0} - Campo requerido")]
            [Display(Name = "Rua")]
            [MinLength(3, ErrorMessage = "O campo deve conter ao menos 3 caracteres.")]
            [MaxLength(100, ErrorMessage = "O campo deve conter no máximo 100 caracteres.")]
            public string Rua { get; set; }

            [Required(ErrorMessage = "{0} - Campo requerido")]
            [Display(Name = "Bairro")]
            [MinLength(3, ErrorMessage = "O campo deve conter ao menos 3 caracteres.")]
            [MaxLength(100, ErrorMessage = "O campo deve conter no máximo 100 caracteres.")]
            public string Bairro { get; set; }

            [Required(ErrorMessage = "{0} - Campo requerido")]
            [Display(Name = "Número")]
            public string Numero { get; set; }


        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            List<string> erros = new List<string>();
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (_context.Users.Where(c => c.Cpf == Input.Cpf).Count() > 0)
            {
                erros.Add("Cpf já cadastrado");
            }
            if (_context.Users.Where(c => c.Rg == Input.Rg).Count() > 0)
            {
                erros.Add("Cpf já cadastrado");
            }
            if (ModelState.IsValid && erros.Count == 0)
            {
                var user = new Usuario { UserName = Input.Email, Email = Input.Email, Cpf = Input.Cpf, Rg = Input.Rg, NomeCompleto = Input.Name, PhoneNumber = Input.Phone, EmailConfirmed = true };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    UsuarioEndereco userEnd = new UsuarioEndereco { UsuarioId = user.Id, Bairro = Input.Bairro, CidadeDistrito = Input.CidadeDistrito, Numero = Convert.ToInt32(Input.Numero), Regiao = Input.Regiao, Rua = Input.Rua };
                    _context.UsuariosEnderecos.Add(userEnd);
                    _context.SaveChanges();
                    _logger.LogInformation("User created a new account with password.");

                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                    //    values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                    //    protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    //if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    //{
                    //    return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    //}
                    //else
                    //{
                    //    await _signInManager.SignInAsync(user, isPersistent: false);
                    //    return LocalRedirect(returnUrl);
                    //}

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            foreach (var error in erros)
            {
                ModelState.AddModelError(string.Empty, error);
            }
            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
