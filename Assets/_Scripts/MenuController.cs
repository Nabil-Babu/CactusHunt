using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject Instructions;

    public void ToggleInstructions()
    {
        Instructions.SetActive(!Instructions.activeInHierarchy);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
