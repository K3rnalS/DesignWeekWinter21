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

    public AudioSource audioSrc;
    public AudioClip paperRuffle;
    public AudioClip correct;
    public AudioClip wrong;

    public enum ShapeType 
    {
        Square,
        Triangle,
        Circle,
        Pentagon,
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
		AudioManager.audioInstance.Audio.PlayOneShot(AudioManager.audioInstance.Scribble);

        switch (currentShapeIndex)
        {
            case 0:
                UIShape1.sprite = sprite;
                UIShape1.color = new Color(1, 1, 1, 1);
                break;
            case 1:
                UIShape2.sprite = sprite;
                UIShape2.color = new Color(1, 1, 1, 1);
                break;
            case 2:
                UIShape3.sprite = sprite;
                UIShape3.color = new Color(1, 1, 1, 1);
                break;
            case 3:
                UIShape4.sprite = sprite;
                UIShape4.color = new Color(1, 1, 1, 1);
                break;
            default:
                break;
        }

        if (currentShapeIndex == 1 && shape == ShapeType.Square)
            UIShape2.transform.Rotate(0, 0, 45);

        currentShapeIndex += 1;

        if (currentShapeIndex >= 4)
            mission.Prompt("Try out this spell?", 1);
    }

    void CheckSpell()
    {
        if (shapeOrder[0] == ShapeType.Circle) //Summoning
        {
            if (shapeOrder[1] == ShapeType.Square)
                if (shapeOrder[2] == ShapeType.Circle)
                    if (shapeOrder[3] == ShapeType.Square)
                    {
                        mission.GetCurrentMission().GetComponent<MissionObj>().SpellCheck(0);
                        return;
                    }
        }

        else if (shapeOrder[0] == ShapeType.Pentagon) //Invisibility
        {
            if (shapeOrder[1] == ShapeType.Circle)
                if (shapeOrder[2] == ShapeType.Square)
                    if (shapeOrder[3] == ShapeType.Pentagon)
                    {
                        mission.GetCurrentMission().GetComponent<MissionObj>().SpellCheck(1);
                        return;
                    }
        }

        else if (shapeOrder[0] == ShapeType.Triangle) //Curse
        {
            if (shapeOrder[1] == ShapeType.Pentagon)
                if (shapeOrder[2] == ShapeType.Pentagon)
                    if (shapeOrder[3] == ShapeType.Pentagon)
                    {
                        mission.GetCurrentMission().GetComponent<MissionObj>().SpellCheck(2);
                        return;
                    }
        }

        else if (shapeOrder[0] == ShapeType.Square) //Protection
        {
            if (shapeOrder[1] == ShapeType.Square)
                if (shapeOrder[2] == ShapeType.Circle)
                    if (shapeOrder[3] == ShapeType.Pentagon)
                    {
                        mission.GetCurrentMission().GetComponent<MissionObj>().SpellCheck(3);
                        return;
                    }
        }

        mission.Alert("That spell didn't seem to do anything");

        ResetSpell();
    }

    void ResetSpell()
    {
        UIShape1.sprite = null;
        UIShape1.color = new Color(1, 1, 1, 0);
        UIShape2.sprite = null;
        UIShape2.color = new Color(1, 1, 1, 0);
        UIShape2.transform.rotation = Quaternion.identity;
        UIShape3.sprite = null;
        UIShape3.color = new Color(1, 1, 1, 0);
        UIShape4.sprite = null;
        UIShape4.color = new Color(1, 1, 1, 0);

        for (int i = 0; i < 4; i++)
            shapeOrder[i] = ShapeType.None;

        currentShapeIndex = 0;
    }

    public void Check()
    {
        mission.CloseAlert();
        CheckSpell();
    }

    public void Decline()
    {
        ResetSpell();
        mission.CloseAlert();
    }

    public void SetSquare()
    {
        InsertShape(ShapeType.Square, square);
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
