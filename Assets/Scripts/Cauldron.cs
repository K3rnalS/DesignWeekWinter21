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
    public PotionOutcome violet;

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

        if (ings.Contains(Color.red) && ings.Contains(Color.blue))
		{
            potion.GetComponent<Potion>().color = purple.result;
			AudioManager.audioInstance.Audio.PlayOneShot(AudioManager.audioInstance.Correct);
		}
        else if (ings.Contains(Color.red) && ings.Contains(Color.green))
		{
            potion.GetComponent<Potion>().color = orange.result;
			AudioManager.audioInstance.Audio.PlayOneShot(AudioManager.audioInstance.Correct);
		}
        else if (ings.Contains(Color.green) && ings.Contains(Color.blue))
		{
            potion.GetComponent<Potion>().color = cyan.result;
			AudioManager.audioInstance.Audio.PlayOneShot(AudioManager.audioInstance.Correct);
		}
        else if (ings.Contains(Color.blue) && ings.Contains(Color.blue))
		{
            potion.GetComponent<Potion>().color = violet.result;
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
        purple.result = new Color(0.50f, 0, 0.50f);

        orange.col1 = Color.red;
        orange.col2 = Color.green;
        orange.result = new Color(1, 0.65f, 0);

        cyan.col1 = Color.green;
        cyan.col2 = Color.blue;
        cyan.result = new Color(0, 1, 1);

        violet.col1 = Color.red;
        violet.col2 = Color.green;
        violet.result = new Color(0.50f, 0, 1);
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
