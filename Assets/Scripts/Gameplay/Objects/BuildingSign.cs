using UnityEngine;
using System.Collections;
using System;

public class BuildingSign : MonoBehaviour {

	/*===================== Variables =====================================================================================*/
	
	public GameObject businessNameText;
	public GameObject businessNameShadow;


	/*===================== Methods =====================================================================================*/

	/*===================== UpdateBusinessNameSign() =====================================================================================*/

	public void UpdateBusinessNameSign(string businessName){

		// try update name of business on sign
		try {

			// Update business name on building sign
			businessNameText.GetComponent<TextMesh>().text = businessName;

			// Update shadow text for businss name on sign
			businessNameShadow.GetComponent<TextMesh>().text = businessName;
		} catch(Exception e){

			// print error
			Debug.Log (e + " Could not update building Sign!");

			// Cannot update, set to default
			businessNameText.GetComponent<TextMesh>().text = "Business Name";
			
			// Cannot update, set to default
			businessNameShadow.GetComponent<TextMesh>().text = "Business Name";

		} finally {

			// print error
			Debug.Log ("Could not update building Sign!");
		} // try catch

	} // UpdateBusinessNameSign()


} // class
