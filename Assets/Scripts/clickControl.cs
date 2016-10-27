using UnityEngine;
using System.Collections;

public class clickControl : MonoBehaviour {
    public static GameObject selectedBlock1;
    public static GameObject selectedBlock2;
    //private int blockSpeed = 10;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown() {
        if (selectedBlock1 == null) {
            selectedBlock1 = gameObject;
            Debug.Log(selectedBlock1 + " is now the 1st selected");
        } else if (selectedBlock2 == null) {
            selectedBlock2 = gameObject;
            if (validateMove()) {
                swapBlocks();
                deselectAll();
                examineMatrix();
            }
            //Debug.Log(selectedBlock2 + " is now the 2nd selected");
        } else {
            deselectAll();
            selectedBlock1 = gameObject;
            Debug.Log("restart selection: selected 1 is: " + selectedBlock1);
        }
    }

    private void deselectAll() {
        if (selectedBlock1 && selectedBlock2) {
            selectedBlock1 = null;
            selectedBlock2 = null;
        } 
    }

    public static void examineMatrix() {
        for (int i = 0; i < blockSpawner.blockObjects.GetLength(0) - 1; i ++) {
            for (int j = 0; j < blockSpawner.blockObjects.GetLength(1) - 1; j++) {
                if (!blockSpawner.blockObjects[i, j]) {
                    continue;
                }
                //Debug.Log("after continue, " + i + " " + j);
                if (blockSpawner.blockObjects[i, j] && blockSpawner.blockObjects[i + 1, j] && blockSpawner.blockObjects[i, j + 1] && blockSpawner.blockObjects[i + 1, j + 1] &&
                    blockSpawner.blockObjects[i, j].GetComponent<blockProfile>().colourIs == blockSpawner.blockObjects[i + 1, j + 1].GetComponent<blockProfile>().colourIs &&
                    blockSpawner.blockObjects[i, j + 1].GetComponent<blockProfile>().colourIs == blockSpawner.blockObjects[i + 1, j].GetComponent<blockProfile>().colourIs) {
                    scoreHandler.registerFourBlockCombo();
                    for (int k = i; k < i + 2; k++) {
                        for (int l = j; l < j + 2; l++) {
                            if (blockSpawner.blockObjects[k, l]) {
                                Destroy(blockSpawner.blockObjects[k, l]);
                            }
                        }
                    }
                } else {
                    continue;
                }
            }
        }
        Debug.Log("examining matrix");
    }
    private bool validateMove() {
        if (Mathf.Abs(selectedBlock1.GetComponent<blockProfile>().horizontalIndex - selectedBlock2.GetComponent<blockProfile>().horizontalIndex) == 1 &&
            Mathf.Abs(selectedBlock1.GetComponent<blockProfile>().verticalIndex - selectedBlock2.GetComponent<blockProfile>().verticalIndex) == 0 ||
            Mathf.Abs(selectedBlock1.GetComponent<blockProfile>().horizontalIndex - selectedBlock2.GetComponent<blockProfile>().horizontalIndex) == 0 &&
            Mathf.Abs(selectedBlock1.GetComponent<blockProfile>().verticalIndex - selectedBlock2.GetComponent<blockProfile>().verticalIndex) == 1) {
            Debug.Log("Swapping and checking");
            return true;
        }
        Debug.Log("hacker!");
        return false;
    }

    private void swapBlocks() {
        GameObject tempBlock = blockSpawner.blockObjects[selectedBlock1.GetComponent<blockProfile>().verticalIndex, selectedBlock1.GetComponent<blockProfile>().horizontalIndex];
        blockSpawner.blockObjects[selectedBlock1.GetComponent<blockProfile>().verticalIndex, selectedBlock1.GetComponent<blockProfile>().horizontalIndex] = 
            blockSpawner.blockObjects[selectedBlock2.GetComponent<blockProfile>().verticalIndex, selectedBlock2.GetComponent<blockProfile>().horizontalIndex];
        blockSpawner.blockObjects[selectedBlock2.GetComponent<blockProfile>().verticalIndex, selectedBlock2.GetComponent<blockProfile>().horizontalIndex] = tempBlock;
        Vector3 tempPosition = selectedBlock1.transform.position;
        selectedBlock1.transform.position = selectedBlock2.transform.position;
        selectedBlock2.transform.position = tempPosition;
        blockProfile.updateIndex();
    }
}


