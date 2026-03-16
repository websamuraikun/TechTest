using TechnicalTest.API.Models.DTOs;

namespace TechnicalTest.API.Services;

public interface ICompanyService
{
    /// <summary>
    /// Retrieves a single company by its ID, including active policy status.
    /// Returns null if no company with the given ID exists.
    /// </summary>
    Task<CompanyDTO?> GetCompanyByIdAsync(int Id);

    /// <summary>
    /// Retrieves all companies with their active policy status.
    /// </summary>
    Task<List<CompanyDTO>> GetCompaniesAsync();
}
