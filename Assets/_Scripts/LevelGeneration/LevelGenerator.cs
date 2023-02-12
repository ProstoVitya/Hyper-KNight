using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utilities;

namespace LevelGeneration
{
    public class LevelGenerator : SingletonPersistent<LevelGenerator>
    {
        [SerializeField, Tooltip("Порядок генерации объектов")]
        private GenerateOrder[] _orderArray;

        private List<IGeneratable> _generatables;

        private void Awake()
        {
            //todo: надо заполнить здесть generatables или в инспекторе?
        }

        public void Generate()
        {
            //todo: обдумать реалзацию
            //двойной foreach выглядит не очень, но так быстрее
            foreach (var order in _orderArray)
            {
                //возможно список _generatables придется дополнить после первого этапа элементами идущими по порядку ниже
                foreach (var generatable in _generatables.Where(g => g.Order == order))
                {
                    generatable.Generate();
                }
            }
        }
    }   
}