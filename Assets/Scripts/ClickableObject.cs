using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                switch (hit.collider.gameObject.tag)
                {
                    case "Spell":
                        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().MoveTo(EnumList.PresetType.Spell);
                        break;
                    case "Potion":
                        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().MoveTo(EnumList.PresetType.Potion);
                        break;
                    default:
                        break;
                }

            }
            
        }
    }

    private void SendMessageToCamera()
    {

    }
}
