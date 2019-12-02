using System;
using System.Collections.Generic;

namespace CompositePattern
{

    enum Rank
    {
        General,
        Colonel,
        LieutenantColonel,
        Major,
        Captain,
        Lieutenant
    }

    abstract class Soldier
    {
        protected string _name;
        protected Rank _rank;

        public Soldier(string name, Rank rank)
        {
            _name = name;
            _rank = rank;
        }

        public abstract void AddSoldier(Soldier soldier);
        public abstract void RemoveSoldier(Soldier soldier);
        public abstract void ExecuteOrder(); 
    }

    class PrimitiveSoldier
     : Soldier
    {
        public PrimitiveSoldier(string name, Rank rank)
         : base(name, rank)
        {

        }
        public override void AddSoldier(Soldier soldier)
        {
            throw new NotImplementedException();
        }
        public override void RemoveSoldier(Soldier soldier)
        {
            throw new NotImplementedException();
        }

        public override void ExecuteOrder()
        {
            Console.WriteLine(String.Format("{0} {1}", _rank, _name));
        }
    }

    class CompositeSoldier
     : Soldier
    {
        private List<Soldier> _soldiers = new List<Soldier>();

        public CompositeSoldier(string name, Rank rank)
         : base(name, rank)
        {

        }

        public override void AddSoldier(Soldier soldier)
        {
            _soldiers.Add(soldier);
        }
        public override void RemoveSoldier(Soldier soldier)
        {
            _soldiers.Remove(soldier);
        }
        public override void ExecuteOrder()
        {
            Console.WriteLine(String.Format("{0} {1}", _rank, _name));
            foreach (Soldier soldier in _soldiers)
            {
                soldier.ExecuteOrder();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CompositeSoldier general = new CompositeSoldier("Tom", Rank.General);

            general.AddSoldier(new PrimitiveSoldier("Tom", Rank.Colonel));
            general.AddSoldier(new PrimitiveSoldier("John", Rank.Colonel));

            CompositeSoldier colonelNevi = new CompositeSoldier("Nevi", Rank.Colonel);
            CompositeSoldier lieutenantColonelZing = new CompositeSoldier("Zing", Rank.LieutenantColonel);

            lieutenantColonelZing.AddSoldier(new PrimitiveSoldier("Tomasson", Rank.Captain));
            colonelNevi.AddSoldier(lieutenantColonelZing);
            colonelNevi.AddSoldier(new PrimitiveSoldier("Liam", Rank.LieutenantColonel));
            general.AddSoldier(colonelNevi);

            general.AddSoldier(new PrimitiveSoldier("Alvin", Rank.Colonel));

            general.ExecuteOrder();

            Console.ReadLine();
        }
    }
}