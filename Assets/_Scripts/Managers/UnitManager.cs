using System;
using UnityEngine;
using Utilities;

namespace Managers
{
    public class UnitManager : Singleton<UnitManager>
    {
        private void SpawnUnit(EnemyType enemyType, Vector3 position)
        {
        }
    }

    [Serializable]
    public enum EnemyType
    {
        Slime,
        Berserk,
        Warrior,
        Archer,
        Magitian
    }
}

