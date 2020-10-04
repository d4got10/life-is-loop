using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsLoop.WaterSystem
{
    public class WaterPool : MonoBehaviour
    {
        [SerializeField] private WaterSystem _waterSystem;
        [Space]
        [SerializeField] private float _maxAmount = 100;
        [SerializeField] private float _fillDelta = 1;
        [Space(20)]
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Sprite _lowWaterSprite;
        [SerializeField] private Sprite _awerageWaterSprite;
        [SerializeField] private Sprite _highWaterSprite;

        private float _amount;
        private int _currentLevel;

        private void Awake()
        {
            _amount = _maxAmount;
            _currentLevel = 3;
        }

        private void Update()
        {
            _amount += _fillDelta * Time.deltaTime;
            if (_amount > _maxAmount)
                _amount = _maxAmount;

            if(_amount < _maxAmount / 3)
            {
                if (_currentLevel != 1)
                {
                    _spriteRenderer.sprite = _lowWaterSprite;
                    _currentLevel = 1;
                }
            }
            else if(_amount < _maxAmount/3 * 2)
            {
                if (_currentLevel != 2)
                {
                    _spriteRenderer.sprite = _awerageWaterSprite;
                    _currentLevel = 2;
                }
            }
            else if(_currentLevel != 3)
            {
                _spriteRenderer.sprite = _highWaterSprite;
                _currentLevel = 3;
            }
        }

        public void Interact()
        {
            _waterSystem.Drink(_amount);
            _amount = 0;
        }
    }
}