using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacterium : MonoBehaviour {

	public BacteriumType type = BacteriumType.COCCUS;
	SpriteRenderer spriteRenderer;
	Rigidbody2D rb;
	PolygonCollider2D polyColl;

	Vector2 posChange;

	float speed = 0.0f;

	// Use this for initialization
	void Start () {
		spriteRenderer = this.GetComponent<SpriteRenderer>();
		rb = this.GetComponent<Rigidbody2D>();  

		posChange = new Vector2(1.0f, 1.0f);

		switch (type)
		{
			case BacteriumType.COCCUS:
				speed = BacteriaData.COCCUS_SPEED;
				spriteRenderer.sprite = Resources.Load<Sprite>("sprites/Coccus");
				break;
			case BacteriumType.DIPLOCOCCI:
				speed = BacteriaData.DIPLOCOCCI_SPEED;
				spriteRenderer.sprite = Resources.Load<Sprite>("sprites/Diplococci");
				break;
			case BacteriumType.TETRAD:
				speed = BacteriaData.TETRAD_SPEED;
				spriteRenderer.sprite = Resources.Load<Sprite>("sprites/Tetrad");
				break;
			case BacteriumType.BACILLUS:
				speed = BacteriaData.BACILLUS_SPEED;
				spriteRenderer.sprite = Resources.Load<Sprite>("sprites/Bacillus");
				break;
			case BacteriumType.DIPLOBACILLI:
				speed = BacteriaData.DIPLOBACILLI_SPEED;
				spriteRenderer.sprite = Resources.Load<Sprite>("sprites/Diplobacilli");
				break;
			case BacteriumType.PALISADES:
				speed = BacteriaData.PALISADES_SPEED;
				spriteRenderer.sprite = Resources.Load<Sprite>("sprites/Palisades");
				break;
			case BacteriumType.STREPTOBACILLI:
				speed = BacteriaData.STREPTOBACILLI_SPEED;
				spriteRenderer.sprite = Resources.Load<Sprite>("sprites/Streptobacilli");
				break;
		}

		Destroy(this.gameObject.GetComponent<PolygonCollider2D>());

		polyColl = this.gameObject.AddComponent<PolygonCollider2D>();

		polyColl.autoTiling = true;
		polyColl.usedByComposite = true;

		posChange.Scale(new Vector2(speed, speed));
	}
	
	// Update is called once per frame
	void Update () {
		if (!PlayerController.isDead)
		{
			rb.AddForce(posChange);
		}
	}
		
	void OnCollisionEnter2D(Collision2D coll) {
		posChange = new Vector2(Random.Range(-10.0f, 10.0f)/9.5f, Random.Range(-10.0f, 10.0f)/10.0f);
		posChange.Scale(new Vector2(speed, speed));
	}

	void OnTriggerExit2D() {
		Destroy(this.gameObject);
	}
}