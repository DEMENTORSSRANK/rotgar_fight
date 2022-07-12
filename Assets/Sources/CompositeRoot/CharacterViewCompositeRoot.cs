using Sources.View.Character;
using UnityEngine;

namespace Sources.CompositeRoot
{
    public class CharacterViewCompositeRoot : Base.CompositeRoot
    {
        [SerializeField] private BoneContainer _playerContainer;

        [SerializeField] private BoneContainer _enemyContainer;

        public BoneContainer PlayerContainer => _playerContainer;

        public BoneContainer EnemyContainer => _enemyContainer;

        public override void Compose()
        {
            
        }
    }
}