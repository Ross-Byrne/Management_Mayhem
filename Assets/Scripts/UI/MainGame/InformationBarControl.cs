using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InformationBarControl : MonoBehaviour {

	// UI Elements

	public Button pausePlayButton;
	public Button playNormalButton;
	public Button playFasterButton;


	public void WorldTimeControl(Button buttonPressed){

		if (buttonPressed.Equals(pausePlayButton)) {

			// if game not paused
			if(pausePlayButton.GetComponentInChildren<Text>().text == "Pause"){

				// pause game
				GameManager.gameManager.PauseGame(true);

				// Change buttons text to "Play"
				pausePlayButton.GetComponentInChildren<Text>().text = "Play";

				// Make buttons text red
				pausePlayButton.GetComponentInChildren<Text>().color = new Color32(154, 0, 0, 255);
			} else { // if game is paused

				// Make buttons text black
				pausePlayButton.GetComponentInChildren<Text>().color = Color.black;

				// Change buttons text to "Pause"
				pausePlayButton.GetComponentInChildren<Text>().text = "Pause";

				// un pause game
				GameManager.gameManager.PauseGame(false);

			} // if
		} // if

	} // WorldTimeControl()

} // class
