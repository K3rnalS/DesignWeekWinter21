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
    public bool complete = false;
    public GameObject nextMission; //mission to activate once this one is done, if any
    public MissionHandler handler; //the mission handler
    public Text questHeader;
    public Sprite character; //character portrait

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
        inProgress = true;

        handler = GetComponentInParent<MissionHandler>();
        handler.OpenTextBox(NPCIntro);

        questHeader = handler.questHeader;
        questHeader.text = simpText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CompleteMission()
    {
        complete = true;
        handler.CompleteMission();
    }

    public void PotionCheck(Color col)
    {
        if (!potReq)
        {
            handler.Alert("I don't think they came for a potion!");
            return;
        }

        if (col == purple)
        {
            handler.OpenTextBox(potPoisonEnd);
            CompleteMission();
        }
        else if (col == orange)
        {
            handler.OpenTextBox(potAntidoteEnd);
            CompleteMission();
        }
        else if (col == cyan)
        {
            handler.OpenTextBox(potTruthEnd);
            CompleteMission();
        }
        else if (col == violet)
        {
            handler.OpenTextBox(potCharismaEnd);
            CompleteMission();
        }
    }

    public void SpellCheck(int spellType, Spell spell = null)
    {
        if (!spellReq)
        {
            handler.Alert("I don't think a spell will come in handy for this!");

            return;
        }

        switch (spellType)
        {
            case 0:
                handler.OpenTextBox(spellSummEnd);
                CompleteMission();
                break;
            case 1:
                handler.OpenTextBox(spellInvEnd);
                CompleteMission();
                break;
            case 2:
                handler.OpenTextBox(spellCurseEnd);
                CompleteMission();
                break;
            case 3:
                handler.OpenTextBox(spellProtEnd);
                CompleteMission();
                break;
            default:
                break;
        }
    }
}
