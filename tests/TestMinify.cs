using System;
using Xunit;
using Minify.Model;
using System.Linq;
using Bogus;
using Bogus.DataSets;

namespace Minify.Tests
{
    public class TestMinify
    {
        Repository repository;
        public TestMinify()
        {
            repository = new Repository();
            Repository.collection = new Faker<MinifyData>()
                .RuleFor(data => data.Key, faker => faker.Lorem.Word())
                .RuleFor(data => data.Url, faker => faker.Internet.Url())
                .Generate(5);

        }
        [Fact]
        public void AddRepository()
        {
            var addfaker = new Faker<MinifyData>()
                .RuleFor(data => data.Key, faker => faker.Lorem.Word())
                .RuleFor(data => data.Url, faker => faker.Internet.Url())
                .Generate();
            repository.Add(addfaker);
            Assert.Equal(expected: 6, Repository.collection.Count());
            Assert.Contains(addfaker, Repository.collection);
        }
        [Fact]
        public void DeleteRepository()
        {
            var deletefaker = Repository.collection.FirstOrDefault();
            repository.Delete(deletefaker.Key);
            Assert.Equal(expected: 4, Repository.collection.Count());
            Assert.DoesNotContain(deletefaker, Repository.collection);
        }

        [Fact]
        public void GetRepository()
        {
            
            var getfaker = repository.Get(Repository.collection.FirstOrDefault().Key);
            Assert.Equal(getfaker, Repository.collection.FirstOrDefault());
        }
        
        [Fact]
        public void GetAllRepositories()
        {
            
            var getallfakers = repository.Get();
            Assert.Equal(getallfakers, Repository.collection);
        }
    }
}