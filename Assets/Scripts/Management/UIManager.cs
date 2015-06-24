using UnityEngine;
using System.Collections;

// UIManager is a singlton

public class UIManager : MonoBehaviour {

	// Scripts

	public static UIManager uiManager;

	// Methods

	// Initialisation
	void Awake(){

		// to make sure only one version of UIManager exisits
		// to enforce singlton patern
		if (uiManager == null) {
			DontDestroyOnLoad (gameObject);
			uiManager = this;
		} else if (uiManager != this) {
			Destroy(gameObject);
		} // if

	} // Awake()
}
