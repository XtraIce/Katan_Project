using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katan_project
{
    public class Player
    {
        string playerName;
        public string PlayerName
        {
            get { return playerName; }
        }

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

        public BResource SheepHeld = new BResource("Sheep",0);
        public BResource WoodHeld = new BResource("Wood",0);
        public BResource BrickHeld = new BResource("Brick", 0);
        public BResource GrainHeld = new BResource("Grain", 0);
        public BResource OreHeld = new BResource("Ore", 0);

        public Player(string PlayerName,int PlayerNum)
        {
            playerName = PlayerName;
            playerNumber = PlayerNum;
        }
    }
}
