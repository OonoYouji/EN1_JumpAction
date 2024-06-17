using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScript : MonoBehaviour {



	/// <summary>
	/// initialize method
	/// </summary>
	void Start() {

	}

	/// <summary>
	/// update method
	/// </summary>
	void Update() {

	}

	///// ----------------------------------------------------------------------------
	///// ↓ user methods
	///// ----------------------------------------------------------------------------

	/// <summary>
	/// sceneのresetに用いる
	/// </summary>
	public void ResetAll() {
		SceneManager.LoadScene("GameScene");
	}


}
