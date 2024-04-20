using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    PandaSpawner spawner;

    private void Awake()
    {
        spawner = GetComponent<PandaSpawner>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.CompareTag("DDdd"))
                {
                    //spawner.PandasList.Add(int.Parse(hit.collider.name));
                }
            }
        }
    }
}
