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
	/// �ڐG��
	/// </summary>
	private void OnTriggerEnter(Collider other) {
		DestroySelf();
	}

	/// <summary>
	/// �ڐG��
	/// </summary>
	private void OnTriggerStay(Collider other) {

	}

	/// <summary>
	/// ���ꂽ�Ƃ�
	/// </summary>
	private void OnTriggerExit(Collider other) {

	}




	///// ------------------------------------------------
	///// Member Methods
	///// ------------------------------------------------

	/// <summary>
	/// ���g�����ł�����
	/// </summary>
	private void DestroySelf() {
		Destroy(gameObject);
	}

}
