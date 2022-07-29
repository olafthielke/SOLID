namespace SOLID.OCP.Standard
{
    public abstract class Car
    {
        public virtual bool HasSpoiler => false;
        public abstract int MaxSpeedInKmPerHour { get; }
    }
}
