using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sources.Model.Bodies;

namespace Sources.Model.Players.ReadyControl.Choose
{
    public abstract class BodyPartSelector : ReadyHandler
    {
        protected readonly Body Body;
        
        private readonly BodyPartTypeGenerator _typeGenerator;
        
        public override bool IsReady => Count >= _capacity;

        private readonly int _capacity;
        
        private readonly Queue<BodyPartType> _chosen = new Queue<BodyPartType>();

        public IEnumerable<BodyPartType> Chosen => _chosen;

        public int Count => _chosen.Count;

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
            if (_chosen.Contains(partType))
                throw new InvalidOperationException($"{partType.ToString()} is already defenced");

            _chosen.Enqueue(partType);

            ValidateCapacity();
        }

        public void ClearAll()
        {
            _chosen.Clear();
        }
        
        private void ValidateCapacity()
        {
            while (_chosen.Count > _capacity)
            {
                _chosen.Dequeue();
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