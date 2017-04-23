using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBacteriaRotater : MonoBehaviour {

	Image image;
	Color color;

	// Use this for initialization
	void Start () {
		image = this.gameObject.GetComponent<Image>();
		color = this.gameObject.GetComponent<Color>();
		SetVisability(false);
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0, 0, -0.1f));
	}

	public static void SetSprite(BacteriumType type) {
		switch (type)
		{
			case BacteriumType.COCCUS:
				image.sprite = Resources.Load<Sprite>("sprites/Coccus");
				break;
			case BacteriumType.DIPLOCOCCI:
				image.sprite = Resources.Load<Sprite>("sprites/Diplococci");
				break;
			case BacteriumType.TETRAD:
				image.sprite = Resources.Load<Sprite>("sprites/Tetrad");
				break;
			case BacteriumType.BACILLUS:
				image.sprite = Resources.Load<Sprite>("sprites/Bacillus");
				break;
			case BacteriumType.DIPLOBACILLI:
				image.sprite = Resources.Load<Sprite>("sprites/Diplobacilli");
				break;
			case BacteriumType.PALISADES:
				image.sprite = Resources.Load<Sprite>("sprites/Palisades");
				break;
			case BacteriumType.STREPTOBACILLI:
				image.sprite = Resources.Load<Sprite>("sprites/Streptobacilli");
				break;
		}
		SetVisability(true);
	}

	public void SetVisability(bool setEnabled) {
		if (setEnabled)
		{
			color.a = 255;
		}
		else
		{
			color.a = 0;
		}
	}
}
