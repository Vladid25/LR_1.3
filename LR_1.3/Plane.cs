using System.Windows.Forms;

namespace LR_1._3
{
    abstract internal class Plane
    {
        public static string PlaneName;
        public PlaneType Type;
        public string Company { get; set; }
        public double Length { get; set; }
        public double MaxSpeed { get; set; }
        public double Weight { get; set; }

        public Plane()
        {
            Company = "Not set";
            Length = 0;
            MaxSpeed = 0;
            Weight = 0;
        }

        public Plane(int type, string company, double length, double maxSpeed, double weight)
        {
            if (type == 1) Type = PlaneType.Warplane;
            else Type = PlaneType.CivilPlane;
            this.Company = company;
            this.Length = length;
            this.MaxSpeed = maxSpeed;
            this.Weight = weight;
        }

        public Plane(Plane other)
        {
            Type = other.Type;
            Company = other.Company;
            Length = other.Length;
            MaxSpeed = other.MaxSpeed;
            Weight = other.Weight;
        }


        virtual public void UpgradeEngine(double power)
        {
            MaxSpeed += power;
        }

        virtual public void AddWeight(double weight)
        {
            if (weight <= 0) return;

            Weight += weight;
        }

        virtual public void AddToListBox(ListBox listBox1)
        {

        }

        public static Plane operator ++(Plane p)
        {
            p.UpgradeEngine(50);
            return p;
        }

        public static Plane operator --(Plane p)
        {
            if (p.MaxSpeed <= 50) return p;
            p.UpgradeEngine(-50);
            return p;
        }

        public static bool operator ==(Plane p1, Plane p2)
        {
            if (p1.Type == p2.Type) return true;
            else return false;
        }

        public static bool operator !=(Plane p1, Plane p2)
        {
            if (p1.Type != p2.Type) return true;
            else return false;
        }

        public static Plane operator +(Plane p, double weight)
        {
            p.AddWeight(weight);
            return p;
        }

        //public static implicit operator Plane(double maxSpeed)
        //{
        //    return new Plane("Вантажний", "Boeing", 0, maxSpeed, 0);
        //}

        public static explicit operator double(Plane plane)
        {
            return plane.MaxSpeed;
        }

    }

    public enum PlaneType
    {
        Warplane,
        CivilPlane
    }
}
