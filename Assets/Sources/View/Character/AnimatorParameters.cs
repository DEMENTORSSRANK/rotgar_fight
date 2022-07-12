using System;
using System.Linq;
using Sources.Model.Bodies;
using Spine.Unity;
using UnityEngine;

namespace Sources.View.Character
{
    [Serializable]
    public class AnimatorParameters
    {
        [SerializeField] private AttackAnimation[] _attackAnimations;

        [SerializeField] private AnimationReferenceAsset _die;

        [SerializeField] private AnimationReferenceAsset _block;

        [SerializeField] private AnimationReferenceAsset _idle;
        
        public AnimationReferenceAsset Die => _die;

        public AnimationReferenceAsset Block => _block;

        public AnimationReferenceAsset Idle => _idle;

        public AnimationReferenceAsset GetAttackAnimationToBodyPart(BodyPartType bodyPart) =>
            _attackAnimations.First(x => x.ToPart == bodyPart).Animation;

        [Serializable]
        private struct AttackAnimation
        {
            [SerializeField] private AnimationReferenceAsset _animation;

            [SerializeField] private BodyPartType _toPart;

            public AnimationReferenceAsset Animation => _animation;

            public BodyPartType ToPart => _toPart;
        }
    }
}