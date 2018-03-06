using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

[RequireComponent(typeof(CharacterController))]
public class player1 : MonoBehaviour {

	public int playerId = 0; // The Rewired player id of this character

	public float moveSpeed = 3.0f;
	public float bulletSpeed = 15.0f;
	public GameObject bulletPrefab;

	private Player player; // The Rewired Player
	private CharacterController cc;
	private Vector3 moveVector;
	private bool fire;

	void Awake() {
		// Get the Rewired Player object for this player and keep it for 
		// the duration of the character's lifetime
		player = ReInput.players.GetPlayer(playerId);

		// Get the character controller
		cc = GetComponent<CharacterController>();
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		GetInput();
		ProcessInput();

		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

		transform.Rotate(0,x,0);
		transform.Translate(0,0,z);
	}

	private void GetInput() 
	{
		// Get the input from the Rewired Player. 
		// All controllers that the Player owns will contribute, so it doesn't matter
		// whether the input is coming from a joystick, the keyboard, mouse, or a custom 
		// controller.

		moveVector.x = player.GetAxis("Move Horizontal"); // get input by name or action id
		moveVector.y = player.GetAxis("Move Vertical");
		fire = player.GetButtonDown("Fire");
	}

	private void ProcessInput() 
	{
		// Process movement
		if(moveVector.x != 0.0f || moveVector.y != 0.0f) {
			cc.Move(moveVector * moveSpeed * Time.deltaTime);
		}

		// Process fire
//		if(fire) {
//			GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position + transform.right, transform.rotation);
//			bullet.rigidbody.AddForce(transform.right * bulletSpeed, ForceMode.VelocityChange);
//		}
	}
}
