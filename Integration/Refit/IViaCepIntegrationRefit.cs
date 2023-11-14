using Ecc.Integration.Response;
using Refit;

namespace Ecc.Integration.Refit;
public interface IViaCepIntegrationRefit 
{
    [Get("/ws/{cep}/json")]
    Task<ApiResponse<ViaCepResponse>> GetCepDetails(string cep);
}