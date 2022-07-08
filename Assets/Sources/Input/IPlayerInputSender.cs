using System;
using Sources.Model.Bodies;

namespace Sources.Input
{
    public interface IPlayerInputSender
    {
        event Action<BodyPartType> OnAttackChosen;

        event Action<BodyPartType> OnDefenseChosen;

        event Action OnGetReady;
    }
}