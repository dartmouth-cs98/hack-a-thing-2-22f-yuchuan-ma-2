// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class ShootBodyguard : MonoBehaviour
// {
// 	[SerializeField] private float _maxForce;
// 	[SerializeField] private float _maxForceTime;

// 	private float _timeMouseButtonDown;

// 	private Camera _camera;

//     // Start is called before the first frame update
//     void Awake()
//     {
//         _camera = GetComponent<Camera>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (Input.GetMouseButtonDown(0))
//         {
//         	_timeMouseButtonDown = Time.time;
//         }

//         if (Input.GetMouseButtonUp(0))
//         {
//         	Ray ray = _camera.ScreenPointToRay(Input.mousePostion);

//         	if (Physics.Raycast(ray, out RaycastHit hitInfo))
//         	{
//         		BodyGuard bodyguard = hitInfo.collider.GetComponentInparent<BodyGuard>();

//         		if (bodyguard != null)
//         		{
//         			float mouseButtonDownDuration = Time.time - _timeMouseButtonDown;
//         			float forcePercentage = mouseButtonDownDuration / _maxForceTime;
//         			float forceMagnitude = Mathf.Lerp(1, _maxForce, forcePercentage);

//         			Vector3 forceDirection = bodyguard.transform.position - 
//         		}
//         	}
//         }
//     }
// }
