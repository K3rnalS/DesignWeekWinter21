using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CauldronLiquid : MonoBehaviour
{
    public Cauldron cauldron;
    public MissionHandler mission;
    MeshRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        if (cauldron.ings.Count == 2)
        {
            mission.currentMission.GetComponent<MissionObj>().PotionCheck(rend.material.color);
            cauldron.ResetCauldron();
        }
        else
            mission.OpenTextBox("This isn't much of a potion...");
    }
}
