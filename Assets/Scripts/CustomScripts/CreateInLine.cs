using UnityEngine;

public class CreateInLine : SampleSript
{
    [SerializeField]
    private GameObject prefab;     // Префаб для копирования

    [SerializeField]
    private int repetitions = 5;   // Количество копий

    [SerializeField]
    private float stepDistance = 2f; // Расстояние между объектами

    [ContextMenu("Pahai")]
    // Метод для создания объектов
    public override void Use()
    {
        if (prefab == null)
        {
            Debug.LogError("Prefab is not assigned!");
            return;
        }

        for (int i = 0; i < repetitions; i++)
        {
            // Рассчитываем позицию для нового объекта
            Vector3 newPosition = transform.position + transform.forward * (stepDistance * i);
            // Создаем экземпляр префаба
            Instantiate(prefab, newPosition, transform.rotation);
        }
    }
}