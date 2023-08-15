using Contracts;
using Entities.Models;
using Moq;

namespace Tests;

public class UnitTest1
{
    [Fact]
    public void GetAllCompaniesAsync_ReturnsListOfCompanies_WithASingleCompany()
    {
        // arrange
        var mockRepo = new Mock<ICompanyRepository>();
        mockRepo.Setup(repo => (repo.GetAllCompaniesAsync(false))).Returns(Task.FromResult(GetCompanies()));

        // act
        var result = mockRepo.Object.GetAllCompaniesAsync(false).GetAwaiter().GetResult().ToList();

        // assert
        Assert.IsType<List<Company>>(result);
        Assert.Single(result);
    }

    public IEnumerable<Company> GetCompanies()
    {
        return new List<Company>
        {
            new Company
            {
                Id = Guid.NewGuid(),
                Name = "Test Company",
                Country = "United States",
                Address = "908  Woodrow Way"
            }
        };
    }
}