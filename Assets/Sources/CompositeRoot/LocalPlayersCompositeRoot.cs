using Sources.Data;
using Sources.Model.Players;
using Sources.Model.Time;
using UnityEngine;

namespace Sources.CompositeRoot
{
    public class LocalPlayersCompositeRoot : Base.CompositeRoot
    {
        [SerializeField] private LocalGameParameters _parameters;

        public LocalPlayer Player { get; private set; }

        public LocalBot Enemy { get; private set; }

        public LocalGameParameters Parameters => _parameters;

        public override void Compose()
        {
            Player = new LocalPlayer(_parameters.GenerateBaseBody(), _parameters.Health, _parameters.Damage,
                _parameters.DefenseChooseCapacity);

            Enemy = new LocalBot(_parameters.GenerateBaseBody(), _parameters.Health, _parameters.Damage,
                _parameters.DefenseChooseCapacity,
                new TimeRange(_parameters.MinBotThinkTime, _parameters.MaxBotThinkTime));
        }
    }
}