using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit;
using NUnit.Framework;
using FakeItEasy;
using skabi.data.DomainModel;
//using skabi.data.Repository.Interfaces;
using skabi.web.mvc4;

//using System.Web.Mvc;
//using System.Web.Security;
using skabi.web.mvc4.Controllers;
using skabi.common.Services;



namespace skabi.web.mvc.tests
{
    [TestFixture]
    [Category("Controllers")]
    public class ProposalsControllerTests
    {
        [Test]
        public void When_ListCarbrands_action_is_called_without_parameter_should_return_all_brands()
        {
            //arrange
            var fakeRpdbService = A.Fake<IRpdbService>();

            var fakeBrands = new List<Carbrand>
                {
                    new Carbrand() {CarbrandID = 1, Name = "Mercedes"},
                    new Carbrand() {CarbrandID = 2, Name = "Fiat"}
                };

            A.CallTo(() => fakeRpdbService.GetAllCarbrands()).Returns(fakeBrands);

            var proposalsController = new ProposalsController(fakeRpdbService);

            //act
            var actual = proposalsController.ListCarbrands();
            var result = actual.Data as IEnumerable;



            //assert
            A.CallTo(
                () => fakeRpdbService.GetAllCarbrands())
                .MustHaveHappened(Repeated.Exactly.Once);

            Assert.IsNotEmpty(result);
            Assert.That(result.OfType<object>().Count(), Is.EqualTo(fakeBrands.Count));
        }

        [TestCase(1)]
        [TestCase(2)]
        public void When_ListCarmodelsFromCarbrandId_action_is_called_with_parameter_should_only_return_models_that_match_parameter(int id)
        {
            //arrange
            var fakeRpdbService = A.Fake<IRpdbService>();

            A.CallTo(() => fakeRpdbService.GetAllCarbrands()).Returns(new List<Carbrand>
                {
                    new Carbrand() {CarbrandID = 1, Name = "Mercedes"},
                    new Carbrand() {CarbrandID = 2, Name = "Fiat"}
                });

            var proposalsController = new ProposalsController(fakeRpdbService);

            //act
            var actual = proposalsController.ListCarmodelsFromCarbrandId(id);
            var result = actual.Data as IEnumerable;

            //assert
            A.CallTo(
                () => fakeRpdbService.GetCarbrandModels(A<int>.That.IsEqualTo(id)))
                .MustHaveHappened(Repeated.Exactly.Once);

            Assert.IsNotEmpty(result);
            Assert.That(result, Is.All.Property("CarbrandID").EqualTo(id));
        }

     


   



        

       
    }

    /*
    [TestFixture]
    public class AccountControllerTests
    {
        private Controllers.AccountController ac;

        [SetUp]
        public void mysetup()
        {
            ac = new AccountController();
        }

        [Test]
        public void IsLoginOK_Always_CallsTheLogger()
        {
            //arrange
            ac.ControllerContext = A.Fake<ControllerContext>();
            

            //act
            LogOnModel m = new LogOnModel();
            m.Password = "lala";
            m.UserName = "lala";
            ac.LogOn(m, string.Empty);

            //assert
            A.CallTo(() => ac.LogOn()).MustHaveHappened();

        }
    }
     */
}
