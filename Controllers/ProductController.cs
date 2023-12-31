﻿using AutoMapper;
using Inventory.Model;
using Inventory.Model.MyDTO;
using Inventory.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace Inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProduct _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProduct productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        //[HttpGet]
        //public async Task<ActionResult<List<Product>>> GetAllProducts()
        //{
        //    var products = await _productService.GetAllProducts();
        //    return Ok(products);
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {
            var product = await _productService.GetProduct(id);

            if (product == null)
            {
                return NotFound("Product Not Found");
            }
            return Ok(product);
        }
        [HttpGet]
        public async Task<ActionResult<List<ProductResponseDTO>>> GetAllProducts(int page = 1, int pageSize = 10)
        {
            var products = await _productService.GetAllProductsAsync(page, pageSize);
            var productDTOs = _mapper.Map<List<ProductResponseDTO>>(products);
            return Ok(productDTOs);
        }

        [HttpPost]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<string>> AddProduct(AddProductDTO productDto)
        {
            var newProduct = _mapper.Map<Product>(productDto);
            var response = await _productService.AddProduct(newProduct);
            return Created($"Products/{newProduct.Id}", response);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<string>> UpdateProduct(Guid id, AddProductDTO updatedProductDto)
        {
            var existingProduct = await _productService.GetProduct(id);

            if (existingProduct == null)
            {
                return NotFound("Product Not Found");
            }

            var updatedProduct = _mapper.Map(updatedProductDto, existingProduct);

            var response = await _productService.UpdateProduct(updatedProduct);
            return Ok(response);
        }

        [HttpGet("filter")]
        public ActionResult<List<ProductResponseDTO>> FilterProducts([FromQuery] string productName, [FromQuery] decimal? price)
        {
            var filteredProducts = _productService.FilterProducts(productName, price);
            var productDTOs = _mapper.Map<List<ProductResponseDTO>>(filteredProducts);
            return Ok(productDTOs);
        }


        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<string>> DeleteProduct(Guid id)
        {
            var existingProduct = await _productService.GetProduct(id);

            if (existingProduct == null)
            {
                return NotFound("Product Not Found");
            }

            var response = await _productService.DeleteProduct(existingProduct);
            return Ok(response);
        }
    }
}


