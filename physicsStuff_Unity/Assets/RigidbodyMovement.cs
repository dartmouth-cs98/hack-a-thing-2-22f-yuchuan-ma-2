using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{
    private Vector3 PlayerMovemetInput;
    private Vector2 PlayerMouseInput;
    private float xRot;

    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private Rigidbody PlayerBody;
    [SerializeField] private Transform FeetTransform;
    [SerializeField] private LayerMask FloorMask;
    [Space]
    [SerializeField] private float Speed;
    [SerializeField] private float Sensitivity; // for the mouse detection
    [SerializeField] private float Jumpfoce;

    [Space]
    //[Header]
    [SerializeField] private LayerMask PickupLayer;
    [SerializeField] private Camera PlayerCamera2;
    [SerializeField] private float PickupRange;
    [SerializeField] private float ThrowingForce;
    [SerializeField] private Transform Hand;

    private Rigidbody CurrentObjectRigidbody;
    private Collider CurrentObjectCollider;

    // Update is called once per frame
    private void Update()
    {
        PlayerMovemetInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        MovePlayer();
        MovePlayerCamera();

        if (Input.GetKeyDown(KeyCode.E)) 
        {
            Ray Pickupray = new Ray(PlayerCamera2.transform.position, PlayerCamera.transform.forward);

            if(Physics.Raycast(Pickupray, out RaycastHit hitInfo, PickupRange, PickupLayer))
            {
                if (CurrentObjectRigidbody) 
                {
                    // replace the obj in hand with the new one
                    // first drop the old, set its physcis state back
                    CurrentObjectRigidbody.isKinematic = false;
                    CurrentObjectCollider.enabled = true;

                    // update to the new
                    CurrentObjectRigidbody = hitInfo.rigidbody;
                    CurrentObjectCollider = hitInfo.collider;

                    CurrentObjectRigidbody.isKinematic = true;
                    CurrentObjectCollider.enabled = false;
                }
                else
                // if no obj in hand, pick it up, set its physics property off to prevent weird movements
                {
                    CurrentObjectRigidbody = hitInfo.rigidbody;
                    CurrentObjectCollider = hitInfo.collider;

                    CurrentObjectRigidbody.isKinematic = true;
                    CurrentObjectCollider.enabled = false;
                }

                return;
            }
            // if raycast hits nothing, drop the obj in hand
            if (CurrentObjectRigidbody) 
                {
                    CurrentObjectRigidbody.isKinematic = false;
                    CurrentObjectCollider.enabled = true;

                    CurrentObjectRigidbody = null;
                    CurrentObjectCollider = null;
                }
        }
        // throwing an obj
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (CurrentObjectRigidbody) 
            {
                // reset it then add force
                CurrentObjectRigidbody.isKinematic = false;
                CurrentObjectCollider.enabled = true;
                
                CurrentObjectRigidbody.AddForce(PlayerCamera2.transform.forward * ThrowingForce, ForceMode.Impulse);

                CurrentObjectRigidbody = null;
                CurrentObjectCollider = null;
            }
        }
        // move the picked up obj to on hand
        if (CurrentObjectRigidbody) 
        {
            CurrentObjectRigidbody.position = Hand.position;
            CurrentObjectRigidbody.rotation = Hand.rotation;
        }
    }

    private void MovePlayer() 
    {
        Vector3 MoveVector = transform.TransformDirection(PlayerMovemetInput) * Speed;
        PlayerBody.velocity = new Vector3(MoveVector.x, PlayerBody.velocity.y, MoveVector.z);

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if (Physics.CheckSphere(FeetTransform.position, 0.1f, FloorMask))
            {
                PlayerBody.AddForce(Vector3.up * Jumpfoce, ForceMode.Impulse);
            }
        }
    }

    private void MovePlayerCamera() 
    {
        xRot -= PlayerMouseInput.y * Sensitivity;
        transform.Rotate(0f, PlayerMouseInput.x*Sensitivity, 0f);
        PlayerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
    }
}
