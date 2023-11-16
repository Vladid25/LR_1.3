using LR_1._3;
using System.Collections.Generic;
using System.Windows.Forms;

internal static class AdditionalClassHelpers
{
    public static void IsHereEqualPlanes(List<Plane> planes)
    {
        int war = 0, civil = 0;
        foreach (var p in planes)
        {
            if (p.Type == PlaneType.Warplane) war++;
            if (p.Type == PlaneType.CivilPlane) civil++;
        }
        if (war > 1 || civil > 1)
        {
            MessageBox.Show("Наявно літаки однакового типу!");
        }
        else
        {
            MessageBox.Show("Відсутні літаки однакового типу!");
        }
    }
}