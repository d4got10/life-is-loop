using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsLoop.Utilities
{
    public class CameraFollowObject : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _target;

        [SerializeField] private Vector3 _offset;


        private void Update()
        {
            _camera.transform.position = _target.position + _offset;
        }
    }
}