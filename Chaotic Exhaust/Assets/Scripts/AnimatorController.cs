using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AnimatorController : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private NavMeshAgent _agent;
    private Animator _animator;
    private float _distanceToPlayer;
    public int targetLayer;

    private void Start()
    {
        _playerHealth = FindObjectOfType<PlayerHealth>();
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetBool("isMoving", _agent.velocity.magnitude > 0.1f);
        _animator.SetFloat("velocity", _agent.velocity.magnitude);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger && other.gameObject.layer.Equals(targetLayer))
        {
            _animator.SetBool("inRange", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.isTrigger && other.gameObject.layer.Equals(targetLayer))
        {
            _animator.SetBool("inRange", false);
        }
    }
}
