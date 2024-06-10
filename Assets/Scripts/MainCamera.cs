using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

	[SerializeField]
	private GameObject player;

	// Start is called before the first frame update
	void Start() {

		///- Playerからの相対距離を求める
		//offset = transform.position - player.transform.position;



	}

	// Update is called once per frame
	void Update() {

		///- XZは移動させないので元の値を使用
		///- YはPlayerを追従
		transform.position = new Vector3(
			transform.position.x,
			player.transform.position.y,
			transform.position.z
		);

	}
}
