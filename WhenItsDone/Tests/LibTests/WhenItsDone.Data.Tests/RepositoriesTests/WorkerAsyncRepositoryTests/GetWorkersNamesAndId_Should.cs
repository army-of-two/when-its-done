using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.Repositories;
using WhenItsDone.Data.Tests.Helpers;
using WhenItsDone.Models;
using AutoMapper;
using WhenItsDone.DTOs.WorkerVIewsDTOs;
using System.Linq;
using System;

namespace WhenItsDone.Data.Tests.RepositoriesTests.WorkerAsyncRepositoryTests
{
    [TestFixture]
    public class GetWorkersNamesAndId_Should
    {
        [SetUp]
        public void BeforeEach()
        {
            Mapper.Initialize(cfg => { });
        }

        [Test]
        public void Work_Properly_WhenEverythingIsValid()
        {
            var colleciton = this.GetMocks();

            var mockedSet = QueryableDbSetMock.GetQueryableMockDbSet(colleciton);

            var mockedContext = new Mock<IWhenItsDoneDbContext>();
            mockedContext.Setup(x => x.Set<Worker>()).Returns(mockedSet);

            Mapper.Initialize(config =>
            {
                config.CreateMap<Worker, WorkerNamesIdDTO>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(x => x.Id))
                .ForMember(dest => dest.FirstName, opts => opts.MapFrom(x => x.FirstName))
                .ForMember(dest => dest.LastName, opts => opts.MapFrom(x => x.LastName))
                .ForMember(dest => dest.NumberOfDishes, opts => opts.MapFrom(x => x.Dishes.Count));
            });

            var expected = colleciton
                                .Select(x => new WorkerNamesIdDTO()
                                {
                                    Id = x.Id,
                                    FirstName = x.FirstName,
                                    LastName = x.LastName,
                                    NumberOfDishes = x.Dishes.Count
                                })
                                .ToList();

            var obj = new WorkerAsyncRepository(mockedContext.Object);

            var result = obj.GetWorkersNamesAndId().Result;

            // coz objects are not same and have to assert vs their values
            CollectionAssert.AreEquivalent(expected.Select(x => x.Id), result.Select(x => x.Id));
            CollectionAssert.AreEquivalent(expected.Select(x => x.FirstName), result.Select(x => x.FirstName));
            CollectionAssert.AreEquivalent(expected.Select(x => x.LastName), result.Select(x => x.LastName));
            CollectionAssert.AreEquivalent(expected.Select(x => x.NumberOfDishes), result.Select(x => x.NumberOfDishes));
        }

        [Test]
        public void NotThrow_WhenCollection_IsEmpty()
        {
            var colleciton = new List<Worker>();

            var mockedSet = QueryableDbSetMock.GetQueryableMockDbSet(colleciton);

            var mockedContext = new Mock<IWhenItsDoneDbContext>();
            mockedContext.Setup(x => x.Set<Worker>()).Returns(mockedSet);

            Mapper.Initialize(config =>
            {
                config.CreateMap<Worker, WorkerNamesIdDTO>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(x => x.Id))
                .ForMember(dest => dest.FirstName, opts => opts.MapFrom(x => x.FirstName))
                .ForMember(dest => dest.LastName, opts => opts.MapFrom(x => x.LastName))
                .ForMember(dest => dest.NumberOfDishes, opts => opts.MapFrom(x => x.Dishes.Count));
            });

            var expected = colleciton
                                .Select(x => new WorkerNamesIdDTO()
                                {
                                    Id = x.Id,
                                    FirstName = x.FirstName,
                                    LastName = x.LastName,
                                    NumberOfDishes = x.Dishes.Count
                                })
                                .ToList();

            var obj = new WorkerAsyncRepository(mockedContext.Object);

            var result = obj.GetWorkersNamesAndId().Result;

            // coz objects are not same and have to assert vs their values
            CollectionAssert.AreEquivalent(expected.Select(x => x.Id), result.Select(x => x.Id));
            CollectionAssert.AreEquivalent(expected.Select(x => x.FirstName), result.Select(x => x.FirstName));
            CollectionAssert.AreEquivalent(expected.Select(x => x.LastName), result.Select(x => x.LastName));
            CollectionAssert.AreEquivalent(expected.Select(x => x.NumberOfDishes), result.Select(x => x.NumberOfDishes));
        }

        [Test]
        public void Throw_InvalidOperationException_WhenAutomapper_HaventRightBinding()
        {
            var colleciton = new List<Worker>();

            var mockedSet = QueryableDbSetMock.GetQueryableMockDbSet(colleciton);

            var mockedContext = new Mock<IWhenItsDoneDbContext>();
            mockedContext.Setup(x => x.Set<Worker>()).Returns(mockedSet);

            var obj = new WorkerAsyncRepository(mockedContext.Object);

            Assert.CatchAsync<InvalidOperationException>(() => obj.GetWorkersNamesAndId());
        }

        private IEnumerable<Worker> GetMocks()
        {
            return new List<Worker>()
            {
                new Worker()
                {
                    Id = 1,
                    FirstName = "Pesho1",
                    LastName = "Last1",
                    Dishes = new List<Dish>()
                    {
                        new Dish(),
                        new Dish(),
                        new Dish(),
                        new Dish(),
                        new Dish(),
                        new Dish(),
                        new Dish()
                    }
                },
                new Worker()
                {
                    Id = 2,
                    FirstName = "Pesho2",
                    LastName = "Last2",
                    Dishes = new List<Dish>()
                    {
                        new Dish(),
                        new Dish(),
                        new Dish(),
                        new Dish(),
                        new Dish(),
                    }
                },
                new Worker()
                {
                    Id = 3,
                    FirstName = "Pesho3",
                    LastName = "Last3",
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                    }
                },
                new Worker()
                {
                    Id = 4,
                    FirstName = "Pesho4",
                    LastName = "Last4",
                    Dishes = new List<Dish>()
                },
                new Worker()
                {
                    Id = 5,
                    FirstName = "Pesho1",
                    LastName = "Last1",
                    Dishes = new List<Dish>()
                    {
                        new Dish(),
                        new Dish(),
                        new Dish()
                    }
                },
            };
        }
    }
}
