using System.Runtime.InteropServices;
using TechnicalTest.API.Models;
using TechnicalTest.API.Models.DTOs;

namespace TechnicalTest.API.Services;

public class CompanyService : ICompanyService
{
    public Task<List<CompanyDTO>> GetCompaniesAsync()
    {
        var companies = MockData.GetMockCompanies();
        var claims = MockData.GetMockClaims();

        var result = companies.Select(company => new CompanyDTO
        {
            Id = company.Id,
            Name = company.Name,
            Address1 = company.Address1,
            Address2 = company.Address2,
            Address3 = company.Address3,
            Postcode = company.Postcode,
            Country = company.Country,
            Active = company.Active,
            InsuranceEndDate = company.InsuranceEndDate,
            HasActivePolicy = claims.Any(c => c.CompanyId == company.Id && !c.Closed),
        }).ToList();

        return Task.FromResult(result);
    }

    public async Task<CompanyDTO?> GetCompanyByIdAsync(int Id)
    {
        var company = MockData.GetMockCompanies().FirstOrDefault(x => x.Id == Id);

        if (company is null)
            return null;

        var claims = MockData.GetMockClaims();

        return new CompanyDTO
        {
            Id = Id,
            Name = company.Name,
            Address1 = company.Address1,
            Address2 = company.Address2,
            Address3 = company.Address3,
            Postcode = company.Postcode,
            Country = company.Country,
            Active = company.Active,
            InsuranceEndDate = company.InsuranceEndDate,
            HasActivePolicy = claims.Any(c => c.CompanyId == Id && !c.Closed),
        };
    }
}
