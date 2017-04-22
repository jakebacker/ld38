using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacterium : MonoBehaviour {

	public BacteriumType type = BacteriumType.COCCUS;
	SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = this.GetComponent<SpriteRenderer>();

		switch (type)
		{
			case BacteriumType.COCCUS:
				spriteRenderer.sprite = Resources.Load<Sprite>("sprites/Coccus");
				break;
			case BacteriumType.DIPLOCOCCI:
				spriteRenderer.sprite = Resources.Load<Sprite>("sprites/Diplococci");
				break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
