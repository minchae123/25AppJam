using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FuBao : MonoBehaviour
{
    public void MoveFuBao(int level)
    {
        transform.DOLocalMoveX(transform.localPosition.x + level * -0.3f, 0.8f);

        if (transform.localPosition.x <= -20)
        {
            UIManager.Instance.GameClear();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject);
    }
}
