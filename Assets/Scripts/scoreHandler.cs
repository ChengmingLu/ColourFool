using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreHandler : MonoBehaviour {
    public static int scoreDisplay;
    public static Text showScore;
	// Use this for initialization
	void Start () {
        showScore = gameObject.GetComponent<Text>();
        showScore.text = scoreDisplay.ToString();
        

        //

	}
	
	// Update is called once per frame
	void Update () {
	    if (blockSpawner.blockObjects[0, 0]) {
            gameObject.transform.position = blockSpawner.blockObjects[0, 0].transform.position - new Vector3(120, 0, 0);
        }
	}

    public static void registerFourBlockCombo() {
        scoreDisplay += 10;
        showScore.text = scoreDisplay.ToString();
    }
}
