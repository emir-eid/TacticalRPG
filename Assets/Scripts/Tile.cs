using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _highlightColor;

    private Material _material;
    private Color _originalColor;
    private bool _originalColorIsSet = false; // Orijinal rengi kaydedip etmedi�imizi kontrol etmek i�in bir bayrak.

    // Awake fonksiyonuna art�k ihtiyac�m�z yok, ��nk� rengi daha sonra ��renece�iz.

    // Bu fonksiyon �a�r�ld���nda karonun rengini vurgu rengi yapar.
    public void Highlight()
    {
        // E�er orijinal rengi daha �nce hi� kaydetmediysek...
        if (!_originalColorIsSet)
        {
            // ...�imdi tam zaman�.
            _material = GetComponent<Renderer>().material; // Materyali al
            _originalColor = _material.color;             // �u anki (dama tahtas�) rengini kaydet
            _originalColorIsSet = true;                   // Ve kaydetti�imizi i�aretle
        }

        // Rengi vurgu rengiyle de�i�tir.
        _material.color = _highlightColor;
    }

    // Bu fonksiyon �a�r�ld���nda karonun rengini orijinal haline d�nd�r�r.
    public void RemoveHighlight()
    {
        // E�er orijinal rengi biliyorsak, o renge geri d�n.
        if (_originalColorIsSet)
        {
            _material.color = _originalColor;
        }
    }
}