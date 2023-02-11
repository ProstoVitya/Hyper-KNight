using System;
using LevelGeneration;
using UnityEngine;
using Utilities;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private LevelGenerator _levelGenerator;
        
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
                case GameState.GeneratingLevel:
                    HandleLevelGenerating();
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
            GameState = GameState.GeneratingLevel;
        }
        
        private void HandleLevelGenerating()
        {
            _levelGenerator.Generate();
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
        GeneratingLevel,
        Fighting,
        Lose,
        NextRoomChoosing
    }
}