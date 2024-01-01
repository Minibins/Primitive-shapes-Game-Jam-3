using UnityEngine;

public class FolowBullet : Bullet
{
    public bool IsFolow;
    public float FollowSpeed;
    public Transform targetTransform;
    
    private void FixedUpdate()
    {
        if(IsFolow) Folow();
    }

    public void Folow()
    {
        if (targetTransform != null)
        {
            Vector3 targetPosition = new Vector3(targetTransform.position.x, targetTransform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, FollowSpeed * Time.fixedDeltaTime);
        }
    }
}
