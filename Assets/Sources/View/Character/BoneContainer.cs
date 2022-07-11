using System;
using System.Linq;
using Sources.Model.Bodies;
using UnityEngine;

namespace Sources.View.Character
{
    public class BoneContainer : MonoBehaviour
    {
        [SerializeField] private BoneOfPartType[] _bones;

        public Transform GetBoneOfPartType(BodyPartType partType) => _bones.First(x => x.PartType == partType).Bone;

        [Serializable]
        private struct BoneOfPartType
        {
            [SerializeField] private Transform _bone;

            [SerializeField] private BodyPartType _partType;

            public Transform Bone => _bone;

            public BodyPartType PartType => _partType;
        }
    }
}