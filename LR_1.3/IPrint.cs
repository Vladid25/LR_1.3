using System.Windows.Forms;

namespace LR_1._3
{
    internal interface IPrint
    {
        void AddToListBox(ListBox listBox1);
    }
}

namespace NewNamespace
{
    public class AdditionalClass
    {
        public void Show()
        {
            MessageBox.Show("Повідомлення з іншого простору імен!");
        }
    }
}