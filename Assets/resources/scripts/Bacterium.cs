using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacterium : MonoBehaviour {

	public BacteriumType type = BacteriumType.COCCUS;
	SpriteRenderer spriteRenderer;
	Rigidbody2D rb;
	public double size = 0.0;

	Vector2 posChange;

	float speed = 0.0f;

	// Use this for initialization
	void Start () {
		spriteRenderer = this.GetComponent<SpriteRenderer>();
		rb = this.GetComponent<Rigidbody2D>();

		posChange = new Vector2(1.0f, 1.0f);

		if (Values.micrometers - size < 0.0)
		{
			Destroy(this.gameObject);
		} else {
			Values.micrometers -= size;
		}
			
		switch (type)
		{
			case BacteriumType.COCCUS:
				size = 0.5;
				speed = 1.0f;
				spriteRenderer.sprite = Resources.Load<Sprite>("sprites/Coccus");
				break;
			case BacteriumType.DIPLOCOCCI:
				size = 1.0;
				speed = 0.5f;
				spriteRenderer.sprite = Resources.Load<Sprite>("sprites/Diplococci");
				break;
			case BacteriumType.BACILLUS:
				size = 0.3;
				speed = 1.1f;
				spriteRenderer.sprite = Resources.Load<Sprite>("sprites/Bacillus");
				break;
		}

		posChange.Scale(new Vector2(speed, speed));
	}
	
	// Update is called once per frame
	void Update () {
		rb.AddForce(posChange);
	}
		
	void OnCollisionEnter2D(Collision2D coll) {
		Debug.Log("Collided with: " + coll.gameObject.name);
		posChange = new Vector2(Random.Range(-10.0f, 10.0f)/10.0f, Random.Range(-10.0f, 10.0f)/10.0f);
		posChange.Scale(new Vector2(speed, speed));
		Debug.Log("New Speed: " + posChange);
	}
}