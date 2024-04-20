using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
	public float time = 0;
	float time2 = 5f;//5段績
	PandaSpawner spawner;

	private void Awake()
	{
		spawner = GetComponent<PandaSpawner>();
	}

	private void Update()
	{
		if (spawner.isClickTime)
		{
			time += Time.deltaTime;
		}
		else
			time = 0;
		if (time > time2)
		{
			print("強強強");
			spawner.Spawn();
			time = 0;
		}
	}

	IEnumerator TIMEDJWJRH()
	{
		while (true)
		{
			if (spawner.isClickTime)
			{
				spawner.Spawn();
				yield return new WaitForSeconds(time2);
			}
		}
	}
}
