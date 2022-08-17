using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NOPAINNOGAIN.Business.Interfaces;
using NOPAINNOGAIN.Data;
using NOPAINNOGAIN.Interfaces;
using NOPAINNOGAIN.Models;
using static System.Net.Mime.MediaTypeNames;

namespace NOPAINNOGAIN.Controllers
{
    [Authorize]
    public class FuncionariosController : Controller
    {

        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly ApplicationDbContext _context;

        public FuncionariosController(IFuncionarioRepository funcionarioRepository, IEnderecoRepository enderecoRepository, ApplicationDbContext context)
        {
            _funcionarioRepository = funcionarioRepository;
            _enderecoRepository = enderecoRepository;
            _context = context;
        }
        [Route("dashboard")]
        public async Task<IActionResult> Index()
        {
            ViewBag.cliques = _context.MedGrupo.Count();
            ViewBag.comentarios = _context.Comentarios.Count();
            ViewBag.usuarios = _context.Usuarios.Count();
            ViewBag.resultado = _context.Funcionarios.Count();

            return View();
            
        }
        // GET: Funcionarios
        public async Task<IActionResult> Index2()
        {
            return View(await _funcionarioRepository.ObterTodos());
        }
        public async Task<IActionResult> Logar(Usuario usuario)
        {
           // SendMail();
            
            usuario.ID = Guid.NewGuid();
            _context.Add(usuario);
            _context.SaveChanges();
            return Redirect("/dashboard");
        }

