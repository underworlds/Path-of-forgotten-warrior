using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {


	public Transform character;
	private float smoothRate = 0.5f;
	private Vector2 velocity;

	//private int yCameraPositionBorder = -13;
	//private int usageCounter = 0;

	//private Vector3 cameraStartPosition;
	//private Vector3 characterStartPosition;
	//private Vector3 direction;


	// Use this for initialization
	void Start () {
		velocity = new Vector2(0.5f,0.5f);

		//direction = this.transform.position - character.transform.position;
		//cameraStartPosition = this.transform.position;
		//characterStartPosition = character.transform.position;
	}

	void Update(){
		Vector2 newPos2D = Vector2.zero;
		newPos2D.x = Mathf.SmoothDamp (this.transform.position.x, character.transform.position.x, ref velocity.x, smoothRate);
		newPos2D.y = Mathf.SmoothDamp (this.transform.position.y, character.transform.position.y, ref velocity.y, smoothRate);


		//UPDATES CAMERA TO OUR CHARACTERS LOCATION
		Vector3 newPos = new Vector3 (newPos2D.x, newPos2D.y, this.transform.position.z);
		this.transform.position = Vector3.Slerp (transform.position, newPos, Time.time);
	}

	void LateUpdate () {
		/* PUVODNI IMPLEMENTACE POHYBU KAMERY + OSTATNI ZAKOMENTOVANE RADKY
		if (this.transform.position.y > yCameraPositionBorder) {
						transform.position = character.transform.position + direction;
		} else {
			//JINAK> camera narazi na pozici kam nesmi a zastavi se ... 
			// pak pod ifem pocka na pozici characteru a pak se tam vrati 
			if(Mathf.Abs(character.transform.position.y - characterStartPosition.y) < 0.3f ){
				this.transform.position = cameraStartPosition;
			}
		}
		*/
	}
}
