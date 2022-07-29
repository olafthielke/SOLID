namespace SOLID.OCP.Standard
{
    public class RaceCar : Car
    {
        public override bool HasSpoiler => true;
        public override int MaxSpeedInKmPerHour => 300;
    }
}
