using UnityEngine;
using System.Collections;

public class blockSpawner : MonoBehaviour {
    public GameObject blockObject;
	// Use this for initialization
	void Start () {
        Debug.Log(blockObject.GetComponent<SpriteRenderer>().bounds.size.x);
        for (int horizontalPos = 0; horizontalPos <= gameObject.transform.parent.gameObject.GetComponent<RectTransform>().rect.size.x *
            gameObject.transform.parent.gameObject.GetComponent<Canvas>().scaleFactor; 
            horizontalPos += Mathf.RoundToInt(blockObject.GetComponent<SpriteRenderer>().bounds.size.x)) {
            Instantiate(blockObject, new Vector3(horizontalPos, 0, 0), Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
