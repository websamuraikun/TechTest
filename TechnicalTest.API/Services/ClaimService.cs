using TechnicalTest.API.DTOs;
using TechnicalTest.API.Models.DTOs;

namespace TechnicalTest.API.Services;

public class ClaimService : IClaimService
{
    public async Task<ClaimDTO> GetClaimByUCRAsync(string ucr)
    {
        var claim = MockData.GetMockClaims().FirstOrDefault(x => x.UCR == ucr);

        if (claim is null)
            return null;

        var claimTypes = MockData.GetMockClaimTypes();

        var mappedObject = new ClaimDTO
        {
            UCR = claim.UCR,
            CompanyId = claim.CompanyId,
            ClaimType = claimTypes.FirstOrDefault(x => x.Id == claim.ClaimTypeId)?.Name ?? "",
            ClaimDate = claim.ClaimDate,
            LossDate = claim.LossDate,
            AssuredName = claim.AssuredName,
            IncurredLoss = claim.IncurredLoss,
            Closed = claim.Closed,
            ClaimAgeInDays = (DateTime.Now - claim.ClaimDate).Days
        };

        return await Task.FromResult(mappedObject);
    }

    public async Task<List<ClaimDTO>> GetClaimsByCompanyIdAsync(int companyId)
    {
        var listOfClaims = MockData.GetMockClaims().Where(x => x.CompanyId == companyId).ToList();

        if (!listOfClaims.Any())
            return null;

        var claimTypes = MockData.GetMockClaimTypes();

        var mappedClaims = listOfClaims.Select(claim => new ClaimDTO
        {
            UCR = claim.UCR,
            CompanyId = claim.CompanyId,
            ClaimType = claimTypes.FirstOrDefault(x => x.Id == claim.ClaimTypeId)?.Name ?? "",
            ClaimDate = claim.ClaimDate,
            LossDate = claim.LossDate,
            AssuredName = claim.AssuredName,
            IncurredLoss = claim.IncurredLoss,
            Closed = claim.Closed,
            ClaimAgeInDays = (DateTime.Now - claim.ClaimDate).Days
        }).ToList();

        return await Task.FromResult(mappedClaims);
    }

    public async Task<ClaimDTO> UpdateClaimAsync(string ucr, ClaimRequestDTO updatedClaim)
    {
        var existing = MockData.GetMockClaims()
            .FirstOrDefault(c => c.UCR.ToLower() == ucr.ToLower());

        if (existing == null)
            return null;

        existing.AssuredName = updatedClaim.AssuredName;
        existing.IncurredLoss = updatedClaim.IncurredLoss;
        existing.Closed = updatedClaim.Closed;
        existing.LossDate = updatedClaim.LossDate;

        var updatedMap = new ClaimDTO
        {
            UCR = ucr,
            CompanyId = existing.CompanyId,
            ClaimDate = existing.ClaimDate,
            LossDate = existing.LossDate,
            AssuredName = existing.AssuredName,
            IncurredLoss = existing.IncurredLoss,
            Closed = existing.Closed,
            ClaimAgeInDays = (DateTime.Now - existing.ClaimDate).Days
        };

        return await Task.FromResult(updatedMap);
    }
}
