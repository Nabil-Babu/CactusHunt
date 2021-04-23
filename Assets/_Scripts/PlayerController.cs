using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public GameObject pickUpCast;
    public LayerMask pickUpMask; 
    [SerializeField] private float RunSpeed;
    [SerializeField] private Vector2 _inputVector = Vector2.zero;
    
    
    private Animator _playerAnimator;
    private Transform _playerTransform;
    private bool PickingUp = false; 
    private bool Running = false; 
    private CharacterController _characterController;
    private Vector3 _moveDirection = Vector3.zero;
    private static readonly int IsRunning = Animator.StringToHash("isRunning");
    private static readonly int PickUp = Animator.StringToHash("PickUp");

    public void Awake()
    {
        _playerTransform = transform;
        _playerAnimator = GetComponent<Animator>();
        //_characterController = GetComponent<CharacterController>();
    }

    public void OnMove(InputValue value)
    {
        _inputVector = value.Get<Vector2>();
        
        if (_inputVector.sqrMagnitude > 0)
        {
            if (PickingUp) return;
            Running = true;
            _playerAnimator.SetBool(IsRunning, true);
        }
        else
        {
            Running = false;
            _playerAnimator.SetBool(IsRunning, false);
        }
    }

    public void OnPickUp(InputValue value)
    {
        if (value.isPressed)
        {
            if (Running) return; 
            if (PickingUp) return; 
            StartCoroutine(PickUpItem()); 
            _playerAnimator.SetTrigger(PickUp);
        }
    }
    
    public void Update()
    {
        _moveDirection = _playerTransform.forward * _inputVector.y + _playerTransform.right * _inputVector.x;
        Vector3 movementDirection = _moveDirection * (RunSpeed * Time.deltaTime);
        if (PickingUp) return;
        if (_inputVector.sqrMagnitude > 0)
        {
            Running = true;
            _playerAnimator.SetBool(IsRunning, true);
        }
        else
        {
            Running = false;
            _playerAnimator.SetBool(IsRunning, false);
        }
        _playerTransform.position += movementDirection;
    }

    IEnumerator PickUpItem()
    {
        PickingUp = true;
        PickUpCircleCast();
        yield return new WaitForSeconds(5.0f);
        PickingUp = false;
    }


    void PickUpCircleCast()
    {
        Collider[] allColliders;
        allColliders = Physics.OverlapSphere(pickUpCast.transform.position, 2.0f, pickUpMask);
        if (allColliders.Length > 0)
        {
            Collider collider = allColliders[0];
            Destroy(collider.transform.parent.gameObject);
            Debug.Log("Cactus Found");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        string otherTag = other.gameObject.tag;
        switch (otherTag)
        {
            case "LifeFlower":
                Debug.Log("Picked Up LifeFlower");
                break;
            case "StunFlower":
                Debug.Log("Picked Up StunFlower");
                break;
            case "SpeedFlower":
                Debug.Log("Picked Up SpeedFlower");
                break;
            default:
                Debug.Log("Unknown Collider Trigger");
                break;
        }
    }
}
