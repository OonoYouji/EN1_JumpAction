using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class ItemGetCountScript : MonoBehaviour {

	TextMeshProUGUI text;
	int getCount;

	///// -----------------------------------------------------------
	///// Å´ default method
	///// -----------------------------------------------------------

	/// <summary>
	/// initialize method
	/// </summary>
	void Start() {
		getCount = 0;
		text = gameObject.GetComponent<TextMeshProUGUI>();
	}

	/// <summary>
	/// update method
	/// </summary>
	void Update() {
		text.text = "Count: " + getCount.ToString();
	}


	///// -----------------------------------------------------------
	///// Å´ user method
	///// -----------------------------------------------------------
	public void AddCount() {
		++getCount; //- â¡éZ
	}

}
