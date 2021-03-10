using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spell : MonoBehaviour
{
    public MissionHandler mission;

    public Image UIShape1;
    public Image UIShape2;
    public Image UIShape3;
    public Image UIShape4;

    public Sprite square;
    public Sprite triangle;
    public Sprite circle;
    public Sprite pentagon;

    public enum ShapeType 
    {
        Square,
        Triangle,
        Circle,
        Pentagon,
        Diamond,
        None
    }

    public ShapeType spellType;
    public ShapeType[] shapeOrder;
    int currentShapeIndex = 0; //where are we in the 4-shape pattern?

    // Start is called before the first frame update
    void Start()
    {
        shapeOrder = new ShapeType[4];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InsertShape(ShapeType shape, Sprite sprite)
    {
        shapeOrder[currentShapeIndex] = shape;

        switch (currentShapeIndex)
        {
            case 0:
                UIShape1.sprite = sprite;
                break;
            case 1:
                UIShape2.sprite = sprite;
                break;
            case 2:
                UIShape3.sprite = sprite;
                break;
            case 3:
                UIShape4.sprite = sprite;
                break;
            default:
                break;
        }

        currentShapeIndex += 1;

        Debug.Log(currentShapeIndex);

        if (currentShapeIndex >= 4)
            CheckSpell();
    }

    void CheckSpell()
    {
        Debug.Log("Checking");
        if (shapeOrder[0] == ShapeType.Circle) //Summoning
        {
            if (shapeOrder[1] == ShapeType.Diamond)
                if (shapeOrder[2] == ShapeType.Circle)
                    if (shapeOrder[3] == ShapeType.Square)
                        mission.GetCurrentMission().SpellCheck(0);
        }

        else if (shapeOrder[0] == ShapeType.Pentagon) //Invisibility
        {
            if (shapeOrder[1] == ShapeType.Circle)
                if (shapeOrder[2] == ShapeType.Square)
                    if (shapeOrder[3] == ShapeType.Pentagon)
                        mission.GetCurrentMission().SpellCheck(1);
        }

        else if (shapeOrder[0] == ShapeType.Triangle) //Curse
        {
            if (shapeOrder[1] == ShapeType.Pentagon)
                if (shapeOrder[2] == ShapeType.Diamond)
                    if (shapeOrder[3] == ShapeType.Circle)
                        mission.GetCurrentMission().SpellCheck(2);
        }

        else if (shapeOrder[0] == ShapeType.Square) //Protection
            if (shapeOrder[1] == ShapeType.Diamond)
                if (shapeOrder[2] == ShapeType.Circle)
                    if (shapeOrder[3] == ShapeType.Pentagon)
                        mission.GetCurrentMission().SpellCheck(3);

        ResetSpell();
    }

    void ResetSpell()
    {
        UIShape1.sprite = null;
        UIShape2.sprite = null;
        UIShape3.sprite = null;
        UIShape4.sprite = null;

        for (int i = 0; i < 4; i++)
            shapeOrder[i] = ShapeType.None;

        currentShapeIndex = 0;
    }

    public void SetSquare()
    {
        InsertShape(ShapeType.Square, square);
    }

    public void SetDiamond()
    {
        InsertShape(ShapeType.Diamond, square);
    }

    public void SetTriangle()
    {
        InsertShape(ShapeType.Triangle, triangle);
    }

    public void SetCircle()
    {
        InsertShape(ShapeType.Circle, circle);
    }

    public void SetPentagon()
    {
        InsertShape(ShapeType.Pentagon, pentagon);
    }
}
