using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject overPanel;
    [SerializeField] private GameObject TopPanel;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject clearPanel;
    [SerializeField] private Animator animator;

    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
	{
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameOver();
        }

        if (Input.anyKey)
        {
            StartPanel();
        }
	}

    public void StartPanel()
    {
        TopPanel.SetActive(true);
        animator.SetTrigger("start");
        GameManager.Instance.GameStart();
    }

    public void GameClear()
    {
        clearPanel.transform.DOLocalMoveY(0, 1);
        print("유아이매니저에서게임클리어를하였다");
    }

	public void GameOver()
    {
        overPanel.transform.DOLocalMoveY(0, 1f);
    }

    public void SceneChange(int num)
    {
        SceneManager.LoadScene(num);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
