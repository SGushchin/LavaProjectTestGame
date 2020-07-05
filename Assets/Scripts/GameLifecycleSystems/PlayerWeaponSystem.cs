using UnityEngine;

namespace LavaGame
{
    public class PlayerWeaponSystem : MonoBehaviour
    {
        private const int BULLET_SETTINGS_START_INDEX = 0;

        [SerializeField] private BulletStats[] _bulletTypes;
        [Header("Debug private fields")]
        [SerializeField] private string _curentBulletTypeName;

        private IGun _weapon;
        private int _curentBulletIndex = BULLET_SETTINGS_START_INDEX;

        private bool _isArmed;

        private int LastBulletTypesIndex => _bulletTypes.Length - 1;


        private void Awake()
        {
            _isArmed = TryGetComponent<IGun>(out var gun);

            if (_isArmed)
            {
                _weapon = gun;
                SetBulletBySettingsIndex(BULLET_SETTINGS_START_INDEX);
            }
        }

        private void OnEnable()
        {
            EventBus.Shoot.Subscribe(Shoot);
            EventBus.SwitchBulletType.Subscribe(SwitchBullet);
        }


        private void OnDisable()
        {
            EventBus.Shoot.Desubscribe(Shoot);
            EventBus.SwitchBulletType.Desubscribe(SwitchBullet);
        }


        public void Shoot()
        {
            Debug.Log("Trying to make a shoot");

            if (_isArmed)
                _weapon.Fire();
        }


        public void SwitchBullet()
        {
            Debug.Log("Trying to switch a bullet type");
            
            var nextIndex = _curentBulletIndex < LastBulletTypesIndex ? ++_curentBulletIndex : BULLET_SETTINGS_START_INDEX;

            SetBulletBySettingsIndex(nextIndex);
        }


        private void SetBulletBySettingsIndex(int index)
        {
            _curentBulletIndex = index;

            if (!_isArmed) return;

            var newBullet = new SimpleBullet(_bulletTypes[index]);

            _weapon.Reload(newBullet);

            _curentBulletTypeName = _bulletTypes[index].name;

            Debug.Log("<color=green>Bullet type switched successful</color>");
        }
    }
}