using System.Windows.Forms;

namespace LR_1._3
{
    internal class CivilAircraft : Plane
    {

        public int PassengerCapacity { get; private set; }
        public int NumberOfTurbines { get; private set; }


        public CivilAircraft(int type, string company, double length, double maxSpeed, double weight, int passengerCapacity, int numberOfTurbines) : base(type, company, length, maxSpeed, weight)
        {
            PassengerCapacity = passengerCapacity;
            NumberOfTurbines = numberOfTurbines;
        }

        public override void AddWeight(double weight)
        {
            base.AddWeight(weight);
        }

        public override void UpgradeEngine(double power)
        {
            base.UpgradeEngine(power);
        }

        public override void AddToListBox(ListBox listBox1)
        {
            listBox1.Items.Add("Цивільний\t" + Company + "\t\t\t" +
            Length + " м\t\t" +
            MaxSpeed + " км/год    \t" +
            Weight + " кг\t\t" + PassengerCapacity + "\t\t" + NumberOfTurbines);

        }

    }
}
