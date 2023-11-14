using Ecc.Integration.Refit;
using Ecc.Integration.Response;

namespace Ecc.Integration;

public class ViaCepIntegration : IViaCepIntegration
{   
    private readonly IViaCepIntegrationRefit _viaCepIntegrationRefit;
    public ViaCepIntegration(IViaCepIntegrationRefit viaCepIntegration)
    {
        _viaCepIntegrationRefit = viaCepIntegration;
    }
    public async Task<ViaCepResponse> GetCepDetails(string cep)
    {
       var responseData = await _viaCepIntegrationRefit.GetCepDetails(cep);


        if(responseData != null && responseData.IsSuccessStatusCode)
        {
            return responseData.Content;
        }
       
       return null;
    }
}