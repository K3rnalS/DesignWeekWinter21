using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionHandler : MonoBehaviour
{
    public MissionObj currentMission;
    public List<MissionObj> missions;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public MissionObj GetCurrentMission()
    {
        return currentMission;
    }
}
