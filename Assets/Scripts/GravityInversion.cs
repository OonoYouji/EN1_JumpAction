using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GravityInversion : MonoBehaviour {

	private Animator animator;
	private int nextAnimationIndex;

	// Start is called before the first frame update
	void Start() {
		animator = GetComponent<Animator>();
		nextAnimationIndex = 0; 
	}

	// Update is called once per frame
	void Update() {

	}

	/// --------------------------------------------------------------
	/// Å´ è’ìÀîªíË
	/// --------------------------------------------------------------

	/// <summary>
	/// è’ìÀÇµÇΩèuä‘
	/// </summary>
	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			Physics.gravity *= -1.0f;

			if(nextAnimationIndex == 0) {
				nextAnimationIndex++;
			} else {
				nextAnimationIndex--;
			}

			animator.SetTrigger("OnTriggerEnter");
			animator.SetInteger("NextAnimation", nextAnimationIndex);
		}
	}

}
