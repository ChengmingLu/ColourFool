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
    }
}
