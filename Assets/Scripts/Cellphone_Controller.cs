
using UnityEngine;
using VRTK;

public class Cellphone_Controller : MonoBehaviour
{
    private Cellphone cellScript;

    private void Start()
    {
        GetComponent<VRTK_ControllerEvents>().TouchpadAxisChanged += new ControllerInteractionEventHandler(DoTouchpadAxisChanged);
        GetComponent<VRTK_ControllerEvents>().TouchpadTouchEnd += new ControllerInteractionEventHandler(DoTouchpadTouchEnd);
        GetComponent<VRTK_ControllerEvents>().TouchpadTouchStart += new ControllerInteractionEventHandler(DoTouchpadTouchStart);
    }

    public void init(Cellphone cellScript)
    {
        this.cellScript = cellScript;
    }

    private void DoTouchpadAxisChanged(object sender, ControllerInteractionEventArgs e)
    {
        cellScript.SetTouchAxis(e.touchpadAxis);
    }

    private void DoTouchpadTouchEnd(object sender, ControllerInteractionEventArgs e)
    {
        cellScript.SetTouchIndicatorEnabled(false);
    }

    private void DoTouchpadTouchStart(object sender, ControllerInteractionEventArgs e)
    {
        cellScript.SetTouchIndicatorEnabled(true);
    }
}