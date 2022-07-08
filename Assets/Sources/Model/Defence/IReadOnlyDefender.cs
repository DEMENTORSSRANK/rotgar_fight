using Sources.Model.Bodies;

namespace Sources.Model.Defence
{
    public interface IReadOnlyDefender
    {
        int DefencedPartsCount { get; }

        void DefencePart(BodyPartType partType);

        void ClearAllDefence();
    }
}