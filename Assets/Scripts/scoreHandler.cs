using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreHandler : MonoBehaviour {
    public static int scoreDisplay;
    private static Text showScore;
    private bool checkBlockPosition;
	// Use this for initialization
	void Start () {
        checkBlockPosition = true;
        showScore = gameObject.GetComponent<Text>();
        showScore.text = scoreDisplay.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	    if (blockSpawner.blockObjects[0, 0] && checkBlockPosition) {
            gameObject.transform.position = blockSpawner.blockObjects[0, 0].transform.position - new Vector3(120, 0, 0);
            checkBlockPosition = false;
        }
	}

    public static void registerFourBlockCombo() {
        scoreDisplay += 10;
        showScore.text = scoreDisplay.ToString();
    }
}
