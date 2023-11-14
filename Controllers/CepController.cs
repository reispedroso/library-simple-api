using Ecc.Integration;
using Ecc.Integration.Refit;
using Ecc.Integration.Response;
using Microsoft.AspNetCore.Mvc;

namespace Ecc.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CepController : ControllerBase 
{
    private readonly IViaCepIntegration _viaCepIntegration;
    public CepController(IViaCepIntegration viaCepIntegration)
    {
        _viaCepIntegration = viaCepIntegration;
    }
    [HttpGet("{cep}")]
    public async Task<ActionResult<ViaCepResponse>> GetCepDetails(string cep)
    {
        var CepDetails = await _viaCepIntegration.GetCepDetails(cep);
        return Ok(CepDetails);
    }
}