using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickableObject : MonoBehaviour
{
    public GameObject UISpellMake;
    public GameObject currentSpell;

    public GameObject header;
    public Text headerText;

    public bool cantInteract = true; //can't interact with smaller objects when on overview or quest open

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
						AudioManager.audioInstance.Audio.PlayOneShot(AudioManager.audioInstance.Paper);
                        cantInteract = false;
                        break;
                    case "Potion":
                        Camera.main.GetComponent<CameraMovement>().MoveTo(EnumList.PresetType.Potion);
                        header.SetActive(true);
                        cantInteract = false;
                        break;
                    case "PotionSheet":
                        Camera.main.GetComponent<CameraMovement>().MoveTo(EnumList.PresetType.PotionSheet);
						AudioManager.audioInstance.Audio.PlayOneShot(AudioManager.audioInstance.Paper);
                        cantInteract = false;
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
        if (obj.GetComponent<Ingredient>() && !cantInteract)
            obj.GetComponent<Ingredient>().Interact();
        else if (obj.GetComponent<CauldronLiquid>() && !cantInteract)
            obj.GetComponent<CauldronLiquid>().Interact();
        else if (obj.GetComponent<Cauldron>() && !cantInteract)
            obj.GetComponent<Cauldron>().Interact();
        else if (obj.gameObject.CompareTag("Spell"))
            SpellMake();
    }

    public void SpellMake()
    {
        UISpellMake.SetActive(true);
        currentSpell.SetActive(true);
    }

    public void CloseSpellMake()
    {
        UISpellMake.SetActive(false);
        currentSpell.SetActive(false);
    }

    public void GoToDefaultPosition()
    {
        Camera.main.GetComponent<CameraMovement>().MoveTo(EnumList.PresetType.Default);
        header.SetActive(false);
        cantInteract = true;
        CloseSpellMake();
    }

    private void SendMessageToCamera()
    {

    }
}
