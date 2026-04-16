using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge3
{
    public class MobilePhone
    {
        public delegate void RingEventHandler();
        public event RingEventHandler OnRing;
        public void ReceiveCall()
        {
            Console.WriteLine("Incoming call detected...\n");
            OnRing?.Invoke();
        }
    }

    public class RingtonePlayer
    {
        public void Play()
        {
            Console.WriteLine("Playing ringtone...");
        }
    }

    public class ScreenDisplay
    {
        public void Show()
        {
            Console.WriteLine("Displaying caller information...");
        }
    }

    public class VibrationMotor
    {
        public void Vibrate()
        {
            Console.WriteLine("Phone is vibrating...");
        }
    }

    internal class Program3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===============Program3===============");
            MobilePhone phone = new MobilePhone();

            RingtonePlayer ringtone = new RingtonePlayer();
            ScreenDisplay screen = new ScreenDisplay();
            VibrationMotor vibration = new VibrationMotor();

            phone.OnRing += ringtone.Play;
            phone.OnRing += screen.Show;
            phone.OnRing += vibration.Vibrate;

            phone.ReceiveCall();

        }

    }
}
