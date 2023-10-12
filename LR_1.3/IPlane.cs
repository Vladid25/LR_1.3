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
}
