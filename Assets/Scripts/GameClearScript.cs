using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearScript : MonoBehaviour {

	int waitTime;
	bool isClear;

	/// <summary>
	/// initialize method
	/// </summary>
	void Start() {
		waitTime = 180;
	}

	/// <summary>
	/// update method
	/// </summary>
	void Update() {

	}


	///// -------------------------------------------------------------
	///// Å´ user methods
	///// -------------------------------------------------------------

	public void SetIsClear(bool clear) {
		isClear = clear; 
	}

}
