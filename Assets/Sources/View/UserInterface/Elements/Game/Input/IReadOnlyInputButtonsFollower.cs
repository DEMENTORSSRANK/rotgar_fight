using Sources.Model.Bodies;
using UnityEngine;

namespace Sources.View.UserInterface.Elements.Game.Input
{
    public interface IReadOnlyInputButtonsFollower
    {
        void UpdateTargetForPlayerType(BodyPartType type, Transform target);

        void UpdateTargetForEnemyType(BodyPartType type, Transform target);
    }
}