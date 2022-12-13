using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{

    public static UIController Instance {get; private set;}
    public TextMeshProUGUI _healthText; //TMPro
    public Slider _healthSlider;
    // Start is called before the first frame update
     void Awake() {
    if(Instance!=null && Instance != this)
    {
        Destroy(this);
    }else{
        Instance = this;
    }
}
}
