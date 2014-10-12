using UnityEngine;
using System.Collections;

public class RestartTrigger : MonoBehaviour {

	public Transform character;

	private Vector3 characterStartPosition;

	void OnTriggerEnter2D(Collider2D obj){
		obj.transform.position = characterStartPosition;
	}

	// Use this for initialization
	void Start () {
		characterStartPosition = character.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
