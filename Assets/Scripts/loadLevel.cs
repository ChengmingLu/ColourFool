using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class loadLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void loadNext() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void loadIndex(int index) {
        SceneManager.LoadScene(index);
    }
}
