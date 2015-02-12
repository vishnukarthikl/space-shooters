using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin,xMax,zMin,zMax;
}

public class PlayerController : MonoBehaviour {

	public Boundary boundary;
	public float speed;
	public float tilt;
	public GameObject bolt;
	public Transform boltSpawn;
	public float fireRate;
	private float nextFire;

	void Update() {
		if (Input.GetButton("Fire1") && nextFire < Time.time) {
			Instantiate(bolt,boltSpawn.position,boltSpawn.rotation);
			nextFire = Time.time + fireRate;
		}
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidbody.velocity = movement * speed;

		rigidbody.position = new Vector3 (
			Mathf.Clamp(rigidbody.position.x,boundary.xMin,boundary.xMax),
			0.0f,
			Mathf.Clamp(rigidbody.position.z,boundary.zMin,boundary.zMax)
			);

		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);

	}
}
