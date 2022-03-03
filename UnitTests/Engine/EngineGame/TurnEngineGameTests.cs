﻿
using NUnit.Framework;

using Game.Engine.EngineGame;
using Game.Models;
using Game.ViewModels;
using System.Linq;

namespace UnitTests.Engine.EngineGame
{
    [TestFixture]
    public class TurnEngineGameTests
    {
        #region TestSetup
        BattleEngine Engine;

        [SetUp]
        public void Setup()
        {
            Engine = new BattleEngine();
            Engine.Round = new RoundEngine();
            Engine.Round.Turn = new TurnEngine();
            //Engine.StartBattle(true);   // Start engine in auto battle mode
        }

        [TearDown]
        public void TearDown()
        {
        }
        #endregion TestSetup

        #region Constructor
        [Test]
        public void TurnEngine_Constructor_Valid_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = Engine;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }
        #endregion Constructor

        #region MoveAsTurn
        [Test]
        public void RoundEngine_MoveAsTurn_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.MoveAsTurn(new PlayerInfoModel());

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void RoundEngine_MoveAsTurn_Valid_Monster_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.MoveAsTurn(new PlayerInfoModel(new MonsterModel()));

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }
        #endregion MoveAsTurn

        #region ApplyDamage
        [Test]
        public void RoundEngine_ApplyDamage_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.ApplyDamage(new PlayerInfoModel(new MonsterModel()));

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }
        #endregion ApplyDamage

        #region Attack
        //[Test]
        //public void RoundEngine_Attack_Valid_Default_Should_Pass()
        //{
        //    // Arrange 

        //    // Act
        //    var result = Engine.Round.Turn.Attack(new PlayerInfoModel());

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(false, result);
        //}
        #endregion Attack

        #region AttackChoice
        //[Test]
        //public void RoundEngine_AttackChoice_Valid_Default_Should_Pass()
        //{
        //    // Arrange 

        //    // Act
        //    var result = Engine.Round.Turn.AttackChoice(new PlayerInfoModel());

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(null, result);
        //}
        #endregion AttackChoice

        #region SelectCharacterToAttack
        //[Test]
        //public void RoundEngine_SelectCharacterToAttack_Valid_Default_Should_Pass()
        //{
        //    // Arrange 

        //    // Act
        //    var result = Engine.Round.Turn.SelectCharacterToAttack();

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(null, result);
        //}
        #endregion SelectCharacterToAttack

        #region UseAbility
        //[Test]
        //public void RoundEngine_UseAbility_Valid_Default_Should_Pass()
        //{
        //    // Arrange 

        //    // Act
        //    var result = Engine.Round.Turn.UseAbility(null);

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(false, result);
        //}
        #endregion UseAbility

        #region BattleSettingsOverrideHitStatusEnum
        //[Test]
        //public void RoundEngine_BattleSettingsOverrideHitStatusEnum_Valid_Default_Should_Pass()
        //{
        //    // Arrange 

        //    // Act
        //    var result = Engine.Round.Turn.BattleSettingsOverrideHitStatusEnum(HitStatusEnum.Unknown);

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(HitStatusEnum.Unknown, result);
        //}
        //#endregion BattleSettingsOverrideHitStatusEnum

        //#region BattleSettingsOverride
        //[Test]
        //public void RoundEngine_BattleSettingsOverride_Valid_Default_Should_Pass()
        //{
        //    // Arrange 

        //    // Act
        //    var result = Engine.Round.Turn.BattleSettingsOverride(new PlayerInfoModel());

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(HitStatusEnum.Unknown, result);
        //}
        #endregion BattleSettingsOverride

        #region CalculateExperience
        //[Test]
        //public void RoundEngine_CalculateExperience_Valid_Default_Should_Pass()
        //{
        //    // Arrange 

        //    // Act
        //    var result = Engine.Round.Turn.CalculateExperience(new PlayerInfoModel(), new PlayerInfoModel());

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(false, result);
        //}
        #endregion CalculateExperience

        #region CalculateAttackStatus
        //[Test]
        //public void RoundEngine_CalculateAttackStatus_Valid_Default_Should_Pass()
        //{
        //    // Arrange 

        //    // Act
        //    var result = Engine.Round.Turn.CalculateAttackStatus(new PlayerInfoModel(), new PlayerInfoModel());

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(HitStatusEnum.Unknown, result);
        //}
        #endregion CalculateAttackStatus

        #region RemoveIfDead
        [Test]
        public void RoundEngine_RemoveIfDead_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.RemoveIfDead(new PlayerInfoModel());

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }
        #endregion RemoveIfDead

        #region ChooseToUseAbility
        [Test]
        public void RoundEngine_ChooseToUseAbility_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.ChooseToUseAbility(new PlayerInfoModel());

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }
        #endregion ChooseToUseAbility

        #region SelectMonsterToAttack
        //[Test]
        //public void RoundEngine_SelectMonsterToAttack_Valid_Default_Should_Pass()
        //{
        //    // Arrange 

        //    // Act
        //    var result = Engine.Round.Turn.SelectMonsterToAttack();

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(null, result);
        //}
        #endregion SelectMonsterToAttack

        #region DetermineActionChoice
        [Test]
        public void TurnEngine_DetermineActionChoice_Valid_Monster_Should_Return_CurrentAction()
        {
            // Arrange
            var MonsterPlayer = new PlayerInfoModel(new MonsterModel());

            MonsterPlayer.CurrentHealth = 1;
            MonsterPlayer.MaxHealth = 1000;

            Engine.EngineSettings.CurrentAction = ActionEnum.Unknown;

            // Act
            var result = Engine.Round.Turn.DetermineActionChoice(MonsterPlayer);

            // Reset

            // Assert
            Assert.AreEqual(ActionEnum.Ability, result);
        }

        [Test]
        public void TurnEngine_DetermineActionChoice_Valid_Character_Should_Return_CurrentAction()
        {
            // Arrange
            var CharacterPlayer = new PlayerInfoModel(new CharacterModel());

            CharacterPlayer.CurrentHealth = 1;
            CharacterPlayer.MaxHealth = 1000;

            Engine.EngineSettings.CurrentAction = ActionEnum.Unknown;
            Engine.EngineSettings.BattleScore.AutoBattle = true;

            // Act
            var result = Engine.Round.Turn.DetermineActionChoice(CharacterPlayer);

            // Reset

            // Assert
            Assert.AreEqual(ActionEnum.Ability, result);
        }

        [Test]
        public void TurnEngine_DetermineActionChoice_Valid_Character_Range_Should_Return_Attack()
        {
            // Arrange

            var CharacterPlayer = new PlayerInfoModel(new CharacterModel());

            // Get the longest range weapon in stock.
            var weapon = ItemIndexViewModel.Instance.Dataset.Where(m => m.Range > 1).ToList().OrderByDescending(m => m.Range).FirstOrDefault();
            CharacterPlayer.PrimaryHand = weapon.Id;
            Engine.EngineSettings.PlayerList.Add(CharacterPlayer);

            var Monster = new MonsterModel();
            Engine.EngineSettings.PlayerList.Add(new PlayerInfoModel(Monster));
            Engine.EngineSettings.PlayerList.Add(new PlayerInfoModel(Monster));

            _ = Engine.EngineSettings.MapModel.PopulateMapModel(Engine.EngineSettings.PlayerList);

            Engine.EngineSettings.CurrentAction = ActionEnum.Unknown;
            Engine.EngineSettings.BattleScore.AutoBattle = true;

            // Act
            var result = Engine.Round.Turn.DetermineActionChoice(CharacterPlayer);

            // Reset

            // Assert
            Assert.AreEqual(ActionEnum.Attack, result);
        }
        #endregion DetermineActionChoice

        #region TurnAsAttack
        //[Test]
        //public void RoundEngine_TurnAsAttack_Valid_Default_Should_Pass()
        //{
        //    // Arrange 

        //    // Act
        //    var result = Engine.Round.Turn.TurnAsAttack(new PlayerInfoModel(), new PlayerInfoModel());

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(false, result);
        //}
        #endregion TurnAsAttack

        #region TargetDied
        //[Test]
        //public void RoundEngine_TargetDied_Valid_Default_Should_Pass()
        //{
        //    // Arrange 

        //    // Act
        //    var result = Engine.Round.Turn.TargetDied(new PlayerInfoModel());

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(false, result);
        //}
        #endregion TargetDied

        #region TakeTurn
        //[Test]
        //public void RoundEngine_TakeTurn_Valid_Default_Should_Pass()
        //{
        //    // Arrange 

        //    // Act
        //    var result = Engine.Round.Turn.TakeTurn(new PlayerInfoModel());

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(false, result);
        //}
        #endregion TakeTurn

        #region RollToHitTarget
        //[Test]
        //public void RoundEngine_RollToHitTarget_Valid_Default_Should_Pass()
        //{
        //    // Arrange 

        //    // Act
        //    var result = Engine.Round.Turn.RollToHitTarget(1,1);

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(HitStatusEnum.Unknown, result);
        //}
        #endregion RollToHitTarget

        #region GetRandomMonsterItemDrops
        //[Test]
        //public void RoundEngine_GetRandomMonsterItemDrops_Valid_Default_Should_Pass()
        //{
        //    // Arrange 

        //    // Act
        //    var result = Engine.Round.Turn.GetRandomMonsterItemDrops(1);

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(null, result);
        //}
        #endregion GetRandomMonsterItemDrops

        #region DetermineCriticalMissProblem
        [Test]
        public void RoundEngine_DetermineCriticalMissProblem_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.DetermineCriticalMissProblem(new PlayerInfoModel());

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }
        #endregion DetermineCriticalMissProblem

        #region DropItems
        //[Test]
        //public void RoundEngine_DropItems_Valid_Default_Should_Pass()
        //{
        //    // Arrange 

        //    // Act
        //    var result = Engine.Round.Turn.DropItems(new PlayerInfoModel());

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(0, result);
        //}
        #endregion DropItems
    }
}