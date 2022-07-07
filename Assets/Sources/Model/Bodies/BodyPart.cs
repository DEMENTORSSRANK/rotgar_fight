namespace Sources.Model.Bodies
{
    public class BodyPart
    {
        public BodyPartType Type { get; }

        public BodyPart(BodyPartType type)
        {
            Type = type;
        }
    }
}