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
        int ownedSettlements;
        public int OwnedSettlements
        {
            get { return ownedSettlements; }
            set
            {
                if (value + 1 > ownedSettlements)
                    Console.WriteLine("cannot increase beyond 1 at a time.");
                else if (ownedSettlements == 5)
                    Console.WriteLine("cannot exceed 4 cities per player.");
                else
                    ownedSettlements = value;
            }
        }
        int ownedCities = 0;
        public int OwnedCities
        {
            get { return ownedCities; }
            set
            {
                if (value+1 > ownedCities)
                    Console.WriteLine("cannot increase beyond 1 at a time.");
                else if (ownedCities == 4)
                    Console.WriteLine("cannot exceed 4 cities per player.");
                else
                    ownedCities = value;
            }
        }
        int ownedRoads = 0;
        public int OwnedRoads
        {
            get { return ownedRoads; }
            set
            {
                if (value + 1 > ownedRoads)
                    Console.WriteLine("cannot increase beyond 1 at a time.");
                else if (ownedRoads == 15)
                    Console.WriteLine("cannot exceed 4 cities per player.");
                else
                    ownedRoads = value;
            }
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
    }
}
