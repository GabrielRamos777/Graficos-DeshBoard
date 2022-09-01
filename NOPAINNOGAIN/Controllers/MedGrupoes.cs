using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NOPAINNOGAIN.Data;
using NOPAINNOGAIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.Json;
using System.Threading.Tasks;

namespace NOPAINNOGAIN.Controllers
{
    [Authorize]
    public class MedGrupoes : Controller
    {
        private readonly ApplicationDbContext _context;

        public MedGrupoes(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MedGrupoes
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> Resultado()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EnviaEmail(MedGrupo medGrupoes)
        {
            
            try
            {
                string nome = Request.Form["Nome"];
                string valor = Request.Form["Valor"];
                if (valor == null || valor == "")
                {
                    TempData["mensagemErro"] = "Por favor insira um valor no campo valor.";
                    return RedirectToAction("Index", "MedGrupoes");
                }
                double RM = (Convert.ToDouble(valor) * (9.92 / 100));
                double RMED = (Convert.ToDouble(valor) * (10.08 / 100));
                double MEDYKLIN = (Convert.ToDouble(valor) * (20.33 / 100));
                double MEDYN = (Convert.ToDouble(valor) * (19.34 / 100));
                double MEDWRITERS = (Convert.ToDouble(valor) * (20.67 / 100));
                double MEDERI = (Convert.ToDouble(valor) * (19.66 / 100));


                ViewBag.Nome = nome;
                ViewBag.Resultado = valor;
                ViewBag.RM = RM;
                ViewBag.RMED = RMED;
                ViewBag.MEDYKLIN = MEDYKLIN;
                ViewBag.MEDYN = MEDYN;
                ViewBag.MEDWRITERS = MEDWRITERS;
                ViewBag.MEDERI = MEDERI;

                TempData["Nome"] = nome.ToString();
                TempData["RM"] = RM.ToString("F");
                TempData["RMED"] = RMED.ToString("F");
                TempData["MEDYKLIN"] = MEDYKLIN.ToString("F");
                TempData["MEDYN"] = MEDYN.ToString("F");
                TempData["MEDWRITERS"] = MEDWRITERS.ToString("F");
                TempData["MEDERI"] = MEDERI.ToString("F");
                TempData["Resultado"] = valor.ToString();
                //SendMail1(); //descomentar quando a função do enviar e-mail, estiver descomentada
                medGrupoes.ID = Guid.NewGuid();
                _context.Add(medGrupoes);
                _context.SaveChanges();
                return Redirect("/MedGrupoes/Resultado");

            }
            catch (Exception)
            { 
                TempData["mensagemErro"] = "Por favor insira um valor no campo valor.";
                return RedirectToAction("Index", "MedGrupoes");
            }
        }

        //[HttpPost]
        //public bool SendMail1()
        //{
        //    try
        //    {

        //        string nome = Request.Form["Nome"];
        //        string valor = Request.Form["Valor"];
        //        double RM = (Convert.ToDouble(valor) * (9.92 / 100));
        //        double RMED = (Convert.ToDouble(valor) * (10.08 / 100));
        //        double MEDYKLIN = (Convert.ToDouble(valor) * (20.33 / 100));
        //        double MEDYN = (Convert.ToDouble(valor) * (19.34 / 100));
        //        double MEDWRITERS = (Convert.ToDouble(valor) * (20.67 / 100));
        //        double MEDERI = (Convert.ToDouble(valor) * (19.66 / 100));
        //        // Estancia da Classe de Mensagem
        //        MailMessage _mailMessage = new MailMessage();
        //        // Remetente
        //        _mailMessage.From = new MailAddress("gmussolini@provertec.com.br");

        //        // Destinatario seta no metodo abaixo

        //        //Contrói o MailMessage
        //        _mailMessage.To.Add("lfigueiredo@provertec.com.br");
        //        _mailMessage.Subject = "Porcentagem MedGrupo foi acionada";
        //        _mailMessage.IsBodyHtml = true;
        //        _mailMessage.Body = $"<h4>Olá Diego, tudo bem?</h4><br>Passando para informar que o Usuário {nome}, acabou de acessar o cálculo MedGrupo:<br><br>O valor de Entrada do {nome}: R${valor}<br>RM: R${RM.ToString("F")}<br>RMED: R${RMED.ToString("F")}<br>MEDYKLIN: R${MEDYKLIN.ToString("F")}<br>MEDYN: R${MEDYN.ToString("F")}<br>MEDWRITERS: R${MEDWRITERS.ToString("F")}<br>MEDERI: R${MEDERI.ToString("F")}<br><br><br>Seguiremos lhe trazendo mais informações sobre o usuário no sistema<br><h4>Obrigado!</h4>";

        //        //CONFIGURAÇÃO COM PORTA
        //        SmtpClient _smtpClient = new SmtpClient("smtp.office365.com", Convert.ToInt32("587"));

        //        //CONFIGURAÇÃO SEM PORTA'   1      
        //        // SmtpClient _smtpClient = new SmtpClient(UtilRsource.ConfigSmtp);

        //        // Credencial para envio por SMTP Seguro (Quando o servidor exige autenticação)
        //        _smtpClient.UseDefaultCredentials = false;
        //        _smtpClient.Credentials = new NetworkCredential("gmussolini@provertec.com.br", "Prover2022!");

        //        _smtpClient.EnableSsl = true;

        //        _smtpClient.Send(_mailMessage);

        //        return true;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        private bool MedGrupoExists(Guid id)
        {
            return _context.MedGrupo.Any(e => e.ID == id);
        }
    }
}


//ViewBag.Valores = new Valores()
//{
//    Nome = nome,
//    Resultado = valor,
//    RM = RM.ToString(),
//    RMEd = RMED.ToString(),
//    MEDYKLIN = MEDYKLIN.ToString(),
//    MEDYN = MEDYN.ToString(),
//    MEDWRITERS = MEDWRITERS.ToString(),
//    MEDERI = MEDERI.ToString(),
//};


