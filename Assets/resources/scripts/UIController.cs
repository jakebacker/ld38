using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AddButton(GameObject.Find("SpawnCoccus"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddButton(GameObject buttonObject) {
		Button button = buttonObject.GetComponent<Button>();
		if (button == null)
		{
			return;
		}
		button.onClick.AddListener(delegate {
			ButtonPressed(button.name);
		});
	}

	public void ButtonPressed(string name) {
		Debug.Log(name);
	}
}
