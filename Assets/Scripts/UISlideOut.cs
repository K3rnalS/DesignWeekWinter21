using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class UISlideOut : MonoBehaviour
{
    public bool sildeOut;
    public float time = 2;
    public Vector2 startLocation;
    public Vector2 endLocation;
    public iTween.EaseType easeType;
    public bool destroyable = false; //destroys after sliding in if true

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Application.isPlaying)
            return;

        startLocation = this.GetComponent<RectTransform>().anchoredPosition;
    }

    /// <summary>
    /// play slide animation to end location
    /// </summary>
    public void ShotSlideOut()
    {
        if (!sildeOut)
        {
            iTween.ValueTo(this.gameObject,
                iTween.Hash(
                    "from", this.GetComponent<RectTransform>().anchoredPosition,
                    "to", endLocation,
                    "time", time,
                    "easetype",easeType,
                    "onupdate", "OnAnimationUpdate"));
            sildeOut = true;
        }
    }

    /// <summary>
    /// play slide animation to start location
    /// </summary>
    public void ShotSlideIn()
    {
        if (sildeOut)
        {
            iTween.ValueTo(this.gameObject,
                iTween.Hash(
                    "from", this.GetComponent<RectTransform>().anchoredPosition,
                    "to", startLocation,
                    "time", time,
                    "easetype", easeType,
                    "onupdate", "OnAnimationUpdate"));
            sildeOut = false;

            if (destroyable)
                StartCoroutine(Destroyer());
        }

    }

    /// <summary>
    /// update movement animation
    /// </summary>
    /// <param name="v2"></param>
    private void OnAnimationUpdate(Vector2 v2)
    {
        this.GetComponent<RectTransform>().anchoredPosition = v2;
    }

    public IEnumerator Destroyer()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
     
}
