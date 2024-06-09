using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesPointer : MonoBehaviour
{
    [SerializeField] Collectable collectable;

    public Collectable Collectable => collectable;
}
