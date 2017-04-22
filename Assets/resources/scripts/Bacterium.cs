using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacterium : MonoBehaviour {

	public BacteriumType type = BacteriumType.COCCUS;
	SpriteRenderer spriteRenderer;
	public double size = 1.0;

	// Use this for initialization
	void Start () {
		size = 1.0;
		spriteRenderer = this.GetComponent<SpriteRenderer>();

		switch (type)
		{
			case BacteriumType.COCCUS:
				size = 0.5;
				spriteRenderer.sprite = Resources.Load<Sprite>("sprites/Coccus");
				break;
			case BacteriumType.DIPLOCOCCI:
				size = 1.0;
				spriteRenderer.sprite = Resources.Load<Sprite>("sprites/Diplococci");
				break;
		}

		if (Values.micrometers - size < 0.0)
		{
			Destroy(this.gameObject);
		} else {
			Values.micrometers -= size;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
