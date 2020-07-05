using System.Collections.Generic;
using UnityEngine;
using Helpers.EventBus;

namespace LavaGame
{
    public class EventBus
    {
        static EventBus()
        {
            LeftMouseButtonClick = new BusEvent<Vector3>();
            Shoot = new BusEvent();
            SwitchBulletType = new BusEvent();
            EnemyKilled = new BusEvent<EnemyLifeSystem>();
            RespawnEnemy = new BusEvent();
        }

        public static BusEvent<Vector3> LeftMouseButtonClick { get; }
        public static BusEvent Shoot { get; }
        public static BusEvent SwitchBulletType { get; }
        public static BusEvent<EnemyLifeSystem> EnemyKilled { get; }
        public static BusEvent RespawnEnemy { get; }
    }
}