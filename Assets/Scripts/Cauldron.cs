using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    public MeshRenderer rend;

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
        if (ings.Count > 2)
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
            potion.GetComponent<Potion>().color = purple.result;
        else if (ings.Contains(Color.red) && ings.Contains(Color.green))
            potion.GetComponent<Potion>().color = orange.result;
        else if (ings.Contains(Color.green) && ings.Contains(Color.blue))
            potion.GetComponent<Potion>().color = cyan.result;
        else if (ings.Contains(Color.red) && ings.Contains(Color.green))
            potion.GetComponent<Potion>().color = violet.result;
        else
        {
            ResetCauldron();
            Destroy(potion);
            return null;
        }

        ResetCauldron();

        return potion;
    }

    void ResetCauldron()
    {
        ings.Clear();
        rend.material.color = Color.white;
    }

    void InitPotionOutcomes()
    {
        purple.col1 = Color.red;
        purple.col2 = Color.blue;
        purple.result = new Color(128, 0, 128);

        orange.col1 = Color.red;
        orange.col2 = Color.green;
        orange.result = new Color(255, 165, 0);

        cyan.col1 = Color.green;
        cyan.col2 = Color.blue;
        cyan.result = new Color(0, 255, 255);

        violet.col1 = Color.red;
        violet.col2 = Color.green;
        violet.result = new Color(127, 0, 255);
    }
}
