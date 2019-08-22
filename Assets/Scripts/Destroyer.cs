using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float Lifetime;
    private void Start()
    {
        Destroy(gameObject, Lifetime);
    }
}
