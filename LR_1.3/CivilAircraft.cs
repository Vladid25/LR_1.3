using System.Windows.Forms;

namespace LR_1._3
{
    internal class CivilAircraft : IPlane
    {
        
        public int PassengerCapacity { get; private set; }
        public int NumberOfTurbines { get; private set; }
        public string PlaneName { get; set; }
        public PlaneType Type { get; set; }
        public string Company { get; set; }
        public double Length { get; set; }
        public double MaxSpeed { get; set; }
        public double Weight { get; set; }

        public CivilAircraft(int type, string company, double length, double maxSpeed, double weight, int passengerCapacity, int numberOfTurbines)
        {
            Type = (PlaneType)type; Company = company; Length = length; MaxSpeed = maxSpeed; Weight = weight;
            PassengerCapacity = passengerCapacity;
            NumberOfTurbines = numberOfTurbines;
        }

        public void AddWeight(double weight)
        {
            if (weight < 0) return;
            Weight += weight;
         }

        public void UpgradeEngine(double power)
        {
            if (power < 0) return;
            MaxSpeed += power;
        }

        public void AddToListBox(ListBox listBox1)
        {
            listBox1.Items.Add("Цивільний\t" + Company + "\t\t\t" +
            Length + " м\t\t" +
            MaxSpeed + " км/год    \t" +
            Weight + " кг\t\t" + PassengerCapacity + "\t\t" + NumberOfTurbines);

        }

    }
}
