using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    public GameObject followTarget;
    
    [Header("Camera Settings")]
    [SerializeField] private float defaultCameraPitch = 10; 
    [SerializeField] private float cameraRotationSpeed = 1f;
    [SerializeField] private float horizontalDamping = 1f;
    //[SerializeField] private float verticalDamping = 1f;
    
    [Header("Debug Values")]
    [SerializeField] private Vector2 lookDelta;
    
    private Transform _followTargetTransform;
    private Transform _playerTransform;
    private Vector2 _previousMouseDelta;

    private void Start()
    {
        _followTargetTransform = followTarget.transform;
        _playerTransform = transform;
    }

    public void OnLook(InputValue value)
    {
        lookDelta = value.Get<Vector2>();
        _followTargetTransform.rotation *=
            Quaternion.AngleAxis(
                Mathf.Lerp(_previousMouseDelta.x, lookDelta.x, 1f / horizontalDamping) * cameraRotationSpeed,
                _playerTransform.up
            );
            
            
        _playerTransform.rotation = Quaternion.Euler(0, _followTargetTransform.transform.rotation.eulerAngles.y, 0);
        _followTargetTransform.localEulerAngles = new Vector3(defaultCameraPitch, 0, 0);
        
        _previousMouseDelta = lookDelta;
    }
}
