using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionObj : MonoBehaviour
{
    public string questName;
    public string NPCIntro; //the NPC's opening dialogue
    public string simpText; //simplified quest description

    public bool potReq; //required potion to fulfill mission
    public bool spellReq; //required spell to fulfill mission

    public bool inProgress = false;
    public MissionObj nextMission; //mission to activate once this one is done, if any
    public MissionHandler handler; //the mission handler

    public string potPoisonEnd;
    public string potCharismaEnd;
    public string potAntidoteEnd;
    public string potTruthEnd;

    public string spellInvEnd;
    public string spellCurseEnd;
    public string spellProtEnd;
    public string spellSummEnd;

    Color purple = new Color(0.50f, 0, 0.50f);
    Color orange = new Color(1, 0.65f, 0);
    Color cyan = new Color(0, 1, 1);
    Color violet = new Color(0.50f, 0, 1);

    // Start is called before the first frame update
    void Start()
    {
        handler = GetComponentInParent<MissionHandler>();
        handler.OpenTextBox(NPCIntro);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CompleteMission()
    { 
        
    }

    public void PotionCheck(Color col)
    {
        if (!potReq)
            return;

        if (col == purple)
            handler.OpenTextBox(potPoisonEnd);
        else if (col == orange)
            handler.OpenTextBox(potAntidoteEnd);
        else if (col == cyan)
            handler.OpenTextBox(potTruthEnd);
        else if (col == violet)
            handler.OpenTextBox(potCharismaEnd);
    }

    public void SpellCheck(int spellType)
    {
        if (!spellReq)
            return;

        switch (spellType)
        {
            case 0:
                handler.OpenTextBox(spellSummEnd);
                break;
            case 1:
                handler.OpenTextBox(spellInvEnd);
                break;
            case 2:
                handler.OpenTextBox(spellCurseEnd);
                break;
            case 3:
                handler.OpenTextBox(spellProtEnd);
                break;
            default:
                break;
        }
    }
}
