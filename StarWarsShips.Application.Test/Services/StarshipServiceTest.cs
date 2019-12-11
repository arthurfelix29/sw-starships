using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StarWarsShips.Application.AutoMapper;
using StarWarsShips.Application.Interfaces;
using StarWarsShips.Application.Services;
using StarWarsShips.Application.ViewModels;
using StarWarsShips.Domain.Starships.Interfaces;
using StarWarsShips.Domain.Starships.Wrappers;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsShips.Application.Test.Services
{
    [TestClass, ExcludeFromCodeCoverage]
    public class StarshipServiceTest
    {
        private IMapper _mapper;
        private Mock<IStarshipRepository> _starshipRepositoryMock;
        private IStarshipService _service;

        [TestInitialize]
        public void Init()
        {
            var mappingConfig = AutoMapperConfig.RegisterMappings();
            _mapper = mappingConfig.CreateMapper();

            _starshipRepositoryMock = new Mock<IStarshipRepository>();
            _starshipRepositoryMock.Setup(x => x.GetAllStarshipsAsync())
                .Returns(Task.FromResult<IEnumerable<StarshipDetailsWrapper>>(new List<StarshipDetailsWrapper> { new StarshipDetailsWrapper { Name = "Name 1", MgltDistance = "40", Consumables = "15 years" } }))
                .Verifiable();

            _service = new StarshipService(_mapper, _starshipRepositoryMock.Object);
        }

        [TestMethod]
        public async Task StarshipList_Should_Contain_One_Item()
        {
            var result = await _service.GetAllStarshipsAsync("1000000");
            var items = result.Should().BeAssignableTo<IEnumerable<StarshipViewModel>>().Subject;
            items.Count().Should().Be(1);

            _starshipRepositoryMock.Verify(x => x.GetAllStarshipsAsync(), Times.Once());
        }
    }
}