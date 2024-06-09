using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LayerUtility
{
    public static bool HasLayerMask(this GameObject obj, LayerMask layermask2)
    {
        return (layermask2.value & 1 << obj.layer) > 0;
    }
}
