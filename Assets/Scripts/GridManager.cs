using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width, _height;
    [SerializeField] private GameObject _tilePrefab;

    // --- YENÝ: Materyal deðiþkenleri ---
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

                // --- YENÝ: Dama tahtasý mantýðý ---
                // (x+y) toplamý çift ise açýk, tek ise koyu renk ata.
                bool isOffset = (x + y) % 2 == 1;
                Material assignedMaterial = isOffset ? _tileMaterialDark : _tileMaterialLight;

                // Tile objesinin Renderer bileþenini bul ve materyalini ata.
                spawnedTile.GetComponent<Renderer>().material = assignedMaterial;
            }
        }
    }
}