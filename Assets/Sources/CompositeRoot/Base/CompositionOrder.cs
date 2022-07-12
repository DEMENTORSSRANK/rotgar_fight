using UnityEngine;

namespace Sources.CompositeRoot.Base
{
    public class CompositionOrder : MonoBehaviour
    {
        [SerializeField] private CompositeRoot[] _roots;

        private void Awake()
        {
            foreach (var root in _roots)
                root.Compose();
        }

        private void OnEnable()
        {
            foreach (var root in _roots)
                root.Initialize();
        }

        private void OnDisable()
        {
            foreach (var root in _roots)
                root.Dispose();
        }
    }
}