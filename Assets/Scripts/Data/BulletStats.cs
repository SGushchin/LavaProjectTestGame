using UnityEngine;

namespace LavaGame
{
    [CreateAssetMenu(fileName = "New bullet stats", menuName = "Bullet")]
    public class BulletStats : ScriptableObject
    {
        [SerializeField] private float _power;

        public float Power => _power;
    }
}