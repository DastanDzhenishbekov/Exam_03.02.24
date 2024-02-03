using System;

namespace EXAM_4
{
    public class Age0To5Strategy : ICharacteristicsStrategy
    {
        public void IncreaseCharacteristics(Crocodile crocodile)
        {
            crocodile.HungerLevel += 10;
            crocodile.MoodLevel += 10;
            crocodile.HealthLevel += 10;
            
            crocodile.HungerLevel = Math.Min(crocodile.HungerLevel, Crocodile.MaxSaturation);
            crocodile.MoodLevel = Math.Min(crocodile.MoodLevel, Crocodile.MaxMood);
            crocodile.HealthLevel = Math.Min(crocodile.HealthLevel, Crocodile.MaxHealth);
            
        }

        public void DecreaseCharacteristics(Crocodile crocodile)
        {
            crocodile.HungerLevel -= 2;
            crocodile.MoodLevel -= 2;
            crocodile.HealthLevel -= 2;
            
            crocodile.HungerLevel = Math.Max(0, crocodile.HungerLevel);
            crocodile.MoodLevel = Math.Max(0, crocodile.MoodLevel);
            crocodile.HealthLevel = Math.Max(0, crocodile.HealthLevel);
        }

        public void ApplyAction(Crocodile crocodile, ActionType actionType)
        {
            switch (actionType)
            {
                case ActionType.Feed:
                    crocodile.HungerLevel += 15;
                    crocodile.MoodLevel += 10;
                    crocodile.HealthLevel += 5;
                    break;

                case ActionType.Play:
                    crocodile.HungerLevel -= 5;
                    crocodile.MoodLevel += 20;
                    crocodile.HealthLevel -= 5;
                    break;

                case ActionType.Heal:
                    crocodile.HungerLevel -= 5;
                    crocodile.MoodLevel += 5;
                    crocodile.HealthLevel += 15;
                    break;
                

                default:
                    break;
            }
            
            crocodile.HungerLevel = Math.Max(0, crocodile.HungerLevel);
            crocodile.MoodLevel = Math.Max(0, crocodile.MoodLevel);
            crocodile.HealthLevel = Math.Max(0, crocodile.HealthLevel);
        }

    }
}