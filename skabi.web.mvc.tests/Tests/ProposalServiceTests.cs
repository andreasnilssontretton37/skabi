using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using NUnit.Framework;
using skabi.common.Services;
using skabi.data.DomainModel;
using skabi.data.Repository.Interfaces;

namespace skabi.web.mvc.tests
{
    [TestFixture]
    [Category("Services")]
    class RpdbServiceTests
    {
        [Test]
        //[ExpectedException(typeof(Exception))]
        public void When_GetCarbrandModels_is_called_with_non_existing_carbrandId_should_return_empty_list()
        {
            //arrange
            var fakeCarbrandRepository = A.Fake<ICarbrandRepository>();

            A.CallTo(() =>
                fakeCarbrandRepository
                    .GetById(A<int>.Ignored))
                        .Throws<Exception>();

            var proposalService = new RpdbService(fakeCarbrandRepository, null, null, null);

            //act
            var actual = proposalService.GetCarbrandModels(99999999);
            

            //assert
            Assert.That(actual.OfType<object>().Count(), Is.EqualTo(0));
        }

        [Test]
        //[ExpectedException(typeof(Exception))]
        public void When_GetCarbrandModels_is_called_with_non_existing_carbrandName_should_return_empty_list()
        {
            //arrange
            var fakeCarbrandRepository = A.Fake<ICarbrandRepository>();

            A.CallTo(() =>
                fakeCarbrandRepository
                    .GetByName(A<string>.Ignored))
                        .Throws<Exception>();

            var proposalService = new RpdbService(fakeCarbrandRepository, null, null, null);

            //act
            var actual = proposalService.GetCarbrandModels("NonExistingCarbrand");


            //assert
            Assert.That(actual.OfType<object>().Count(), Is.EqualTo(0));
        }

        
    }
}
