using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour {

	Camera cam;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		float axis = -Input.GetAxisRaw("MouseScrollWheel");
		if (cam.orthographicSize + axis > 0 && cam.orthographicSize + axis <= 30) {
			cam.orthographicSize += axis;
		}
	}

	public static void SpawnBacteria(BacteriumType type) {
		GameObject bacteria = Instantiate(Resources.Load<GameObject>("prefabs/Bacteria"));
		Bacterium bacteriaScript = bacteria.GetComponent<Bacterium>();

		bacteriaScript.type = type;
	}
}
