using System;
using System.Collections.Generic;

namespace diceGenerator
{
    class MainClass
    {
        // creating a random number class
        public static class DiceRoll
        {
            private static Random random;

            private static void Init()
            {
                if (random == null) random = new Random();
            }

            public static int Random(int min, int max)
            {
                Init();
                return random.Next(min, max);
            }
        }


        // attack method
        public static int attackRoll()
        {
            // int attack = DiceRoll.Random(1,7) + DiceRoll.Random(1,7);
            int res1 = DiceRoll.Random(1, 7);
            int res2 = DiceRoll.Random(1, 7);
            int attack = res1 + res2;
            Console.WriteLine(" dice rolls attack : {0}, {1} = sum {2}", res1, res2, attack);
            return attack;
        }


        // Combat  method
        public static  int Combat(Human p1, Human p2)
        {
            int ArmourPierce = DiceRoll.Random(1, 21);

            if (ArmourPierce > p2.Strength)
            {
                Console.WriteLine("Armour Pierce: {0}", ArmourPierce);
                int attack = attackRoll();
                return attack;

            }
            else
            {
                Console.WriteLine("**********************  fails!  {0} ************************************", ArmourPierce);
                return 0;

            }


        }


        // clase humano
        public class Human
        {
            public string Name { get; set; }
            public int Hp { get; set; }
            public int Strength { get; set; }
            public int Dexterity { get; set; }
            public int Constitution { get; set; }
            public int Intelligence { get; set; }
            public int Wisdom { get; set; }
            public int Charisma { get; set; }

            // modifiers:
            // (ability -10) / 2

            public int ModStre { get; set; }
            public int ModDex { get; set; }
            public int ModCons { get; set; }
            public int ModInt { get; set; }
            public int ModWis { get; set; }
            public int ModChar { get; set; }


            // initializers
            public Human(string name, int hp, int st, int dex, int cons, int inte, int wis, int cha)
            {
                Name = name;
                Hp = hp;
                Strength = st;
                Dexterity = dex;
                Constitution = cons;
                Intelligence = inte;
                Wisdom = wis;
                Charisma = cha;
                SetMod();

            }

            public Human()
            {
                SetAbilities();

            }



            // methods
            static private int RandomAbility()
            {
                // usando la clase InUtil creada
                int randomNumber = DiceRoll.Random(1, 21);
                // usando metodo random distinto
                var random = new Random((int)DateTime.Now.Ticks);
                var randomValue = random.Next(1, 21 + 1);

                return randomNumber;


            }

            public void SetAbilities()
            {

                this.Strength = RandomAbility();
                this.Dexterity = RandomAbility();
                this.Constitution = RandomAbility();
                this.Intelligence = RandomAbility();
                this.Wisdom = RandomAbility();
                this.Charisma = RandomAbility();
                SetMod();


            }

            public int ModCalculator(int ability)
            {
                double res = (double)(ability - 10) / 2.0;
                return (int)res;
            }

            private void SetMod()
            {
                this.ModStre = ModCalculator(Strength);
                this.ModDex = ModCalculator(Dexterity);
                this.ModCons = ModCalculator(Constitution);
                this.ModInt = ModCalculator(Intelligence);
                this.ModWis = ModCalculator(Wisdom);
                this.ModChar = ModCalculator(Charisma);
            }

            public void PrintHuman()
            {
                string humanClass = String.Format("\nName :{0}\nhp :{1}\nStrength :{2}---->Mod {7}\nDexterity :{3}---->Mod {8}\nConstitution :{4} ---->Mod {9}\nIntelligence :{5} ---->Mod {10}\nWisdom :{6} ---->Mod {11}", Name, Hp, Strength, Dexterity, Constitution, Intelligence, Wisdom, ModStre, ModDex, ModCons, ModInt, ModWis);
                Console.WriteLine(humanClass);
            }


        }



        /*
        public int D20()
        {
            int roll = DiceRoll.Random(1, 21);
            return roll;

        }

        public int D6()
        {
            int roll = DiceRoll.Random(1, 7);
            return roll;

        }

        public int D4()
        {
            int roll = DiceRoll.Random(1, 5);
            return roll;

        }

*/
 


        public static void Main(string[] args)
        {
            Human G = new Human();
            Human G1 = new Human("J", 100, 10, 8, 15, 9, 7, 15);
            G.PrintHuman();
            G1.PrintHuman();
            Combat(G,G1);

            string s = "";
            do
            {
                Combat(G, G1);
                Console.WriteLine("more");
                s = Console.ReadLine();

            } while (s != "n");

        }
    }
}
