using Ecc.Integration.Response;

namespace Ecc.Integration;
public interface IViaCepIntegration
{
    Task<ViaCepResponse> GetCepDetails(string cep);
}