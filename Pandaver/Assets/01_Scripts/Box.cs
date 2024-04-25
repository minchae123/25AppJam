using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public bool isClick = false;
    private PandaSpawner spawner;

    private MeshRenderer render;
    [SerializeField] private Material mat;
    [SerializeField] private Material defaultMat;

    private void Awake()
    {
        spawner = FindObjectOfType<PandaSpawner>();
        render = GetComponent<MeshRenderer>();
    }

    public void BoxClick()
    {
        spawner.Check(int.Parse(this.gameObject.name) - 1);

        ColorChange();
    }

    public void ColorChange()
    {
        if (spawner.isCheck)
        {
            render.material = mat;
        }
        else
        {
            render.material = defaultMat;
        }
    }
}
