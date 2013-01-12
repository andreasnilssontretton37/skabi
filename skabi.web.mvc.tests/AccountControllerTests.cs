using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit;
using NUnit.Framework;
using FakeItEasy;
using skabi.web.mvc;
using skabi.web.mvc.Controllers;

using System.Web.Security;
using skabi.web.mvc.Models;
using System.Web.Mvc;


namespace skabi.web.mvc.tests
{


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
}
