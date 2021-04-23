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


    private PlayerStats _playerStats;
    private Animator _playerAnimator;
    private Transform _playerTransform;
    private bool _pickingUp = false; 
    private bool _running = false;
    private Vector3 _moveDirection = Vector3.zero;
    private static readonly int IsRunning = Animator.StringToHash("isRunning");
    private static readonly int PickUp = Animator.StringToHash("PickUp");

    public void Awake()
    {
        _playerTransform = transform;
        _playerAnimator = GetComponent<Animator>();
        _playerStats = GetComponent<PlayerStats>();
    }

    public void Start()
    {
        _playerStats.CurrentHealth = _playerStats.MaxHealth;
    }

    public void OnMove(InputValue value)
    {
        _inputVector = value.Get<Vector2>();
        
        if (_inputVector.sqrMagnitude > 0)
        {
            if (_pickingUp) return;
            _running = true;
            _playerAnimator.SetBool(IsRunning, true);
        }
        else
        {
            _running = false;
            _playerAnimator.SetBool(IsRunning, false);
        }
    }

    public void OnPickUp(InputValue value)
    {
        if (value.isPressed)
        {
            if (_running) return; 
            if (_pickingUp) return; 
            StartCoroutine(PickUpItem()); 
            _playerAnimator.SetTrigger(PickUp);
        }
    }

    public void OnStun(InputValue value)
    {
        if (value.isPressed)
        {
            if (_playerStats.HasStunLoaded)
            {
                // Stun Enemies Around Player
                _playerStats.HasStunLoaded = false;
            }
        }
    }
    
    public void Update()
    {
        _moveDirection = _playerTransform.forward * _inputVector.y + _playerTransform.right * _inputVector.x;
        Vector3 movementDirection = _moveDirection * (RunSpeed * Time.deltaTime);
        if (_pickingUp) return;
        if (_inputVector.sqrMagnitude > 0)
        {
            _running = true;
            _playerAnimator.SetBool(IsRunning, true);
        }
        else
        {
            _running = false;
            _playerAnimator.SetBool(IsRunning, false);
        }
        _playerTransform.position += movementDirection;
    }

    IEnumerator PickUpItem()
    {
        _pickingUp = true;
        PickUpCircleCast();
        yield return new WaitForSeconds(5.0f);
        _pickingUp = false;
    }

    IEnumerator SpeedBoost(GameObject flower)
    {
        Debug.Log("Boosting Player Speed");
        Destroy(flower);
        RunSpeed = 6.0f;
        _playerStats.HasSpeedBoost = true;
        yield return new WaitForSeconds(3.0f);
        Debug.Log("Reducing Player Speed");
        _playerStats.HasSpeedBoost = false;
        RunSpeed = 3.0f;
    }


    void PickUpCircleCast()
    {
        Collider[] allColliders;
        allColliders = Physics.OverlapSphere(pickUpCast.transform.position, 2.0f, pickUpMask);
        if (allColliders.Length > 0)
        {
            Collider collider = allColliders[0];
            Destroy(collider.transform.parent.gameObject);
            _playerStats.CurrentCactusCount++;
            Debug.Log("Cactus Found");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        string otherTag = other.gameObject.tag;
        switch (otherTag)
        {
            case "LifeFlower":
                if (_playerStats.CurrentHealth < _playerStats.MaxHealth)
                {
                    AddHealth(other.gameObject);
                }
                break;
            case "StunFlower":
                if (!_playerStats.HasStunLoaded)
                {
                    _playerStats.HasStunLoaded = true;
                    Destroy(other.gameObject);
                } 
                break;
            case "SpeedFlower":
                if (!_playerStats.HasSpeedBoost) StartCoroutine(SpeedBoost(other.gameObject));
                break;
            default:
                Debug.Log("Unknown Collider Trigger");
                break;
        }
    }

    private void AddHealth(GameObject flower)
    {
        _playerStats.CurrentHealth += 10;
        Destroy(flower);
    }

    public void DamagePlayer(int dmg)
    {
        _playerStats.CurrentHealth -= dmg;
    }
}
