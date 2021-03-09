using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public GameObject item; //what item does the player get when they click on this object?

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
                Interact(hit.transform.gameObject);
        }
    }

    void Interact(GameObject obj)
    {
        if (obj.GetComponent<Ingredient>())
            obj.GetComponent<Ingredient>().Interact();
    }
}
