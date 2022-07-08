using System;
using System.Threading.Tasks;
using Sources.Model.Bodies;
using Sources.Model.Time;

namespace Sources.Model.Players
{
    public class LocalBot : BasePlayer
    {
        private readonly TimeRange _thinkTime;

        public LocalBot(Body body, int startHealth, int damage, int defenceCapacity, TimeRange thinkTime) : base(body,
            startHealth, damage, defenceCapacity)
        {
            _thinkTime = thinkTime;
        }

        protected override async Task<BodyPartType> ChooseDefense() => await WaitThinkTimeAndGetRandomType();

        protected override async Task<BodyPartType> ChooseAttack() => await WaitThinkTimeAndGetRandomType();

        private async Task<BodyPartType> WaitThinkTimeAndGetRandomType()
        {
            await Task.Delay(GetRandomThinkTimeInMilliseconds());

            TryToGetReadyAsync();
            
            return BodyPartTypeGenerator.GenerateRandom();
        }

        private int GetRandomThinkTimeInMilliseconds()
        {
            return (int) Math.Round(_thinkTime.Random * 1000);
        }

        private async void TryToGetReadyAsync()
        {
            await Task.Delay(GetRandomThinkTimeInMilliseconds());
            
            if (AvailableToReady && !IsReady)
                MakeReady();
        }
    }
}