public class DistanceTransition : EnemyTransition
{
    private void Update()
    {
        if (Target is null)
            return;

        NeedTransit = true;
    }
}