using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width, _height;
    [SerializeField] private GameObject _tilePrefab;

    // --- YEN�: Materyal de�i�kenleri ---
    [SerializeField] private Material _tileMaterialLight;
    [SerializeField] private Material _tileMaterialDark;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                float xPos = x - (_width / 2.0f) + 0.5f;
                float zPos = y - (_height / 2.0f) + 0.5f;

                GameObject spawnedTile = Instantiate(_tilePrefab, new Vector3(xPos, 0, zPos), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

                // --- YEN�: Dama tahtas� mant��� ---
                // (x+y) toplam� �ift ise a��k, tek ise koyu renk ata.
                bool isOffset = (x + y) % 2 == 1;
                Material assignedMaterial = isOffset ? _tileMaterialDark : _tileMaterialLight;

                // Tile objesinin Renderer bile�enini bul ve materyalini ata.
                spawnedTile.GetComponent<Renderer>().material = assignedMaterial;
            }
        }
    }
}