using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Script for controlling the Business Upgrades Menus

public class BusinessUpgradesMenuControl : MonoBehaviour {

	/*===================== GameObjects =====================================================================================*/
	
	// Menus
	
	public GameObject addRoomMenu;
	public GameObject upgradeEquipmentMenu;
	public GameObject researchMenu;
	public GameObject upgradeDrugLabMenu;
	
	
	/*===================== UI Elements =====================================================================================*/
	
	// Buttons

	public Button addRoomButton;
	public Button upgradeEquipButton;
	public Button researchButton;
	public Button upgradeDrugLabButton;

	// Text

	public Text headingText;
	
	
	/*===================== Methods =====================================================================================*/
	
	/*===================== AddRoomControl() =====================================================================================*/
	
	// Fires when AddRoomButton is Clicked
	public void AddRoomControl(){
		
		// Turn off other menus
		upgradeEquipmentMenu.SetActive (false);
		researchMenu.SetActive (false);
		upgradeDrugLabMenu.SetActive (false);

		// Update headingText
		headingText.text = "Upgrade Rooms";

		// Turn on AddRoomMenu
		addRoomMenu.SetActive (true);

		// Disable button to show the menu is selected
		addRoomButton.interactable = false;

		// Activate other buttons
		upgradeEquipButton.interactable = true;
		researchButton.interactable = true;
		upgradeDrugLabButton.interactable = true;

	} // AddRoomControl()
	
	
	/*===================== UpgradeEquipmentControl() =====================================================================================*/
	
	// Fires when UpgradeEquipButton is Clicked
	public void UpgradeEquipmentControl(){
		
		// Turn off other menus
		addRoomMenu.SetActive (false);
		researchMenu.SetActive (false);
		upgradeDrugLabMenu.SetActive (false);
		
		// Update headingText
		headingText.text = "Upgrade Equipment";
		
		// Turn on UpgradeEquipmentMenu
		upgradeEquipmentMenu.SetActive (true);
		
		// Disable button to show the menu is selected
		upgradeEquipButton.interactable = false;
		
		// Activate other buttons
		addRoomButton.interactable = true;
		researchButton.interactable = true;
		upgradeDrugLabButton.interactable = true;
		
	} // UpgradeEquipmentControl()
	
	
	/*===================== ResearchControl() =====================================================================================*/
	
	// Fires when ResearchButton is Clicked
	public void ResearchControl(){
		
		// Turn off other menus
		addRoomMenu.SetActive (false);
		upgradeEquipmentMenu.SetActive (false);
		upgradeDrugLabMenu.SetActive (false);
		
		// Update headingText
		headingText.text = "Research Upgrades";
		
		// Turn on ResearchMenu
		researchMenu.SetActive (true);
		
		// Disable button to show the menu is selected
		researchButton.interactable = false;
		
		// Activate other buttons
		addRoomButton.interactable = true;
		upgradeEquipButton.interactable = true;
		upgradeDrugLabButton.interactable = true;
		
	} // ResearchControl()
	
	
	/*===================== UpgradeDrugLabControl() =====================================================================================*/
	
	// Fires when UpgradeDrugLabButton is Clicked
	public void UpgradeDrugLabControl(){

		// Turn off other menus
		addRoomMenu.SetActive (false);
		upgradeEquipmentMenu.SetActive (false);
		researchMenu.SetActive (false);

		// if player has a drug lab
		if (GameManager.gameManager.CanStartMakingDrugs) { 

			// Update headingText
			headingText.text = "Upgrade Drug Lab";
		
			// Turn on UpgradeDrugLabMenu
			upgradeDrugLabMenu.SetActive (true);

		} else { // if no

			// Update headingText
			headingText.text = "???????";
		} // if

		// Disable button to show the menu is selected
		upgradeDrugLabButton.interactable = false;

		// Activate other buttons
		addRoomButton.interactable = true;
		upgradeEquipButton.interactable = true;
		researchButton.interactable = true;
		
	} // UpgradeDrugLabControl()

} // class
