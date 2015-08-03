using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lore
{
    static class DiceTypes
    {
        public const int RedDice = 0;
        public const int BlueDice = 1;
        public const int YellowDice = 2;
        public const int BrownDice = 3;
        public const int GreyDice = 4;
        public const int BlackDice = 5;
    }


    class Dice
    {
        public Dice()
        {
        }

        public struct BattleDice
        {
            public int damage;
            public int range;
            public int trigger;
            public bool hit;
        }

        public struct CombatDice
        {
            public int damage;
            public int trigger;
            public int range;
        }

        public struct DefenseDice
        {
            public int defense;
        }

        /// <summary>
        /// Rolls one red combat dice.
        /// </summary>
        /// <returns>Result of dice roll (damage, trigger)</returns>
        public CombatDice RollRedDice()
        {
            // Red Dice
            // 1 = 1 Damage
            // 2 = 2 Damage
            // 3 = 2 Damage
            // 4 = 2 Damage
            // 5 = 3 Damage
            // 6 = 3 Damage, 1 Trigger
            CombatDice ret = new CombatDice();
            int diceRoll = DiceRoll();
            if (diceRoll == 1)
                ret.damage = 1;
            else if (diceRoll > 1 && diceRoll < 5)
                ret.damage = 2;
            else if (diceRoll == 5)
                ret.damage = 3;
            else
            {
                ret.damage = 3;
                ret.trigger = 1;
            }
            return ret;
        }

        /// <summary>
        /// Rolls one blue battle dice.
        /// </summary>
        /// <returns>Result of dice roll. (hit, range, damage, trigger)</returns>
        public BattleDice RollBlueDice()
        {
            // Blue Dice
            // 1 = X
            // 2 = 2 Range, 2 Damage, 1 Trigger
            // 3 = 3 Range, 2 Damage
            // 4 = 4 Range, 2 Damage
            // 5 = 5 Range, 1 Damage
            // 6 = 6 Range, 1 Damge, 1 Trigger
            BattleDice ret = new BattleDice();
            int diceRoll = DiceRoll();

            if (diceRoll > 1)
            {
                ret.hit = true;
                ret.range = diceRoll;
            }
            else
            {
                ret.hit = false;
            }

            switch (diceRoll)
            {
                case 1:
                    break;
                case 2:
                    ret.damage = 2;
                    ret.trigger = 1;
                    break;
                case 3:
                    ret.damage = 2;
                    break;
                case 4:
                    ret.damage = 2;
                    break;
                case 5:
                    ret.damage = 1;
                    break;
                case 6:
                    ret.damage = 1;
                    ret.trigger = 1;
                    break;
            }

            return ret;
        }

        /// <summary>
        /// Rolls one yellow combat dice.
        /// </summary>
        /// <returns>Result of dice roll. (range, damage, trigger)</returns>
        public CombatDice RollYellowDice()
        {
            // Yellow Dice
            // 1 = 1 Range, 1 Trigger
            // 2 = 1 Range, 1 Damage
            // 3 = 2 Range, 1 Damage
            // 4 = 1 Damage, 1 Trigger
            // 5 = 2 Damage
            // 6 = 2 Damage, 1 Trigger
            CombatDice ret = new CombatDice();

            switch (DiceRoll())
            {
                case 1:
                    ret.range = 1;
                    ret.trigger = 1;
                    break;
                case 2:
                    ret.range = 1;
                    ret.damage = 1;
                    break;
                case 3:
                    ret.range = 2;
                    ret.damage = 1;
                    break;
                case 4:
                    ret.damage = 1;
                    ret.trigger = 1;
                    break;
                case 5:
                    ret.damage = 2;
                    break;
                case 6:
                    ret.damage = 2;
                    ret.trigger = 1;
                    break;
            }
            return ret;
        }

        public DefenseDice RollBrownDice()
        {
            // Brown Dice
            // 1 = 0 Defense
            // 2 = 0 Defense
            // 3 = 0 Defense
            // 4 = 1 Defense
            // 5 = 1 Defense
            // 6 = 2 Defense
            DefenseDice ret = new DefenseDice();
            int dice = DiceRoll();
            if (dice < 4)
                ret.defense = 0;
            else if (dice == 5)
                ret.defense = 1;
            else
                ret.defense = 2;
            return ret;
        }

        public DefenseDice RollGreyDice()
        {
            // Grey Dice
            // 1 = 0 Defense
            // 2 = 1 Defense
            // 3 = 1 Defense
            // 4 = 1 Defense
            // 5 = 2 Defense
            // 6 = 3 Defense
            DefenseDice ret = new DefenseDice();
            int dice = DiceRoll();
            if (dice == 1)
                ret.defense = 0;
            else if (dice > 1 && dice < 5)
                ret.defense = 1;
            else if (dice == 5)
                ret.defense = 2;
            else
                ret.defense = 3;
            return ret;
        }

        public DefenseDice RollBlackDice()
        {
            // Black Dice
            // 1 = 0 Defense
            // 2 = 2 Defense
            // 3 = 2 Defense
            // 4 = 2 Defense
            // 5 = 3 Defense
            // 6 = 4 Defense
            DefenseDice ret = new DefenseDice();
            int dice = DiceRoll();
            if (dice == 1)
                ret.defense = 0;
            else if (dice > 1 && dice < 5)
                ret.defense = 2;
            else if (dice == 5)
                ret.defense = 3;
            else
                ret.defense = 4;
            return ret;
        }


        public BattleDice RollBattle(int amountRed, int amountYellow)
        {
            BattleDice ret = RollBlueDice(); // Roll blue dice
            CombatDice cb;

            // Roll red dice
            for (int rD = 0; rD < amountRed; rD++)
            {
                cb = RollRedDice();
                ret.damage += cb.damage;
                ret.trigger += cb.trigger;
            }

            // Roll yellow dice
            for (int yD = 0; yD < amountYellow; yD++)
            {
                cb = RollYellowDice();
                ret.damage += cb.damage;
                ret.range += cb.range;
                ret.trigger += cb.trigger;
            }

            return ret;
        }

        public DefenseDice RollDefense(int amountBrown, int amountGrey, int amountBlack)
        {
            DefenseDice ret = new DefenseDice();
            DefenseDice dd;

            // brown dice
            for (int bD = 0; bD < amountBrown; bD++)
            {
                dd = RollBrownDice();
                ret.defense = dd.defense;
            }

            // grey dice
            for (int gD = 0; gD < amountGrey; gD++)
            {
                dd = RollGreyDice();
                ret.defense = dd.defense;
            }

            // black dice
            for (int bD = 0; bD < amountBlack; bD++)
            {
                dd = RollBlackDice();
                ret.defense = dd.defense;
            }
            return ret;
        }

        private int DiceRoll()
        {
            Random r = new Random();
            return r.Next(1, 6);
        }
    }
}
