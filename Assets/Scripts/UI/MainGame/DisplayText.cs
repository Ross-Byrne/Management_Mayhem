using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour {

	public Text outputText;
	public Button displayButton;
	public Button resetButton;

	// displays text to output text
	public void OutputText(){

		outputText.text = "Hello World!";

		displayButton.GetComponent<Button> ().gameObject.SetActive(false);
		resetButton.GetComponent<Button> ().gameObject.SetActive(true);

	} // OutputText()

	public void ResetButton(){

		outputText.text = "Output";

		resetButton.GetComponent<Button> ().gameObject.SetActive(false);
		displayButton.GetComponent<Button> ().gameObject.SetActive(true);

	}

	public void ShowText(string text){

		outputText.text = text;
	} // ShowText()
}
