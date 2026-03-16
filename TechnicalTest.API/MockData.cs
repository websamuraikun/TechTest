using TechnicalTest.API.Models;

namespace TechnicalTest.API;

public static class MockData
{
    public static List<Claim> GetMockClaims()
    {
        return new List<Claim>
        {
            new Claim
            {
                UCR = "UCR2024001",
                CompanyId = 1,
                ClaimTypeId = 3, // Fire
                ClaimDate = new DateTime(2024, 1, 15),
                LossDate = new DateTime(2024, 1, 10),
                AssuredName = "Hartley Construction Ltd",
                IncurredLoss = 15750.00m,
                Closed = false
            },
            new Claim
            {
                UCR = "UCR2024002",
                CompanyId = 1,
                ClaimTypeId = 2, // Theft
                ClaimDate = new DateTime(2024, 2, 3),
                LossDate = new DateTime(2024, 1, 28),
                AssuredName = "Hartley Construction Ltd",
                IncurredLoss = 4200.50m,
                Closed = true
            },
            new Claim
            {
                UCR = "UCR2024003",
                CompanyId = 2,
                ClaimTypeId = 5, // Liability
                ClaimDate = new DateTime(2024, 3, 22),
                LossDate = new DateTime(2024, 3, 20),
                AssuredName = "Meridian Logistics PLC",
                IncurredLoss = 89500.00m,
                Closed = false
            },
            new Claim
            {
                UCR = "UCR2024004",
                CompanyId = 2,
                ClaimTypeId = 1, // Accidental Damage
                ClaimDate = new DateTime(2024, 4, 11),
                LossDate = new DateTime(2024, 4, 9),
                AssuredName = "Meridian Logistics PLC",
                IncurredLoss = 3100.75m,
                Closed = true
            },
            new Claim
            {
                UCR = "UCR2024005",
                CompanyId = 3,
                ClaimTypeId = 4, // Flood
                ClaimDate = new DateTime(2024, 5, 30),
                LossDate = new DateTime(2024, 5, 25),
                AssuredName = "Pinnacle Retail Group",
                IncurredLoss = 22000.00m,
                Closed = false
            }
        };
    }
    public static List<Company> GetMockCompanies()
    {
        return new List<Company>
        {
            new Company
            {
                Id = 1,
                Name = "Hartley Construction Ltd",
                Address1 = "14 Victoria Street",
                Address2 = "Holbeck",
                Address3 = "Leeds",
                Postcode = "LS1 6AT",
                Country = "United Kingdom",
                Active = true,
                InsuranceEndDate = new DateTime(2025, 12, 31)
            },
            new Company
            {
                Id = 2,
                Name = "Meridian Logistics PLC",
                Address1 = "Unit 5 Trafford Park",
                Address2 = "Stretford",
                Address3 = "Manchester",
                Postcode = "M17 1HP",
                Country = "United Kingdom",
                Active = true,
                InsuranceEndDate = new DateTime(2024, 6, 30)
            },
            new Company
            {
                Id = 3,
                Name = "Pinnacle Retail Group",
                Address1 = "200 Broad Street",
                Address2 = "Birmingham City Centre",
                Address3 = "Birmingham",
                Postcode = "B15 1AY",
                Country = "United Kingdom",
                Active = false,
                InsuranceEndDate = new DateTime(2026, 3, 15)
            }
        };
    }

    public static List<ClaimType> GetMockClaimTypes()
    {
        return new List<ClaimType>
        {
            new ClaimType { Id = 1, Name = "Accidental Damage" },
            new ClaimType { Id = 2, Name = "Theft" },
            new ClaimType { Id = 3, Name = "Fire" },
            new ClaimType { Id = 4, Name = "Flood" },
            new ClaimType { Id = 5, Name = "Liability" }
        };
    }
}
