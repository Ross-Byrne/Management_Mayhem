using UnityEngine;
using System.Collections;

// Script to manage the Business Building in Game

public class BusinessBuilding : MonoBehaviour {

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

	/*===================== Start() =====================================================================================*/

	void Start(){

		// Set up the building
		SetupBuilding ();

	} // Start()


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
		buildingRoof.transform.SetParent (gameObject.transform, false);

		/*
		// instantiate Building ground Floor
		buildingLevel = (GameObject)Instantiate (buildingLevelPrefab);

		// Set position of ground floor
		buildingLevel.transform.position = new Vector3 (0, 0, 0);

		// make buildingLevel a child of "TheBuilding" GameObject
		buildingLevel.transform.SetParent (gameObject.transform, false);

		// instantiate Building First Floor
		buildingLevel = (GameObject)Instantiate (buildingLevelPrefab);

		// Set position of first floor
		buildingLevel.transform.position = new Vector3 (0, yDisBetweenLevels * 1, 0);
		
		// make buildingLevel a child of "TheBuilding" GameObject
		buildingLevel.transform.SetParent (gameObject.transform, false);
		*/

		// Add building ground floor
		AddBuildingLevel ();

	 	//Add building first floor
		AddBuildingLevel ();

	} // SetupBuilding()


	/*===================== AddBuildingLevel() =====================================================================================*/

	// Adds a level to the building
	public void AddBuildingLevel(){

		// instantiate Building Level
		buildingLevel = (GameObject)Instantiate (buildingLevelPrefab);

		if (numOfBuildingLevels == 0) {

			// Set position of Building Level
			buildingLevel.transform.position = new Vector3 (0, 0, 0);
		} else {

			// Set position of Building Level
			buildingLevel.transform.position = new Vector3 (0, yDisBetweenLevels * numOfBuildingLevels, 0);
		}

		// make buildingLevel a child of "TheBuilding" GameObject
		buildingLevel.transform.SetParent (gameObject.transform, false);

		// increase building level counter
		numOfBuildingLevels++;

		float yCoor = (yDisBetweenLevels * numOfBuildingLevels);

		Vector3 temp = new Vector3 (0, yCoor, 0);

		// move the Building Roof Up to accomidate new Level
		buildingRoof.transform.position = temp; // +1 becuase the roof is always 1 above

		Debug.Log (yDisBetweenLevels);

		Debug.Log (numOfBuildingLevels);

		Debug.Log (yDisBetweenLevels * numOfBuildingLevels);


	} // AddBuildingLevel()

	
} // class
