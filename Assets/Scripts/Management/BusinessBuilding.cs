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

		// instantiate Building Roof
		buildingRoof = (GameObject)Instantiate (buildingRoofPrefab);

		// Set position of building roof
		buildingRoof.transform.position = new Vector3 (0, yDisBetweenLevels * 2, 0);
		
		// make buildingRoof a child of "TheBuilding" GameObject
		buildingRoof.transform.SetParent (gameObject.transform, false);


	} // SetupBuilding()

	
} // class
