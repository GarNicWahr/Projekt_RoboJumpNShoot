using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public Slider live1;
    public Slider live2;
    public Slider live3;

    private int maxValue = 1;

    // Start is called before the first frame update
    void Start()
    {
        live1.value = maxValue;
        live2.value = maxValue;
        live3.value = maxValue;
    }

    //Anzahl Leben
    public void SetLiveCount(int count)
    {
        if (live3.value == 1)
        {
            live3.value = count;
        }
        else if (live2.value == 1 && live3.value == 0)
        {
            live2.value = count;
        }
        else if (live1.value== 1 && live3.value == 0 && live2.value == 0) 
        { 
            live1.value = count; 
        }
    }
    
}
