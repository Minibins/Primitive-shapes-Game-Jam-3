public class BossEnemyHealth : EnemyHealth
{
    public override void Die()
    {
       //base.Die();
       Destroy(gameObject);
       GetComponent<BossEnemy>()._bossRoom.BossDie();
    }
}