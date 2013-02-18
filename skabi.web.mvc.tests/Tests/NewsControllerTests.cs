using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using FakeItEasy;
using NUnit.Framework;
using skabi.common.Services;
using skabi.data.DomainModel;
using skabi.web.mvc4.Controllers;

namespace skabi.web.mvc.tests
{
    [Category("Controllers")]
    [TestFixture]
    public class NewsControllerTests
    {
        [Test]
        //[ExpectedException(typeof(ArgumentNullException))]
        public void when_adding_a_post_without_a_text_a_badrequest_response_should_be_returned()
        {
            //arrange
            var fakeNewsService = A.Fake<INewsService>();
            var fakeNews = A.Fake<News>();
            fakeNews.text = string.Empty;

            A.CallTo(
                () => fakeNewsService
                    .Add(A<News>
                        .That
                            .Matches(item => 
                                item.text == string.Empty)))
                                    .Throws<ArgumentNullException>();

            var newsController = new NewsController(fakeNewsService);

            //act
            var result = newsController.Put(fakeNews);
            var actual = result as HttpStatusCodeResult;

            //assert
            Assert.That(result, Is.InstanceOf(typeof(HttpStatusCodeResult))); //IsInstanceOf(typeof(HttpStatusCodeResult), result);
            Assert.That(actual.StatusCode, Is.EqualTo((int)HttpStatusCode.BadRequest));
        }
    }
}

