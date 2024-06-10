using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step : MonoBehaviour {

	private Renderer material;
	private int materialIndex = 0;
	private float rotateZ;

	// Start is called before the first frame update
	void Start() {
		material = GetComponent<Renderer>();
		rotateZ = gameObject.transform.rotation.eulerAngles.z;
	}

	// Update is called once per frame
	void Update() {

		if (gameObject.transform.rotation.z < 0.0f) {
			rotateZ = -gameObject.transform.rotation.eulerAngles.z;
		} else {
			rotateZ = gameObject.transform.rotation.eulerAngles.z;
		}

		if (rotateZ > 60.0f) {
			if (material != null && material.materials.Length > materialIndex) {
				material.materials[materialIndex].color = Color.gray;
			}
		}
	}


}
