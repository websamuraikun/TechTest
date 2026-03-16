using TechnicalTest.API.Services;

namespace TechnicalTest.Test;

[TestClass]
public class CompanyServiceTests
{
    private readonly CompanyService companyService = new();

    // GetCompanyByIdAsync

    [TestMethod]
    public async Task GetCompanyByIdAsync_ValidId_ReturnsCorrectCompany()
    {
        var result = await companyService.GetCompanyByIdAsync(1);

        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Id);
        Assert.AreEqual("Hartley Construction Ltd", result.Name);
    }

    [TestMethod]
    public async Task GetCompanyByIdAsync_InvalidId_ReturnsNull()
    {
        var result = await companyService.GetCompanyByIdAsync(999);

        Assert.IsNull(result);
    }

    [TestMethod]
    public async Task GetCompanyByIdAsync_CompanyWithOpenClaim_HasActivePolicyIsTrue()
    {
        // Company 1 has UCR2024001 which is Closed = false
        var result = await companyService.GetCompanyByIdAsync(1);

        Assert.IsNotNull(result);
        Assert.IsTrue(result.HasActivePolicy);
    }

    [TestMethod]
    public async Task GetCompanyByIdAsync_MapsAllFieldsCorrectly()
    {
        var result = await companyService.GetCompanyByIdAsync(1);

        Assert.IsNotNull(result);
        Assert.AreEqual("14 Victoria Street", result.Address1);
        Assert.AreEqual("Holbeck", result.Address2);
        Assert.AreEqual("Leeds", result.Address3);
        Assert.AreEqual("LS1 6AT", result.Postcode);
        Assert.AreEqual("United Kingdom", result.Country);
        Assert.IsTrue(result.Active);
        Assert.AreEqual(new DateTime(2025, 12, 31), result.InsuranceEndDate);
    }

    // GetCompaniesAsync

    [TestMethod]
    public async Task GetCompaniesAsync_ReturnsAllCompanies()
    {
        var result = await companyService.GetCompaniesAsync();

        Assert.IsNotNull(result);
        Assert.HasCount(3, result);
    }

    [TestMethod]
    public async Task GetCompaniesAsync_EachCompanyHasCorrectActivePolicyFlag()
    {
        var result = await companyService.GetCompaniesAsync();

        // Company 1: has open claim UCR2024001 → true
        Assert.IsTrue(result.First(x => x.Id == 1).HasActivePolicy);
        // Company 2: has open claim UCR2024003 → true
        Assert.IsTrue(result.First(x => x.Id == 2).HasActivePolicy);
        // Company 3: has open claim UCR2024005 → true
        Assert.IsTrue(result.First(x => x.Id == 3).HasActivePolicy);
    }

    [TestMethod]
    public async Task GetCompaniesAsync_InactiveCompanyIsIncluded()
    {
        var result = await companyService.GetCompaniesAsync();

        var inactive = result.First(x => x.Id == 3);
        Assert.IsFalse(inactive.Active);
    }
}
