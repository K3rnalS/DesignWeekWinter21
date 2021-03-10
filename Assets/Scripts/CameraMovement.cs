using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = FindPresetLocation(EnumList.PresetType.Default).transform.position;
        this.transform.rotation = FindPresetLocation(EnumList.PresetType.Default).transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {

    }

    /// <summary>
    /// call main camera back to Overlook location
    /// </summary>
    public void MoveToDefault()
    {
        MoveTo(EnumList.PresetType.Default);
    }

    /// <summary>
    /// using iTween to move the camera
    /// </summary>
    /// <param name="type"></param>
    public void MoveTo(EnumList.PresetType type)
    {

        GameObject target = FindPresetLocation(type);

        if (!target)
            return;

        iTween.MoveTo(this.gameObject, 
            iTween.Hash("position", target.transform, 
            "time", 3,
            "onstart", "OnMovementStart",
            "oncomplete", "OnMovementComplete"
            ));

        iTween.RotateTo(this.gameObject, 
            iTween.Hash("rotation", target.transform,
            "islocal", false,
            "time", 3,
            "onstart", "OnRotationStart",
            "oncomplete", "OnRotationComplete"
            ));
    }

    private GameObject FindPresetLocation(EnumList.PresetType type)
    {
        GameObject obj = null;

        GameObject[] targetlist = GameObject.FindGameObjectsWithTag("PresetCameraLocation");
        for (int i = 0; i < targetlist.Length; i++)
        {
            if (targetlist[i].GetComponent<PresetCameraLocation>().presetType == type)
            {
                obj = targetlist[i];
                break;
            }
        }
        return obj;
    }

    private void OnMovementStart()
    {

    }

    private void OnMovementComplete()
    {

    }

    private void OnRotationStart()
    {


    }

    private void OnRotationComplete()
    {

    }

    

}
