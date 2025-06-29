using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _highlightColor;

    private Material _material;
    private Color _originalColor;
    private bool _originalColorIsSet = false; // Orijinal rengi kaydedip etmediðimizi kontrol etmek için bir bayrak.

    // Awake fonksiyonuna artýk ihtiyacýmýz yok, çünkü rengi daha sonra öðreneceðiz.

    // Bu fonksiyon çaðrýldýðýnda karonun rengini vurgu rengi yapar.
    public void Highlight()
    {
        // Eðer orijinal rengi daha önce hiç kaydetmediysek...
        if (!_originalColorIsSet)
        {
            // ...þimdi tam zamaný.
            _material = GetComponent<Renderer>().material; // Materyali al
            _originalColor = _material.color;             // Þu anki (dama tahtasý) rengini kaydet
            _originalColorIsSet = true;                   // Ve kaydettiðimizi iþaretle
        }

        // Rengi vurgu rengiyle deðiþtir.
        _material.color = _highlightColor;
    }

    // Bu fonksiyon çaðrýldýðýnda karonun rengini orijinal haline döndürür.
    public void RemoveHighlight()
    {
        // Eðer orijinal rengi biliyorsak, o renge geri dön.
        if (_originalColorIsSet)
        {
            _material.color = _originalColor;
        }
    }
}