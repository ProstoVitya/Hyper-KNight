using UnityEngine;

namespace Usables
{
    public interface IUsable
    {
        public float Delay { get; }
        public void Use(Transform usingObjectTransform = null);
    }
}