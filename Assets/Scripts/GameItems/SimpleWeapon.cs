using UnityEngine;

namespace LavaGame
{
    public class SimpleWeapon : MonoBehaviour, IGun
    {
        [SerializeField] private Transform _endOfBarrelWeapon;

        private IBullet _bullet;
        

        public void Fire()
        {
            _bullet.Launch(_endOfBarrelWeapon);
        }


        public void Reload(IBullet bullet)
        {
            _bullet = bullet;
        }
    }
}