using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace LR_1._3
{
    public partial class Form1 : Form
    {
        private readonly string TorZ = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
        private List<CivilAircraft> civil = new List<CivilAircraft>();
        private List<Warplane> war = new List<Warplane>();
        private List<Plane> planes = new List<Plane>();
        private PlaneType planeType;
        private delegate void OutputDelegate(ListBox listBox);
        private OutputDelegate del;

        public Form1()
        {
            InitializeComponent();
        }

        private void CheckIsNumber(KeyPressEventArgs e, TextBox textBox)
        {
            bool TZFound = false;
            //if (listBox.Text.Contains('-') && e.KeyChar == '-' || listBox.Text.Length > 0 && e.KeyChar == '-')
            //{
            //    e.Handled = true;
            //    return;
            //}
            //if (listBox.Text == "-" && e.KeyChar == ',')
            //{
            //    e.Handled = true;
            //    return;
            //}
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back) return;
            if (textBox.Text.IndexOf(TorZ) != -1) TZFound = true;
            if (TZFound)
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar.ToString() == TorZ) return;
            e.Handled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty || textBox3.Text == string.Empty || textBox4.Text == string.Empty || textBox5.Text == string.Empty)
            {
                MessageBox.Show("Введіть всі поля!");
                return;
            }
            if (planeType == PlaneType.Warplane)
            {
                Warplane w = InputWarplane();
                planes.Add(w);
                Register(w);
            }
            else
            {
                CivilAircraft c = InputCivilAircraft();
                planes.Add(c);
                Register(c);
            }

            UpdateListBox();
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;
            button4.Visible = false;
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button4.Visible = false;
            //Plane.PlaneName = "Різновиди літаків";
            //label1.Text = Plane.PlaneName;
            
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckIsNumber(e, textBox3);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckIsNumber(e, textBox4);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckIsNumber(e, textBox5);
        }

        private void WarHeader()
        {
            string formattedText = "Тип літака\tКомпанія виробник\tДовжина\t\tМакс швидкість\tМаса\tВантажопідйом\tК-сть боєприпасів\tГармата\tКалібр\tПасажиромісткість\tК-сть турбін\tДвигун\tПотужність";
            listBox1.Items.Add(formattedText);
        }

        private void літакПоЗамовчуваннюToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void UpdateListBox()
        {
            listBox1.Items.Clear();
            WarHeader();
            del(listBox1);
        }

        private void літакЗПараметрамиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            button4.Visible = true;

        }

        private void очиститиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //war.Clear();
            //civil.Clear();
            //listBox1.Items.Clear();
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void піднятиПотужністьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (planes.Count == 0)
            {
                MessageBox.Show("Відсутні записи!");
                return;
            }
            for (int i = 0; i < planes.Count; i++)
            {
                planes[i].UpgradeEngine(50);
            }
            UpdateListBox();
        }

        private void зменшитиПотужністьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (planes.Count == 0)
            {
                MessageBox.Show("Відсутні записи!");
                return;
            }
            for (int i = 0; i < planes.Count; i++)
            {
                planes[i].UpgradeEngine(50);
            }
            UpdateListBox();
        }

        private void додатиВантажToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (planes.Count == 0)
            {
                MessageBox.Show("Відсутні записи!");
                return;
            }
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Відсутні дані");
                return;
            }
            double weight = Convert.ToDouble(textBox1.Text);
            for (int i = 0; i < planes.Count; i++)
            {
                planes[i].AddWeight(weight);
            }
            textBox1.Clear();
            UpdateListBox();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckIsNumber(e, textBox1);
        }

        private void літакImplicitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if(textBox6.Text.Length == 0)
            //{
            //    MessageBox.Show("Дані відсутні!");
            //    return;
            //}
            ////Plane p = Convert.ToDouble(textBox6.Text);
            //textBox6.Clear();
            ////planes.Add(p);
            //UpdateListBox();
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            //CheckIsNumber(e, textBox6);
        }

        private void чиЄЛітакиОднаковогоТипуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int war = 0, civil = 0;
            foreach(var p in planes)
            {
                if (p.Type == PlaneType.Warplane) war++;
                if (p.Type == PlaneType.CivilPlane) civil++;
            }
            if(war>1||civil>1)
            {
                MessageBox.Show("Наявно літаки однакового типу!");
            }
            else
            {
                MessageBox.Show("Відсутні літаки однакового типу!");
            }
        }

        private void військовийЛітакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label9.Text = "Вантажопідйомність: ";
            label2.Text = "К-сть боєприпасів: ";
            label10.Text = "Гармата";
            label8.Text = "Калібр";
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            textBox9.Enabled = true;
            button4.Visible = true;
            planeType = PlaneType.Warplane;
        }

        private Warplane InputWarplane()
        {
            Warplane w = new Warplane
            {
                Type = PlaneType.Warplane,
                Company = textBox2.Text,
                Length = Convert.ToDouble(textBox3.Text),
                MaxSpeed = Convert.ToDouble(textBox4.Text),
                Weight = Convert.ToDouble(textBox5.Text),
                LoadCapacity = Convert.ToInt32(textBox7.Text),
                NumberAmmunition = Convert.ToInt32(textBox8.Text),
                MainWeapon = new Weapon(textBox6.Text,Convert.ToDouble(textBox9.Text))
            };
            return w;
        }

        private CivilAircraft InputCivilAircraft()
        {
            CivilAircraft c = new CivilAircraft
            (
                (int)PlaneType.CivilPlane,
                textBox2.Text,
                Convert.ToDouble(textBox3.Text),
                Convert.ToDouble(textBox4.Text),
                Convert.ToDouble(textBox5.Text),
                Convert.ToInt32(textBox7.Text),
                Convert.ToInt32(textBox8.Text),
                textBox6.Text,
                Convert.ToDouble(textBox9.Text)
                );
           
            return c;
        }

        private void цивільнийЛітакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label9.Text = "Пасажиромісткість: ";
            label2.Text = "К-сть турбін: ";
            label10.Text = "Двигун";
            label8.Text = "Потужність";
            
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            textBox9.Enabled = true;
            button4.Visible = true;
            planeType = PlaneType.CivilPlane;

        }

        private void військовомуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (planes.Count == 0)
            {
                MessageBox.Show("Відсутні записи!");
                return;
            }
            for (int i = 0; i < planes.Count; i++)
            {
                if (planes[i].Type == PlaneType.Warplane) planes[i].UpgradeEngine(50);
            }
            UpdateListBox();
        }

        private void цивільномуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (civil.Count == 0)
            {
                MessageBox.Show("Відсутні записи!");
                return;
            }
            for (int i = 0; i < planes.Count; i++)
            {
                if (planes[i].Type == PlaneType.CivilPlane) planes[i].UpgradeEngine(50);
            }
            UpdateListBox();
        }

        private void цивільніToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void максимальнаШвидкістьМенше200ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var i in planes)
            {
                if (i.MaxSpeed < 200&&i.Type==PlaneType.CivilPlane)
                {
                    planes.Remove(i);
                    Unregister(i);
                }
            }
            UpdateListBox();
        }

        private void кстьБоєприпасівМенше2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //foreach (var i in planes)
            //{
            //    if (i. < 2)
            //    {
            //        planes.Remove(i);
            //        Unregister(i);
            //    }
            //}
            //UpdateListBox();
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckIsNumber(e, textBox7);
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckIsNumber(e, textBox8);
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckIsNumber(e, textBox9);
        }

        private void Register(Plane p)
        {
            del += p.AddToListBox;
        }

        private void Unregister(Plane p)
        {
            del-=p.AddToListBox;
        }
    }
}
