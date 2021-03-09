using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresetCameraLocation : MonoBehaviour
{
    // camera location type for interact object
    public EnumList.PresetType presetType;
    // gizmos drawing parameter
    public float lineLenght = 1;
   

#if UNITY_EDITOR
    /// <summary>
    /// Draw Gizmos icon on preset object for easy to select. 
    /// </summary>
    private void OnDrawGizmos()
    {
        string customIcon = "Camera_G" + ".png";
        if (presetType == EnumList.PresetType.Default)
        {
            customIcon = "Camera_D" + ".png";
        }
        Gizmos.DrawIcon(this.transform.position, customIcon);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(this.transform.position, this.transform.position + this.transform.forward * lineLenght);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(this.transform.position, this.transform.position + this.transform.up);
    }
#endif
}
