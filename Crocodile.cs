using System;

namespace EXAM_4
{
    public class Crocodile
    {
        public event EventHandler CrocodileDied;
        public event Action OnMaxSaturation;
        public event Action OnMaxMood;
        public event Action OnMaxHealth;

        public const int MaxSaturation = 100;
        public const int MaxMood = 100;
        public const int MaxHealth = 100;

        private ICharacteristicsStrategy _strategy;

        private int _saturationLevel;
        public int SaturationLevel
        {
            get => _saturationLevel;
            set
            {
                _saturationLevel = value;
                if (_saturationLevel >= MaxSaturation)
                {
                    OnMaxSaturationHandler();
                }
            }
        }

        private int _moodLevel;
        public int MoodLevel
        {
            get => _moodLevel;
            set
            {
                _moodLevel = value;
                if (_moodLevel >= MaxMood)
                {
                    OnMaxMoodHandler();
                }
            }
        }

        private int _healthLevel;
        public int HealthLevel
        {
            get => _healthLevel;
            set
            {
                _healthLevel = value;
                if (_healthLevel >= MaxHealth)
                {
                    OnMaxHealthHandler();
                }
            }
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public int HungerLevel { get; set; }

        public Crocodile(string name, int age)
        {
            Name = name;
            Age = age;
            HungerLevel = MoodLevel = HealthLevel = 10;
            SetAgeStrategy(age);

            OnMaxSaturation += () => Console.WriteLine($"{Name} reached max saturation!");
            OnMaxMood += () => Console.WriteLine($"{Name} reached max mood!");
            OnMaxHealth += () => Console.WriteLine($"{Name} reached max health!");
        }

        private void SetAgeStrategy(int age)
        {
            _strategy = age switch
            {
                >= 0 and <= 5 => new Age0To5Strategy(),
                >= 6 and <= 10 => new Age6To10Strategy(),
                _ => new Age10AndAboveStrategy()
            };
        }

        public void ApplyAction(ActionType actionType)
        {
            SaturationLevel = Math.Min(SaturationLevel, MaxSaturation);
            MoodLevel = Math.Min(MoodLevel, MaxMood);
            HealthLevel = Math.Min(HealthLevel, MaxHealth);
            
            _strategy.ApplyAction(this, actionType);

            Random random = new Random();
            int randomEventChance = random.Next(0, 300);

            if (actionType == ActionType.Feed)
            {
                if (randomEventChance < 10)
                {
                    HealthLevel -= 30;
                    MoodLevel -= 20;
                    Console.WriteLine($"{Name} poisoned!");
                }
                else if (randomEventChance < 20)
                {
                    MoodLevel += 20;
                    Console.WriteLine($"{Name} in a good mood after the meal");
                }
            }
            else if (actionType == ActionType.Play)
            {
                if (randomEventChance < 10)
                {
                    HealthLevel -= 20;
                    MoodLevel -= 30;
                    Console.WriteLine($"{Name} injured its arm!");
                }
                else if (randomEventChance < 20)
                {
                    MoodLevel += 20;
                    Console.WriteLine($"{Name} found a rat, caught it, and is happy!");
                }
            }
            else if (actionType == ActionType.Heal)
            {
                if (randomEventChance < 10)
                {
                    HealthLevel -= 40;
                    MoodLevel -= 20;
                    Console.WriteLine($"{Name} you gave the wrong medicine! {Name} feels horrible!");
                }
                else if (randomEventChance < 20)
                {
                    HealthLevel += 20;
                    Console.WriteLine($"{Name} feels much healthier, good job!");
                }
            }
            CheckIfCrocodileDied();
        }


        public bool IsAlive()
        {
            return HealthLevel > 0 && MoodLevel > 0;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"{Name}, Age: {Age}, Hunger level: {HungerLevel}, Mood level: {MoodLevel}, " +
                              $"Health level: {HealthLevel}");
        }

        private void CheckIfCrocodileDied()
        {
            if (HealthLevel <= 0)
            {
                Console.WriteLine($"{Name} умер!");
                CrocodileDied?.Invoke(this, EventArgs.Empty);
            }
            else if (MoodLevel <= 0)
            {
                Console.WriteLine($"{Name} is furious, {Name} has eaten you :(");
            }
        }

        private void OnMaxSaturationHandler()
        {
            SaturationLevel = MaxSaturation;
            OnMaxSaturation?.Invoke();
        }

        private void OnMaxMoodHandler()
        {
            MoodLevel = MaxMood;
            OnMaxMood?.Invoke();
        }

        private void OnMaxHealthHandler()
        {
            HealthLevel = MaxHealth;
            OnMaxHealth?.Invoke();
        }
    }
}

public enum ActionType
{
    Feed,
    Play,
    Heal
}
