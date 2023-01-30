using System;
using UnityEngine;
using Utilities;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        public static event Action<GameState> OnBeforeStateChanged;
        public static event Action<GameState> OnAfterStateChanged;
        
        public GameState GameState { get; private set; }
        
        private void Start() => ChangeState(GameState.Starting);

        private void ChangeState(GameState newState)
        {
            OnBeforeStateChanged?.Invoke(newState);
            GameState = newState;
            
            switch (newState)
            {
                case GameState.Starting:
                    HandleStarting();
                    break;
                case GameState.SpawningEnemies:
                    HandleSpawningEnemies();
                    break;
                case GameState.Fighting:
                    HandleFighting();
                    break;
                case GameState.Lose:
                    HandleLose();
                    break;
                case GameState.NextRoomChoosing:
                    HangleNextRoomChoosing();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
            }
            OnAfterStateChanged?.Invoke(newState);
            Debug.Log($"New state: {newState}");
        }

        private void HandleStarting()
        {
            //Сбрасываем время у всех спеллов
            //Ставим игрока в начальное место комнаты
            //Переводим в нормальное положение UI
            GameState = GameState.SpawningEnemies;
        }
        
        private void HandleSpawningEnemies()
        {
            //Спавним врагов
            GameState = GameState.Fighting;
        }
        
        private void HandleFighting()
        {
            //Основная логика игры
            GameState = GameState.NextRoomChoosing;
        }

        private void HangleNextRoomChoosing()
        {
            //Нажатие на следующую комнату
            //Перевод UI в состояние загрузки следующей комнаты
            GameState = GameState.Starting;
        }
        
        private void HandleLose()
        {
        }
    }

    [Serializable]
    public enum GameState
    {
        Starting,
        SpawningEnemies,
        Fighting,
        Lose,
        NextRoomChoosing
    }
}