using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
//using XpTO2.Server.Model;
//using XpTO2.Server.Service;
using XPTOApp.Model;
using XPTOApp.Service;
using XPTOApp.Core;

namespace XPTOApp.Controller
{
    [ApiController()]
    [Route("api")]
    [AllowAnonymous]
    public class KitchenController : HomeController
    {       

        private OrderService _orderService ;
        private readonly ILogger<KitchenController> _logger;

        public KitchenController(ILogger<KitchenController> logger) {
            _logger = logger;
            _orderService = new OrderService();
        }

        [HttpGet("kitchen/v1")]
        public IActionResult getAllOrders()
        {   
            var result = _orderService.GetAllOrders();                          
            return Ok(new BaseViewModel<List<OrderViewModel>>(true, "operação concluída", "sucesso", result.ResultObject ));
        }

        [HttpPut("kitchen/v1/{id}")]
        public IActionResult updateOrder(OrderViewModel order, int id)
        {
            var result = _orderService.UpdateStatus(order, id);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

    }
}