using UnityEngine;

namespace Usables
{
    public interface IUsable
    {
        public float Cooldown { get; }
        public void Use(Transform usingObjectTransform = null);
    }
}