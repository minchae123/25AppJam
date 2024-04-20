using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isStart = false;

    private void Awake()
    {
        Instance = this;
    }


    public int Hp;
    [SerializeField] private List<GameObject> heart;

    public void ReduceHP()
    {
        if(Hp < 3)
        {
            heart[Hp].SetActive(false);
            Hp++;
        }

        if(Hp == 3)
        {
            UIManager.Instance.GameOver();
            isStart = false;
        }
    }

    public void GameStart()
    {
        isStart = true;
    }
}
