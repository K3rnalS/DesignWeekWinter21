using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cauldron : MonoBehaviour
{
    public MeshRenderer rend;
    public MissionHandler mission;

    public struct PotionOutcome
    {
        public Color col1;
        public Color col2;
        public Color result;
    }

    public PotionOutcome purple;
    public PotionOutcome orange;
    public PotionOutcome cyan;
    public PotionOutcome magenta;

    //Camera Check
    public GameObject CameraLoc;
    public GameObject CameraPinLoc;

    public List<Color> ings;

    // Start is called before the first frame update
    void Start()
    {
        InitPotionOutcomes();

        ings = new List<Color>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //add an ingredient to the cauldron, then check if any potions have been made
    public void AddIngredient(Color ing)
    {
        if (ings.Count >= 2)
            return;

        ings.Add(ing);

        rend.material.color = ing;

        if (ings.Count == 2)
            CheckForPotion();
    }

    public GameObject CheckForPotion()
    {
        GameObject potion = new GameObject("Potion", typeof(Potion));

        if (ings[0] == Color.blue && ings[1] == Color.red)
		{
            potion.GetComponent<Potion>().color = purple.result;
			AudioManager.audioInstance.Audio.PlayOneShot(AudioManager.audioInstance.Correct);
		}
        else if (ings[0] == Color.red && ings[1] == Color.green)
		{
            potion.GetComponent<Potion>().color = orange.result;
			AudioManager.audioInstance.Audio.PlayOneShot(AudioManager.audioInstance.Correct);
		}
        else if (ings[0] == Color.green && ings[1] == Color.blue)
		{
            potion.GetComponent<Potion>().color = cyan.result;
			AudioManager.audioInstance.Audio.PlayOneShot(AudioManager.audioInstance.Correct);
		}
        else if (ings[0] == Color.red && ings[1] == Color.blue)
		{
            potion.GetComponent<Potion>().color = magenta.result;
			AudioManager.audioInstance.Audio.PlayOneShot(AudioManager.audioInstance.Correct);
		}
        else
        {
			AudioManager.audioInstance.Audio.PlayOneShot(AudioManager.audioInstance.Wrong);
            Destroy(potion);
            rend.material.color = new Color(0, 0.4f, 0);
            mission.Alert("That potion didn't seem to have any effect.");
            ResetCauldron();
            return null;
        }

        rend.material.color = potion.GetComponent<Potion>().color;

        return potion;
    }

    public void ResetCauldron()
    {
        ings.Clear();
        rend.material.color = new Color(0, 0.4f, 0);
    }

    void InitPotionOutcomes()
    {
        purple.col1 = Color.red;
        purple.col2 = Color.blue;
        purple.result = new Color(96f / 255f, 92f / 255f, 168f / 255f);

        orange.col1 = Color.red;
        orange.col2 = Color.green;
        orange.result = new Color(247f / 255f, 148f / 255f, 29f / 255f);

        cyan.col1 = Color.green;
        cyan.col2 = Color.blue;
        cyan.result = new Color(28f / 255f, 187f / 255f, 180f / 255f);

        magenta.col1 = Color.red;
        magenta.col2 = Color.green;
        magenta.result = new Color(237f / 255f, 20f / 255f, 91f / 255f);
    }

    public void Interact()
    {
        if (CameraLoc.transform.position == CameraPinLoc.transform.position)
        {
            if (ings.Count == 2)
                mission.Prompt("Create the potion?", 0);
            else
                mission.Alert("This isn't much of a potion...");
        }
    }
}
