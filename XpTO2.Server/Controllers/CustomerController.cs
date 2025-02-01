using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XPTOApp.Model;
using XPTOApp.Service;

namespace XPTOApp.Controller
{
    [ApiController()]
    [Route("api")]
    public class CustomerController : ControllerBase
    {

        private OrderService _orderService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
            _orderService = new OrderService();
        }

        [HttpPost("customer/v1")]
        public IActionResult insertOrder(OrderViewModel order)
        {
            if (order == null)
                return BadRequest(new BaseViewModel<OrderViewModel>(false, "Não é possível inserir um pedido vazio", "Erro"));
            else
            {
                BaseViewModel<OrderViewModel> result = _orderService.InsertOrder(order);
                if (result.Success)
                    return Ok(result);
                else
                    return BadRequest(result);
            }
        }
    }
}