using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Test.Database;
using Test.Services;

namespace Test.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly ITestService<Product> _productService;

    public ProductController(ITestService<Product> productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var products = _productService.GetData();

        return Ok(products);
    }
}
