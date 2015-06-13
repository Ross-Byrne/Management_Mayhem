using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// GameObjects

	public GameObject player;
	public Business business;

	// Scripts

	private Player playerScript;
	private DisplayText displayScript;

	// Variables



	// Initialization

	void Start () {
		playerScript = player.GetComponent<Player>();
		displayScript = GetComponent<DisplayText> ();

		displayScript.ShowText ("Player's Name: " + playerScript.playerName);
	} // Start()
	
	// Update is called once per frame
	void Update () {
		//displayScript.ShowText ("Player's Name: " + playerScript.playerName);
	} // 


}
