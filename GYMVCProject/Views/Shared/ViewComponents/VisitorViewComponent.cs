using Microsoft.AspNetCore.Mvc;

namespace GYMVCProject.Views.Shared.ViewComponents
{
    public class VisitorViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
