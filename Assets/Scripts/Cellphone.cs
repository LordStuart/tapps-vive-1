
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Cellphone : VRTK_InteractableObject {

    public GameObject TouchIndicator;
    public GameObject Screen;
    public Texture whatz;
    public MovieTexture movTexture;
    private bool changed = false;

    private Vector2 touchAxis;

    public void SetTouchAxis(Vector2 data)
    {
        touchAxis = data;
    }

    public void SetTouchIndicatorEnabled(bool enabled)
    {
        TouchIndicator.GetComponent<Renderer>().enabled = enabled;
    }

    public override void Grabbed(GameObject currentGrabbingObject)
    {
        base.Grabbed(currentGrabbingObject);

        Cellphone_Controller script = currentGrabbingObject.AddComponent<Cellphone_Controller>();
        script.init(this);
    }

    public override void Ungrabbed(GameObject previousGrabbingObject)
    {
        base.Ungrabbed(previousGrabbingObject);

        Destroy(previousGrabbingObject.GetComponent<Cellphone_Controller>());

        TouchIndicator.GetComponent<Renderer>().enabled = false;
    }

    public override void StartUsing(GameObject usingObject)
    {
    }

    public override void StopUsing(GameObject usingObject)
    {
        if (!changed) {
            Screen.GetComponent<Renderer>().material.mainTexture = whatz;
            changed = true;
        }
        else {
            Screen.GetComponent<Renderer>().material.mainTexture = movTexture;
            GetComponent<AudioSource>().Play();
            movTexture.Play();
            changed = false;
        }
    }

    protected override void Update()
    {
        TouchIndicator.transform.localPosition = new Vector3(
            -0.45f * touchAxis.y,
            TouchIndicator.transform.localPosition.y,
            0.45f * touchAxis.x
        );
    }
}