using Sources.Model.Bodies;

namespace Sources.Model.Attack
{
    public interface IReadOnlyPlayerAttacker
    {
        int Damage { get; }
        
        BodyPartType SelectedToAttack { get; }
    }
}