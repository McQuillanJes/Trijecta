using Game.GameRules;

namespace Game.Models
{
    /// <summary>
    /// The Monsters in the Game
    /// 
    /// Derives from BasePlayer Model just like Character
    /// </summary>
    public class MonsterModel : BasePlayerModel<MonsterModel>
    {
        /// <summary>
        /// Set Type to Monster
        /// 
        /// Set Name and Description
        /// </summary>
        public MonsterModel()
        {
            PlayerType = PlayerTypeEnum.Monster;
            Guid = Id;
            Name = "Cate";
            Description = "Purrs and everything";
            Attack = 1;
            Difficulty = DifficultyEnum.Average;
            UniqueItem = null;
            ImageURI = "monster_bodyguard.png";
            HeadshotImageURI = GetHeadshotURI(ImageURI);
            HeadshotGIFURI = GetHeadshotGIFURI(ImageURI);
            ExperienceTotal = 0;
            ExperienceRemaining = LevelTableHelper.LevelDetailsList[Level + 1].Experience - 1;
            MonsterJob = MonsterJobEnum.Unknown;
            

            // Default to unknown, which is no special job
            MonsterJob = MonsterJobEnum.Unknown;
        }

        /// <summary>
        /// Make a copy
        /// </summary>
        /// <param name="data"></param>
        public MonsterModel(MonsterModel data)
        {
            _ = Update(data);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="newData"></param>
        /// <returns></returns>
        public override bool Update(MonsterModel newData)
        {
            if (newData == null)
            {
                return false;
            }

            PlayerType = newData.PlayerType;
            Guid = newData.Guid;
            Name = newData.Name;
            Description = newData.Description;
            Level = newData.Level;
            ImageURI = newData.ImageURI;
            HeadshotImageURI = GetHeadshotURI(newData.ImageURI);
            HeadshotGIFURI = GetHeadshotGIFURI(newData.ImageURI);

            Difficulty = newData.Difficulty;

            Speed = newData.Speed;
            Defense = newData.Defense;
            Attack = newData.Attack;

            ExperienceTotal = newData.ExperienceTotal;
            ExperienceRemaining = newData.ExperienceRemaining;
            CurrentHealth = newData.CurrentHealth;
            MaxHealth = newData.MaxHealth;

            Head = newData.Head;
            Necklass = newData.Necklass;
            PrimaryHand = newData.PrimaryHand;
            OffHand = newData.OffHand;
            RightFinger = newData.RightFinger;
            LeftFinger = newData.LeftFinger;
            Feet = newData.Feet;
            UniqueItem = newData.UniqueItem;

            MonsterJob = newData.MonsterJob;
            return true;
        }

        /// <summary>
        /// Helper to combine the attributes into a single line, to make it easier to display the item as a string
        /// </summary>
        /// <returns></returns>
        public override string FormatOutput()
        {
            var myReturn = Name;
            myReturn += " , " + Description;
            myReturn += " , a " + MonsterJob.ToMessage();
            myReturn += " , Level : " + Level.ToString();
            myReturn += " , Difficulty : " + Difficulty.ToString();
            myReturn += " , Total Experience : " + ExperienceTotal;
            myReturn += " , Items : " + ItemSlotsFormatOutput();
            myReturn += " , Damage : " + GetDamageTotalString;

            return myReturn;
        }

        /// <summary>
        /// Checks if a character is a boss based on their job
        /// </summary>
        /// <param name="monsterJob"></param>
        /// <returns></returns>
        public bool IsMonsterBoss()
        {
            if (MonsterJob == MonsterJobEnum.Mastermind)
            {
                return true;
            }

            if (MonsterJob == MonsterJobEnum.Godfather)
            {
                return true;
            } 

            return false;
                
        }

    }
}