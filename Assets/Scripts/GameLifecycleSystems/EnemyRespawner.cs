using UnityEngine;

namespace LavaGame
{
    public class EnemyRespawner : MonoBehaviour
    {
        [Header("Debug private fields")]
        [SerializeField] private EnemyLifeSystem _killedEnemy;


        private void OnEnable()
        {
            EventBus.EnemyKilled.Subscribe(EnemyKilledHandler);
            EventBus.RespawnEnemy.Subscribe(Respawn);
        }


        private void OnDisable()
        {
            EventBus.EnemyKilled.Desubscribe(EnemyKilledHandler);
            EventBus.RespawnEnemy.Desubscribe(Respawn);
        }


        private void EnemyKilledHandler(EnemyLifeSystem killedEnemy) =>
            _killedEnemy = killedEnemy;
        
        
        private void Respawn()
        {
            if (_killedEnemy != null)
            {
                _killedEnemy.transform.position = transform.position;
                _killedEnemy.transform.rotation = transform.rotation;

                _killedEnemy.SetActiveRagdollPhysics(false);
                _killedEnemy.SetAlive();

                _killedEnemy = null;
            }
        }
    }
}