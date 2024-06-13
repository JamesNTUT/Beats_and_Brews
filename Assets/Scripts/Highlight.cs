using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    public List<Renderer> _renderers;
    public Color _color = Color.white;
    public List<Material> _materials;

    private void Awake()
    {
        _materials = new List<Material>();
        foreach (var renderer in _renderers)
        {
            _materials.AddRange(new List<Material>(renderer.materials));
        }
    }

    public void ToggleHighlight(bool _val)
    {
        if (_val)
        {
            foreach (var material in _materials)
                {
                    material.EnableKeyword("EMISSION");
                    material.SetColor("EMISSIONCOLOR", _color);
                }
        }
        else
        {
            foreach (var material in _materials)
            {
                material.DisableKeyword("EMISSION");
            }
        }
    }
}
