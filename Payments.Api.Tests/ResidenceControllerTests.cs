using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using Payments.Api.WebHost.Controllers;
using Payments.Api.WebHost.Models;
using Xunit;

namespace Payments.Api.Tests
{
    public class ResidenceControllerTests
    {
        private readonly ResidenceController _residenceController;
        private readonly IResidents _residents;
        private Residence _singleResident;

        public ResidenceControllerTests()
        {
            _residents = new ResidentsInMemory();
            _singleResident = _residents.Get(2734);
            _residenceController = new ResidenceController(_residents);
        }

        [Fact]
        public void Constructing_A_Residence_Controller_Returns_Type_ResidenceController()
        {
            Assert.IsType<ResidenceController>(_residenceController);
        }

        [Fact]
        public void Get_Residence_Returns_Correct_Length_Of_Items()
        {
            var result = _residenceController.Get() as OkNegotiatedContentResult<IEnumerable<Residence>>;

            Assert.Equal(_residents.Get().Count(), result.Content.Count());
        }

        [Fact]
        public void Get_Residence_By_Id_Returns_Correct_Resident()
        {
            var result = _residenceController.Get(2734) as OkNegotiatedContentResult<Residence>;

            Assert.Equal(_singleResident, result.Content);
        }

        [Fact]
        public void Get_Residence_By_Id_Returns_NotFound_For_Invalid_Id()
        {
            var result = _residenceController.Get(21);

            Assert.IsType<NotFoundResult>(result);
        }
    }
}
