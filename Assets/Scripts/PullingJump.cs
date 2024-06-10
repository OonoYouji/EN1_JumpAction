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

		///- �g���K�[���̍��W���擾
		if (Input.GetMouseButtonDown(0)) {
			clickPosition = Input.mousePosition;
		}

		///- �����[�X�����x�̌v�Z
		if (isCanJump && Input.GetMouseButtonUp(0)) {
			isCanJump = false;

			Vector3 dist = clickPosition - Input.mousePosition;

			///- �N���b�N�ƃ����[�X���������W�Ȃ疳��
			if (dist.sqrMagnitude == 0) { return; }

			rb.velocity = dist.normalized * jumpPower;

		}

	}



	///// ------------------------------------------------
	///// Collision Methods
	///// ------------------------------------------------

	/// <summary>
	/// �Փ˂����u��
	/// </summary>
	private void OnCollisionEnter(Collision collision) {
		//Debug.Log("�Փ˂���");
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
		float dotUN = Vector3.Dot(Vector3.up, otherNormal);
		///- ���ϒl�ɋt�O�p�֐�arccos�������Ċp�x���Z�oA; �����x�����֕ϊ�����
		float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;

		///- ��̃x�N�g�����Ȃ��p�x��45�x��菬������΍ĂуW�����v�\�Ƃ���
		if (dotDeg <= 60.0f) {
			isCanJump = true;
		}

	}

	/// <summary>
	/// ���ꂽ�Ƃ�
	/// </summary>
	private void OnCollisionExit(Collision collision) {


		//isCanJump = false;
	}





	
}
