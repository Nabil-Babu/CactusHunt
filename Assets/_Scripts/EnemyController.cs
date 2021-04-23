using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject Player;

    public LayerMask attackMask;
    // GO Components
    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshAgent _agent;
    
    private bool _isStunned = false;
    private bool _isAttacking = false;
    
    private static readonly int IsRunning = Animator.StringToHash("isRunning");
    private static readonly int IsStunned = Animator.StringToHash("isStunned");
    private static readonly int Attack = Animator.StringToHash("Attack");

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _agent.SetDestination(Player.transform.position); 
        AnimateAgent();
        CheckAttack();
    }

    private void AnimateAgent()
    {

        if (_isStunned)
        {
            _animator.SetBool(IsRunning, false);
            _agent.speed = 0;
            return; 
        }
        else
        {
            _agent.speed = 2;
        }
        
        if (_agent.velocity.sqrMagnitude > 0)
        {
            _animator.SetBool(IsRunning, true);
        }
        else
        {
            _animator.SetBool(IsRunning, false);
        }
    }

    public void Stun()
    {
        if (!_isStunned)
        {
            StartCoroutine(StartStun());
        }
    }

    void CheckAttack()
    {
        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            if (!_isStunned && !_isAttacking)
            {
                StartCoroutine(StartAttack());
            }
        }
    }

    IEnumerator StartStun()
    {
        _isStunned = true;
        _animator.SetBool(IsStunned, true);
        yield return new WaitForSeconds(5.0f);
        _isStunned = false;
        _animator.SetBool(IsStunned, false);
    }

    IEnumerator StartAttack()
    {
        _isAttacking = true;
        _animator.SetTrigger(Attack);
        AttackOverlapCall();
        yield return new WaitForSeconds(3.0f);
        _isAttacking = false; 
    }

    void AttackOverlapCall()
    {
        Collider[] allColliders;
        allColliders = Physics.OverlapSphere(transform.position, 2.0f, attackMask);
        if (allColliders.Length > 0)
        {
            Debug.Log("attacking player");
            Collider collider = allColliders[0];
            collider.gameObject.GetComponent<PlayerController>().DamagePlayer(25);
        }
    }
}
