using UnityEngine;

namespace LavaGame
{
    public interface IDamagable
    {
        void ApplyDamage(Collider hitedCollider, Vector3 hitPoint, Vector3 hitPower);
    }
}