using UnityEngine;
using System.Collections;

public class restartScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown() {
        scoreHandler.scoreDisplay = 0;
        gameObject.transform.parent.gameObject.GetComponentInChildren<loadLevel>().loadIndex(0);
    }
}
