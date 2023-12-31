public class BossEnemy : Enemy
{
    public bool CanMove;
    public BoosRoom _bossRoom;
    
    private IShooting _gun;
    
    
    protected override void Start()
    {
        base.Start();
        _gun = GetComponentInChildren<BossAttack>();
    }
    
    protected override void Move()
    {
       // if (CanMove)
         //   base.Move();
    }


    protected override void Attack()
    {
        if (CanMove)
        {
            _gun.Fire();
        }
    }
}