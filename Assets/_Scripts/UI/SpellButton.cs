using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI
{
    [RequireComponent(typeof(Button))]
    public class SpellButton : MonoBehaviour
    {
        private TMP_Text _timer;
        private Button _button;
        
        private float _cooldownTime = 0;
        
        private void Awake()
        {
            _timer = transform.GetComponentInChildren<TMP_Text>();
            _button = transform.GetComponentInChildren<Button>();
        }

        private void Update()
        {
            if (_cooldownTime <= 0)
            {
                _button.interactable = true;
                _timer.text = "";
            }
            else
            {
                _timer.text = Math.Round(_cooldownTime, 0, MidpointRounding.AwayFromZero)
                    .ToString(CultureInfo.InvariantCulture);
                _cooldownTime -= Time.deltaTime;
            }
        }

        public void OnClick(int cooldown)
        {
            _cooldownTime = cooldown;
            _button.interactable = false;
            Debug.Log($"usedSpell {_cooldownTime}");
        }
    }
}