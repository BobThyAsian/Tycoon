using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
	public float interpVelocity;
	public float minDistance;
	public float followDistance;
	public GameObject target;
	public Vector3 offset;
	Vector3 targetPos;
	Camera mainCamera;
	float zoomMin = 6f;
	float zoomMax = 20f;
	// Use this for initialization
	void Start()
	{
		targetPos = transform.position;
		mainCamera = Camera.main;
	}

	private void Update()
	{
		float scrollAxis = Input.GetAxis("Mouse ScrollWheel") * 5f;
		if (mainCamera.orthographicSize <= zoomMin)
		{
			mainCamera.orthographicSize = zoomMin;
		}
		if (mainCamera.orthographicSize >= zoomMax)
		{
			mainCamera.orthographicSize = zoomMax;
		}
		mainCamera.orthographicSize -= scrollAxis;


	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (target)
		{
			Vector3 posNoZ = transform.position;
			posNoZ.z = target.transform.position.z;

			Vector3 targetDirection = (target.transform.position - posNoZ);

			interpVelocity = targetDirection.magnitude * 5f;

			targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

			transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);

		}
	}
}
