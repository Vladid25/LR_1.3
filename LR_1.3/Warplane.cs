using System.Windows.Forms;

namespace LR_1._3
{
    internal class Warplane : Plane
    {
        public double LoadCapacity { get; private set; }
        public int NumberAmmunition { get; private set; }

        public Warplane(int type, string company, double length, double maxSpeed, double weight, double loadCapacity, int numberAmmunition)
        {
            Type = (PlaneType)type;
            Company = company;
            Length = length;
            MaxSpeed = maxSpeed;
            Weight = weight;
            LoadCapacity = loadCapacity;
            NumberAmmunition = numberAmmunition;
        }

        public override void AddWeight(double weight)
        {
            if (weight < 0) return;
            Weight += weight;
        }

        public override void UpgradeEngine(double power)
        {
            if (power < 0) return;
            MaxSpeed += power;
        }

        public override void AddToListBox(ListBox listBox1)
        {
            listBox1.Items.Add("Військовий\t" + Company + "\t\t\t" +
            Length + " м\t\t" +
            MaxSpeed + " км/год    \t" +
            Weight + " кг\t\t" + LoadCapacity + "\t\t" + NumberAmmunition);
        }

    }
}
