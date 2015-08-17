using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Script to manage the Business Finances Menu

public class BusinessFinances : MonoBehaviour {

	/*===================== UI Elements =====================================================================================*/




	/*===================== Methods =====================================================================================*/

	/*===================== SetUpMenu() =====================================================================================*/

	// Sets up the finances menu for use
	public void SetUpMenu(){

		// Select Maintenance as the default selected menu
		gameObject.GetComponent<BusinessFinancesMenuControl> ().maintenanceButtonControl ();

	} // SetUpMenu()
} // Class
