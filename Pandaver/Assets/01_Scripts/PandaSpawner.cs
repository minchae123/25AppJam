using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PandaSpawner : MonoBehaviour
{
	TimeManager timeManager;

	public List<Transform> SpawnPositionList = new List<Transform>();
	public List<GameObject> RealPandas = new List<GameObject>();

	private List<int> point = new List<int>();

	public GameObject PandasPrefab;

	public bool isClickTime = false;

	[SerializeField] private int maxCount;

	public int curLevel = 0;

	[SerializeField] private FuBao fubao;

	public GameObject correctInfo;

	private void Start()
	{
		timeManager = GetComponent<TimeManager>();
        //fubao = FindObjectOfType<FuBao>();
    }

    void Update()
	{
		if (RealPandas.Count == 0)
		{
			isClickTime = true;
		}
	}

	public void Spawn()
	{
		point = new List<int>();
		RealPandas = new List<GameObject>();

		isClickTime = false;

		/*maxCount = curLevel switch
        {
            < 2 => 2,
            >= 2 and < 5 => 5,
            >= 5 and <= 8 => 7,
            >= 9 and < 13 => 9,
            >= 13 and < 17 => 12,
            _ => 16
        };*/

		int randomCount = Random.Range(1, maxCount);

		for (int i = 0; i < curLevel; i++)
		{
			int randomIndex = Random.Range(0, SpawnPositionList.Count);
			if (SpawnPositionList[randomIndex].childCount == 0)
			{
				point.Add(randomIndex);
				GameObject obj = Instantiate(PandasPrefab, SpawnPositionList[randomIndex]);

				RealPandas.Add(obj);
			}

		}
	}

	public void LevelUp()
	{
		curLevel++;
	}

	public void Check(int remove)
	{
		if (point.Contains(remove))
			point.Remove(remove);
		else
		{
			Fail();
		}

		if (EveryCheck())
		{
			GameClear();
		}
	}

	public void GameClear()
	{
		print("¼º°ø");
		StartCoroutine(GameInfoCoroutine());
		LevelUp();
		fubao.MoveFuBao(curLevel);
	}

	IEnumerator GameInfoCoroutine()
	{
		correctInfo.SetActive(true);
		yield return new WaitForSeconds(0.4f);
		correctInfo.SetActive(false);
        timeManager.time = 0;
        Spawn();
    }

	public void Fail()
	{
		print("‹¯");
		GameManager.Instance.ReduceHP();
        timeManager.time = 0;
        Spawn();
    }

	public bool EveryCheck()
	{
		if (point.Count == 0)
			return true;
		else
			return false;
	}
}
