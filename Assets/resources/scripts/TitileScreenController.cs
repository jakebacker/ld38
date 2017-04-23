using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitileScreenController : MonoBehaviour {

	Button playButton;
	Button quitButton;

	// Use this for initialization
	void Start () {
		playButton = GameObject.Find("PlayButton").GetComponent<Button>();
		quitButton = GameObject.Find("QuitButton").GetComponent<Button>();

		playButton.onClick.AddListener(delegate {
			SceneManager.LoadScene("_SCENE");
		});

		quitButton.onClick.AddListener(Application.Quit);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
