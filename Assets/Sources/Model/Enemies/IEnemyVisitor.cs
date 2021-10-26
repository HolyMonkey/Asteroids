namespace Asteroids.Model
{
    public interface IEnemyVisitor
    {
        void Visit(Enemy enemy);
        void Visit(Asteroid asteroid);
        void Visit(Nlo nlo);
        void Visit(PartOfAsteroid nlo);
    }
}
