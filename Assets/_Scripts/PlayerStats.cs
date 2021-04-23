using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Private values for Properities
    private int _currentCactusCount; 
    private int _currentHealth;
    
    // Power Up States
    private bool _hasStunLoaded = false; 
    
    // Public Values
    public int MaxHealth = 100;
    // Properties
    public int CurrentCactusCount
    {
        get
        {
            return _currentCactusCount;
        }
        set
        {
            _currentCactusCount = value;
            HUDHandler.instance.CurrentCactusCount = value;
        }
    }
    public int CurrentHealth
    {
        get => _currentHealth;
        set
        {
            _currentHealth = value;
            HUDHandler.instance.CurrentHealth = value; 
        }
    }

    public bool HasSpeedBoost { get; set; } = false;

    public bool HasStunLoaded
    {
        get => _hasStunLoaded;
        set
        {
            _hasStunLoaded = value;
            HUDHandler.instance.StunAlert.gameObject.SetActive(value);
        }
    }
}
