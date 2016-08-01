using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : Singleton<GameManager>
{

    //this section manages whether there is an active quest or not

    private bool _isQuestSet = false;

    public bool IsQuestSet
    {
        get { return _isQuestSet; }
        set { _isQuestSet = value; }
    } 

    //this section manages the active quest

    private Quest _activeQuest = new Quest();

    public Quest ActiveQuest
    {
        get { return _activeQuest; }
        set { _activeQuest = value; }
    }

    //this section manages data pulled in from quest files

    private Dictionary<string, Quest> _quests = new Dictionary<string, Quest>();

    public Dictionary<string, Quest> Quests
    {
        get { return _quests; }
        set { _quests = value; }
    }

    //this section manages data displayed on the GUI

    private string _userInteractionText;

    public string UserInteractionText
    {
        get { return _userInteractionText; }
        set { _userInteractionText = value; }
    }
}
