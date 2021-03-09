using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public Color color;
    public Cauldron cauldron;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().material.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        cauldron.AddIngredient(color);
    }
}
