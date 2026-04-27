using _1294372_Master_Details.Data;
using _1294372_Master_Details.Models;
using _1294372_Master_Details.Models.Entity;
using _1294372_Master_Details.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _1294372_Master_Details.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _he;
        public CustomerController(ApplicationDbContext _context, IWebHostEnvironment _he)
        {
            this._context = _context;
            this._he = _he;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customers.Include(x=>x.ServiceEntries).ThenInclude(y=>y.Service).ToListAsync());
        }
        public IActionResult AddNewService(int? id)
        {
            ViewBag.Service = new SelectList(_context.Services, "ServiceId", "ServiceName", id.ToString() ?? "");
            return PartialView("_addNewService");
        }


        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create(CustomerVM customerVM, int[] ServiceId)
        {
            if (ModelState.IsValid)
            {
                Customer customer = new Customer()
                {
                    CustomerName = customerVM.CustomerName,
                    Address = customerVM.Address,
                    Phone = customerVM.Phone,
                    EntryDate = customerVM.EntryDate,
                    BuyingDate = customerVM.BuyingDate,
                    IsRegular = customerVM.IsRegular,
                    Problem = customerVM.Problem,
                    DeviceName = customerVM.DeviceName,
                    DeviceAge = customerVM.DeviceAge
                };

                var file = customerVM.DevicePictureFile;
                string webroot = _he.WebRootPath;
                string folder = "Images";
                string ext = Path.GetExtension(file.FileName);
                string imgFileName = Path.GetRandomFileName() + ext;
                string fileSave = Path.Combine(webroot, folder, imgFileName);

                if (file != null)
                {
                    using (var stream = new FileStream(fileSave, FileMode.Create))
                    {
                        customerVM.DevicePictureFile.CopyToAsync(stream);
                        customer.DevicePicture = "/" + folder + "/" + imgFileName;
                    }
                }

                foreach (var i in ServiceId)
                {
                    ServiceEntry serviceEntry = new ServiceEntry()
                    {
                        Customer = customer,
                        CustomerId = customer.CustomerId,
                        ServiceId = i
                    };
                    _context.ServiceEntries.Add(serviceEntry);
                }
                await _context.SaveChangesAsync();
                return PartialView("_success");
            }
            return PartialView("_error");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            Customer customer = await _context.Customers.FirstOrDefaultAsync(x => x.CustomerId == id);
            var customerService = _context.ServiceEntries.Where(x => x.CustomerId == id).ToList();
            CustomerVM customerVM = new CustomerVM()
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.CustomerName,
                EntryDate = customer.EntryDate,
                BuyingDate = customer.BuyingDate,
                Address = customer.Address,
                Phone = customer.Phone,
                Problem = customer.Problem,
                DeviceName = customer.DeviceName,
                IsRegular = customer.IsRegular,
                DevicePicture = customer.DevicePicture,
                DeviceAge = customer.DeviceAge
            };
            
            foreach (var item in customerService)
            {
                customerVM.ServiceList.Add(item.ServiceId);
            }
            return View(customerVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CustomerVM customerVM, int[] ServiceId)
        {
            if (ModelState.IsValid)
            {
                Customer customer = new Customer()
                {
                    CustomerId = customerVM.CustomerId,
                    CustomerName = customerVM.CustomerName,
                    Address = customerVM.Address,
                    Phone = customerVM.Phone,
                    EntryDate = customerVM.EntryDate,
                    BuyingDate = customerVM.BuyingDate,
                    IsRegular = customerVM.IsRegular,
                    Problem = customerVM.Problem,
                    DeviceName = customerVM.DeviceName,
                    DeviceAge = customerVM.DeviceAge
                };

                
                var file = customerVM.DevicePictureFile;
                var oldPic = customerVM.DevicePicture;
                if (file != null)
                {
                    string webroot = _he.WebRootPath;
                    string folder = "Images";
                    string ext = Path.GetExtension(file.FileName);
                    string imgFileName = Path.GetRandomFileName() + ext;
                    string fileSave = Path.Combine(webroot, folder, imgFileName);

                    using (var stream = new FileStream(fileSave, FileMode.Create))
                    {
                        customerVM.DevicePictureFile.CopyTo(stream);
                        customer.DevicePicture = "/" + folder + "/" + imgFileName;
                    }
                }
                else
                {
                    customer.DevicePicture = oldPic;
                }

                var serviceEntry = _context.ServiceEntries.Where(x => x.CustomerId == customer.CustomerId).ToList();
                foreach (var service in serviceEntry)
                {
                    _context.ServiceEntries.Remove(service);
                }
                foreach (var id in ServiceId)
                {
                    ServiceEntry serviceEntry1 = new ServiceEntry()
                    {
                        CustomerId = customer.CustomerId,
                        ServiceId = id
                    };
                    _context.ServiceEntries.Add(serviceEntry1);
                }
                _context.Update(customer);
                await _context.SaveChangesAsync();
                return PartialView("_success");
            }
            return PartialView("_error");
        }

        public async Task<ActionResult> Delete(int? id)
        {
            Customer customer = await _context.Customers.FirstOrDefaultAsync(x => x.CustomerId == id);
            var customerService = _context.ServiceEntries.Where(x => x.CustomerId == id).ToList();
            CustomerVM customerVM = new CustomerVM()
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.CustomerName,
                EntryDate = customer.EntryDate,
                BuyingDate = customer.BuyingDate,
                Address = customer.Address,
                Phone = customer.Phone,
                Problem = customer.Problem,
                DeviceName = customer.DeviceName,
                IsRegular = customer.IsRegular,
                DevicePicture = customer.DevicePicture,
                DeviceAge = customer.DeviceAge
            };

            foreach (var item in customerService)
            {
                customerVM.ServiceList.Add(item.ServiceId);
            }
            return View(customerVM);
        }

        [HttpPost]
        [ActionName(name: "Delete")]
        public async Task<IActionResult> Deleted(int? id)
        {
            var emp = await _context.Customers.FirstOrDefaultAsync(x => x.CustomerId == id);
            if (emp == null)
            {
                return NotFound();
            }
            var exitSkill = _context.ServiceEntries.Where(x => x.CustomerId == id).ToList();
            foreach (var item in exitSkill)
            {
                _context.ServiceEntries.Remove(item);
            }

            _context.Remove(emp);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
