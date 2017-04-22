using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacterium : MonoBehaviour {

	public BacteriumType type = BacteriumType.COCCUS;
	SpriteRenderer spriteRenderer;
	public double size = 0.0;

	// Use this for initialization
	void Start () {
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
			case BacteriumType.BACILLUS:
				size = 0.3;
				spriteRenderer.sprite = Resources.Load<Sprite>("sprites/Bacillus");
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
		if (this.tag == "Bacteria") {
			transform.position += new Vector3(0.01f, 0.0f, 0.0f);
		}
	}


	void OnCollisionEnter2D(Collision2D coll) {
		Debug.Log("Collided with: " + coll.gameObject.name);
	}
}
