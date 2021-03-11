using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionHandler : MonoBehaviour
{
    public GameObject currentMission;
    public List<GameObject> missions;

    public Text textBox;
    public Text alertText;
    public GameObject alertBox;
    public Button close;
    public Text questHeader;
    public Image character;

    public GameObject potionButts;
    public GameObject spellButts;

    public AudioSource audioSrc;
    public AudioClip doorOpen;
    public AudioClip announcement;

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

            while (missions[index].GetComponent<MissionObj>().complete)
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
            GenerateMission();
    }

    public GameObject GetCurrentMission()
    {
        return currentMission;
    }
}
