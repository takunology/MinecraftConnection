using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftConnection.Fireworks
{
    public class Fireworks : FireworksBase
    {
        public static Fireworks LeargeBallRed = SetLeargeBallRed();
        public static Fireworks LeargeBallBlue = SetLeargeBallBlue();

        private static Fireworks SetLeargeBallRed()
        {
            FlightDuration = 2.ToString();
            Shape = "1";
            IsTrail(true);
            IsFlicker(false);
            ExplosionColors = "11743532";
            FadeColors = "3887386";
            return new Fireworks();
        }

        private static Fireworks SetLeargeBallBlue()
        {

            return new Fireworks();
        }

        public string FireworksCommand(int x, int y, int z, int time, Fireworks fireworks)
        {
            string command;
            PosX = x.ToString();
            PosY = y.ToString();
            PosZ = z.ToString();
            LifeTime = time.ToString();

            command = "/summon firework_rocket " + PosX + " " + PosY + " " + PosZ +
                " {LifeTime:" + LifeTime + ",FireworksItem:{id:firework_rocket,Count:1,tag:{Fireworks:{Flight:" + FlightDuration + 
                ",Explosions:[{Type:" + Shape + ",Flicker:" + Flicker + ",Trail:" + Trail + ",Colors:[I;" + ExplosionColors +
                "],FadeColors:[I;" + FadeColors + "]}]}}}}";

            Console.WriteLine(command);

            return command;
        }

    }
}
