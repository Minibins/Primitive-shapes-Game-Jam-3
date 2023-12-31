public class BossEnemy : RedCubeEnemy
{
    public bool CanMove;
    public BoosRoom _boosRoom;
    
    protected override void Move()
    {
        if (CanMove)
            base.Move();
    }
}