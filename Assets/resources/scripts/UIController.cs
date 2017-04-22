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
			ButtonPressed(buttonObject.GetComponent<UIType>().type);
		});
	}

	public void ButtonPressed(BacteriumType type) {
		Instantiate(Resources.Load<GameObject>("prefabs/Bacteria")).GetComponent<Bacterium>().type = type;
	}
}
