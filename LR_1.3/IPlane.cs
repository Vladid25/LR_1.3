using System.Windows.Forms;

namespace LR_1._3
{
    internal interface IPlane
    {
        string PlaneName { get; set; }
        PlaneType Type { get; set; }
        string Company { get; set; }
        double Length { get; set; }
        double MaxSpeed { get; set; }
        double Weight { get; set; }

        void UpgradeEngine(double power);

        void AddWeight(double weight);
    }

    internal partial class Warplane : Plane
    {
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

        public  override void AddToListBox(ListBox listBox1)
        {
            listBox1.Items.Add("Військовий\t" + Company + "\t\t\t" +
            Length + " м\t\t" +
            MaxSpeed + " км/год    \t" +
            Weight + " кг\t\t" + LoadCapacity + "\t\t" + NumberAmmunition + "\t" + MainWeapon.Name + "\t" + MainWeapon.Gauge);
        }
    }
}
