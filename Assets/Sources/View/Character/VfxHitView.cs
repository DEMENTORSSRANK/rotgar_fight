using System;
using System.Linq;
using System.Threading.Tasks;
using Sources.Extensions;
using Sources.Model.Bodies;
using UnityEngine;

namespace Sources.View.Character
{
    [Serializable]
    public class VfxHitView
    {
        [SerializeField] private VfxOfBodyPart[] _vfxOfBody;

        public async void PlayHitOfPartAsync(BodyPartType part)
        {
            var vfxOfBody = _vfxOfBody.First(x => x.Part == part); 
            
            await Task.Delay(vfxOfBody.Delay.ToMilliseconds());
            
            vfxOfBody.Vfx.Play(true);
        }

        [Serializable]
        private struct VfxOfBodyPart
        {
            [SerializeField] private ParticleSystem _vfx;

            [SerializeField] private BodyPartType _part;

            [Min(0)] [SerializeField] private float _delay;

            public ParticleSystem Vfx => _vfx;

            public BodyPartType Part => _part;

            public float Delay => _delay;
        }
    }
}