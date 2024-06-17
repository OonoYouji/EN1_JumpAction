using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class PullingJump : MonoBehaviour {


	private Rigidbody rb; //- 
	private Vector3 clickPosition; //- クリックした座標
	[SerializeField]
	private float jumpPower; //- ジャンプの強さ
	private bool[] isCanJumps = { true, true }; //- ジャンプ可能かどうか

	///- playerの子オブジェクト
	private GameObject childObject;

	[SerializeField]
	ItemGetCountScript itemGetCount;

	[SerializeField]
	ResetScript resetScript;
	int deathTime;
	

	///// ---------------------------------------------------------------------------
	///// Default Methods
	///// ---------------------------------------------------------------------------

	/// <summary>
	/// Initialize method
	/// </summary>
	void Start() {
		rb = gameObject.GetComponent<Rigidbody>();
		childObject = transform.GetChild(0).gameObject;
		deathTime = 60;
	}

	/// <summary>
	/// Update method
	/// </summary>
	void Update() {

		///- トリガー時の座標を取得
		if (Input.GetMouseButtonDown(0)) {
			clickPosition = Input.mousePosition;

			///- ジャンプ可能であれば移動を停止させる
			if (IsCanJump(isCanJumps)) {
				rb.isKinematic = true;
			}
		}

		///- リリース時速度の計算
		if (IsCanJump(isCanJumps) && Input.GetMouseButtonUp(0)) {

			///- 移動を再開させる
			rb.isKinematic = false;

			SetIsCanJump(isCanJumps, false);

			Vector3 dist = clickPosition - Input.mousePosition;

			///- クリックとリリースが同じ座標なら無視
			if (dist.sqrMagnitude == 0) { return; }

			rb.velocity = dist.normalized * jumpPower;

		}

		childObject.SetActive(IsCanJump(isCanJumps));

		if (transform.position.y < 0) {
			if (--deathTime < 0) {
				resetScript.ResetAll();
			}
		}

	}



	///// ---------------------------------------------------------------------------
	///// Collision Methods
	///// ---------------------------------------------------------------------------

	/// <summary>
	/// 衝突した瞬間
	/// </summary>
	private void OnCollisionEnter(Collision collision) {

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

			for (int i = 0; i < contacts.Length; i++) {
				SetIsCanJump(isCanJumps, true);
			}

		}

	}

	/// <summary>
	/// 離れたとき
	/// </summary>
	private void OnCollisionExit(Collision collision) {


		//isCanJumps = false;
	}


	///// ---------------------------------------------------------------------------
	///// User Methods
	///// ---------------------------------------------------------------------------

	bool IsCanJump(bool[] isCanJumps) {

		int max = isCanJumps.Length;
		for (int i = 0; i < max; ++i) {
			if (isCanJumps[i]) {
				return true;
			}
		}

		return false;
	}

	void SetIsCanJump(bool[] isCanJumps, bool isCanJump) {
		bool inverse = !isCanJump;
		int max = isCanJumps.Length;

		for (int i = 0; i < max; ++i) {
			if (isCanJumps[i] == inverse) {
				isCanJumps[i] = isCanJump;
				return;
			}
		}

	}


	public void AddGetCount() {
		itemGetCount.AddCount();
	}


}
