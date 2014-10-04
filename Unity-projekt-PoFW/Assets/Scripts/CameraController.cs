using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {


	public Transform player;

	Vector3 direction;


	// Use this for initialization
	void Start () {
		direction = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + direction;
	}
}
