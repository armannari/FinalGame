using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class middleCube : MonoBehaviour {

	public Transform player1;
	public Transform player2;

	private const float DISTANCE_MARGIN = 1.0f;

	private Vector3 middlePoint;
	public float distanceFromMiddlePoint;
	public float distanceBetweenPlayers;
	public float cameraDistance;
	private float aspectRatio;
	public float fov;
	private float tanFov;

	void Start() {
		aspectRatio = Screen.width / Screen.height;
		tanFov = Mathf.Tan(Mathf.Deg2Rad * Camera.main.fieldOfView / 2.0f);
	}

	void Update () {
		// Position the camera in the center.
		Vector3 newCameraPos;
		newCameraPos.x = middlePoint.x;
		newCameraPos.z = middlePoint.z;
		newCameraPos.y = middlePoint.y;
		transform.position = newCameraPos;

		// Find the middle point between players.
		Vector3 vectorBetweenPlayers = player2.position - player1.position;
		middlePoint = player1.position + 0.5f * vectorBetweenPlayers;

		// Calculate the new distance.
		distanceBetweenPlayers = vectorBetweenPlayers.magnitude;
		cameraDistance = (distanceBetweenPlayers / 2.0f / aspectRatio) / tanFov;

		// Set camera to new position.
		Vector3 dir = (transform.position - middlePoint).normalized;
		transform.position = middlePoint + dir * (cameraDistance + DISTANCE_MARGIN);
	}
}
