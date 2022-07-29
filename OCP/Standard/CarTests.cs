using FluentAssertions;
using Xunit;

namespace SOLID.OCP.Standard
{
    public class CarTests
    {
        [Fact]
        public void Test_Cars()
        {
            var car = new PassengerCar();
            car.HasSpoiler.Should().BeFalse();
            car.MaxSpeedInKmPerHour.Should().Be(150);

            var raceCar = new RaceCar();
            raceCar.HasSpoiler.Should().BeTrue();
            raceCar.MaxSpeedInKmPerHour.Should().Be(300);
        }
    }
}
