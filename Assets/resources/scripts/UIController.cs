﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour {

	Text micrometersAvail;
	Text bacteriaPower;
	public GameObject[] buttons;
	GameObject descriptionParent;
	Text description;

	// Use this for initialization
	void Start () {
		micrometersAvail = GameObject.Find("Micrometers").GetComponent<Text>();
		bacteriaPower = GameObject.Find("BacteriaPower").GetComponent<Text>();

		descriptionParent = GameObject.Find("DescriptionBackground");
		description = descriptionParent.GetComponentInChildren<Text>();

		foreach (GameObject b in buttons)
		{
			AddButton(b);
		}
	}
	
	// Update is called once per frame
	void Update () {
		micrometersAvail.text = "Micrometers available: " + Values.micrometers + "μm";
		bacteriaPower.text = "Bacteria Power: " + Values.bacteriaPower;
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

	public void ButtonHover(BaseEventData data) {

		PointerEventData pointerData = (PointerEventData)data;

		GameObject button = pointerData.pointerEnter.transform.parent.gameObject; 

		UIType type = button.GetComponent<UIType>();

		if (type.type == BacteriumType.COCCUS)
		{
			description.text = 
				"Size: " + BacteriaData.COCCUS_SIZE + "μm\n" +
			"Cost: " + BacteriaData.COCCUS_COST + "bp\n" +
			"Power: " + BacteriaData.COCCUS_POWER + "bpps\n" +
			"Speed: " + BacteriaData.COCCUS_SPEED;

		}
		else if (type.type == BacteriumType.DIPLOCOCCI)
		{
			description.text = 
				"Size: " + BacteriaData.DIPLOCOCCI_SIZE + "μm\n" +
			"Cost: " + BacteriaData.DIPLOCOCCI_COST + "bp\n" +
			"Power: " + BacteriaData.DIPLOCOCCI_POWER + "bpps\n" +
			"Speed: " + BacteriaData.DIPLOCOCCI_SPEED;
		}
		else if (type.type == BacteriumType.BACILLUS)
		{
			description.text = 
				"Size: " + BacteriaData.BACILLUS_SIZE + "μm\n" +
				"Cost: " + BacteriaData.BACILLUS_COST + "bp\n" +
				"Power: " + BacteriaData.BACILLUS_POWER + "bpps\n" +
				"Speed: " + BacteriaData.BACILLUS_SPEED;
		}
		descriptionParent.SetActive(true);
	}

	public void ButtonExit() {
		descriptionParent.SetActive(false);
	}
}
