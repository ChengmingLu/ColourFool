using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerScript : MonoBehaviour {
    private Text timerText;
    public float timeCounter;
    private bool checkBlockPosition;
	// Use this for initialization
	void Start () {
        checkBlockPosition = true;
        timerText = gameObject.GetComponent<Text>();
        timerText.text = timeCounter.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        timeCounter -= Time.deltaTime;
        if (timeCounter >= 0) {
            timerText.text = Mathf.FloorToInt(timeCounter).ToString();
        }
        if (blockSpawner.blockObjects[0, 0] && checkBlockPosition) {
            gameObject.transform.position = blockSpawner.blockObjects[0, 0].transform.position + new Vector3(0, 120, 0);
            checkBlockPosition = false;
        }
        if (timeCounter <= 0) {
            gameObject.transform.parent.gameObject.GetComponentInChildren<loadLevel>().loadNext();
        }
	}
}
