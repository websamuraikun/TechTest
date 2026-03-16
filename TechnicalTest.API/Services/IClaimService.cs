using TechnicalTest.API.DTOs;
using TechnicalTest.API.Models.DTOs;

namespace TechnicalTest.API.Services;
/// <summary>
/// Claim interfaces
/// </summary>
public interface IClaimService
{
    /// <summary>
    /// Retrieves a single claim by its Unique Claim Reference.
    /// Returns null if no matching claim is found.
    /// </summary>
    Task<ClaimDTO> GetClaimByUCRAsync(string ucr);

    /// <summary>
    /// Retrieves all claims associated with the given company ID.
    /// Returns null if no claims exist for the company.
    /// </summary>
    Task<List<ClaimDTO>> GetClaimsByCompanyIdAsync(int companyId);

    /// <summary>
    /// Updates the editable fields of an existing claim identified by its UCR.
    /// Returns null if no matching claim is found.
    /// </summary>
    Task<ClaimDTO> UpdateClaimAsync(string ucr, ClaimRequestDTO updatedClaim);
}
