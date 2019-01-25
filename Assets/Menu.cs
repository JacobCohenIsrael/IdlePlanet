using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private Text dna;
    
    void Update()
    {
        dna.text = GameManager.Dna.ToString();
    }
}
