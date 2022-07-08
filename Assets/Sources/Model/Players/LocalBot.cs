using System;
using System.Threading.Tasks;
using Sources.Model.Bodies;
using Sources.Model.Time;

namespace Sources.Model.Players
{
    public class LocalBot : BasePlayer
    {
        private readonly TimeRange _thinkTime;

        private readonly BodyPartTypeGenerator _typeGenerator;

        public LocalBot(Body body, int startHealth, int damage, TimeRange thinkTime, BodyPartTypeGenerator generator) :
            base(body, startHealth, damage)
        {
            _thinkTime = thinkTime;
            _typeGenerator = generator ?? throw new ArgumentNullException(nameof(generator));
        }

        public override async Task<BodyPartType> ChooseDefense() => await WaitThinkTimeAndGetRandomType();

        public override async Task<BodyPartType> ChooseAttack() => await WaitThinkTimeAndGetRandomType();
        
        private async Task<BodyPartType> WaitThinkTimeAndGetRandomType()
        {
            await Task.Delay(GetRandomThinkTimeInMilliseconds());

            return _typeGenerator.GenerateRandom();
        }
        
        private int GetRandomThinkTimeInMilliseconds()
        {
            return (int) Math.Round(_thinkTime.Random * 1000);
        }
    }
}