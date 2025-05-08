using System.Collections;
using UnityEngine;

public class StartingLights : MonoBehaviour
{
    public GameObject RedLightOn;
    public GameObject OrangeLightOn;
    public GameObject GreenLightOn;

    public GameObject Countone;
    public GameObject Counttwo;
    public GameObject Countthree;
    public GameObject Go;

    public AudioSource BeepSound1;
    public AudioSource BeepSound2;
    public AudioSource BeepSound3;
    public AudioSource Gosound;

    public float stepDelay = 1f; // Configurable delay between steps

    void Start()
    {
        StartCoroutine(StartingLight());
    }

    IEnumerator StartingLight()
    {
        yield return new WaitForSeconds(stepDelay);
        ActivateStep(RedLightOn, BeepSound3, Countone);

        yield return new WaitForSeconds(stepDelay);
        ActivateStep(OrangeLightOn, BeepSound2, Counttwo);
        DeactivatePreviousStep(RedLightOn, Countone);

        yield return new WaitForSeconds(stepDelay);
        ActivateStep(GreenLightOn, BeepSound1, Countthree);
        DeactivatePreviousStep(OrangeLightOn, Counttwo);

        yield return new WaitForSeconds(stepDelay);
        DeactivatePreviousStep(GreenLightOn, Countthree);
        Gosound.Play();
        Go.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        SaveScript.RaceStart = true;
        Go.SetActive(false);
    }

    void ActivateStep(GameObject light, AudioSource sound, GameObject countText)
    {
        if (light != null) light.SetActive(true);
        if (sound != null) sound.Play();
        if (countText != null) countText.SetActive(true);
    }

    void DeactivatePreviousStep(GameObject light, GameObject countText)
    {
        if (light != null) light.SetActive(false);
        if (countText != null) countText.SetActive(false);
    }

    void Update()
    {
        // Update logic (if needed)
    }
}