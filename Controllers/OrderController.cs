using AutoMapper;
using Inventory.Model;
using Inventory.Model.MyDTO;
using Inventory.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrder _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrder orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrders();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(Guid id)
        {
            var order = await _orderService.GetOrder(id);

            if (order == null)
            {
                return NotFound("Order Not Found");
            }

            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<string>> AddOrder(AddOrdersDTO orderDto)
        {
            var newOrder = _mapper.Map<Order>(orderDto);
            var response = await _orderService.AddOrder(newOrder);
            return Created($"Orders/{newOrder.OrderId}", response);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<string>> UpdateOrder(Guid id, AddOrdersDTO updatedOrderDto)
        {
            var existingOrder = await _orderService.GetOrder(id);

            if (existingOrder == null)
            {
                return NotFound("Order Not Found");
            }

            var updatedOrder = _mapper.Map(updatedOrderDto, existingOrder);

            var response = await _orderService.UpdateOrder(updatedOrder);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<string>> DeleteOrder(Guid id)
        {
            var existingOrder = await _orderService.GetOrder(id);

            if (existingOrder == null)
            {
                return NotFound("Order Not Found");
            }

            var response = await _orderService.DeleteOrder(existingOrder);
            return Ok(response);
        }
    }
}



