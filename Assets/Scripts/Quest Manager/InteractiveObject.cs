using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InteractiveObject : MonoBehaviour {

    public string activatedObjectText;
    public Shader glowShader;
    public Shader normalShader;
    public Renderer rend;
    public Quest activeQuest;
    public string objectName;
    public bool objectClicked;

	// Use this for initialization
	void Start () {
        //assign variables
        rend = GetComponent<Renderer>();
        normalShader = Shader.Find("Standard");
        glowShader = Shader.Find("Custom/ItemGlow");
        objectName = gameObject.name;

    }
	
	// Update is called once per frame
	void Update () {
        //get most recent quest data for game object
        activeQuest = GameManager.instance.ActiveQuest;

    }


    public void OnMouseOver()
    {
        //if object hasn't been clicked and is active quest object
        if (objectClicked != true && (objectName == activeQuest.questObject))
        {
            //make object glow and push message to GUI
            //rend.material.shader = glowShader;
            activatedObjectText = activeQuest.messageOnMouseOver;

        }
    }

    void OnMouseDown()
    {
        //if object clicked, push message to GUI and activate boolean
        objectClicked = true;
        activatedObjectText = activeQuest.messageOnMouseDown;
        rend.material.shader = normalShader;

    }

    public void OnMouseExit()
    {
        //object doesn't glow anymore
        rend.material.shader = normalShader;

    }
}
