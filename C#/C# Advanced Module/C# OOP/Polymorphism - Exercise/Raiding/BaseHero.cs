using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public abstract class BaseHero
    {
        public BaseHero(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public virtual int Power { get; set; } = 0;
        public virtual string CastAbility()
        {
            return "";
        }
    }
    public class Druid : BaseHero
    {
        public override int Power { get; set; } = 80;
        public Druid(string name) : base(name)
        {
        }
        public override string CastAbility()
        {
            return $"Druid - {this.Name} healed for {this.Power}";
        }
    }
    public class Paladin : BaseHero
    {
        public override int Power { get; set; } = 100;
        public Paladin(string name) : base(name)
        {
        }
        public override string CastAbility()
        {
            return $"Paladin - {this.Name} healed for {this.Power}";
        }
    }
    public class Rogue : BaseHero
    {
        public override int Power { get; set; } = 80;
        public Rogue(string name) : base(name)
        {
        }
        public override string CastAbility()
        {
            return $"Rogue - { this.Name} hit for {this.Power} damage";
        }
    }
    public class Warrior : BaseHero
    {
        public override int Power { get; set; } = 100;
        public Warrior(string name) : base(name)
        {
        }
        public override string CastAbility()
        {
            return $"Warrior - { this.Name} hit for {this.Power} damage";
        }
    }



}
