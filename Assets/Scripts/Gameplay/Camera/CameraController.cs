using UnityEngine;
using System.Collections;

// Script to control the camera in main scene

public class CameraController : MonoBehaviour {

	private float dist;
	private Vector3 mouseOrigin;
	
	void Start () {
		dist = transform.position.z;  // Distance camera is above map
	}
	
	void Update () {

		// get the mouse position when first click
		if (Input.GetMouseButtonDown (0)) {

			// get screen coordinates for where mouse is clicked
			mouseOrigin = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);

			// turn screen coordinates into world space coordinates
			mouseOrigin = Camera.main.ScreenToWorldPoint (mouseOrigin);

			// keep camera's original x axis, so it doesn't change 
			mouseOrigin.x = transform.position.x;

		} else if (Input.GetMouseButton (0)) { // while the mouse button is being held down

			// get the mouse's current coordinates (as it moves)
			var mouseCurrent = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);

			// turn screen coordinates into world space coordinates
			mouseCurrent = Camera.main.ScreenToWorldPoint (mouseCurrent);

			// keep mouse's x axis, so it doesn't change 
			mouseCurrent.x = transform.position.x;

			// move the camera to where the mouse currently is
			// using original coords as an offset
			// so the camera moves around properly
			transform.position -= (mouseCurrent - mouseOrigin);

		} // if
	} // Update()
	
	
} // class
