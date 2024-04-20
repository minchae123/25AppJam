using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FuBao : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.D))
		{
			MoveFuBao(8);
		}
	}

	public void MoveFuBao(int level)
	{
		transform.DOLocalMoveX(transform.localPosition.x + level * -10f, 1f);
	}
}
