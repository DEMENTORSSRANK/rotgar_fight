using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Model.Bodies;
using UnityEngine;

namespace Sources.View.Character
{
    [Serializable]
    public class BoneContainer
    {
        [SerializeField] private BoneOfPartType[] _bones;

        public IEnumerable<BoneOfPartType> Bones => _bones;
        
        public Transform GetBoneOfPartType(BodyPartType partType) => _bones.First(x => x.PartType == partType).Bone;

        [Serializable]
        public struct BoneOfPartType
        {
            [SerializeField] private Transform _bone;

            [SerializeField] private BodyPartType _partType;

            public Transform Bone => _bone;

            public BodyPartType PartType => _partType;
        }
    }
}