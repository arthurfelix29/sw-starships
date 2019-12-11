using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsShips.Domain.Core.Models;
using StarWarsShips.Domain.Starships;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace StarWarsShips.Domain.Test
{
    [TestClass, ExcludeFromCodeCoverage]
    public class StarshipTest
    {
        private Starship _entity;

        [TestMethod]
        public async Task Starship_Should_Add_UnknownConsumable()
        {
            _entity = await Starship.AddAsync("Name 1", string.Empty, "unknown", 1000000);

            _entity.Should().NotBeNull().And.BeOfType(typeof(Starship)).And.BeAssignableTo(typeof(Entity));

            _entity.Id.Should().NotBeEmpty();
            _entity.Name.Should().Be("Name 1");
            _entity.MgltDistance.Should().Be(0);
            _entity.Consumables.Should().Be("unknown");
            _entity.AmountStopsRequired.Should().Be(0);
        }

        [TestMethod]
        public async Task Starship_Should_Add_NoConsumable()
        {
            _entity = await Starship.AddAsync("Name 2", string.Empty, string.Empty, 1000000);

            _entity.Should().NotBeNull().And.BeOfType(typeof(Starship)).And.BeAssignableTo(typeof(Entity));

            _entity.Id.Should().NotBeEmpty();
            _entity.Name.Should().Be("Name 2");
            _entity.MgltDistance.Should().Be(0);
            _entity.Consumables.Should().BeNullOrEmpty();
            _entity.AmountStopsRequired.Should().Be(0);
        }

        [TestMethod]
        public async Task Starship_Should_Add_HoursConsumable()
        {
            _entity = await Starship.AddAsync("Name 4", "10", "12 hours", 1000000);

            _entity.Should().NotBeNull().And.BeOfType(typeof(Starship)).And.BeAssignableTo(typeof(Entity));

            _entity.Id.Should().NotBeEmpty();
            _entity.Name.Should().Be("Name 4");
            _entity.MgltDistance.Should().Be(10);
            _entity.Consumables.Should().Be("12 hours");
            _entity.AmountStopsRequired.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public async Task Starship_Should_Add_HourConsumable()
        {
            _entity = await Starship.AddAsync("Name 5", "20", "1 hour", 1000000);

            _entity.Should().NotBeNull().And.BeOfType(typeof(Starship)).And.BeAssignableTo(typeof(Entity));

            _entity.Id.Should().NotBeEmpty();
            _entity.Name.Should().Be("Name 5");
            _entity.MgltDistance.Should().Be(20);
            _entity.Consumables.Should().Be("1 hour");
            _entity.AmountStopsRequired.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public async Task Starship_Should_Add_DaysConsumable()
        {
            _entity = await Starship.AddAsync("Name 6", "30", "20 days", 1000000);

            _entity.Should().NotBeNull().And.BeOfType(typeof(Starship)).And.BeAssignableTo(typeof(Entity));

            _entity.Id.Should().NotBeEmpty();
            _entity.Name.Should().Be("Name 6");
            _entity.MgltDistance.Should().Be(30);
            _entity.Consumables.Should().Be("20 days");
            _entity.AmountStopsRequired.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public async Task Starship_Should_Add_DayConsumable()
        {
            _entity = await Starship.AddAsync("Name 7", "40", "1 day", 1000000);

            _entity.Should().NotBeNull().And.BeOfType(typeof(Starship)).And.BeAssignableTo(typeof(Entity));

            _entity.Id.Should().NotBeEmpty();
            _entity.Name.Should().Be("Name 7");
            _entity.MgltDistance.Should().Be(40);
            _entity.Consumables.Should().Be("1 day");
            _entity.AmountStopsRequired.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public async Task Starship_Should_Add_WeeksConsumable()
        {
            _entity = await Starship.AddAsync("Name 8", "50", "5 weeks", 1000000);

            _entity.Should().NotBeNull().And.BeOfType(typeof(Starship)).And.BeAssignableTo(typeof(Entity));

            _entity.Id.Should().NotBeEmpty();
            _entity.Name.Should().Be("Name 8");
            _entity.MgltDistance.Should().Be(50);
            _entity.Consumables.Should().Be("5 weeks");
            _entity.AmountStopsRequired.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public async Task Starship_Should_Add_WeekConsumable()
        {
            _entity = await Starship.AddAsync("Name 9", "60", "1 week", 1000000);

            _entity.Should().NotBeNull().And.BeOfType(typeof(Starship)).And.BeAssignableTo(typeof(Entity));

            _entity.Id.Should().NotBeEmpty();
            _entity.Name.Should().Be("Name 9");
            _entity.MgltDistance.Should().Be(60);
            _entity.Consumables.Should().Be("1 week");
            _entity.AmountStopsRequired.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public async Task Starship_Should_Add_MonthsConsumable()
        {
            _entity = await Starship.AddAsync("Name 10", "70", "11 months", 1000000);

            _entity.Should().NotBeNull().And.BeOfType(typeof(Starship)).And.BeAssignableTo(typeof(Entity));

            _entity.Id.Should().NotBeEmpty();
            _entity.Name.Should().Be("Name 10");
            _entity.MgltDistance.Should().Be(70);
            _entity.Consumables.Should().Be("11 months");
            _entity.AmountStopsRequired.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public async Task Starship_Should_Add_MonthConsumable()
        {
            _entity = await Starship.AddAsync("Name 11", "80", "1 month", 1000000);

            _entity.Should().NotBeNull().And.BeOfType(typeof(Starship)).And.BeAssignableTo(typeof(Entity));

            _entity.Id.Should().NotBeEmpty();
            _entity.Name.Should().Be("Name 11");
            _entity.MgltDistance.Should().Be(80);
            _entity.Consumables.Should().Be("1 month");
            _entity.AmountStopsRequired.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public async Task Starship_Should_Add_YearsConsumable()
        {
            _entity = await Starship.AddAsync("Name 12", "5", "10 years", 1000000);

            _entity.Should().NotBeNull().And.BeOfType(typeof(Starship)).And.BeAssignableTo(typeof(Entity));

            _entity.Id.Should().NotBeEmpty();
            _entity.Name.Should().Be("Name 12");
            _entity.MgltDistance.Should().Be(5);
            _entity.Consumables.Should().Be("10 years");
            _entity.AmountStopsRequired.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public async Task Starship_Should_Add_YearConsumable()
        {
            _entity = await Starship.AddAsync("Name 13", "100", "1 year", 1000000);

            _entity.Should().NotBeNull().And.BeOfType(typeof(Starship)).And.BeAssignableTo(typeof(Entity));

            _entity.Id.Should().NotBeEmpty();
            _entity.Name.Should().Be("Name 13");
            _entity.MgltDistance.Should().Be(100);
            _entity.Consumables.Should().Be("1 year");
            _entity.AmountStopsRequired.Should().BeGreaterThan(0);
        }
    }
}