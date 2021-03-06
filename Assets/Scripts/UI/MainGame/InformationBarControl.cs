﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InformationBarControl : MonoBehaviour {
	
	/*===================== UI Elements =====================================================================================*/

	public Button pausePlayButton;
	public Button playNormalButton;
	public Button playFasterButton;


	/*===================== InfoDisplayControl() =====================================================================================*/

	public void InfoDisplayControl(GameObject infoDisplayMenu){

		// if menu is turned on
		if (infoDisplayMenu.activeSelf) {

			// turn off
			infoDisplayMenu.SetActive (false);
		} else { // if menu off

			// turn on
			infoDisplayMenu.SetActive (true);
		} // if

	} // InfoDisplayControl()


	/*===================== WorldTimeControl() =====================================================================================*/

	public void WorldTimeControl(Button buttonPressed){

		// if button pressed is pausePlayButton
		if (buttonPressed.Equals(pausePlayButton)) {

			// if game not paused
			if(pausePlayButton.GetComponentInChildren<Text>().text == "Pause"){

				// pause game
				GameManager.gameManager.PauseGame(true);

				// Change buttons text to "Play"
				pausePlayButton.GetComponentInChildren<Text>().text = "Play";

				// Make buttons text red
				pausePlayButton.GetComponentInChildren<Text>().color = new Color32(255, 0, 0, 255);
			} else { // if game is paused

				// Make buttons text Silver
				pausePlayButton.GetComponentInChildren<Text>().color = new Color32(219, 219, 219, 255);

				// Change buttons text to "Pause"
				pausePlayButton.GetComponentInChildren<Text>().text = "Pause";

				// un pause game
				GameManager.gameManager.PauseGame(false);

			} // if
		} // if

		// if button pressed is playNormalButton
		if (buttonPressed.Equals (playNormalButton)) {

			// set game speed to normal
			GameManager.gameManager.GameSpeed = GameManager.gameManager.NormalGameSpeed;
		
			// unpause game if game is paused
			GameManager.gameManager.PauseGame(false);

			// Make pause play button text silver
			pausePlayButton.GetComponentInChildren<Text>().color = new Color32(219, 219, 219, 255);
			
			// Change pause play button text to "Pause"
			pausePlayButton.GetComponentInChildren<Text>().text = "Pause";

		} // if

		if (buttonPressed.Equals (playFasterButton)) {

			// set game speed to faster
			GameManager.gameManager.GameSpeed = GameManager.gameManager.FastGameSpeed;
			
			// unpause game if game is paused
			GameManager.gameManager.PauseGame(false);

			// Make pause play button text silver
			pausePlayButton.GetComponentInChildren<Text>().color = new Color32(219, 219, 219, 255);
			
			// Change pause play button text to "Pause"
			pausePlayButton.GetComponentInChildren<Text>().text = "Pause";
		} // if

	} // WorldTimeControl()
 
} // class
