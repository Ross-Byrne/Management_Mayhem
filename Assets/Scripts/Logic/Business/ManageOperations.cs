using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Script to control the Business Operations menu

public class ManageOperations : MonoBehaviour {

	/*===================== UI Elements =====================================================================================*/


	/*===================== Methods =====================================================================================*/

	/*===================== SetUpMenu() =====================================================================================*/

	// Gets the Operations Menu ready for use
	public void SetUpMenu(){

		// Select Products Menu as default selected menu
		gameObject.GetComponent<ManageOperationsMenuControl> ().ProductionButtonControl ();

	} // SetUpMenu()

} // class
