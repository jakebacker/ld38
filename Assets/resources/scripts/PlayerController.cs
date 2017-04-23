using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
	Rigidbody2D rb;
	static Text healthText;
	static Text timeoutText;
	static Text timeText;
	static int health = 100;
	public static float timeout = 5.0f;
	float deathTime;
	public static bool isDead;

	GameObject diedObject;

	AudioSource hitSound;
	AudioClip deathSound;

	// Use this for initialization
	void Start()
	{

		health = 100;
		timeout = 5.0f;
		isDead = false;
		rb = this.gameObject.GetComponent<Rigidbody2D>();
		healthText = GameObject.Find("Health").GetComponentInChildren<Text>();
		timeoutText = GameObject.Find("Timeout").GetComponentInChildren<Text>();
		timeText = GameObject.Find("TimeSpent").GetComponentInChildren<Text>();

		diedObject = GameObject.Find("DiedObject");

		GameObject.Find("Restart").GetComponent<Button>().onClick.AddListener(WorldController.ReloadScene);
		GameObject.Find("Quit").GetComponent<Button>().onClick.AddListener(Application.Quit);

		diedObject.SetActive(false);

		hitSound = this.gameObject.GetComponent<AudioSource>();
		deathSound = Resources.Load<AudioClip>("sounds/die");

		UpdateUI();
	}
	
	// Update is called once per frame
	void Update()
	{
		if (!isDead)
		{
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3 newPos = new Vector3(mousePos.x, mousePos.y, 0);

			Collider2D coll = Physics2D.OverlapPoint(new Vector2(newPos.x, newPos.y));

			if (coll != null)
			{
				if (coll.gameObject.tag == "PetriDish")
				{
					rb.MovePosition(newPos);
				}
			}

			UpdateUI();
		}
	}

	void Damage(int amount) {
		if (!isDead)
		{
			hitSound.Play();
			health -= amount;
			if (health <= 0)
			{
				deathTime = Time.timeSinceLevelLoad;
				isDead = true;
				Die();
			}
			UpdateUI();
		}
	}

	public void Die() {
		hitSound.PlayOneShot(deathSound);
		diedObject.SetActive(true);
		diedObject.transform.FindChild("Score").gameObject.GetComponent<Text>().text = "Survived: " + deathTime + "s";
	}

	public static void UpdateUI() {
		healthText.text = "Health: " + health;
		timeoutText.text = "Timeout: " + timeout;
		timeText.text = "Time Spent Playing: " + Time.timeSinceLevelLoad;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Bacteria")
		{
			Debug.Log("Coll");
			Damage(1);
		}
	}
}

