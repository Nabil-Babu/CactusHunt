using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDHandler : Singleton<HUDHandler>
{
    public TextMeshProUGUI CactusCount;
    public TextMeshProUGUI Health;
    public TextMeshProUGUI StunAlert;
    public TextMeshProUGUI GameOver;
    public TextMeshProUGUI Victory;
    public int CurrentCactusCount
    {
        set => CactusCount.text = value.ToString();
    }
    
    public int CurrentHealth
    {
        set => Health.text = value.ToString();
    }
}
