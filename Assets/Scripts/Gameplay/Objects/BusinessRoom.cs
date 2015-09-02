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

		// Rooms are empty by default
		Type = "Empty";

	} // Awake()


	/*===================== Start() =====================================================================================*/

	void Start(){

		// if room is meant to be unlocked
		if (!IsLocked) {

			// unlock room
			UnlockRoom();
		} else { // otherwise

			// lock room
			LockRoom();
		} // if

	} // Start


	/*===================== UnlockRoom() =====================================================================================*/

	// Unlocks the Room
	public void UnlockRoom(){

		// flags room as unlocked
		IsLocked = false;

		// deactivates the lock screen
		lockScreen.SetActive(false);

	} // UnlockRoom()


	/*===================== LockRoom() =====================================================================================*/
	
	// Locks the Room
	public void LockRoom(){
		
		// flags room as locked
		IsLocked = true;
		
		// activates the lock screen
		lockScreen.SetActive(true);
		
	} // LockRoom()
} // class
