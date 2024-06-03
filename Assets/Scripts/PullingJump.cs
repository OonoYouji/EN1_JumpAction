using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PullingJump : MonoBehaviour {


	private Rigidbody rb;
	private Vector3 clickPosition;
	[SerializeField]
	private float jumpPower = 20;
	private bool isCanJump;


	// Start is called before the first frame update
	void Start() {

		rb = gameObject.GetComponent<Rigidbody>();

	}

	// Update is called once per frame
	void Update() {

		///- トリガー時の座標を取得
		if (Input.GetMouseButtonDown(0)) {
			clickPosition = Input.mousePosition;
		}

		///- リリース時速度の計算
		if (isCanJump && Input.GetMouseButtonUp(0)) {

			Vector3 dist = clickPosition - Input.mousePosition;

			///- クリックとリリースが同じ座標なら無視
			if (dist.sqrMagnitude == 0) { return; }

			rb.velocity = dist.normalized * jumpPower;

		}

	}



	///// ------------------------------------------------
	///// Collision Methods
	///// ------------------------------------------------

	/// <summary>
	/// 衝突した瞬間
	/// </summary>
	private void OnCollisionEnter(Collision collision) {
		//Debug.Log("衝突した");
	}

	/// <summary>
	/// 衝突している間
	/// </summary>
	private void OnCollisionStay(Collision collision) {

		///- 衝突している点の情報が複数格納されている
		ContactPoint[] contacts = collision.contacts;

		///- 0番目の衝突情報から、衝突している点の法線を取得
		Vector3 otherNormal = contacts[0].normal;

		float dotUN = Vector3.Dot(Vector3.up, otherNormal);


		isCanJump = true;
	}

	/// <summary>
	/// 離れたとき
	/// </summary>
	private void OnCollisionExit(Collision collision) {


		isCanJump = false;
	}

}
