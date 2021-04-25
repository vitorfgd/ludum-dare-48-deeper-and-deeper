using System;
using System.Collections.Generic;
using UnityEngine;

namespace Collectable
{
    [Serializable]
    public class CollectablesCreationGuide
    {
        public Collectables Collectable;
        public float DistanceBetweenCollectables;
        public AnimationCurve InstanceOverDepth;
    }

    public class CollectablesPlacer : MonoBehaviour
    {
        [SerializeField]
        private float _maxDepth;

        [SerializeField]
        private float _exclusionZone;

        [SerializeField]
        private float _tolerance;

        [SerializeField]
        private Transform _minHorizontalVariation;

        [SerializeField]
        private Transform _maxHorizontalVariation;

        [SerializeField]
        private CollectablesCreationGuide[] _collectablesCreationGuides;

        private void Awake()
        {
            foreach (var guide in _collectablesCreationGuides)
            {
                var depth = _exclusionZone;
                while (depth < _maxDepth)
                {
                    var horizontal = ReturnRandomHorizontal();

                    var normalizedDepth = depth / _maxDepth;
                    depth += guide.DistanceBetweenCollectables - guide.InstanceOverDepth.Evaluate(normalizedDepth);
                    
                    var position = new Vector2(horizontal, depth);
                    var instance = Instantiate(
                        guide.Collectable,
                        position,
                        Quaternion.identity
                    );

                    instance.transform.SetParent(transform);
                }
            }
        }

        private float ReturnRandomHorizontal()
        {
            return UnityEngine.Random.Range(
                _minHorizontalVariation.position.x,
                _maxHorizontalVariation.position.x
            );
        }
    }
}
