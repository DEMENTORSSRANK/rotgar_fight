using Spine.Unity;
using UnityEngine;

namespace Sources.View.Character
{
    [RequireComponent(typeof(SkeletonAnimation))]
    public class SpineController : MonoBehaviour
    {
        [SerializeField] private BoneContainer _boneContainer;

        [SerializeField] private AnimatorParameters _animatorParameters;

        private SkeletonAnimation _spineAnimation;
        
        public SpineAnimator Animator { get; private set; }

        private void Awake()
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