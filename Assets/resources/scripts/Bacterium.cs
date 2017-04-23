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
				size = BacteriaData.DIPLOCOCCI_SIZE;
				cost = BacteriaData.DIPLOCOCCI_COST;
				power = BacteriaData.DIPLOCOCCI_POWER;
				speed = BacteriaData.DIPLOCOCCI_SPEED;
				spriteRenderer.sprite = Resources.Load<Sprite>("sprites/Diplococci");
				break;
			case BacteriumType.TETRAD:
				size = BacteriaData.TETRAD_SIZE;
				cost = BacteriaData.TETRAD_COST;
				power = BacteriaData.TETRAD_POWER;
				speed = BacteriaData.TETRAD_SPEED;
				spriteRenderer.sprite = Resources.Load<Sprite>("sprites/Tetrad");
				break;
			case BacteriumType.BACILLUS:
				size = BacteriaData.BACILLUS_SIZE;
				cost = BacteriaData.BACILLUS_COST;
				power = BacteriaData.BACILLUS_POWER;
				speed = BacteriaData.BACILLUS_SPEED;
				spriteRenderer.sprite = Resources.Load<Sprite>("sprites/Bacillus");
				break;
			case BacteriumType.DIPLOBACILLI:
				size = BacteriaData.DIPLOBACILLI_SIZE;
				cost = BacteriaData.DIPLOBACILLI_COST;
				power = BacteriaData.DIPLOBACILLI_POWER;
				speed = BacteriaData.DIPLOBACILLI_SPEED;
				spriteRenderer.sprite = Resources.Load<Sprite>("sprites/Diplobacilli");
				break;
			case BacteriumType.PALISADES:
				size = BacteriaData.PALISADES_SIZE;
				cost = BacteriaData.PALISADES_COST;
				power = BacteriaData.PALISADES_POWER;
				speed = BacteriaData.PALISADES_SPEED;
				spriteRenderer.sprite = Resources.Load<Sprite>("sprites/Palisades");
				break;
			case BacteriumType.STREPTOBACILLI:
				size = BacteriaData.STREPTOBACILLI_SIZE;
				cost = BacteriaData.STREPTOBACILLI_COST;
				power = BacteriaData.STREPTOBACILLI_POWER;
				speed = BacteriaData.STREPTOBACILLI_SPEED;
				spriteRenderer.sprite = Resources.Load<Sprite>("sprites/Streptobacilli");
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
		if (this.gameObject.name != "OriginalBacteria")
		{
			Values.micrometers += size;
			Destroy(this.gameObject);
		}
	}

	IEnumerator GeneratePower() {
		while (true)
		{
			yield return new WaitForSeconds(1.0f);
			Values.bacteriaPower += power;
		}
	}
}