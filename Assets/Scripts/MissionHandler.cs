using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionHandler : MonoBehaviour
{
    public GameObject currentMission;
    public List<GameObject> missions;

    public Text textBox;
    public Image bg;
    public Button close;

    // Start is called before the first frame update
    void Start()
    {
        currentMission = missions[0];
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void GenerateMission()
    {
        if (currentMission != null && currentMission.GetComponent<MissionObj>().nextMission != null)
        {
            foreach (GameObject obj in missions)
            {
                if (obj.GetComponent<MissionObj>() == currentMission.GetComponent<MissionObj>().nextMission)
                {
                    missions.Remove(currentMission);
                    currentMission = obj;
                    Instantiate(currentMission, transform);
                    Debug.Log("Next mission assignment successful");
                }
            }
        }
        else
        {
            missions.Remove(currentMission);
            currentMission = missions[Random.Range(0, missions.Count)];
            Instantiate(currentMission, transform);
        }

    }

    public GameObject GetCurrentMission()
    {
        return currentMission;
    }
}
