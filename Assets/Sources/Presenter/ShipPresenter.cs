using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipPresenter : Presenter
{
    private EndGameWindowPresenter _endGameWindow;
    private Init _init;

    public void Init(Init init, EndGameWindowPresenter endGameWindow)
    {
        _init = init;
        _endGameWindow = endGameWindow;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _init.DisableShip();
            _endGameWindow.Show(0, () => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));
        }
    }
}
