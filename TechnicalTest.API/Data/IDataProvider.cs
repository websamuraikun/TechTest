using TechnicalTest.API.Models;

namespace TechnicalTest.API.Data;

public interface IDataProvider
{
    List<Company> GetCompanies();
    List<Claim> GetClaims();
}
