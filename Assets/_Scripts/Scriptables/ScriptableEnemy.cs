﻿using System;
using Managers;
using UnityEngine;

namespace Scriptables
{
    [UnityEngine.CreateAssetMenu(fileName = "FILENAME", menuName = "MENUNAME", order = 0)]
    public class ScriptableEnemy : UnityEngine.ScriptableObject
    {
        public EnemyType Type;

        [SerializeField] private Stats _stats;
        public Stats BaseStats => _stats;
        
        //public [тип данных] Prefab;
    }

    /// <summary>
    /// Содержит данные о персонаже
    /// </summary>
    [Serializable]
    public struct Stats
    {
        public int Health;
        public int Damage;
        public int TravelDistance;
    }
}