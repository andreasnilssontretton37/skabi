using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using NUnit.Framework;
using skabi.data.DomainModel;
using skabi.data.Repository;
using skabi.data.Repository.Interfaces;

namespace skabi.web.mvc.tests.Tests.Repositories
{
    [Category("Repositories")]
    [TestFixture]
    class CarmodelRepositoryTests
    {
        [TestCase("Mercedes")]
        [TestCase("Fiat")]
        public void When_CarbrandRepository_GetByName_is_called_should_only_return_brands_that_match_parameter(string name)
        {
            //arrange
            var fakeObjectContext = A.Fake<IObjectContext>();
            var fakeObjectSet = new FakeObjectSet<Carbrand>(new List<Carbrand>
                {
                    new Carbrand() {CarbrandID = 1, Name = "Mercedes"},
                    new Carbrand() {CarbrandID = 2, Name = "Fiat"}
                });

            A.CallTo(() => fakeObjectContext.CreateObjectSet<Carbrand>()).Returns(fakeObjectSet);

            var carbrandRepository = new CarbrandRepository(fakeObjectContext);

            //act
            var result = carbrandRepository.GetByName(name);

            //assert
            Assert.That(result, Has.Property("Name").EqualTo(name));
        }
    }

}
