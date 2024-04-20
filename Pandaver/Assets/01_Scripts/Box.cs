using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public bool isClick = false;
    private PandaSpawner spawner;

    private Material mat;

    private void Awake()
    {
        spawner = FindObjectOfType<PandaSpawner>();
    }

    public void BoxClick()
    {
        spawner.Check(int.Parse(this.gameObject.name) - 1);
    }
}
