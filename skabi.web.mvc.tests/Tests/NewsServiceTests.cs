using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using NUnit.Framework;
using skabi.common.Services;
using skabi.data.DomainModel;
using skabi.data.Repository;
using skabi.data.Repository.Interfaces;

namespace skabi.web.mvc.tests
{
    [TestFixture]
    [Category("Services")]
    public class NewsServiceTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void when_adding_a_post_without_a_text_an_exception_should_be_raised()
        {
            //arrange
            var fakeRepository = A.Fake<INewsRepository>();
            var fakeNews = A.Fake<News>();
            //var fakeContext = A.Fake<ObjectContext>();
            fakeNews.text = string.Empty;

            var newsService = new NewsService(fakeRepository);

            /*
            A.CallTo(
                () => fakeRepository.Add(A<News>.That.Matches(item => item.text == string.Empty)))
                .Throws<ArgumentNullException>();
            */
            //var newsController = new NewsController(fakeNewsService);
            

            //act
            newsService.Add(fakeNews);

            //assert

        }
    }
    
}
