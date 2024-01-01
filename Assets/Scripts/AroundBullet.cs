using System.Collections;
using UnityEngine;

public class AroundBullet : Bullet
{
    public bool IsAround;
    public float RotationSpeed; // Скорость вращения
    public Transform centerPoint; // Центр вращения

    private void FixedUpdate()
    {
        if (IsAround)
        {
            RotateAroundCenter();
        }
    }

    private void RotateAroundCenter()
    {
        if (centerPoint != null)
        {
            // Получаем текущую позицию пули относительно центра вращения
            Vector3 offset = transform.position - centerPoint.position;

            // Вычисляем угол вращения
            float rotation = RotationSpeed * Time.fixedDeltaTime;

            // Поворачиваем позицию пули относительно центра вращения
            offset = Quaternion.Euler(0, 0, rotation) * offset;

            // Обновляем позицию пули
            transform.position = centerPoint.position + offset;

            // При необходимости, вы также можете поворачивать сам объект пули
            // transform.Rotate(Vector3.forward * rotation);
        }
    }
}