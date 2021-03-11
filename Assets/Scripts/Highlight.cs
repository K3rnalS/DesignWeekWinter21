using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    MeshRenderer rend;
    Color orgColor; //original color of the material
    Color highlight; //highlighted color of the material

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();

        Color col = rend.material.color;
        orgColor = col;
        highlight = new Color(col.r + 0.1f, col.g + 0.1f, col.b + 0.1f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        rend.material.color = highlight;
    }

    private void OnMouseExit()
    {
        rend.material.color = orgColor;
    }
}
