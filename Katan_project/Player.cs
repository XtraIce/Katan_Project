using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katan_project
{
    public class Player
    {
        int playerNumber;
        public int PlayerNumber
        {
            get { return playerNumber; }
        }
        public BResource SheepHeld;
        public BResource WoodHeld;
        public BResource BrickHeld;
        public BResource GrainHeld;
        public BResource OreHeld;

        public Player(int PlayerNum)
        {
            playerNumber = PlayerNum;
            SheepHeld.Value = 0;SheepHeld.Type = "Sheep";
            WoodHeld.Value = 0; SheepHeld.Type = "Wood";
            BrickHeld.Value = 0; SheepHeld.Type = "Brick";
            GrainHeld.Value = 0; SheepHeld.Type = "Grain";
            OreHeld.Value = 0; SheepHeld.Type = "Ore";
        }

        public void PlaceSettlement()
        {

        }
    }
}
