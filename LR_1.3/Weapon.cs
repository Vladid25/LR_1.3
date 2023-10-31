namespace LR_1._3
{
    internal class Weapon
    {
        public string Name { get; private set; }
        public double Gauge { get; private set; }

        public Weapon(string name, double gauge)
        {
            Name = name;
            Gauge = gauge;
        }
    }
}
