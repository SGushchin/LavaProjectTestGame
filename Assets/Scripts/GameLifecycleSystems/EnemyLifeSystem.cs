using UnityEngine;

namespace LavaGame
{
    public class EnemyLifeSystem : MonoBehaviour, IDamagable
    {
        [Header("Editor ragdoll physics switcher")]
        [ContextMenuItem("Switch enabled state", nameof(SwitchRagdollPhysicsStatus))]
        [SerializeField]private bool _isRagdoll;
        [Header("Debug private fields")]
        [SerializeField] private Animator _enemyAnimator;
        [SerializeField] private Rigidbody[] _bonesRigidbodies;
        [SerializeField] private bool _isAlive;

        
        private void Awake()
        {
            _enemyAnimator = GetComponent<Animator>();
            _bonesRigidbodies = GetComponentsInChildren<Rigidbody>(true);

            _isAlive = true;

            _isRagdoll = false;
            SetActiveRagdollPhysics(_isRagdoll);
        }

        private void SwitchRagdollPhysicsStatus()
        {
            _isRagdoll = !_isRagdoll;
            SetActiveRagdollPhysics(_isRagdoll);
        }

        public void SetActiveRagdollPhysics(bool value)
        {
            _enemyAnimator.enabled = !value;

            foreach (var boneRigidbody in _bonesRigidbodies)
            {
                boneRigidbody.isKinematic = !value;
                boneRigidbody.useGravity = value;
            }
        }

        public void ApplyDamage(Collider hitedCollider, Vector3 hitPoint, Vector3 hitPower)
        {
            SetActiveRagdollPhysics(true);

            hitedCollider.attachedRigidbody.AddForce(hitPower, ForceMode.Impulse);

            if (_isAlive)
            {
                EventBus.EnemyKilled.Publish(this);
                _isAlive = false;
            }
        }

        public void SetAlive()
        {
            _isAlive = true;
        }
    }
}