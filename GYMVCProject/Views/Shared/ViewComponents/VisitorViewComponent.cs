using AutoMapper;
using GYMVCProject.Models;
using GYMVCProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GYMVCProject.Views.Shared.ViewComponents
{
    public class VisitorViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public VisitorViewComponent(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var visitor = _context.Visitors.ToList();

            var visitorViewModels = _mapper.Map<List<VisitorViewModel>>(visitor);
            ViewBag.visitorViewModels = visitorViewModels;
            return View();
        }
    }
}
