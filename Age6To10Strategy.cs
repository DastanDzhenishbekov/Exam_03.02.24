using System;

namespace EXAM_4
{
    public class Age6To10Strategy : ICharacteristicsStrategy
    {
        public void IncreaseCharacteristics(Crocodile crocodile)
        {
            crocodile.HungerLevel += 5;
            crocodile.MoodLevel += 5;
            crocodile.HealthLevel += 5;
            
            crocodile.HungerLevel = Math.Min(crocodile.HungerLevel, Crocodile.MaxSaturation);
            crocodile.MoodLevel = Math.Min(crocodile.MoodLevel, Crocodile.MaxMood);
            crocodile.HealthLevel = Math.Min(crocodile.HealthLevel, Crocodile.MaxHealth);
        }

        public void DecreaseCharacteristics(Crocodile crocodile)
        {
            crocodile.HungerLevel -= 5;
            crocodile.MoodLevel -= 5;
            crocodile.HealthLevel -= 5;
            
            crocodile.HungerLevel = Math.Max(0, crocodile.HungerLevel);
            crocodile.MoodLevel = Math.Max(0, crocodile.MoodLevel);
            crocodile.HealthLevel = Math.Max(0, crocodile.HealthLevel);
        }

        public void ApplyAction(Crocodile crocodile, ActionType actionType)
        {
            
        }
    }
}