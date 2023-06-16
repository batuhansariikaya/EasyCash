using EasyCash.Application.Abstractions.Services;
using EasyCash.Application.DTOs;
using EasyCash.Application.Repositories;
using EasyCash.Domain.Entities;
using EasyCash.Domain.Entities.Identity;
using EasyCash.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit.Encodings;

namespace EasyCash.Web.Controllers
{
    public class SendMoneyController : Controller
    {
        readonly UserManager<AppUser> _userManager;
        readonly EasyCashDbContext _context;
        readonly IAccountProcessWriteRepository _accountProcessWriteRepository;

        public SendMoneyController(UserManager<AppUser> userManager, EasyCashDbContext context, IAccountProcessWriteRepository accountProcessWriteRepository)
        {
            _userManager = userManager;
            _context = context;
            _accountProcessWriteRepository = accountProcessWriteRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(SendMoneyDTO sendMoney)
        {
          
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var receiverAccountNumberID = _context.CustomerAccounts.Where(x => x.AccountNumber == sendMoney.ReceiverAccountNumber).Select(y => y.Id).FirstOrDefault();

            var senderAccountNumberID = _context.CustomerAccounts.Where(x => x.AppUser.Id == user.Id).Where(y => y.Currency == "Türk Lirası").Select(z => z.Id).FirstOrDefault();

            var values = new CustomerAccountProcess();
            values.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            values.SenderID = senderAccountNumberID;
            values.ProcessType = "Havale";
            values.ReceiverID = receiverAccountNumberID;
            values.Amount = sendMoney.Amount;
            values.Description = sendMoney.Description;

            await _accountProcessWriteRepository.AddAsync(values);
            _accountProcessWriteRepository.SaveAsync();

            return View("Index","Deneme");
        }    
    }
}
