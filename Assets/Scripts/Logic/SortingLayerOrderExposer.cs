using UnityEngine;
using System.Collections;

// Script for exposing the Sorting Layer and Order of an Object

public class SortingLayerOrderExposer : MonoBehaviour {

	/*===================== Variables =====================================================================================*/

	public string SortingLayerName = "Default";
	public int SortingOrder = 0;


	/*===================== Methods =====================================================================================*/

	/*===================== Awake() =====================================================================================*/

	void Awake (){

		// Set Sorting Layer Name
		gameObject.GetComponent<MeshRenderer> ().sortingLayerName = SortingLayerName;

		// Set Sorting Layer Order
		gameObject.GetComponent<MeshRenderer> ().sortingOrder = SortingOrder;

	} // Awake()

} // class
