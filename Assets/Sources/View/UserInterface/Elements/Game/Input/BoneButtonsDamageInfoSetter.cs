using System;
using Sources.Model.Bodies;
using Sources.Model.Players;

namespace Sources.View.UserInterface.Elements.Game.Input
{
    public class BoneButtonsDamageInfoSetter
    {
        private readonly BasePlayer _player;

        private readonly BasePlayer _enemy;

        private readonly ButtonsContainer _container;

        public BoneButtonsDamageInfoSetter(BasePlayer player, BasePlayer enemy, ButtonsContainer container)
        {
            _player = player ?? throw new ArgumentNullException(nameof(player));
            _enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
            _container = container ?? throw new ArgumentNullException(nameof(container));
        }

        public void SetInfo()
        {
            foreach (var partType in BodyPartTypeGenerator.ObligatoryPartTypes)
            {
                _container.GetAttackButtonByType(partType).InfoPanel.SetInfo(partType,
                    _enemy.DamageTaker.CalculatePrevResultDamage(partType, _player.Attacker.Damage));

                _container.GetDefenseButtonByType(partType).InfoPanel.SetInfo(partType,
                    _player.DamageTaker.CalculatePrevResultDamage(partType, _enemy.Attacker.Damage));
            }
        }
    }
}