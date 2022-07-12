using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sources.Model.Bodies;

namespace Sources.Model.Players.ReadyControl.Choose
{
    public abstract class BodyPartSelector : ReadyHandler
    {
        private readonly BodyPartTypeGenerator _typeGenerator;
        
        protected readonly Body Body;
        
        public override bool IsReady => Count >= _capacity;

        private readonly int _capacity;
        
        private readonly List<BodyPartType> _chosen = new List<BodyPartType>();

        public IEnumerable<BodyPartType> Chosen => _chosen;

        public int Count => _chosen.Count;
        
        public event Action<BodyPartType> OnSelected;

        public event Action<BodyPartType> OnUnSelected;

        protected BodyPartSelector(Body body, int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));
            
            Body = body ?? throw new ArgumentNullException(nameof(body));
            _typeGenerator = new BodyPartTypeGenerator();
            _capacity = capacity;
        }

        public abstract Task<BodyPartType> ChoosePart();
        
        public bool Contains(BodyPartType partType) => _chosen.Contains(partType);

        public void SelectNew(BodyPartType partType)
        {
            if (Contains(partType))
                throw new InvalidOperationException($"{partType.ToString()} is already defenced");

            _chosen.Add(partType);

            ValidateCapacity();
            
            OnSelected?.Invoke(partType);
        }

        public void Unselect(BodyPartType partType)
        {
            if (!Contains(partType))
                throw new InvalidOperationException($"{partType} doesn't contains");

            _chosen.Remove(partType);
            
            OnUnSelected?.Invoke(partType);
        }

        public void ClearAll()
        {
            while (_chosen.Count > 0)
            {
                Unselect(_chosen[0]);
            }
        }
        
        private void ValidateCapacity()
        {
            while (_chosen.Count > _capacity)
            {
                Unselect(_chosen[0]);
            }
        }

        protected override void OnPushingToReady()
        {
            while (!IsReady)
            {
                SelectNew(_typeGenerator.GenerateRandom(_chosen.ToArray()));
            }
        }
    }
}