using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA;
using GTA.Native;

namespace BankAccount
{
    public class Main : Script
    {
        public Main()
        {
            Tick += EachTick.OnTick;
        }
    }

    public static class EachTick
    {
        public static Player Player = Game.LocalPlayer;
        public static List<GTA.Object> ATMList = new List<GTA.Object>();
        public static void OnTick(object sender, EventArgs e)
        {
            if (Helpers.debug) Helpers.Cheats();
            GTA.Object[] ATMs = World.GetAllObjects(Model.FromString("0x6223E19A"));
            foreach(GTA.Object ATM in ATMs) //mark atms on map
            {
                if(!ATMList.Contains(ATM))
                {
                    Blip blip = ATM.AttachBlip();
                    blip.Color = BlipColor.Purple;
                    blip.ShowOnlyWhenNear = true;
                    ATMList.Add(ATM);
                }
            }
            if(Player.Character.Position.DistanceTo(Helpers.GetNearestObject(Model.FromString("0x6223E19A")).Position)<=2)
            {
                Game.DisplayText("using atm");
            }
        }
    }
}
