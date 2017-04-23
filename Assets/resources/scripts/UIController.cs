using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour {

	Text micrometersAvail;
	Text bacteriaPower;
	public GameObject[] buttons;
	public GameObject upgradeButton1;
	public GameObject upgradeButton2;
	public GameObject destroyButton;
	public GameObject closeButton;
	public GameObject upgradeDescriptionParent;
	public Text upgradeDescription;
	GameObject descriptionParent;
	Text description;

	Bacterium currentBacteria;

	// Use this for initialization
	void Start () {
		micrometersAvail = GameObject.Find("Micrometers").GetComponent<Text>();
		bacteriaPower = GameObject.Find("BacteriaPower").GetComponent<Text>();

		descriptionParent = GameObject.Find("DescriptionBackground");
		description = descriptionParent.GetComponentInChildren<Text>();

		// TODO: Clean this mess up...
		upgradeButton1 = GameObject.Find("UpgradeButton1");
		upgradeButton2 = GameObject.Find("UpgradeButton2");
		destroyButton = GameObject.Find("DestroyButton");
		closeButton = GameObject.Find("CloseButton");
		upgradeDescriptionParent = GameObject.Find("UpgradeDescriptionBackground");
		upgradeDescription = upgradeDescriptionParent.GetComponentInChildren<Text>();

		foreach (GameObject b in buttons)
		{
			AddButton(b);
		}

		closeButton.GetComponent<Button>().onClick.AddListener(Close);
		destroyButton.GetComponent<Button>().onClick.AddListener(KillBacteria);
			
		Close();
		descriptionParent.SetActive(false);
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

	public void ShowDescription(BacteriumType type) {
		if (type == BacteriumType.COCCUS)
		{
			description.text = 
				"Size: " + BacteriaData.COCCUS_SIZE + "μm\n" +
				"Cost: " + BacteriaData.COCCUS_COST + "bp\n" +
				"Power: " + BacteriaData.COCCUS_POWER + "bpps\n" +
				"Speed: " + BacteriaData.COCCUS_SPEED;

		}
		else if (type == BacteriumType.DIPLOCOCCI)
		{
			description.text = 
				"Size: " + BacteriaData.DIPLOCOCCI_SIZE + "μm\n" +
				"Cost: " + BacteriaData.DIPLOCOCCI_COST + "bp\n" +
				"Power: " + BacteriaData.DIPLOCOCCI_POWER + "bpps\n" +
				"Speed: " + BacteriaData.DIPLOCOCCI_SPEED;
		}
		else if (type == BacteriumType.BACILLUS)
		{
			description.text = 
				"Size: " + BacteriaData.BACILLUS_SIZE + "μm\n" +
				"Cost: " + BacteriaData.BACILLUS_COST + "bp\n" +
				"Power: " + BacteriaData.BACILLUS_POWER + "bpps\n" +
				"Speed: " + BacteriaData.BACILLUS_SPEED;
		}
		else if (type == BacteriumType.TETRAD)
		{
			description.text = 
				"Size: " + BacteriaData.TETRAD_SIZE + "μm\n" +
				"Cost: " + BacteriaData.TETRAD_COST + "bp\n" +
				"Power: " + BacteriaData.TETRAD_POWER + "bpps\n" +
				"Speed: " + BacteriaData.TETRAD_SPEED;
		} else if (type == BacteriumType.DIPLOBACILLI)
		{
			description.text = 
				"Size: " + BacteriaData.DIPLOBACILLI_SIZE + "μm\n" +
				"Cost: " + BacteriaData.DIPLOBACILLI_COST + "bp\n" +
				"Power: " + BacteriaData.DIPLOBACILLI_POWER + "bpps\n" +
				"Speed: " + BacteriaData.DIPLOBACILLI_SPEED;
		} else if (type == BacteriumType.PALISADES)
		{
			description.text = 
				"Size: " + BacteriaData.PALISADES_SIZE + "μm\n" +
				"Cost: " + BacteriaData.PALISADES_COST + "bp\n" +
				"Power: " + BacteriaData.PALISADES_POWER + "bpps\n" +
				"Speed: " + BacteriaData.PALISADES_SPEED;
		} else if (type == BacteriumType.STREPTOBACILLI)
		{
			description.text = 
				"Size: " + BacteriaData.STREPTOBACILLI_SIZE + "μm\n" +
				"Cost: " + BacteriaData.STREPTOBACILLI_COST + "bp\n" +
				"Power: " + BacteriaData.STREPTOBACILLI_POWER + "bpps\n" +
				"Speed: " + BacteriaData.STREPTOBACILLI_SPEED;
		}
	}

	private void KillBacteria() {
		if (currentBacteria != null)
		{
			Destroy(currentBacteria.gameObject);
			Close();
		}
	}

	private static void ShowUpgradeButtons(Bacterium bacteria) {
		// Enable buttons and set data

		if (bacteria.type == BacteriumType.COCCUS || // These are all types that split into 2 things
		    bacteria.type == BacteriumType.DIPLOCOCCI ||
		    bacteria.type == BacteriumType.TETRAD ||
		    bacteria.type == BacteriumType.DIPLOBACILLI)
		{
			this.upgradeButton2.SetActive(true);
		}
		this.upgradeButton1.SetActive(true);

		switch (bacteria.type)
		{
			case BacteriumType.COCCUS:
				this.upgradeButton1.GetComponent<UIType>().type = BacteriumType.DIPLOCOCCI;
		}
	}

	private static void ShowRemoveButton(Bacterium bacteria) {
		
	}

	public static void ShowUpgradeWindow(Bacterium bacteria) {
		ShowUpgradeButtons(bacteria);
		ShowRemoveButton(bacteria);
		this.upgradeDescriptionParent.SetActive(true);
		this.closeButton.SetActive(true);
		this.currentBacteria = bacteria;
	}

	public void Close() {
		upgradeButton1.SetActive(false);
		upgradeButton2.SetActive(false);
		destroyButton.SetActive(false);
		upgradeDescriptionParent.SetActive(false);
		closeButton.SetActive(false);
	}

	public void ButtonHover(BaseEventData data) {

		PointerEventData pointerData = (PointerEventData)data;

		GameObject button = pointerData.pointerEnter.transform.parent.gameObject; 

		UIType type = button.GetComponent<UIType>();

		ShowDescription(type.type);
		descriptionParent.SetActive(true);
	}

	public void UpgradeButtonHover(BaseEventData data) {
		PointerEventData pointerData = (BaseEventData)data;

		GameObject button = pointerData.pointerEnter.transform.parent.gameObject;
	}

	public void ButtonExit() {
		descriptionParent.SetActive(false);
	}
}
