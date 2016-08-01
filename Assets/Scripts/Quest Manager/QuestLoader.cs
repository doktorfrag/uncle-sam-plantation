using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;

public class QuestLoader : MonoBehaviour {

    //folder where quest files are stored
    string questFolder = @"Assets\Quests";

    //variables to match data fields in quest file
    string questObject;
    bool questCompleted;
    string messageOnMouseOver;
    string messageOnMouseDown;
    string nextQuest;

    //other class variables
    Dictionary<string, Quest> quests = new Dictionary<string, Quest>();
    int dataPointer = 0;

    // Use this for initialization
    void Start ()
    {
        ReadQuestFiles();
        PushQuestFiles();

    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void ReadQuestFiles()
    {
        foreach (string dataFile in Directory.GetFiles(questFolder, "*.data", SearchOption.AllDirectories))
        {
            //read all lines in file and get file name
            string[] lines = File.ReadAllLines(dataFile);
            string fileName = dataFile.Substring(dataFile.LastIndexOf("\\") + 1, dataFile.LastIndexOf(".") - (dataFile.LastIndexOf("\\") + 1));
            //Debug.Log("Files loaded:" + fileName);

            while (dataPointer < lines.Length)
            {
                //skip white space
                if (lines[dataPointer].Length < 1)
                {
                    dataPointer++;
                    continue;
                }

                //read in the lines according to line header
                if (lines[dataPointer].StartsWith("questObject:"))
                {
                    questObject = lines[dataPointer].Substring(lines[dataPointer].IndexOf(":") + 1);
                    dataPointer++;
                }

                else if (lines[dataPointer].StartsWith("questCompleted:"))
                {
                    questCompleted = Convert.ToBoolean(lines[dataPointer].Substring(lines[dataPointer].IndexOf(":") + 1));
                    dataPointer++;
                    continue;
                }

                else if (lines[dataPointer].StartsWith("messageOnMouseOver:"))
                {
                    messageOnMouseOver = lines[dataPointer].Substring(lines[dataPointer].IndexOf(":") + 1);
                    dataPointer++;
                    continue;

                }

                else if (lines[dataPointer].StartsWith("messageOnMouseDown:"))
                {
                    messageOnMouseDown = lines[dataPointer].Substring(lines[dataPointer].IndexOf(":") + 1);
                    dataPointer++;
                    continue;

                }

                else if (lines[dataPointer].StartsWith("nextQuest:"))
                {
                    nextQuest = lines[dataPointer].Substring(lines[dataPointer].IndexOf(":") + 1);
                    dataPointer++;
                    continue;
                }

                /**** Add extra line headers here
                else if (lines[dataPointer].StartsWith("Header goes here:"))
                {
                    dataPointer++;
                    continue;

                }
                ****/

                //skip anything else that is not a line header or white space
                else {
                    Debug.Log("Line: `" + lines[dataPointer] + "` not recognized as valid token");
                    dataPointer++;
                    continue;
                }
            }

            //reset data pointer and add struct to dictionary
            dataPointer = 0;
            quests.Add(fileName, new Quest(fileName, questObject, questCompleted, messageOnMouseOver, messageOnMouseDown, nextQuest));

        }
    }

    void PushQuestFiles()
    {
        //if files have indeed been loaded, push dictionary reference to GameManager
        if (quests != null)
        {
            GameManager.instance.Quests = quests;

            //if no active quest, assign active quest
            if (GameManager.instance.IsQuestSet == false)
            {
                bool questSet = true;
                GameManager.instance.IsQuestSet = questSet;
                GameManager.instance.ActiveQuest = quests["FirstQuest"];
            }
        }
    }
}
