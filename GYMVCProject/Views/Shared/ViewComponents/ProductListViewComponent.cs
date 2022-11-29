using GYMVCProject.Models;
using GYMVCProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GYMVCProject.Views.Shared.ViewComponents
{
    public class ProductListViewComponent : ViewComponent
    {

        private readonly AppDbContext _context;

        public ProductListViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int type=1)
        {

            var viewmodel = _context.Products.Select(x => new ProductListComponentViewModel()
            {
                Name = x.Name,
                Description = x.Description

            }).ToList();

            if (type==1)
            {

                return View("Default",viewmodel);
            }
            else
            {
                return View("Type2",viewmodel);
            }

        }


    }
}
