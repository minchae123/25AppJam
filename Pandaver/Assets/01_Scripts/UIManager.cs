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
