using UnityEngine;
using System.Collections;

// object to represent each room in the business

public class BusinessRoom : MonoBehaviour {

	/*===================== GameObjects =====================================================================================*/

	public GameObject lockScreen;


	/*===================== Variables =====================================================================================*/

	public int Number { get; set;}
	public string Type { get; set;}
	public bool IsLocked { get; set;}


	/*===================== Methods =====================================================================================*/

	/*===================== Awake() =====================================================================================*/

	void Awake(){

		// Rooms are locked by default
		IsLocked = true;

	} // Awake()


	/*===================== Start() =====================================================================================*/

	void Start(){

		// if room is meant to be unlocked
		if (!IsLocked) {

			// unlock room
			lockScreen.SetActive(false);

		} else { // otherwise

			// lock room
			lockScreen.SetActive(true);

		} // if

	} // Start


} // class
