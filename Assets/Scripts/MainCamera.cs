using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

	[SerializeField]
	private GameObject player;

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

		///- XZ�͈ړ������Ȃ��̂Ō��̒l���g�p
		///- Y��Player��Ǐ]
		transform.position = new Vector3(
			transform.position.x,
			player.transform.position.y,
			transform.position.z
		);

	}
}
