using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacterium : MonoBehaviour {

	public BacteriumType type = BacteriumType.COCCUS;
	SpriteRenderer spriteRenderer;
	Rigidbody2D rb;
	PolygonCollider2D polyColl;
	public double size = 0.0;
	public double cost = 0.0;
	public double power = 0.0;

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
				size = BacteriaData.COCCUS_SIZE;
				cost = BacteriaData.COCCUS_COST;
				power = BacteriaData.COCCUS_POWER;
				speed = BacteriaData.COCCUS_SPEED;
				spriteRenderer.sprite = Resources.Load<Sprite>("sprites/Coccus");
				break;
			case BacteriumType.DIPLOCOCCI:
				size = 1.0;
				cost = 5.4;
				power = 0.25;
				speed = 0.5f;
				spriteRenderer.sprite = Resources.Load<Sprite>("sprites/Diplococci");
				break;
			case BacteriumType.BACILLUS:
				size = 0.3;
				cost = 6.0;
				power = 0.3;
				speed = 1.1f;
				spriteRenderer.sprite = Resources.Load<Sprite>("sprites/Bacillus");
				break;
		}

		if (Values.micrometers - size < 0.0 || Values.bacteriaPower - cost < 0.0)
		{
			StopAllCoroutines();
			Destroy(this.gameObject);
		} else {
			Values.micrometers -= size;
			Values.bacteriaPower -= cost;
		}

		Destroy(this.gameObject.GetComponent<PolygonCollider2D>());

		polyColl = this.gameObject.AddComponent<PolygonCollider2D>();

		polyColl.autoTiling = true;
		polyColl.usedByComposite = true;

		posChange.Scale(new Vector2(speed, speed));
		StartCoroutine("GeneratePower");
	}
	
	// Update is called once per frame
	void Update () {
		rb.AddForce(posChange);
	}
		
	void OnCollisionEnter2D(Collision2D coll) {
		posChange = new Vector2(Random.Range(-10.0f, 10.0f)/10.0f, Random.Range(-10.0f, 10.0f)/10.0f);
		posChange.Scale(new Vector2(speed, speed));
	}

	void OnTriggerExit2D() {
		Destroy(this.gameObject);
	}

	void OnMouseDown() {
		Debug.Log("Mouse Down!");
	}

	IEnumerator GeneratePower() {
		while (true)
		{
			yield return new WaitForSeconds(1.0f);
			Values.bacteriaPower += power;
		}
	}
}