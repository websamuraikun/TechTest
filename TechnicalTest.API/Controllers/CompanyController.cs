using Microsoft.AspNetCore.Mvc;
using TechnicalTest.API.Models.DTOs;
using TechnicalTest.API.Services;

namespace TechnicalTest.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;
    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    /// <summary>
    /// Retrieves a company by its ID, including whether it has an active policy.
    /// </summary>
    /// <param name="id">The ID of the company to retrieve.</param>
    /// <returns>The matching company DTO, or 404 if not found.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<CompanyDTO>> GetCompany(int id)
    {
        if(id <= 0)
         return BadRequest($"Id {id} is not a valid id");

        var company = await _companyService.GetCompanyByIdAsync(id);

        if(company is null)
        return NotFound($"Company with id {id} could not be found!");

        return Ok(company);
    }
}
