using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpUI : MonoBehaviour
{
    public Slider sliderPulse;
    public Slider sliderSuper;
    public Slider sliderSpacePart;

    private void Start()
    {
        //SpaceShipPart Indikator ausblenden
        sliderSpacePart.value = 0;
    }
    public void SetSliderPulse(int on)
    {
        //Pulse Indikator anzeigen
        sliderPulse.value = on;
    }

    public void SetSliderSuper(int on)
    {
        //SuperGun Indikator anzeigen
        sliderSuper.value = on;
    }

    public void SetSliderSpacePart(int on)
    {
        //SpaceShipPart Indikator
        sliderSpacePart.value = on;
    }
}
