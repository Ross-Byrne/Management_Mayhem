using UnityEngine;
using System.Collections;

// Script to control the camera in main scene

public class CameraController : MonoBehaviour {

	/*===================== Variables =====================================================================================*/

	private float zAxis;
	private Vector3 mouseOrigin;

	public float maxHeight = 0f; 	// y coordinate that center of screen can reach 
	public float minHeight = 0f;
	public float topMargin = -2f; 	// dist on Y axis between roof and center of screen
	public float speed = 3;			// speed at which camera will move back to max/min Height if it is met and past


	/*===================== Methods =====================================================================================*/

	/*===================== Start() =====================================================================================*/

	void Start () {

		// Distance camera is above map
		zAxis = transform.position.z;  

		// get max height
		maxHeight = GameManager.gameManager.theBuilding.GetComponent<BusinessBuildingGeneration>().buildingRoof.transform.position.y + topMargin;

		// initialise camera movement tracking variable
		GameManager.gameManager.CameraMoving = false;
	} // Start()


	/*===================== Update() =====================================================================================*/
	
	void Update () {

		// get the mouse position when first click
		if (Input.GetMouseButtonDown (1)) {

			// get screen coordinates for where mouse is clicked
			mouseOrigin = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, zAxis);

			// turn screen coordinates into world space coordinates
			mouseOrigin = Camera.main.ScreenToWorldPoint (mouseOrigin);

			// keep camera's original x axis, so it doesn't change 
			mouseOrigin.x = transform.position.x;

		} else if (Input.GetMouseButton (1)) { // while the mouse button is being held down

			// get the mouse's current coordinates (as it moves)
			var mouseCurrent = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, zAxis);

			// turn screen coordinates into world space coordinates
			mouseCurrent = Camera.main.ScreenToWorldPoint (mouseCurrent);

			// keep mouse's x axis, so it doesn't change 
			mouseCurrent.x = transform.position.x;

			// get current camera coordinates
			Vector3 temp = transform.position;

			// calculate where the camera is going to go
			temp -= (mouseCurrent - mouseOrigin);

			// check if the camera is going to move above maxHeight or below minHeight
			if (temp.y > maxHeight) { // if moving above maxHeight

				// state camera is moving
				GameManager.gameManager.CameraMoving = true;
			
				// set current y axis to maxHeight
				temp.y = maxHeight;

				// set the speed at which to move to maxHeight at
				float step = speed * Time.deltaTime;

				// move to maxHeight at set speed
				transform.position = Vector3.MoveTowards (transform.position, temp, step);

			} else if (temp.y < minHeight) { // if moving below minHeight

				// state camera is moving
				GameManager.gameManager.CameraMoving = true;

				// set current y axis to minHeight
				temp.y = minHeight;
				
				// set the speed at which to move to minHeight at
				float step = speed * Time.deltaTime;
				
				// move to minHeight at set speed
				transform.position = Vector3.MoveTowards (transform.position, temp, step);

			} else { // if within allowed range, move camera normally

				// state camera is moving
				GameManager.gameManager.CameraMoving = true;

				// move the camera to where the mouse currently is
				// using original coords as an offset
				// so the camera moves around properly
				transform.position -= (mouseCurrent - mouseOrigin);
			} // if

		} else { // if mouse button not clicked or held

			// state camera isn't moving
			GameManager.gameManager.CameraMoving = false;

		} // if

		// To slowly bring the camera back after going past the border

		/*Vector3 currentCameraPos = transform.position;

		// check if the camera is going to move above maxHeight or below minHeight
		if (currentCameraPos.y > maxHeight) { // if moving above maxHeight
			
			// set current y axis to maxHeight
			currentCameraPos.y = maxHeight;
			 
			// set the speed at which to move to maxHeight at
			float step = speed * Time.deltaTime;
			
			// move to maxHeight at set speed
			transform.position = Vector3.MoveTowards (transform.position, currentCameraPos, step);
			
		} else if (currentCameraPos.y < minHeight) { // if moving below minHeight
			
			// set current y axis to minHeight
			currentCameraPos.y = minHeight;
			
			// set the speed at which to move to minHeight at
			float step = speed * Time.deltaTime;
			
			// move to minHeight at set speed
			transform.position = Vector3.MoveTowards (transform.position, currentCameraPos, step);
		}*/

	} // Update()
	
	
} // class