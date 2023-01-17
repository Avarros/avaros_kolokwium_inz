using SharpDX.DirectInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PadPadPad
{
    public partial class Form1 : Form
    {
        PadKierownica padKierownica = new PadKierownica();
        public Form1()
        {
            InitializeComponent();
        }
        void manipulatorStart()
        {
            Joystick joystick = padKierownica.wyszukajManipulator();
            padKierownica.obslugaZdarzenManipulatora(joystick);
        }

        private void buttonPolacz_Click(object sender, EventArgs e)
        {
            timerJoy.Enabled = true;
            Joystick joystick = padKierownica.wyszukajManipulator();
            textBox1.Text = PadKierownica.joystickGuid.ToString();
            Thread thread = new Thread(manipulatorStart);
            thread.Start();
        }

        private void timerJoy_Tick(object sender, EventArgs e)
        {
            textBoxManipulatora.Text = PadKierownica.wskazanieManipulatora;
        }

        void ustawLicznik()
        {
            int gdzie_ = textBoxManipulatora.Text.IndexOf("_");
            int dlugosc = textBoxManipulatora.Text.Length;
            string przycisk = textBoxManipulatora.Text.Remove(gdzie_);
            string wartosc = textBoxManipulatora.Text.Replace(przycisk + "_", "");

            if (przycisk == "X")
            {
                lbAnalogMeter1.Value = int.Parse(wartosc);
            }
        }

        private void textBoxManipulatora_TextChanged(object sender, EventArgs e)
        {
            int gdzie_ = textBoxManipulatora.Text.IndexOf("_");
            int dlugosc = textBoxManipulatora.Text.Length;
            string przycisk = textBoxManipulatora.Text.Remove(gdzie_);
            string wartosc = textBoxManipulatora.Text.Replace(przycisk + "_", "");
            textBoxA.Text = przycisk;
            textBoxB.Text = wartosc;
            ustawLicznik();
        }
    }
}
