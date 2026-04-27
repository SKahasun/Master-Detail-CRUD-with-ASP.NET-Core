using Microsoft.AspNetCore.Mvc;
using _1294372_Master_Details.Data;
using Microsoft.EntityFrameworkCore;

public class ServiceListViewComponent : ViewComponent
{
    private readonly ApplicationDbContext _context;

    public ServiceListViewComponent(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var services = await _context.Services.ToListAsync();
        return View(services);
    }
}