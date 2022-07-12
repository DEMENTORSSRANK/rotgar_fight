using System;
using Sources.Model.Bodies;
using Spine.Unity;

namespace Sources.View.Character
{
    public class SpineAnimator
    {
        private readonly SkeletonAnimation _animation;

        private readonly AnimatorParameters _parameters;

        public SpineAnimator(SkeletonAnimation animation, AnimatorParameters parameters)
        {
            _animation = animation ? animation : throw new ArgumentNullException(nameof(animation));
            _parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
        }

        public void Die()
        {
            _animation.AnimationState.SetAnimation(0, _parameters.Die, false);
        }

        public void ToIdle()
        {
            _animation.AnimationState.SetAnimation(0, _parameters.Idle, true);
        }

        public void Block()
        {
            var entry = _animation.AnimationState.SetAnimation(0, _parameters.Block, false);

            entry.Complete += delegate { ToIdle(); };
        }

        public void AttackToBodyPart(BodyPartType partType)
        {
            var entry = _animation.AnimationState.SetAnimation(0, _parameters.GetAttackAnimationToBodyPart(partType),
                false);

            entry.Complete += delegate { ToIdle(); };
        }
    }
}