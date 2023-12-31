using UnityEngine;
using System.Collections.Generic;

public class Shop : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject[] _items;

    private void Start()
    {
        // Создаем список для хранения индексов объектов
        List<int> availableIndexes = new List<int>(_items.Length);
        for (int i = 0; i < _items.Length; i++)
        {
            availableIndexes.Add(i);
        }

        // Применяем алгоритм Fisher-Yates Shuffle к списку индексов
        for (int i = 0; i < availableIndexes.Count - 1; i++)
        {
            int randomIndex = Random.Range(i, availableIndexes.Count);
            int temp = availableIndexes[i];
            availableIndexes[i] = availableIndexes[randomIndex];
            availableIndexes[randomIndex] = temp;
        }

        // Создаем объекты в случайных местах без повторений
        for (int i = 0; i < Mathf.Min(_spawnPoints.Length, availableIndexes.Count); i++)
        {
            int randomItemIndex = availableIndexes[i];
            Instantiate(_items[randomItemIndex], _spawnPoints[i].position, Quaternion.identity);
        }
    }
}