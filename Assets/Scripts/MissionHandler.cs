using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionHandler : MonoBehaviour
{
    public GameObject currentMission;
    public List<GameObject> missions;
    int missionCompleteCount = 0;

    //== UI ==//
    public Text textBox; //Slide-out text box for quest descriptions
    public Text alertText; //alert message text
    public GameObject alertBox; //alert message box
    public Button close; //close button
    public Text questHeader; //quest header
    public Image character; //character portrait
    public GameObject finish; //finish button

    public GameObject potionButts;
    public GameObject spellButts;

    public GameObject canvas; //UI Canvas
    public GameObject SlideOutCopy; //a copy of the quest log to duplicate for delayed endings

    // Start is called before the first frame update
    void Start()
    {
        GameObject mission = Instantiate(missions[0], transform);
        currentMission = mission;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenTextBox(string newText)
    {
        textBox.text = newText;
        //textBox.gameObject.SetActive(true);
        //bg.gameObject.SetActive(true);
    }

    public void Alert(string alert)
    {
        alertText.text = alert;
        alertBox.SetActive(true);
        close.gameObject.SetActive(true);
    }

    public void CloseAlert()
    {
        alertText.text = "";
        alertBox.SetActive(false);
        close.gameObject.SetActive(false);
        potionButts.SetActive(false);
        spellButts.SetActive(false);
    }

    public void Prompt(string prompt, int type)
    {
        if (type == 0)
            potionButts.SetActive(true);
        else if (type == 1)
            spellButts.SetActive(true);
        else
            return;

        alertBox.SetActive(true);
        alertText.text = prompt;
    }

    public void GenerateMission()
    {
        //if all missions complete, show an ending if we ever get it in
        if (missionCompleteCount >= missions.Count)
        {
            Debug.Log("out of missions!");
            return;
        }

        if (currentMission != null && currentMission.GetComponent<MissionObj>().nextMission != null)
        {
            GameObject obj = Instantiate(currentMission.GetComponent<MissionObj>().nextMission, transform);
            Destroy(currentMission);
            currentMission = obj;
        }
        else
        {
            int checkCount = 0;
            int index = Random.Range(0, missions.Count);
            GameObject obj;

            //keep generating a number until a mission that isn't in progress or complete shows up
            while (missions[index].GetComponent<MissionObj>().complete || missions[index].GetComponent<MissionObj>().inProgress)
            {
                if (checkCount > 10)
                {
                    for (int i = 0; i < missions.Count; i++)
                    {
                        if (!missions[i].GetComponent<MissionObj>().complete)
                        {
                            obj = Instantiate(missions[i], transform);
                            Destroy(currentMission);
                            currentMission = obj;
                            return;
                        }
                    }
                }
                index = Random.Range(0, missions.Count);
                checkCount++;
            }

            obj = Instantiate(missions[index], transform);
            Destroy(currentMission);
            currentMission = obj;
        }

    }

    public void CompleteMission()
    {
        if (currentMission.GetComponent<MissionObj>().complete)
        {
            missionCompleteCount += 1;
            GenerateMission();
        }
    }

    //delay the ending of a quest -- in the meantime, a new one shows up
    public IEnumerator QuestResult()
    {
        Instantiate(SlideOutCopy, canvas.transform);
        yield return new WaitForSeconds(Random.Range(15, 30)); //wait a random amount of time, then show the quest ending
    }

    public GameObject GetCurrentMission()
    {
        return currentMission;
    }
}
