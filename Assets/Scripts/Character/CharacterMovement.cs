using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsLoop.Character
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Rigidbody2D _rigidbody;
        [Space]
        [SerializeField] private float _speed;

        private Vector3 _normalScale;

        private void Awake()
        {
            _normalScale = transform.localScale;
        }

        private void Update()
        {
            float input = Input.GetAxis("Horizontal");

            if(input < -0.05f)
            {
                _rigidbody.transform.localScale = new Vector3(-_normalScale.x, _normalScale.y, _normalScale.z);
            }
            else if(input > 0.05f)
            {
                _rigidbody.transform.localScale = new Vector3(_normalScale.x, _normalScale.y, _normalScale.z);
            }

            _rigidbody.velocity = new Vector2(input * _speed, 0);
            if (Mathf.Abs(input) > 0.2f)
                _animator.SetBool("IsRunning", true);
            else
                _animator.SetBool("IsRunning", false);
        }
    }
}
