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

	private FuBao fubao;

	private void Start()
	{
		timeManager = GetComponent<TimeManager>();
		fubao = FindObjectOfType<FuBao>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Spawn();
		}
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
			else
			{
				print("두개는나오지마셈");
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
			timeManager.time = 0;
			Spawn();
		}
	}

	public void GameClear()
	{
		print("성공");
		LevelUp();
		fubao.MoveFuBao(curLevel);
	}

	public void Fail()
	{
		print("떙");
	}

	public bool EveryCheck()
	{
		if (point.Count == 0)
			return true;
		else
			return false;
	}
}
