using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;



public class ArrowDraw : MonoBehaviour {

	[SerializeField]
	private Image arrowImage;
	private Vector3 clickPosition;

	// Start is called before the first frame update
	void Start() {
		arrowImage.gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update() {

		///- �N���b�N�����^�C�~���O�̍��W���擾
		if (Input.GetMouseButtonDown(0)) {
			clickPosition = Input.mousePosition;
			arrowImage.gameObject.SetActive(true);
		}

		///- �����Ă���Ԗ��̉摜����]������
		if (Input.GetMouseButton(0)) {
			Vector3 dist = clickPosition - Input.mousePosition;

			//- �x�N�g���̒����𒊏o
			float size = dist.magnitude;

			//- �x�N�g������p�x���Z�o
			float angleRad = Mathf.Atan2(dist.y, dist.x);

			//- ���̉摜���N���b�N�����ꏊ�Ɉړ�
			arrowImage.rectTransform.position = clickPosition;
			//- ���̉摜���x�N�g������Z�o�����p�x��x�����ɕϊ�����Z����]
			arrowImage.rectTransform.rotation =
				Quaternion.Euler(0, 0, angleRad * Mathf.Rad2Deg);

			//- ���̉摜�̑傫�����h���b�O���������ɍ��킹��
			arrowImage.rectTransform.sizeDelta = new Vector2(size, size);

		}


		///- ��������\�����Ȃ��悤�ɂ���
		if (Input.GetMouseButtonUp(0)) {
			arrowImage.gameObject.SetActive(false);
		}


	}
}
