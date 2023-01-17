using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.DirectInput;

namespace PadPadPad
{
    class PadKierownica
    {
        public static string wskazanieManipulatora = "";
        public static Guid joystickGuid = Guid.Empty;


        public Joystick wyszukajManipulator()
        {
            string czyWyszukanoManipulator = "T";
            try
            {
                var directInput = new DirectInput();

                foreach (var deviceInstance in directInput.GetDevices(DeviceType.Gamepad, DeviceEnumerationFlags.AllDevices))
                    joystickGuid = deviceInstance.InstanceGuid;
                if (joystickGuid == Guid.Empty)
                    foreach (var deviceInstance in directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices))
                        joystickGuid = deviceInstance.InstanceGuid;
                if (joystickGuid == Guid.Empty)
                {
                    czyWyszukanoManipulator = "N";
                }

                //dodatkowe info o rodzaju manipulatora
                var joystick = new Joystick(directInput, joystickGuid);
                var allEffects = joystick.GetEffects();
                return joystick;

            }
            catch
            {
                return null;
            };
        }

        public void obslugaZdarzenManipulatora(Joystick joy)//dla konsoli
        {

            joy.Properties.BufferSize = 128;

            joy.Acquire();

            while (true)
            {

                joy.Poll();
                var datas = joy.GetBufferedData();
                foreach (var state in datas)

                    wskazanieManipulatora = (state.Offset + "_" + state.Value);

            }

        }
    }
}
