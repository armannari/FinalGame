using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

// [RequireComponent(typeof(CharacterController))]
public class player1 : MonoBehaviour {

	public int playerId = 10; // The Rewired player id of this character
	public float bulletSpeed = 15.0f;
	public GameObject bulletPrefab;

	private Player player; // The Rewired Player
	private CharacterController cc;
	private Vector3 moveVector;
	private bool fire;

	public float rotateSpeed;
	public float moveSpeed; 
	public float strafeSpeed;

	void Awake() {
		// Get the Rewired Player object for this player and keep it for 
		// the duration of the character's lifetime
		player = ReInput.players.GetPlayer(playerId);

		// Get the character controller
		// cc = GetComponent<CharacterController>();
	}

	void Start () {
		rotateSpeed = 150;
		moveSpeed = 3;
		strafeSpeed = 3;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log("player1: " + player.id);
		GetInput();
		// ProcessInput();

		var rotate = player.GetAxis("Rotate Player") * Time.deltaTime * rotateSpeed;
		var move = player.GetAxis("Move Horizontal") * Time.deltaTime * moveSpeed;
		var strafe = player.GetAxis("Strafe") * Time.deltaTime * strafeSpeed;

		transform.Rotate(0, rotate, 0);
		transform.Translate(0, 0, move);

		if(fire)
		{
			Debug.Log("fire!");
		}
	}

	private void GetInput() 
	{
		// Get the input from the Rewired Player. 
		// All controllers that the Player owns will contribute, so it doesn't matter
		// whether the input is coming from a joystick, the keyboard, mouse, or a custom 
		// controller.

		// smoveVector.x = player.GetAxis("Move Horizontal"); // get input by name or action id
		// moveVector.y = player.GetAxis("Rotate Player");
		fire = player.GetButtonDown("Fire");
	}

	private void ProcessInput() 
	{
		// Process movement
		if(moveVector.x != 0.0f || moveVector.y != 0.0f) {
			cc.Move(moveVector * moveSpeed * Time.deltaTime);
		}

		// Process fire
		if(fire) {
//			GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position + transform.right, transform.rotation);
//			bullet.rigidbody.AddForce(transform.right * bulletSpeed, ForceMode.VelocityChange);
			
		}
	}
}
