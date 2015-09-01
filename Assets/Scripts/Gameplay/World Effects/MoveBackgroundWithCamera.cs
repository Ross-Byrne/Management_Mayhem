using UnityEngine;
using System.Collections;

// Script to move the games background with the camera when it moves

public class MoveBackgroundWithCamera : MonoBehaviour {

	/*===================== GameObjects =====================================================================================*/

	public GameObject blueSkyBackground;


	/*===================== GameObjects =====================================================================================*/

	private Vector3 pos;


	/*===================== Methods =====================================================================================*/

	/*===================== Update() =====================================================================================*/

	void Update () {
	
		// while the camera is flagged as moving
		if (GameManager.gameManager.CameraMoving) { 

			// save position of background
			pos = blueSkyBackground.transform.position;

			// get y pos of camera
			pos.y = Camera.main.transform.position.y;

			// update background y axis to match cameras 
			blueSkyBackground.transform.position = pos;

		} // if

	} // Update()


} // class
