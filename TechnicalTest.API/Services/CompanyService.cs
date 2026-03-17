using System.Runtime.InteropServices;
using TechnicalTest.API.Models;
using TechnicalTest.API.Models.DTOs;

namespace TechnicalTest.API.Services;

public class CompanyService : ICompanyService
{
    public Task<List<CompanyDTO>> GetCompaniesAsync()
    {
        var companies = MockData.GetMockCompanies();

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
            HasActivePolicy = company.InsuranceEndDate > DateTime.Now,
        }).ToList();

        return Task.FromResult(result);
    }

    public async Task<CompanyDTO?> GetCompanyByIdAsync(int Id)
    {
        var company = MockData.GetMockCompanies().FirstOrDefault(x => x.Id == Id);

        if (company is null)
            return null;

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
            HasActivePolicy = company.InsuranceEndDate > DateTime.Now,
        };
    }
}
