using UnityEngine;

namespace LavaGame
{
    public class SimpleBullet : IBullet
    {
        private const float CAST_DISTANCE = 100.0f;
        
        private BulletStats _bulletStats;


        public SimpleBullet(BulletStats stats)
        {
            _bulletStats = stats;
        }


        public void Launch(Transform launcher)
        {
            if (Physics.Raycast(launcher.position, launcher.forward, out var hitInfo, CAST_DISTANCE))
            {
                if (hitInfo.transform.root.TryGetComponent<IDamagable>(out var damagable))
                {
                    damagable.ApplyDamage(hitInfo.collider, hitInfo.point, _bulletStats.Power * launcher.forward);
                }
            }

            Debug.Log("Bullet launched");
        }
    }
}