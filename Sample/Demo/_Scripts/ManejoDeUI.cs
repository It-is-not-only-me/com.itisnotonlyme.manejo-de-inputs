using ItIsNotOnlyMe.ManejoDeInputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejoDeUI : MonoBehaviour
{
    [SerializeField] private EventoActivacion _activarUI;

    [Space]

    [SerializeField] private GameObject _textoMenu, _textoInventario;

    [Space]

    [SerializeField] private Evento _eventoMenu, _eventoInventario;

    private bool _mostrandoMenu = false, _mostrandoInventario = false;

    private void Awake()
    {
        _activarUI?.SetearActivacion(true);

        if (_eventoMenu != null)
            _eventoMenu.EventoActual += ActivarMenu;

        if (_eventoInventario != null)
            _eventoInventario.EventoActual += ActivarInventario;
    }

    private void OnDestroy()
    {
        if (_eventoMenu != null)
            _eventoMenu.EventoActual -= ActivarMenu;

        if (_eventoInventario != null)
            _eventoInventario.EventoActual -= ActivarInventario;
    }

    private void ActivarMenu()
    {
        ActivacionInventario(false);
        ActivacionMenu(!_mostrandoMenu);
    }

    private void ActivarInventario()
    {
        ActivacionMenu(false);
        ActivacionInventario(!_mostrandoInventario);
    }

    private void ActivacionMenu(bool activado)
    {
        _mostrandoMenu = activado;
        _textoMenu.SetActive(_mostrandoMenu);
    }

    private void ActivacionInventario(bool activado)
    {
        _mostrandoInventario = activado;
        _textoInventario.SetActive(_mostrandoInventario);
    }
}
