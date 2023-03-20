using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Usables.Spells
{
    public class AreaSpell : SimpleSpell
    {
        [SerializeField] private GameObject _areaIndicator;
        [SerializeField] private GameObject _areaSpell;


        private bool _isActive = false;
        private Camera _camera = null;
        private Ray p_ray;
        private RaycastHit p_hit;

        private void Awake()
        {
            _camera = Camera.main;
        }

        protected override void UseSpell(Transform transform)
        {
            _isActive = !_isActive;
            _areaIndicator.SetActive(_isActive);

        }
       

        void Update()
        {
            if (_isActive) {
                p_ray = _camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(p_ray, out p_hit))
                {
                    if (p_hit.collider.tag == "Terrain")
                    {
                        _areaIndicator.transform.position = new Vector3(p_hit.point.x,p_hit.point.y+0.5f,p_hit.point.z);
                    }
                    if (Input.GetMouseButtonDown(0))
                    {
                        Instantiate(_areaSpell, _areaIndicator.transform.position, _areaIndicator.transform.rotation);
                    }
                }


            }

        }
    }


}