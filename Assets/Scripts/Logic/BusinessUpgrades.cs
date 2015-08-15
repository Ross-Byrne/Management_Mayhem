using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Script to manage the business upgrades menu

public class BusinessUpgrades : MonoBehaviour {

	/*===================== GameObjects =====================================================================================*/
	
	// businessUpgrades Menu Window
	public GameObject businessUpgradeMenuWindow;


	/*===================== UI Elements =====================================================================================*/
	
	// Buttons

	public Button upgradeDrugLabButton;
	
	/*===================== Methods =====================================================================================*/
	
	/*===================== SetUpMenu() =====================================================================================*/
	
	// Sets up the Menu to be used
	public void SetUpMenu(){

		Debug.Log (GameManager.gameManager.CanStartMakingDrugs);
		
		// Open the AddRooms Menu by default
		businessUpgradeMenuWindow.GetComponent<BusinessUpgradesMenuControl> ().AddRoomControl ();

		// Check if player has a drug lab
		if (GameManager.gameManager.CanStartMakingDrugs) { // if yes

			// name hidden menu
			upgradeDrugLabButton.GetComponent<UpgradeDrugLabButton> ().buttonText.text = "Drug Lab";
		} else { // if no

			// name hidden menu
			upgradeDrugLabButton.GetComponent<UpgradeDrugLabButton> ().buttonText.text = "???????";
		} // if
	} // SetUpMenu()


} // class
