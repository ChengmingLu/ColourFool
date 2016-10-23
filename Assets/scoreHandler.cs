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
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static void registerFourBlockCombo() {
        scoreDisplay += 10;
        showScore.text = scoreDisplay.ToString();
    }
}
