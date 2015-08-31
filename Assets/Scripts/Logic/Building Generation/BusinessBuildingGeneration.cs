using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Script to manage the generation of the Business Building in Game

public class BusinessBuildingGeneration : MonoBehaviour {

	/*===================== GameObjects =====================================================================================*/
	
	// Building Parts Prefabs
	
	public GameObject buildingRoofPrefab;
	public GameObject buildingLevelPrefab;
	public GameObject buildingEntrancePrefab;
	public GameObject buildingFoundationPrefab;
	
	// Building Parts
	
	public GameObject buildingRoof;
	public GameObject buildingLevel;
	public GameObject buildingEntrance;
	public GameObject buildingFoundation;

	// List of Rooms in Building
	[SerializeField]
	private List<GameObject> rooms = new List<GameObject> ();
	public List<GameObject> Rooms {

		get{ return rooms;}
		set{ rooms = value;}
	}
	
	/*===================== Variables =====================================================================================*/
	
	// distance each building level is to be places apart on Y axis
	private float yDisBetweenLevels = 1.92f;
	
	// X and Y for foundation
	private float foundationX = -6.196f;
	private float foundationY = -0.716f;
	
	// X and Y for building Entrance
	private float buildingEntranceX = -1.5f;
	private float buildingEntranceY = 0.459f;
	
	// keeping track of number of building levels
	public int numOfBuildingLevels = 0;
	

	/*===================== Methods =====================================================================================*/
	
	/*===================== Awake() =====================================================================================*/
	
	void Awake(){
		
		// Set up the building (this will be somewhere else later)
		SetupBuilding ();
		
	} // Awake()
	
	
	/*===================== SetupBuilding() =====================================================================================*/
	
	// instansiates the business building in the game
	public void SetupBuilding(){
		
		// instantiate Building Foundation
		buildingFoundation = (GameObject)Instantiate (buildingFoundationPrefab);
		
		// Set position of Foundation
		buildingFoundation.transform.position = new Vector3 (foundationX, foundationY, 0);
		
		// make buildingFoundation a child of "TheBuilding" GameObject
		buildingFoundation.transform.SetParent (gameObject.transform, false);
		
		// instantiate Building Entrance
		buildingEntrance = (GameObject)Instantiate (buildingEntrancePrefab);
		
		// Set position of Entrance
		buildingEntrance.transform.position = new Vector3 (buildingEntranceX, buildingEntranceY, 0);
		
		// make buildingEntrance a child of "TheBuilding" GameObject
		buildingEntrance.transform.SetParent (gameObject.transform, false);
		
		// instantiate Building Roof
		buildingRoof = (GameObject)Instantiate (buildingRoofPrefab);
		
		// Set position of building roof
		buildingRoof.transform.position = new Vector3 (0, yDisBetweenLevels, 0);
		
		// make buildingRoof a child of "TheBuilding" GameObject
		buildingRoof.transform.SetParent (gameObject.transform, true);
		
		// Add building ground floor
		AddBuildingLevel ();

		//Add building first floor
		AddBuildingLevel ();

		// Unlock the corrent amount of Rooms
		UnlockBuildingRooms ();

	} // SetupBuilding()
	
	
	/*===================== AddBuildingLevel() =====================================================================================*/
	
	// Adds a level to the building
	public void AddBuildingLevel(){
		
		// instantiate Building Level
		buildingLevel = (GameObject)Instantiate (buildingLevelPrefab);
		
		// Set position of Building Level
		buildingLevel.transform.position = new Vector3 (0, yDisBetweenLevels * numOfBuildingLevels, 0);
		
		// make buildingLevel a child of "TheBuilding" GameObject
		buildingLevel.transform.SetParent (gameObject.transform, false);

		// Get Number of rooms in building level
		int numOfRoomsInLevel = buildingLevel.GetComponent<BuildingLevel> ().RoomsInLevel.Count;

		// loop through number of rooms in building level
		for (int i = 0; i < numOfRoomsInLevel; i++) {

			// Give the rooms in the building level a number
			buildingLevel.GetComponent<BuildingLevel>().RoomsInLevel[i].GetComponent<BusinessRoom>().Number = ((numOfBuildingLevels * 4) + i+1);

			// Add Rooms in building level to Rooms list
			Rooms.Add(buildingLevel.GetComponent<BuildingLevel>().RoomsInLevel[i]);
		
		} // for

		// increase building level counter
		numOfBuildingLevels++;
		
		// move the Building Roof Up to accomidate new Level
		buildingRoof.transform.localPosition = new Vector3 (0f, yDisBetweenLevels * numOfBuildingLevels, 0f); // +1 numOfBuildingLevels becuase the roof is always 1 above
		
	} // AddBuildingLevel()


	/*===================== UnlockBuildingRooms() =====================================================================================*/

	// unlocks all Rooms that are meant to be unlocked
	public void UnlockBuildingRooms(){

		int numOfRooms = 0;

		try {

			// try get the number of rooms from the business
			numOfRooms = GameManager.businessScript.BuildingSize;
		} catch {

			Debug.Log("Couldn't get buildingSize");

			// if cant get number of rooms, use default
			numOfRooms = 4;
		} // try catch

		// Unlock the correct number of rooms
		for (int i = 0; i < numOfRooms; i++) {

			// if there are enough rooms to unlock
			if(i < Rooms.Count-1){ // unlock rooms up to second last room

				// unlock room
				Rooms[i].GetComponent<BusinessRoom>().UnlockRoom();
			} else { // when second last available room is unlocked

				// unlock last room
				Rooms[i].GetComponent<BusinessRoom>().UnlockRoom();

				// then add another level
				AddBuildingLevel();
			} // if
		} // for

	} // UnlockBuildingRooms()


} // class
