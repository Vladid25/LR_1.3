using System;
using System.Windows.Forms;

namespace LR_1._3
{
    [Serializable]
    internal partial class Warplane : Plane
    {
        public double LoadCapacity { get; set; }
        public int NumberAmmunition { get; set; }
        public Weapon MainWeapon { get; set; }
        public MyDelegate D_AddWeight { get; set; }

        public Warplane(int type, string company, double length, double maxSpeed, double weight, double loadCapacity, int numberAmmunition, Weapon weapon) :
            base(type, company, length, maxSpeed, weight)
        {
            LoadCapacity = loadCapacity;
            NumberAmmunition = numberAmmunition;
            MainWeapon = weapon;
            D_AddWeight += AddWeight;
        }

        public Warplane()
        {
        }
    }
}
