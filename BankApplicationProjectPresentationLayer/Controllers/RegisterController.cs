using BankApplicationProjectDtoLayer.Dtos.AppUserDtos;
using BankApplicationProjectEntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace BankApplicationProjectPresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
		[HttpPost]
		public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
		{
			if (ModelState.IsValid)
			{			
				Random random = new Random();
				int code;
				code = random.Next(100000, 1000000);
				AppUser appUser = new AppUser()
				{
					UserName = appUserRegisterDto.UserName,
					Name = appUserRegisterDto.Name,
					Surname = appUserRegisterDto.Surname,
					Email = appUserRegisterDto.Email,
					City="aaaa",
					District="bbbb",
					ImageUrl="cccc",
					ConfirmCode=code
				};

				var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);
				if (result.Succeeded)
				{
					MimeMessage mimeMessage = new MimeMessage();
					MailboxAddress mailboxAddressfrom = new MailboxAddress("Bank Application Admin", "sukrukilinc60@gmail.com");
					MailboxAddress mailboxAddressTo=new MailboxAddress("User",appUser.Email);

					mimeMessage.From.Add(mailboxAddressfrom);
					mimeMessage.To.Add(mailboxAddressTo);

					var bodyBuilder = new BodyBuilder();
					bodyBuilder.TextBody = "Kayıt işlemini gerçekleştirmek için onay kodunuz" + code;
					mimeMessage.Body = bodyBuilder.ToMessageBody();

					mimeMessage.Subject = "Bank Application Onay Kodu";

					SmtpClient client = new SmtpClient();
					client.Connect("smtp.gmail.com",587,false);
					client.Authenticate("sukrukilinc60@gmail.com", "ydax crhv june kbun");
					client.Send(mimeMessage);
					client.Disconnect(true);

					TempData["Mail"] = appUserRegisterDto.Email;

					return RedirectToAction("Index", "ConfirmMail");
				}
				else
				{
					foreach (var item in result.Errors)
					{
						ModelState.AddModelError("", item.Description);
					}

				}
				
			}
			return View();
		}
	}
}
