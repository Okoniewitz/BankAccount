using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA;
using System.IO;
using System.Windows.Forms;

namespace BankAccount
{
    public static class Helpers
    {
        public static bool debug = true;
        public static Player Player = Game.LocalPlayer;
        public static void Cheats()
        {
            if (Game.isKeyPressed(Keys.L))
            {
               Game.DisplayText(GetNearestObject(0).Model.ToString(),5000);
            }
        }

        public static GTA.Object GetNearestObject(Model model)
        {
            GTA.Object[] AllObjects;
            if (model!=0)
            {
                AllObjects = World.GetAllObjects(model);
            }
            else AllObjects = World.GetAllObjects();

            float Dist = 999999f;
            GTA.Object FinalObject=null;
            foreach(GTA.Object obj in AllObjects)
            {
                if(obj.Position.DistanceTo(Player.Character.Position)<Dist)
                {
                    Dist = obj.Position.DistanceTo(Player.Character.Position);
                    FinalObject = obj;
                }
            }
            return FinalObject;
        }
    }
}
