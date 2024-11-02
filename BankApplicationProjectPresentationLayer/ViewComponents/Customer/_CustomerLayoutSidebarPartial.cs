using Microsoft.AspNetCore.Mvc;

namespace BankApplicationProjectPresentationLayer.ViewComponents.Customer
{
    public class _CustomerLayoutSidebarPartial:ViewComponent
    {
        public IViewComponentResult Invoke() 
        {  
            return View(); 
        } 
        
    }
}
