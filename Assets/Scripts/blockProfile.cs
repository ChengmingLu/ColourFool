using UnityEngine;
using System.Collections;

public class blockProfile : MonoBehaviour {
    public enum colourType {Black, Red, Yellow, Blue, Green, Pink};
    public colourType colourIs;
    public int horizontalIndex, verticalIndex;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public static void updateIndex() { 
        for (int i = 0; i < blockSpawner.blockObjects.GetLength(0); i++) {
            for (int j = 0; j < blockSpawner.blockObjects.GetLength(1); j++) {
                if (blockSpawner.blockObjects[i, j]) {
                    blockSpawner.blockObjects[i, j].GetComponent<blockProfile>().verticalIndex = i;
                    blockSpawner.blockObjects[i, j].GetComponent<blockProfile>().horizontalIndex = j;
                }
            }
        }
    }
}
