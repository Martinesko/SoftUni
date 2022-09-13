using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class Wizard : Hero
    {
        public Wizard(string username , int level) : base(username , level)
        {
        }
    }
    public class DarkWizard : Wizard
    {
        public DarkWizard(string username , int level): base(username , level)
        {
        }
    }
    public class SoulMaster: DarkWizard
    {
        public SoulMaster(string username , int level): base(username , level)
        {
        }
    }

}
