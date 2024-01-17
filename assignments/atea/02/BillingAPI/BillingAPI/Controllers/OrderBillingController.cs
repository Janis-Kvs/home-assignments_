using BillingAPI.Data;
using BillingAPI.Interfaces;
using BillingAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BillingAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderBillingController : ControllerBase
    {
        private readonly IBillingService _billingService;

        public OrderBillingController(IBillingService billingService)
        {
            _billingService = billingService;
        }

        //Process order
        [HttpPost]
        public IActionResult ProcessOrder(Order order)
        {
            try
            {
                Receipt receipt = _billingService.ProcessOrder(order);

                if (receipt == null)
                    return BadRequest();

                return Ok(receipt);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        //Create && Edit order
        [HttpPost]
        public IActionResult CreateOrder(Order order)
        {
            if(order.Id == 0)
            {
                order = _billingService.CreateOrder(order);
            } else
            {
                Order dbOrder = _billingService.GetOrder(order.Id);

                if (dbOrder == null)
                    return  NotFound();

                order = _billingService.UpdateOrder(dbOrder, order);
            }

            return Ok(order);
        }

        //Get order
        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var order = _billingService.GetOrder(id);

            if (order == null)
                return NotFound();

            return Ok(order);
        }

        //Delete order
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var order = _billingService.GetOrder(id);

            if (order == null)
                return NotFound();

            _billingService.DeleteOrder(order);

            return NoContent();
        }
    }
}
