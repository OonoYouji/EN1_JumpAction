using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour {

	Animator animator;
	AudioSource audioSource;
	bool isGet;

	// Start is called before the first frame update
	void Start() {
		animator = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
		isGet = false;
	}

	// Update is called once per frame
	void Update() {

	}


	///// ------------------------------------------------
	///// Not IsTrigger Collision Methods
	///// ------------------------------------------------

	/// <summary>
	/// ê⁄êGéû
	/// </summary>
	private void OnTriggerEnter(Collider other) {
		animator.SetTrigger("Get");
		audioSource.Play();
		if (!isGet) {
			other.GetComponent<PullingJump>().AddGetCount();
			isGet = true;
		}
	}

	/// <summary>
	/// ê⁄êGíÜ
	/// </summary>
	private void OnTriggerStay(Collider other) {

	}

	/// <summary>
	/// ó£ÇÍÇΩÇ∆Ç´
	/// </summary>
	private void OnTriggerExit(Collider other) {

	}




	///// ------------------------------------------------
	///// Member Methods
	///// ------------------------------------------------

	/// <summary>
	/// é©êgÇè¡ñ≈Ç≥ÇπÇÈ
	/// </summary>
	private void DestroySelf() {
		Destroy(gameObject);
	}

	public bool GetIsGet() { return isGet; }

}
