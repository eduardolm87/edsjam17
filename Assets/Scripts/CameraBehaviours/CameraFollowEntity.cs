using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowEntity : MonoBehaviour
{
	public GameObject ObjectToFollow;

	private Vector3 Offset;

	// Use this for initialization
	void Start()
	{
		//Calculate and store the offset value by getting the distance between the player's position and camera's position.
		Offset = transform.position - ObjectToFollow.transform.position;
	}

	// LateUpdate is called after Update each frame
	void LateUpdate()
	{
		// Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
		transform.position = ObjectToFollow.transform.position + Offset;
	}

}
