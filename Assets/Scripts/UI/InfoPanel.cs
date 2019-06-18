﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanel : UI_Element
{
    public override void Highlight()
    {
        // If the infopanel is part of a magic corner, keep the magic corner highlighted as well
        if (menuManager != null)
            menuManager.Highlight();
    }

    protected override void SubclassStart()
    {
        
    }

    protected override void SubclassUpdate()
    {
        
    }
}
