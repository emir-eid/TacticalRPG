using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width, _height;
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private Material _tileMaterialLight, _tileMaterialDark;

    private Tile _highlightedTile; // Vurgulanan karoyu hafýzada tutmak için deðiþkenimiz

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

                bool isOffset = (x + y) % 2 == 1;
                Material assignedMaterial = isOffset ? _tileMaterialDark : _tileMaterialLight;
                spawnedTile.GetComponent<Renderer>().material = assignedMaterial;
            }
        }
    }

    // --- GÜNCELLENEN UPDATE FONKSÝYONU ---
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Tile tile = hitInfo.collider.GetComponent<Tile>();

            if (tile != null)
            {
                if (_highlightedTile != tile)
                {
                    if (_highlightedTile != null)
                        _highlightedTile.RemoveHighlight();

                    tile.Highlight();
                    _highlightedTile = tile;
                }
            }
            else
            {
                if (_highlightedTile != null)
                {
                    _highlightedTile.RemoveHighlight();
                    _highlightedTile = null;
                }
            }
        }
        else
        {
            if (_highlightedTile != null)
            {
                _highlightedTile.RemoveHighlight();
                _highlightedTile = null;
            }
        }
    }
}