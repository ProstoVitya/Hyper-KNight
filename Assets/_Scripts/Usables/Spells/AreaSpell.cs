using UnityEngine;

namespace Usables.Spells
{
    public class AreaSpell : SimpleSpell
    {
        [SerializeField] private GameObject _areaSpell;

        protected override void UseSpell(Transform transform)
        {
            Vector3 position = transform.position;
            position.y = 0.1f;
            GameObject spawnedObject = Instantiate(_areaSpell, position, _areaSpell.transform.rotation);
            spawnedObject.transform.parent = transform;
        }
    }

}