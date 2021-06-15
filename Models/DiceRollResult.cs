using System;
using System.Collections.Generic;

namespace Dice.API
{
    public class DiceRollResult
    {
        public int sumOfRolls { get; set; }
        public List<int> actualRolls { get; set; }
    }
}