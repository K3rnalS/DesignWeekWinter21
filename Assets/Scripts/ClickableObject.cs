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
                        Camera.main.GetComponent<CameraMovement>().MoveTo(EnumList.PresetType.Spell);
                        break;
                    case "Potion":
                        Camera.main.GetComponent<CameraMovement>().MoveTo(EnumList.PresetType.Potion);
                        break;
                    case "PotionSheet":
                        Camera.main.GetComponent<CameraMovement>().MoveTo(EnumList.PresetType.PotionSheet);
                        break;
                    default:
                        Camera.main.GetComponent<CameraMovement>().MoveTo(EnumList.PresetType.Default);
                        break;
                }

                Interact(hit.transform.gameObject);
            }
            
        }
    }

    void Interact(GameObject obj)
    {
        if (obj.GetComponent<Ingredient>())
            obj.GetComponent<Ingredient>().Interact();
        else if (obj.GetComponent<CauldronLiquid>())
            obj.GetComponent<CauldronLiquid>().Interact();
    }

    public void GoToDefaultPosition()
    {
        Camera.main.GetComponent<CameraMovement>().MoveTo(EnumList.PresetType.Default);
    }

    private void SendMessageToCamera()
    {

    }
}
