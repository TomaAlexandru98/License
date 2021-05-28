using License.Service.Logic.ViewModels.Orders;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace License.Service.Controllers
{
    public class OrderController : Controller
    {
        public OrderController()
        {

        }

        public IActionResult StartOrder(Guid serviceId)
        {
            try
            {
                var viewModel = new CreateOrderViewModel
                {

                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Pay(CreateOrderViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("StartOrder");
                }
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
