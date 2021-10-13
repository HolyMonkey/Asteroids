using UnityEngine;
using Asteroids.Model;

public class AsteroidPresenter : Presenter
{
    private PresentersFactory _factory;

    public new Asteroid Model => base.Model as Asteroid;

    public void Init(PresentersFactory factory)
    {
        _factory = factory;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _factory.CreateAsteroidParts(this);
            DestroyCompose();
        }
    }
}
