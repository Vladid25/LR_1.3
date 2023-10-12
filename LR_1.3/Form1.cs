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
        private PlaneType planeType;

        public Form1()
        {
            InitializeComponent();
        }

        private void CheckIsNumber(KeyPressEventArgs e, TextBox textBox)
        {
            bool TZFound = false;
            //if (textBox.Text.Contains('-') && e.KeyChar == '-' || textBox.Text.Length > 0 && e.KeyChar == '-')
            //{
            //    e.Handled = true;
            //    return;
            //}
            //if (textBox.Text == "-" && e.KeyChar == ',')
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
                war.Add(InputWarplane());
            }
            else
            {
                civil.Add(InputCivilAircraft());
            }
            UpdateListBox();
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            button4.Visible = false;
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox7.Clear();
            textBox8.Clear();
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

        //private void AddWarPlaneToListBox(Plane plane)
        //{
        //    listBox1.Items.Add(plane.Company + "\t\t\t" + 
        //        plane.Length + " м\t\t" +
        //        plane.MaxSpeed + " км/год    \t" +
        //        plane.Weight + " кг\t\t");
        //}

        private void WarHeader()
        {
            string formattedText = "Тип літака\tКомпанія виробник\tДовжина\t\tМакс швидкість\tМаса\tВантажопідйом\tК-сть боєприпасів\tПасажиромісткість\tК-сть турбін";
            listBox1.Items.Add(formattedText);
        }

        private void CivilHeader()
        {
            string formattedText = "Тип літака\tКомпанія виробник\tДовжина\t\tМакс швидкість\tМаса\tПасажиромісткість\tК-сть турбін";
            listBox1.Items.Add(formattedText);
        }

        private void літакПоЗамовчуваннюToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void UpdateListBox()
        {
            listBox1.Items.Clear();
            WarHeader();
            foreach (var plane in war)
            {
                plane.AddToListBox(listBox1);
            }

            //CivilHeader();
            foreach (var plane in civil)
            {
                plane.AddToListBox(listBox1);
            }

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
            if (war.Count == 0)
            {
                MessageBox.Show("Відсутні записи!");
                return;
            }
            for (int i = 0; i < war.Count; i++)
            {
                war[i].UpgradeEngine(50);
            }
            UpdateListBox();
        }

        private void зменшитиПотужністьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (war.Count == 0 && civil.Count == 0)
            {
                MessageBox.Show("Відсутні записи!");
                return;
            }
            for (int i = 0; i < war.Count; i++)
            {
                war[i].UpgradeEngine(50);
            }
            UpdateListBox();
        }

        private void додатиВантажToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (war.Count == 0 && civil.Count == 0)
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
            for (int i = 0; i < war.Count; i++)
            {
                war[i].AddWeight(weight);
            }
            for (int i = 0; i < war.Count; i++) civil[i].AddWeight(weight);
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
            if (war.Count > 1 || civil.Count > 1) MessageBox.Show("Наявно літаки однакового типу!");
            else MessageBox.Show("Відсутні літаки однакового типу!");
        }

        private void військовийЛітакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label9.Text = "Вантажопідйомність: ";
            label2.Text = "К-сть боєприпасів: ";
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            button4.Visible = true;
            planeType = PlaneType.Warplane;
        }

        private Warplane InputWarplane()
        {
            string company;
            double length, maxSpeed, weight;
            int loadCap, ammo;

            company = textBox2.Text;
            length = Convert.ToDouble(textBox3.Text);
            maxSpeed = Convert.ToDouble(textBox4.Text);
            weight = Convert.ToDouble(textBox5.Text);
            loadCap = Convert.ToInt32(textBox7.Text);
            ammo = Convert.ToInt32(textBox8.Text);
            return new Warplane(0, company, length, maxSpeed, weight, loadCap, ammo);
        }

        private CivilAircraft InputCivilAircraft()
        {
            string company;
            double length, maxSpeed, weight;
            int passengerCapacity, numberOfTurbines;
            company = textBox2.Text;
            length = Convert.ToDouble(textBox3.Text);
            maxSpeed = Convert.ToDouble(textBox4.Text);
            weight = Convert.ToDouble(textBox5.Text);
            passengerCapacity = Convert.ToInt32(textBox7.Text);
            numberOfTurbines = Convert.ToInt32(textBox8.Text);
            return new CivilAircraft(1, company, length, maxSpeed, weight, passengerCapacity, numberOfTurbines);
        }

        private void цивільнийЛітакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label9.Text = "Пасажиромісткість: ";
            label2.Text = "К-сть турбін: ";
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            button4.Visible = true;
            planeType = PlaneType.CivilPlane;

        }

        private void військовомуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (war.Count == 0)
            {
                MessageBox.Show("Відсутні записи!");
                return;
            }
            for (int i = 0; i < war.Count; i++)
            {
                war[i].UpgradeEngine(50);
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
            for (int i = 0; i < civil.Count; i++)
            {
                civil[i].UpgradeEngine(50);
            }
            UpdateListBox();
        }

        private void цивільніToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void максимальнаШвидкістьМенше200ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var i in civil)
            {
                if (i.MaxSpeed < 200) civil.Remove(i);
            }
            UpdateListBox();
        }

        private void кстьБоєприпасівМенше2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var i in war)
            {
                if (i.LoadCapacity < 2) war.Remove(i);
            }
            UpdateListBox();
        }
    }
}
