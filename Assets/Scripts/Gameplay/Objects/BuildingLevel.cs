using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Script to keep track of rooms in each level

public class BuildingLevel : MonoBehaviour {

	/*===================== GameObjects =====================================================================================*/

	// Rooms
	[SerializeField]
	private List<GameObject> roomsInLevel = new List<GameObject> ();
	public List<GameObject> RoomsInLevel 
	{
		get{ return roomsInLevel;}
		set{ roomsInLevel = value;}
	}

} // class
