using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LifeIsLoop.Character
{
    public class CharacterNeedsView : MonoBehaviour
    {
        [SerializeField] private CharacterNeeds _characterNeeds;
        [Space(20)]
        [SerializeField] private Slider _hungerSlider;
        [SerializeField] private Slider _sleepSlider;
        [SerializeField] private Slider _thirstSlider;

        private void Awake()
        {
            _hungerSlider.value = _characterNeeds.Hunger.Value;
            _hungerSlider.maxValue = _characterNeeds.Hunger.MaxValue;

            _sleepSlider.value = _characterNeeds.Sleep.Value;
            _sleepSlider.maxValue = _characterNeeds.Sleep.MaxValue;

            _thirstSlider.value = _characterNeeds.Thirst.Value;
            _thirstSlider.maxValue = _characterNeeds.Thirst.MaxValue;

            _characterNeeds.Hunger.OnValueChange += (value) => _hungerSlider.value = _hungerSlider.maxValue - value;
            _characterNeeds.Sleep.OnValueChange += (value) => _sleepSlider.value = _sleepSlider.maxValue - value;
            _characterNeeds.Thirst.OnValueChange += (value) => _thirstSlider.value = _thirstSlider.maxValue - value;
        }
    }
}
