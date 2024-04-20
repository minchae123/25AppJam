using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PandaSpawner : MonoBehaviour
{
    public List<Transform> SpawnPositionList = new List<Transform>();
    public List<GameObject> RealPandas = new List<GameObject>();

    private List<int> point = new List<int>();

    public GameObject PandasPrefab;

    Dictionary<bool, bool> dic = new Dictionary<bool, bool>();
    //public List<int> PandasList = new List<int>();

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Spawn();
        }
    }

    void Spawn()
    {
        point = new List<int>();
        RealPandas = new List<GameObject>();

        int randomCount = Random.Range(0, 10);

        for (int i = 0; i < randomCount; i++)
        {
            int randomIndex = Random.Range(0, SpawnPositionList.Count);
            if (SpawnPositionList[randomIndex].childCount == 0)
            {
                point.Add(randomIndex);
                GameObject obj = Instantiate(PandasPrefab, SpawnPositionList[randomIndex]);


                RealPandas.Add(obj);
            }
            else
            {
                print("두개는나오지마셈");
            }

        }
    }

    public void Check(int remove)
    {
        print(remove);
        if (point.Contains(remove))
            point.Remove(remove);

        print(EveryCheck());
    }

    public bool EveryCheck()
    {
        if (point.Count == 0)
            return true;
        else
            return false;
    }
}
