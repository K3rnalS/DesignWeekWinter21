using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionHandler : MonoBehaviour
{
    public GameObject currentMission;
    public List<GameObject> missions;
    int missionCompleteCount = 0;

    public Text questTitle;

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

    int missionCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject mission = Instantiate(missions[0], transform);
        currentMission = mission;

        UpdateQuestDetails();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenTextBox(string newText)
    {
        textBox.text = newText;
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

        missionCounter++;
        GameObject mission = Instantiate(missions[missionCounter], transform);
        currentMission = mission;

        UpdateQuestDetails();
    }

    public void CompleteMission()
    {
        if (currentMission.GetComponent<MissionObj>().complete)
        {
            missionCompleteCount += 1;
            questTitle.text = "Quest Completed: Item Delivered";
            StartCoroutine(QuestResult());
            GenerateMission();
        }
    }

    //delay the ending of a quest -- in the meantime, a new one shows up
    public IEnumerator QuestResult()
    {

        GameObject end = Instantiate(SlideOutCopy, canvas.transform);
        end.SetActive(false);

        yield return new WaitForSeconds(2); //wait a random amount of time, then show the quest ending
        end.SetActive(true);
        end.GetComponent<UISlideOut>().destroyable = true;
        end.GetComponent<UISlideOut>().ShotSlideOut();

    }

    void UpdateQuestDetails()
    {
        questHeader.text = currentMission.GetComponent<MissionObj>().simpText;
        questTitle.text = currentMission.GetComponent<MissionObj>().questName;
        character.sprite = currentMission.GetComponent<MissionObj>().character;
    }

    public GameObject GetCurrentMission()
    {
        return currentMission;
    }
}
