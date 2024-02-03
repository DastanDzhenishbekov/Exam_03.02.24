using System;
namespace EXAM_4
{
    public class Age10AndAboveStrategy : ICharacteristicsStrategy
    {
        public void IncreaseCharacteristics(Crocodile crocodile)
        {
            crocodile.HungerLevel += 2;
            crocodile.MoodLevel += 2;
            crocodile.HealthLevel += 2;
            
            crocodile.HungerLevel = Math.Min(crocodile.HungerLevel, Crocodile.MaxSaturation);
            crocodile.MoodLevel = Math.Min(crocodile.MoodLevel, Crocodile.MaxMood);
            crocodile.HealthLevel = Math.Min(crocodile.HealthLevel, Crocodile.MaxHealth);
        }

        public void DecreaseCharacteristics(Crocodile crocodile)
        {
            crocodile.HungerLevel -= 10;
            crocodile.MoodLevel -= 10;
            crocodile.HealthLevel -= 10;
            
            crocodile.HungerLevel = Math.Max(0, crocodile.HungerLevel);
            crocodile.MoodLevel = Math.Max(0, crocodile.MoodLevel);
            crocodile.HealthLevel = Math.Max(0, crocodile.HealthLevel);
        }

        public void ApplyAction(Crocodile crocodile, ActionType actionType)
        {
          
        }
    }
}