using System;
using System.Linq;
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

        public override async Task<BodyPartType> ChooseDefense()
        {
            await Task.Delay(GetRandomThinkTimeInMilliseconds());

            TryToGetReadyAsync();

            var result = BodyPartTypeGenerator.GenerateRandom(Defender.Chosen.ToArray());

            return result;
        }

        public override async Task<BodyPartType> ChooseAttack()
        {
            await Task.Delay(GetRandomThinkTimeInMilliseconds());

            TryToGetReadyAsync();
            
            return BodyPartTypeGenerator.GenerateRandom(Attacker.Chosen.ToArray());
        }

        private int GetRandomThinkTimeInMilliseconds()
        {
            return (int) Math.Round(_thinkTime.Random * 1000);
        }

        private async void TryToGetReadyAsync()
        {
            await Task.Delay(GetRandomThinkTimeInMilliseconds());
            
            if (Readiness.AvailableToReady && !Readiness.IsReady)
                Readiness.MakeReady();
        }
    }
}