        public bool SendMail()
        {
            try
            {
                // Estancia da Classe de Mensagem
                MailMessage _mailMessage = new MailMessage();
                // Remetente
                _mailMessage.From = new MailAddress("gmussolini@provertec.com.br");

                //Contrói o MailMessage
                _mailMessage.To.Add("lfigueiredo@provertec.com.br");
                _mailMessage.Subject = "Usuário Acabou de Logar no Sistema";
                _mailMessage.IsBodyHtml = true;
                _mailMessage.Body = $"<h4>Olá Diego, tudo bem?</h4><br>Um usuário acabou de logar no Sistema, seu negócio está crescendo<h4>Orgulhe-se</h4>Obs: Iremos te trazer mais informações sobre os próximos passos do usuário no sistema<br><h4>Obrigado!</h4>";

                //CONFIGURAÇÃO COM PORTA
                SmtpClient _smtpClient = new SmtpClient("smtp.office365.com", Convert.ToInt32("587"));

                //CONFIGURAÇÃO SEM PORTA
                // SmtpClient _smtpClient = new SmtpClient(UtilRsource.ConfigSmtp);

                // Credencial para envio por SMTP Seguro (Quando o servidor exige autenticação)
                _smtpClient.UseDefaultCredentials = false;
                _smtpClient.Credentials = new NetworkCredential("gmussolini@provertec.com.br", "Prover2022!");

                _smtpClient.EnableSsl = true;

                _smtpClient.Send(_mailMessage);

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool SendMail2()
        {
            try
            {
                // Estancia da Classe de Mensagem
                MailMessage _mailMessage = new MailMessage();
                // Remetente
                _mailMessage.From = new MailAddress("gmussolini@provertec.com.br");

                string nome = Request.Form["Nome"];
                string documento = Request.Form["Documento"];
                DateTime data = Convert.ToDateTime(Request.Form["DataNascimento"]);
                double salario = Convert.ToDouble(Request.Form["Salario"]);
                //Contrói o MailMessage
                _mailMessage.To.Add("lfigueiredo@provertec.com.br");
                _mailMessage.Subject = "Funcionário Cadastrado Com Sucesso ";
                _mailMessage.IsBodyHtml = true;
                _mailMessage.Body = $"<h4>Olá Diego, tudo bem?</h4><br>Tivemos mais um cadastro de Funcionário, segue algumas informações importantes do novo Funcionário:<br><br>Nome: {nome}<br>Documento: {documento}<br>Data de Nascimento: {data.ToString("dd/MM/yyyy")}<br>Salario: R$ {salario.ToString("F")}<br><br>Obs: Seguiremos te trazendo mais informações sobre os próximos passos do usuário no sistema<br><h4>Obrigado!</h4>";

                //CONFIGURAÇÃO COM PORTA
                SmtpClient _smtpClient = new SmtpClient("smtp.office365.com", Convert.ToInt32("587"));

                //CONFIGURAÇÃO SEM PORTA
                // SmtpClient _smtpClient = new SmtpClient(UtilRsource.ConfigSmtp);

                // Credencial para envio por SMTP Seguro (Quando o servidor exige autenticação)
                _smtpClient.UseDefaultCredentials = false;
                _smtpClient.Credentials = new NetworkCredential("gmussolini@provertec.com.br", "Prover2022!");

                _smtpClient.EnableSsl = true;

                _smtpClient.Send(_mailMessage);

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Funcionarios/Details/5
        public async Task<IActionResult> Details(Guid id)
        {

            var funcionario = await ObterFuncionarioEndereco(id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // GET: Funcionarios/Create
        public IActionResult Create()
        {
            return View();

        }
        // POST: Funcionarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Funcionario funcionario)
        {
            //  if (!ModelState.IsValid) return View(funcionario);

            var imgPrefixo = Guid.NewGuid() + "_";
            if (!await UploadArquivo(funcionario.ImagemUpload, imgPrefixo))
            {
                return View(funcionario);
            }

            funcionario.Imagem = imgPrefixo + funcionario.ImagemUpload.FileName;
            await _funcionarioRepository.Adicinar(funcionario);


           SendMail2();
            return RedirectToAction(nameof(Index2));
        }

        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {


            var funcionario = await ObterFuncionarioEndereco(id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Funcionario funcionario)
        {
            if (id != funcionario.ID) return NotFound();
            var funcionarioatualizacao = await ObterFuncionarioEndereco(id);

            funcionario.Imagem = funcionarioatualizacao.Imagem;
            // var funcionario1 = await ObterFuncionarioEndereco(id);
            

            if(funcionario.ImagemUpload != null)
            {
                var imgPrefixo = Guid.NewGuid() + "_";
                if (!await UploadArquivo(funcionario.ImagemUpload, imgPrefixo))
                {
                    return View(funcionario);
                }

                funcionario.Imagem = imgPrefixo + funcionario.ImagemUpload.FileName;
            }



            await _funcionarioRepository.Atualizar(funcionario);

            return RedirectToAction(nameof(Index2));
            if (!ModelState.IsValid) return View(funcionario);

        }

        // GET: Funcionarios/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {

            var funcionario = await ObterFuncionarioEndereco(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var funcionario = await ObterFuncionarioEndereco(id);

            if (funcionario == null) return NotFound();

            await _funcionarioRepository.Remover(id);

            return RedirectToAction(nameof(Index2));
        }

        public async Task<IActionResult> ObterEndereco(Guid id)
        {
            var funcionario = await ObterFuncionarioEndereco(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            return PartialView("_DetalhesEndereco", funcionario);
        }

        public async Task<IActionResult> AtualizarEndereco(Guid id)
        {
            var funcionario = await ObterFuncionarioEndereco(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            return PartialView("_AtualizarEndereco", new Funcionario { Endereco = funcionario.Endereco });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AtualizarEndereco(Funcionario funcionario)
        {


            await _enderecoRepository.Atualizar(funcionario.Endereco);

            var url = Url.Action("ObterEndereco", "Funcionarios", new { id = funcionario.Endereco.FuncionarioId });
            return Json(new { success = true, url });
            if (!ModelState.IsValid) return PartialView("_AtualizarEndereco", funcionario);
        }


        private async Task<Funcionario> ObterFuncionarioEndereco(Guid id)
        {
            return (await _funcionarioRepository.ObterFuncionarioEndereco(id));
        }


        private async Task<bool> UploadArquivo(IFormFile arquivo, string imgPrefixo)
        {
            if (arquivo.Length <= 0) return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens", imgPrefixo + arquivo.FileName);

            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Já existe um arquivo com este nome!");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }
            
            return true;
        }
    }
}
