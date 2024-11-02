using Microsoft.AspNetCore.Mvc;

namespace BankApplicationProjectPresentationLayer.ViewComponents.Customer
{
    public class _CustomerLayoutFooterPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        { 
            return View(); 
        }
    }
}
