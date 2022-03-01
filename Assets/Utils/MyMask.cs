using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMask 
{
    public static bool Contains(LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }
}
