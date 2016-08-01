using UnityEngine;
using System.Collections;

public struct Quest {

    public string fileName;
    public string questObject;
    public bool questCompleted;
    public string messageOnMouseOver;
    public string messageOnMouseDown;
    public string nextQuest;

    public Quest(string fileName, string questObject, bool questCompleted, string messageOnMouseOver, string messageOnMouseDown, string nextQuest)
    {
        this.fileName = fileName;
        this.questObject = questObject;
        this.questCompleted = questCompleted;
        this.messageOnMouseOver = messageOnMouseOver;
        this.messageOnMouseDown = messageOnMouseDown;
        this.nextQuest = nextQuest;

    }
}
