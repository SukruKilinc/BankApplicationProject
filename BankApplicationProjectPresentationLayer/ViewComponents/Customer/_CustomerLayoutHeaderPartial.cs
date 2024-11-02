using Microsoft.AspNetCore.Mvc;

namespace BankApplicationProjectPresentationLayer.ViewComponents.Customer   
{
    public class _CustomerLayoutHeaderPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }



    }
}
