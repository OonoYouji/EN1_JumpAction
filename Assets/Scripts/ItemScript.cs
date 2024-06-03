using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour {
	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}


	///// ------------------------------------------------
	///// Not IsTrigger Collision Methods
	///// ------------------------------------------------

	/// <summary>
	/// 接触時
	/// </summary>
	private void OnTriggerEnter(Collider other) {
		DestroySelf();
	}

	/// <summary>
	/// 接触中
	/// </summary>
	private void OnTriggerStay(Collider other) {

	}

	/// <summary>
	/// 離れたとき
	/// </summary>
	private void OnTriggerExit(Collider other) {

	}




	///// ------------------------------------------------
	///// Member Methods
	///// ------------------------------------------------

	/// <summary>
	/// 自身を消滅させる
	/// </summary>
	private void DestroySelf() {
		Destroy(gameObject);
	}

}
