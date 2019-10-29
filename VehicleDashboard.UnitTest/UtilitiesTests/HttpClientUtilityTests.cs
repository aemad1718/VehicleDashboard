using Moq;
using System;
using VehicleDashboard.CrossCutting;
using Xunit;

namespace VehicleDashboard.UnitTest.UtilitiesTests
{
    public class HttpClientUtilityTests
    {
        [Fact]
        [Trait("Category", "GenericRepository-GetList")]
        public void GetNoEndpoingUrlPassedShouldThrowException()
        {
            HttpClientUtility httpClientUtility = new HttpClientUtility();

            Assert.ThrowsAnyAsync<NullReferenceException>(() => httpClientUtility.Get<Object>(null));
        }
    }
}
