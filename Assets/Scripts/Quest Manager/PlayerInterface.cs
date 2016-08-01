using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInterface : MonoBehaviour
{

    //class variables
    private Camera _camera;
    private Quest activeQuest;
    private bool clearDisplay = true;
    private Dictionary<string, Quest> quests = new Dictionary<string, Quest>();

    // Use this for initialization
    void Start()
    {
        //get camera attached to object
        _camera = GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {

        //get the status of the current quest
        activeQuest = GameManager.instance.ActiveQuest;

        //create ray and raycast
        Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
        Ray ray = _camera.ScreenPointToRay(point);
        RaycastHit hit;

        //if the ray connects with an object
        if (Physics.Raycast(ray, out hit))
        {
            //try to load interactive object
            GameObject hitObject = hit.transform.gameObject;
            InteractiveObject activatedObject = hitObject.GetComponent<InteractiveObject>();


            //if object moused over is quest object
            if (hit.transform.gameObject.name == activeQuest.questObject)
            {
                GameManager.instance.UserInteractionText = activatedObject.activatedObjectText;


                //if the object is activated
                if (Input.GetMouseButtonDown(0))
                {
                    //update game manager with interface text
                    GameManager.instance.UserInteractionText = activatedObject.activatedObjectText;

                    //launch coroutine to pause display text
                    StartCoroutine(PauseDisplay());

                    //load new quest
                    quests = GameManager.instance.Quests;
                    Quest newQuest = new Quest();
                    if (quests.TryGetValue(activeQuest.nextQuest, out newQuest))
                    {
                        GameManager.instance.ActiveQuest = newQuest;

                    }

                    else
                    {
                        Quest emptyQuest = new Quest();
                        GameManager.instance.ActiveQuest = emptyQuest;
                    }
                }
            }

            //clear the user interface if object moused over is not activated
            else if (clearDisplay == true)
            {
                GameManager.instance.UserInteractionText = "";
              
            }
        }
    }

    //function to display dot on GUI
    void OnGUI()
    {
        int size = 20;
        float positionX = _camera.pixelWidth / 2 - size / 4;
        float positionY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(positionX, positionY, size, size), "•");
    }

    //couroutine to pause display text
    private IEnumerator PauseDisplay()
    {
        clearDisplay = false;
        yield return new WaitForSeconds(4.0f);
        clearDisplay = true;
    }
}
