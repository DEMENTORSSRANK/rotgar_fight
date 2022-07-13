using Spine.Unity;
using UnityEngine;

namespace Sources.View.Character
{
    [RequireComponent(typeof(SkeletonAnimation))]
    public class SpineController : MonoBehaviour
    {
        [SerializeField] private BoneContainer _boneContainer;

        [SerializeField] private AnimatorParameters _animatorParameters;

        [SerializeField] private VfxHitView _hitView;

        private SkeletonAnimation _spineAnimation;
        
        public SpineAnimator Animator { get; private set; }

        public VfxHitView HitView => _hitView;

        public void Init()
        {
            _spineAnimation = GetComponent<SkeletonAnimation>();
            
            Animator = new SpineAnimator(_spineAnimation, _animatorParameters);
        }

        private void Start()
        {
            Animator.ToIdle();
        }
    }
}