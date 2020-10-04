using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsLoop.Character
{
    public class CharacterNeeds : MonoBehaviour
    {
        [SerializeField] private CharacterNeed _hunger = new CharacterNeed();
        [SerializeField] private CharacterNeed _thirst = new CharacterNeed();
        [SerializeField] private CharacterNeed _sleep = new CharacterNeed();

        public Action OnDeath;

        public CharacterNeed Hunger => _hunger;
        public CharacterNeed Thirst => _thirst;
        public CharacterNeed Sleep => _sleep;

        private void Awake()
        {
            _hunger.Initialize();
            _thirst.Initialize();
            _sleep.Initialize();

            _hunger.OnMaxValueReach += () => OnDeath?.Invoke();
            _thirst.OnMaxValueReach += () => OnDeath?.Invoke();
            _sleep.OnMaxValueReach += () => OnDeath?.Invoke();
        }

        private void Update()
        {
            _hunger.Update(Time.deltaTime);
            _thirst.Update(Time.deltaTime);
            _sleep.Update(Time.deltaTime);
        }
    }

    [System.Serializable]
    public class CharacterNeed
    {
        [SerializeField] private float _maxValue = 300;
        [SerializeField] private float _defaultDelta = 1;

        public Action OnMaxValueReach;
        public Action<float> OnValueChange;

        public float MaxValue => _maxValue;
        public float Value { get; private set; }
        
        public CharacterNeed()
        {
            Initialize();
        }

        public void Initialize()
        {
            Value = 0;
        }

        public void ApplyMultiplier(float multiplier)
        {
            _defaultDelta *= multiplier;
        }

        public void RemoveValue(float value)
        {
            if (value > Value)
                Value = 0;
            else
                Value -= value;
            OnValueChange?.Invoke(Value);
        }

        public void Update(float deltaTime)
        {
            Value += _defaultDelta * deltaTime;
            if(Value >= _maxValue)
            {
                Value = _maxValue;
                OnMaxValueReach?.Invoke();
            }
            OnValueChange?.Invoke(Value);
        }
    }
}