using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class Knight : Hero
    {
        public Knight(string username, int level) : base(username, level)
        { 
        }
    }
    public class DarkKnight : Knight
    {
        public DarkKnight(string username, int level) : base(username, level)
        { 
        }
    }public class BladeKnight : DarkKnight
    {
        public BladeKnight(string username, int level) : base(username, level)
        { 
        }
    }

}
