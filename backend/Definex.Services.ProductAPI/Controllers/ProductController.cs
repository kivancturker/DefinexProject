using Definex.Services.ProductAPI.Dtos;
using Definex.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Definex.Services.ProductAPI.Controllers;

[Route("api/products")]
public class ProductController : ControllerBase
{
    protected ResponseDto _response;
    private IProductRepository _productRepository;
    
    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
        _response = new ResponseDto();
    }
    
    [HttpGet]
    public async Task<object> Get()
    {
        try
        {
            IEnumerable<ProductDto> productDtos = await _productRepository.GetProducts();
            _response.Result = productDtos;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        } 
        return _response;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<object> Get(int id)
    {
        try
        {
            ProductDto productDto = await _productRepository.GetProductById(id);
            _response.Result = productDto;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages
                = new List<string>() { ex.ToString() };
        }
        return _response;
    }


    [HttpPost]
    [Authorize]
    public async Task<object> Post([FromBody] ProductDto productDto)
    {
        try
        {
            ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
            _response.Result = model;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages
                = new List<string>() { ex.ToString() };
        }
        return _response;
    }


    [HttpPut]
    [Authorize]
    public async Task<object> Put([FromBody] ProductDto productDto)
    {
        try
        {
            ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
            _response.Result = model;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages
                = new List<string>() { ex.ToString() };
        }
        return _response;
    }
        
    [HttpDelete]
    [Authorize(Roles = "Admin")]
    [Route("{id}")]
    public async Task<object> Delete(int id)
    {
        try
        {
            bool isSuccess = await _productRepository.DeleteProduct(id);
            _response.Result = isSuccess;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages
                = new List<string>() { ex.ToString() };
        }
        return _response;
    }
}