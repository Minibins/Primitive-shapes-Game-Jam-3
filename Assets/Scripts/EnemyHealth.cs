public class EnemyHealth: Health
    {
        public override void ApplyDamage(int _damage)
        {
            base.ApplyDamage(_damage);
        }

        public override void RegenerateHealth(int _coutHealth)
        {
            base.RegenerateHealth(_coutHealth);
        }
    }