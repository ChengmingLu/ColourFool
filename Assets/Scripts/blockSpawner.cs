using UnityEngine;
using System.Collections;

public class blockSpawner : MonoBehaviour {
    public GameObject blockObject;
    public GameObject[] colourfoolBlockObjects;
    volatile public int spawnSizeHor;
    volatile public int spawnSizeVer;
    public static GameObject[,] blockObjects;
    private Vector3[,] blockPositions;
    private int canvasSizeX;
    private int canvasSizeY;
    private int blockSize;
    private float canvasScaleFactor;
    private int origin = 0;

	// Use this for initialization
	void Start () {
        blockPositions = new Vector3[spawnSizeVer, spawnSizeHor];
        blockObjects = new GameObject[spawnSizeVer, spawnSizeHor];
        Debug.Log(blockObject.GetComponent<SpriteRenderer>().bounds.size.x);
        Debug.Log(gameObject.transform.parent.gameObject.GetComponent<RectTransform>().rect.size.x);
        canvasSizeX = Mathf.RoundToInt(gameObject.transform.parent.gameObject.GetComponent<RectTransform>().rect.size.x);
        canvasSizeY = Mathf.RoundToInt(gameObject.transform.parent.gameObject.GetComponent<RectTransform>().rect.size.y);
        blockSize = Mathf.RoundToInt(blockObject.GetComponent<SpriteRenderer>().bounds.size.x);
        canvasScaleFactor = gameObject.transform.parent.gameObject.GetComponent<Canvas>().scaleFactor;
        assignBlockPos();
        
        for (int i = 0; i < spawnSizeVer; i++) {
            for (int j = 0; j < spawnSizeHor; j++) {
                blockObject = randomizedBlockObject();
                blockObjects[i, j] = Instantiate(blockObject, blockPositions[i, j], Quaternion.identity) as GameObject;
            }
        }
        blockProfile.updateIndex();
        //clickControl.examineMatrix();
	}
	// Update is called once per frame
	void Update () {
	}
    public void assignBlockPos() {
        int verticalCount = 1;
        bool isSpawnSizeEven;
        float referenceObjectPos = origin;
        float referenceObjectUpPos = origin + blockSize / 2, referenceObjectDownPos = origin - blockSize / 2;
        if (spawnSizeVer % 2 != 0) {
            assignBlockPosHor(spawnSizeVer / 2, origin);
            isSpawnSizeEven = false;         
        } else {
            assignBlockPosHor(spawnSizeVer / 2 - 1, referenceObjectUpPos);
            assignBlockPosHor(spawnSizeVer / 2, referenceObjectDownPos);
            isSpawnSizeEven = true;           
        }
        while (verticalCount <= spawnSizeVer / 2 && !isSpawnSizeEven || isSpawnSizeEven && verticalCount < spawnSizeVer / 2) {
            if (!isSpawnSizeEven) {
                assignBlockPosHor(spawnSizeVer / 2 - verticalCount, referenceObjectPos + verticalCount * blockSize);
            } else {
                assignBlockPosHor(spawnSizeVer / 2 - verticalCount - 1, referenceObjectUpPos + verticalCount * blockSize);
            }
            verticalCount += 1;
        }
        verticalCount = 1;
        while (verticalCount <= spawnSizeVer / 2 && !isSpawnSizeEven || isSpawnSizeEven && verticalCount < spawnSizeVer / 2) {
            if (!isSpawnSizeEven) {
                assignBlockPosHor(spawnSizeVer / 2 + verticalCount, referenceObjectPos - verticalCount * blockSize);
            } else {
                assignBlockPosHor(spawnSizeVer / 2 + verticalCount, referenceObjectDownPos - verticalCount * blockSize);
            }
            verticalCount += 1;
        }
    }
    private void assignBlockPosHor(int verticalIndex, float verticalPos) {
        int horizontalCount = 1;
        bool isSpawnSizeEven;
        Vector3 referenceObjectPos = new Vector3(0, 0, 0); // when spawnSize is odd
        Vector3 referenceObjectLeftPos = new Vector3(0, 0, 0), referenceObjectRightPos = new Vector3(0, 0, 0); // when spawnSize is even
        if (spawnSizeHor % 2 != 0) {
            referenceObjectPos = new Vector3(origin, verticalPos, origin);
            blockPositions[verticalIndex, spawnSizeHor / 2] = referenceObjectPos;          
            isSpawnSizeEven = false;
        } else {
            referenceObjectLeftPos = new Vector3(origin - blockSize / 2, verticalPos, origin);
            blockPositions[verticalIndex, spawnSizeHor / 2 - 1] = referenceObjectLeftPos;
            referenceObjectRightPos = new Vector3(origin + blockSize / 2, verticalPos, origin);
            blockPositions[verticalIndex, spawnSizeHor / 2] = referenceObjectRightPos;
            isSpawnSizeEven = true;
        }
        while (horizontalCount <= spawnSizeHor / 2 && !isSpawnSizeEven || isSpawnSizeEven && horizontalCount < spawnSizeHor / 2) {
            if (!isSpawnSizeEven) {
                blockPositions[verticalIndex, spawnSizeHor / 2 - horizontalCount] =
                    referenceObjectPos - new Vector3(blockSize * horizontalCount, origin, origin);
            } else {
                blockPositions[verticalIndex, spawnSizeHor / 2 - horizontalCount - 1] =
                    referenceObjectLeftPos - new Vector3(blockSize * horizontalCount, origin, origin);       
            }
            horizontalCount += 1;
        }
        horizontalCount = 1;
        while (horizontalCount <= spawnSizeHor / 2 && !isSpawnSizeEven || isSpawnSizeEven && horizontalCount < spawnSizeHor / 2) {
            if (!isSpawnSizeEven) {
                blockPositions[verticalIndex, spawnSizeHor / 2 + horizontalCount] =
                    referenceObjectPos + new Vector3(blockSize * horizontalCount, origin, origin);
            } else {
                blockPositions[verticalIndex, spawnSizeHor / 2 + horizontalCount] =
                    referenceObjectRightPos + new Vector3(blockSize * horizontalCount, origin, origin);      
            }
            horizontalCount += 1;
        }
    }

    GameObject randomizedBlockObject() {
        int rNG = UnityEngine.Random.Range(0, colourfoolBlockObjects.Length);
        Debug.Log(rNG);
        blockObject = colourfoolBlockObjects[rNG];
        return blockObject;
    }
}
