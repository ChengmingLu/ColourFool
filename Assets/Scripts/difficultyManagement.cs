using UnityEngine;
using System.Collections;

public class difficultyManagement : MonoBehaviour {
    private int setWidth;
    private int setHeight;
	// Use this for initialization
	void Start () {
        setHeight = gameObject.GetComponent<difficulty>().height;
        setWidth = gameObject.GetComponent<difficulty>().width;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown() {
        Debug.Log("clicked");
        blockSpawner.spawnSizeHor = setWidth;
        blockSpawner.spawnSizeVer = setHeight;
        gameObject.transform.parent.gameObject.GetComponentInChildren<loadLevel>().loadNext();
        if (setWidth <= 6 || setHeight <= 6) {
            TimerScript.timeCounter = 30;
        } else if (setWidth <= 9 || setHeight <= 9) {
            TimerScript.timeCounter = 45;
        } else {
            TimerScript.timeCounter = 60;
        }
    }
}
