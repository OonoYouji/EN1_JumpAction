using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class PullingJump : MonoBehaviour {


	private Rigidbody rb; //- 
	private Vector3 clickPosition; //- �N���b�N�������W
	[SerializeField]
	private float jumpPower; //- �W�����v�̋���
	private bool[] isCanJumps = { true, true }; //- �W�����v�\���ǂ���

	///- player�̎q�I�u�W�F�N�g
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

		///- �g���K�[���̍��W���擾
		if (Input.GetMouseButtonDown(0)) {
			clickPosition = Input.mousePosition;

			///- �W�����v�\�ł���Έړ����~������
			if (IsCanJump(isCanJumps)) {
				rb.isKinematic = true;
			}
		}

		///- �����[�X�����x�̌v�Z
		if (IsCanJump(isCanJumps) && Input.GetMouseButtonUp(0)) {

			///- �ړ����ĊJ������
			rb.isKinematic = false;

			SetIsCanJump(isCanJumps, false);

			Vector3 dist = clickPosition - Input.mousePosition;

			///- �N���b�N�ƃ����[�X���������W�Ȃ疳��
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
	/// �Փ˂����u��
	/// </summary>
	private void OnCollisionEnter(Collision collision) {

	}

	/// <summary>
	/// �Փ˂��Ă����
	/// </summary>
	private void OnCollisionStay(Collision collision) {

		///- �Փ˂��Ă���_�̏�񂪕����i�[����Ă���
		ContactPoint[] contacts = collision.contacts;

		///- 0�Ԗڂ̏Փˏ�񂩂�A�Փ˂��Ă���_�̖@�����擾
		Vector3 otherNormal = contacts[0].normal;

		///- ������Ɩ@���̓���; ��̃x�N�g���͂Ƃ��ɒ�����1�Ȃ̂�cos�Ƃ̌��ʂ�dotUN�ϐ��ɓ���
		float dotUN = 0.0f;
		if (Physics.gravity.y > 0.0f) { ///- �d�͂������
			dotUN = Vector3.Dot(Vector3.down, otherNormal);
		} else { ///- �d�͂�������
			dotUN = Vector3.Dot(Vector3.up, otherNormal);
		}
		///- ���ϒl�ɋt�O�p�֐�arccos�������Ċp�x���Z�oA; �����x�����֕ϊ�����
		float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;

		///- ��̃x�N�g�����Ȃ��p�x��n�x��菬������΍ĂуW�����v�\�Ƃ���
		if (dotDeg <= 60.0f) {

			for (int i = 0; i < contacts.Length; i++) {
				SetIsCanJump(isCanJumps, true);
			}

		}

	}

	/// <summary>
	/// ���ꂽ�Ƃ�
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
