using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuField 
{
    public string text { get; set; }

    public MenuField(string field)
    {
        text = field;
    }

    public virtual void OnClick(AudioManager audioManager)
    {
        
    }

}
