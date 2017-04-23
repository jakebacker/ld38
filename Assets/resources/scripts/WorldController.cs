using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldController : MonoBehaviour {

	public static CircleCollider2D petriColl;

	static AudioSource spawnSound;

	// Use this for initialization
	void Start () {
		petriColl = GameObject.Find("PetriDish").GetComponentInChildren<CircleCollider2D>();
		spawnSound = this.gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void SpawnBacteria(BacteriumType type, Vector3 position) {
		if (!PlayerController.isDead)
		{
			spawnSound.Play();
			GameObject bacteria = Instantiate(Resources.Load<GameObject>("prefabs/Bacteria"));
			Bacterium bacteriaScript = bacteria.GetComponent<Bacterium>();

			bacteriaScript.gameObject.transform.position = position;
			bacteriaScript.type = type;
		}
	}

	public static void SpawnBacteria(BacteriumType type) {
		SpawnBacteria(type, new Vector3(0, 0, 0));
	}

	public static void ReloadScene() {
		SceneManager.LoadScene("_SCENE");
	}
}
