using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechnicalTest.API.DTOs;
using TechnicalTest.API.Models;
using TechnicalTest.API.Models.DTOs;
using TechnicalTest.API.Services;

namespace TechnicalTest.API.Controllers;

[Route("[controller]")]
public class ClaimController : Controller
{
    private readonly ILogger<ClaimController> _logger;
    private readonly IClaimService _claimService;

    public ClaimController(ILogger<ClaimController> logger, IClaimService claimService)
    {
        _claimService = claimService;
        _logger = logger;

    }

    /// <summary>
    /// Retrieves a claim by its Unique Claim Reference (UCR).
    /// </summary>
    /// <param name="ucr">The Unique Claim Reference of the claim to retrieve.</param>
    /// <returns>The matching claim, or 404 if not found.</returns>
    [HttpGet("{ucr}")]
    public async Task<ActionResult<ClaimDTO>> GetClaim(string ucr)
    {
        if (string.IsNullOrEmpty(ucr))
            return BadRequest("UCR provided is not valid");

        var claim = await _claimService.GetClaimByUCRAsync(ucr);

        if (claim is null)
            return NotFound($"Claim {ucr} could not be found");

        return Ok(claim);
    }

    /// <summary>
    /// Retrieves all claims associated with a given company.
    /// </summary>
    /// <param name="companyId">The ID of the company to retrieve claims for.</param>
    /// <returns>A list of claims for the company, or 404 if none exist.</returns>
    [HttpGet("/company/{companyId}")]
    public async Task<ActionResult<List<ClaimDTO>>> GetCompanyClaims(int companyId)
    {
        if (companyId <= 0)
            return BadRequest($"Id {companyId} is not a valid id");

        var claims = await _claimService.GetClaimsByCompanyIdAsync(companyId);

        if (!claims.Any())
            return NotFound($"There are no claims for company {companyId}");

        return Ok(claims);
    }

    /// <summary>
    /// Updates an existing claim identified by its UCR.
    /// </summary>
    /// <param name="ucr">The Unique Claim Reference of the claim to update.</param>
    /// <param name="request">The updated claim data.</param>
    /// <returns>The updated claim, or 404 if the claim does not exist.</returns>
    [HttpPut("{ucr}")]
    public async Task<ActionResult<List<ClaimDTO>>> UpdateClaim(
    [FromRoute] string ucr,
    [FromBody] ClaimRequestDTO request)
    {
        if (string.IsNullOrEmpty(ucr))
            return BadRequest("UCR is required");

        if (request == null)
            return BadRequest("Claim data is required");

        var result = await _claimService.UpdateClaimAsync(ucr, request);

        if (result == null) return NotFound($"Claim {ucr} not found");

        return Ok(result);
    }
}
