using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateUI : MonoBehaviour {

    [SerializeField]
    private Text userInteractionText;

    
    // Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        userInteractionText.text = GameManager.instance.UserInteractionText;

    }
}
