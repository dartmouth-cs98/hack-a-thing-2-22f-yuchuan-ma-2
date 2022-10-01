using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyGuard : MonoBehaviour
{
	// simple state machine for control
	private enum BodyGuardState
	{
		Walking,
		Ragdoll
	}

    private Rigidbody[] _ragdollRigidbodies;
    private BodyGuardState _currentState = BodyGuardState.Walking;

    [SerializeField] private Camera _camera;
    private Animator _animator;
    private CharacterController _characterController;

    void Awake()
    {
        _ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
        DisableRagdoll();
    }

    // Update is called once per frame
    void Update()
    {
    	switch (_currentState)
    	{
    		case BodyGuardState.Walking:
    			WalkingBehavior();
    			break;
    		case BodyGuardState.Ragdoll:
    			RagdollBehavior();
    			break;
    	}
    }

    private void DisableRagdoll()
    {
    	foreach (var rigidbody in _ragdollRigidbodies)
    	{
    		rigidbody.isKinematic = true;
    	}
    	_animator.enabled = true;
    	_characterController.enabled = true;
    }

    private void EnableRagdoll()
    {
    	foreach (var rigidbody in _ragdollRigidbodies)
    	{
    		rigidbody.isKinematic = false;
    	}
    	_animator.enabled = false;
    	_characterController.enabled = false;
    }

    private void WalkingBehavior()
    {
    	Vector3 direction = _camera.transform.position - transform.position;
    	direction.y = 0;
    	direction.Normalize();

    	Quaternion toRotate = Quaternion.LookRotation(direction, Vector3.up);
    	transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, 20 * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
        	EnableRagdoll();
        	_currentState = BodyGuardState.Ragdoll;
        }
    }

    // public void TriggerRagdoll(Vector3 force, Vector3 hitPoint)
    // {
    	
    // }

    private void RagdollBehavior()
    {
    	
    }
}



























