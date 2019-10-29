using Moq;
using System;
using VehicleDashboard.CrossCutting;
using VehicleDashboard.DatabaseRepository;
using VehicleDashboard.DatabaseRepositoryInterface;
using Xunit;

namespace VehicleDashboard.UnitTest.GenericRepositoryTests
{
    public class GetListTests
    {
        [Fact]
        [Trait("Category", "GenericRepository-GetList")]
        public void GetListNoDbContextPassedShouldThrowException()
        {
            GenericRepository genericRepository = new GenericRepository(null, new LoggerService());

            Assert.Throws<NullReferenceException>(() => genericRepository.GetList<Customer>());
        }

        [Fact]
        [Trait("Category", "GenericRepository-GetList")]
        public void GetListNonDbContextEntityPassedShouldThrowException()
        {
            Mock<VehicledashboardContext> dbContextMock = new Mock<VehicledashboardContext>();
            Mock<LoggerService> loggerMock = new Mock<LoggerService>();

            GenericRepository genericRepository = new GenericRepository(dbContextMock.Object, loggerMock.Object);

            Assert.Throws<NullReferenceException>(() => genericRepository.GetList<NonDbContextEntity>());
        }

        private class NonDbContextEntity
        {
        }
    }
}
