using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionObj : MonoBehaviour
{
    public string NPCIntro; //the NPC's opening dialogue
    public Color potReq; //required potion to fulfill mission
    public GameObject spellReq; //required spell to fulfill mission
    public Text textBox;

    public string potPoisonEnd;
    public string potCharismaEnd;
    public string potAntidoteEnd;
    public string potTruthEnd;

    public string spellInvEnd;
    public string spellCurseEnd;
    public string spellProtEnd;
    public string spellSummEnd;

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

    public void CloseTextBox()
    {
        textBox.text = "";
        textBox.gameObject.SetActive(false);
    }

    public void PotionCheck()
    { 
        
    }
}
