using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	Text micrometersAvail;

	// Use this for initialization
	void Start () {
		micrometersAvail = GameObject.Find("Micrometers").GetComponent<Text>();
		AddButton(GameObject.Find("SpawnCoccus"));
	}
	
	// Update is called once per frame
	void Update () {
		micrometersAvail.text = "Micrometers available: " + Values.micrometers + "μm";
	}

	public void AddButton(GameObject buttonObject) {
		Button button = buttonObject.GetComponent<Button>();
		if (button == null)
		{
			return;
		}
		button.onClick.AddListener(delegate {
			ButtonPressed(buttonObject.GetComponent<UIType>().type);
		});
	}

	public void ButtonPressed(BacteriumType type) {
		WorldController.SpawnBacteria(type);
	}
}
