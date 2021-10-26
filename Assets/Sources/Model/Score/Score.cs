namespace Asteroids.Model
{
    public class Score
    {
        public int Value => _enemyVisitor.AccumulatedScore;

        private readonly EnemyVisitor _enemyVisitor = new EnemyVisitor();

        public void OnKill(Enemy enemy)
        {
            _enemyVisitor.Visit(enemy);
        }

        private class EnemyVisitor : IEnemyVisitor
        {
            public int AccumulatedScore { get; private set; }

            public void Visit(Asteroid asteroid)
            {
                AccumulatedScore += 10;
            }

            public void Visit(Nlo nlo)
            {
                AccumulatedScore += 20;
            }

            public void Visit(PartOfAsteroid nlo)
            {
                AccumulatedScore += 5;
            }

            public void Visit(Enemy enemy)
            {
                Visit((dynamic)enemy);
            }
        }
    }
}
