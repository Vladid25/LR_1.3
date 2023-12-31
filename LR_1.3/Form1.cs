﻿using NewNamespace;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using static System.Convert;
using Vlad = System.Windows.Forms.MessageBox;

namespace LR_1._3
{
    public partial class Form1 : Form
    {
        private readonly string TorZ = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
        private List<Plane> planes = new List<Plane>();
        private PlaneType planeType;
        private delegate void OutputDelegate(ListBox listBox);
        private OutputDelegate del;
        private delegate void SetDel();
        private event SetDel eventDel;
        private const string fileName = "planes.dat";

        partial void WarHeader();

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
                Vlad.Show("Введіть всі поля!");
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

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                formatter.Serialize(stream, planes);
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
            eventDel += SetName;
            eventDel();
            AdditionalClass additional = new AdditionalClass();
            additional.Show();
        }

        private void SetName()
        {
            label1.Text = "Літаки";
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

        partial void WarHeader()
        {
            string formattedText = "Тип літака\tКомпанія виробник\tДовжина\t\tМакс швидкість\tМаса\tВантажопідйом\tК-сть боєприпасів\tГармата\tКалібр\tПасажиромісткість\tК-сть турбін\tДвигун\tПотужність";
            listBox1.Items.Add(formattedText);
        }

        private void UpdateListBox()
        {
            listBox1.Items.Clear();
            if (del != null)
            {
                WarHeader();
                del.Invoke(listBox1);
            }
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void піднятиПотужністьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (planes.Count == 0)
            {
                Vlad.Show("Відсутні записи!");
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
                Vlad.Show("Відсутні записи!");
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
                Vlad.Show("Відсутні записи!");
                return;
            }
            if (textBox1.Text.Length == 0)
            {
                Vlad.Show("Відсутні дані");
                return;
            }
            double weight = ToDouble(textBox1.Text);
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

        private void чиЄЛітакиОднаковогоТипуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int war = 0, civil = 0;
            foreach (var p in planes)
            {
                if (p.Type == PlaneType.Warplane) war++;
                if (p.Type == PlaneType.CivilPlane) civil++;
            }
            if (war > 1 || civil > 1)
            {
                Vlad.Show("Наявно літаки однакового типу!");
            }
            else
            {
                Vlad.Show("Відсутні літаки однакового типу!");
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
                Length = ToDouble(textBox3.Text),
                MaxSpeed = ToDouble(textBox4.Text),
                Weight = ToDouble(textBox5.Text),
                LoadCapacity = ToInt32(textBox7.Text),
                NumberAmmunition = ToInt32(textBox8.Text),
                MainWeapon = new Weapon(textBox6.Text, ToDouble(textBox9.Text))
            };
            w.D_AddWeight = w.AddWeight;
            w.D_AddWeight(w.Weight);
            return w;
        }

        private CivilAircraft InputCivilAircraft()
        {
            CivilAircraft c2 = new CivilAircraft();
            c2.Type = PlaneType.CivilPlane;
            c2.Company = textBox2.Text;
            c2.Length = ToDouble(textBox3.Text);
            c2.MaxSpeed = ToDouble(textBox4.Text);
            c2.Weight = ToDouble(textBox5.Text);
            c2.PassengerCapacity = ToInt32(textBox7.Text);
            c2.NumberOfTurbines = ToInt32(textBox8.Text);
            c2.Engine = new PlaneEngine(textBox6.Text, ToDouble(textBox9.Text));
            return c2;
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
                Vlad.Show("Відсутні записи!");
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
            if (planes.Count == 0)
            {
                Vlad.Show("Відсутні записи!");
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
            for (int i = 0; i < planes.Count; i++)
            {
                if (planes[i].Type == PlaneType.CivilPlane)
                {
                    Unregister(planes[i]);
                    planes.Remove(planes[i]);
                }
            }
            UpdateListBox();
        }

        private void максимальнаШвидкістьМенше200ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var i in planes)
            {
                if (i.MaxSpeed < 200 && i.Type == PlaneType.CivilPlane)
                {
                    Unregister(i);
                    planes.Remove(i);
                }
            }
            UpdateListBox();
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
            del -= p.AddToListBox;
        }

        private void військовіToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < planes.Count; i++)
            {
                if (planes[i].Type == PlaneType.Warplane)
                {
                    Unregister(planes[i]);
                    planes.Remove(planes[i]);
                }
            }
            UpdateListBox();
        }

        private void прочитатиЗФайлуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                List<Plane> _new = (List<Plane>)formatter.Deserialize(stream);
                foreach (var i in _new)
                {
                    planes.Add(i);
                }
                listBox1.Items.Clear();
                WarHeader();
                foreach (Plane plane in planes)
                {
                    plane.AddToListBox(listBox1);
                }
            }
        }

    }

    public static class ExtensionClass
    {
        static void AddOne(this Plane plane)
        {
            plane.AddWeight(50);
        }
    }

}