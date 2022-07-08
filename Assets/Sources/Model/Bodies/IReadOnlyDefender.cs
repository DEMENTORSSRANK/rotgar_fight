namespace Sources.Model.Bodies
{
    public interface IReadOnlyDefender
    {
        int DefencedPartsCount { get; }

        void DefencePart(BodyPartType partType);

        void ClearAllDefence();
    }
}