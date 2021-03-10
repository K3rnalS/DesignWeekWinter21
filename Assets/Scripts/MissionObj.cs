using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionObj : MonoBehaviour
{
    public string NPCIntro; //the NPC's opening dialogue
    public Color potReq; //required potion to fulfill mission
    public GameObject spellReq; //required spell to fulfill mission

    public bool inProgress = false;

    public Text textBox;
    public Image bg;
    public Button close;

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
        textBox.text = NPCIntro;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TextTimer(float secs)
    {
        yield return new WaitForSeconds(secs);
        textBox.text = "";
        textBox.gameObject.SetActive(false);
    }

    public void OpenTextBox(string newText)
    {
        textBox.text = newText;
        textBox.gameObject.SetActive(true);
        bg.gameObject.SetActive(true);
        close.gameObject.SetActive(true);
    }

    public void CloseTextBox()
    {
        textBox.text = "";
        textBox.gameObject.SetActive(false);
        bg.gameObject.SetActive(false);
        close.gameObject.SetActive(false);
    }

    public void PotionCheck(Color col)
    {
        if (col == purple)
            OpenTextBox(potPoisonEnd);
        else if (col == orange)
            OpenTextBox(potAntidoteEnd);
        else if (col == cyan)
            OpenTextBox(potTruthEnd);
        else if (col == violet)
            OpenTextBox(potCharismaEnd);
    }

    public void SpellCheck(int spellType)
    {
        Debug.Log("YO");
        switch (spellType)
        {
            case 0:
                OpenTextBox(spellSummEnd);
                break;
            case 1:
                OpenTextBox(spellInvEnd);
                break;
            case 2:
                OpenTextBox(spellCurseEnd);
                break;
            case 3:
                OpenTextBox(spellProtEnd);
                break;
            default:
                break;
        }

        Debug.Log("Completed mission with " + spellType);
    }
}
