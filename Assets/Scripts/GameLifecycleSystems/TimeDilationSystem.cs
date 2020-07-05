using System.Collections;
using UnityEngine;

namespace LavaGame
{
    public class TimeDilationSystem : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField, Range(0.0f, 1.0f)] private float _scaleValue = 0.5f;
        [SerializeField] private float _duration = 1.5f;
        [SerializeField] private bool _coroutineIsStarted = false;

        private void OnEnable() =>
            EventBus.EnemyKilled.Subscribe(EnemyKilledHandler);


        private void OnDisable() =>
            EventBus.EnemyKilled.Desubscribe(EnemyKilledHandler);


        private void EnemyKilledHandler(EnemyLifeSystem _)
        {
            if (!_coroutineIsStarted)
                StartCoroutine(ApplyDilation());
        }
        
        
        private IEnumerator ApplyDilation()
        {
            _coroutineIsStarted = true;

            var startFixedDeltaTime = Time.fixedDeltaTime;
            var startTimeScale = Time.timeScale;

            Time.timeScale = _scaleValue;
            Time.fixedDeltaTime = startFixedDeltaTime * Time.timeScale;

            yield return new WaitForSecondsRealtime(_duration);

            Time.timeScale = startTimeScale;
            Time.fixedDeltaTime = startFixedDeltaTime;

            _coroutineIsStarted = false;
        }
    }
}