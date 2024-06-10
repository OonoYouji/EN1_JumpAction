using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class PullingJump : MonoBehaviour {


	private Rigidbody rb;
	private Vector3 clickPosition;
	[SerializeField]
	private float jumpPower = 20;
	private bool isCanJump;

	private GameObject childObject;


	// Start is called before the first frame update
	void Start() {

		rb = gameObject.GetComponent<Rigidbody>();
		childObject = transform.GetChild(0).gameObject;

	}

	// Update is called once per frame
	void Update() {

		///- トリガー時の座標を取得
		if (Input.GetMouseButtonDown(0)) {
			clickPosition = Input.mousePosition;
		}

		///- リリース時速度の計算
		if (isCanJump && Input.GetMouseButtonUp(0)) {
			isCanJump = false;

			Vector3 dist = clickPosition - Input.mousePosition;

			///- クリックとリリースが同じ座標なら無視
			if (dist.sqrMagnitude == 0) { return; }

			rb.velocity = dist.normalized * jumpPower;

		}

		childObject.SetActive(isCanJump);

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

		///- 上方向と法線の内積; 二つのベクトルはともに長さが1なのでcosθの結果がdotUN変数に入る
		float dotUN = 0.0f;
		if (Physics.gravity.y > 0.0f) { ///- 重力が上方向
			dotUN = Vector3.Dot(Vector3.down, otherNormal);
		} else { ///- 重力が下方向
			dotUN = Vector3.Dot(Vector3.up, otherNormal);
		}
		///- 内積値に逆三角関数arccosをかけて角度を算出A; それを度数方へ変換する
		float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;

		///- 二つのベクトルがなす角度がn度より小さければ再びジャンプ可能とする
		if (dotDeg <= 60.0f) {
			isCanJump = true;
		}

	}

	/// <summary>
	/// 離れたとき
	/// </summary>
	private void OnCollisionExit(Collision collision) {


		//isCanJump = false;
	}






}
