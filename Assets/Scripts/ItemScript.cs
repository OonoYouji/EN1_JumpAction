using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour {

	private Animator animator;
	private AudioSource audioSource;

	// Start is called before the first frame update
	void Start() {
		animator = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
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
		//DestroySelf();
		animator.SetTrigger("Get");
		audioSource.Play();
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
