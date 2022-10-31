using Codice.Client.Common.GameUI;
using ItIsNotOnlyMe.ManejoDeInputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ControlarPersonaje : MonoBehaviour
{
    [SerializeField] private EventoActivacion _activacionPersonaje;
    [SerializeField] private EventoActivacion _activacionAuto;

    [Space]

    [SerializeField] private EventoVector2 _eventoMover;
    [SerializeField] private Evento _eventoInteractuar;

    [Space]

    [SerializeField] private Evento _entraZonaInteraccion;
    [SerializeField] private Evento _saleZonaInteraccion;

    [Space]

    [SerializeField] private float _rapidezAlCaminar = 10;
    [SerializeField] private float _gravedad = 10;
    [SerializeField] private float _tiempoDeTransicionEnMovimiento;

    private CharacterController _controlador;
    private Vector3 _direccionInput;
    private Vector3 _velocidad;
    private float _velocidadVertical;

    private bool _puedeInteractuar = false;

    private void Awake()
    {
        _controlador = GetComponent<CharacterController>();

        if (_activacionPersonaje != null)
            _activacionPersonaje.SetearActivacion(true);

        if (_eventoMover != null)
            _eventoMover.EventoActual += Moverse;

        if (_eventoInteractuar != null)
            _eventoInteractuar.EventoActual += Interactuar;

        if (_entraZonaInteraccion != null)
            _entraZonaInteraccion.EventoActual += PermiteInteractuar;

        if (_saleZonaInteraccion != null)
            _saleZonaInteraccion.EventoActual += NoPermiteInteractuar;

        _puedeInteractuar = false;
    }

    private void OnDestroy()
    {
        if (_eventoMover != null)
            _eventoMover.EventoActual -= Moverse;

        if (_eventoInteractuar != null)
            _eventoInteractuar.EventoActual -= Interactuar;

        if (_entraZonaInteraccion != null)
            _entraZonaInteraccion.EventoActual -= PermiteInteractuar;

        if (_saleZonaInteraccion != null)
            _saleZonaInteraccion.EventoActual -= NoPermiteInteractuar;
    }

    private void Update()
    {
        Vector3 worldInputDir = transform.TransformDirection(_direccionInput);
        Vector3 targetVelocity = worldInputDir * _rapidezAlCaminar;
        Vector3 velocidadSuavidado = Vector3.zero;

        _velocidad = Vector3.SmoothDamp(_velocidad, targetVelocity, ref velocidadSuavidado, _tiempoDeTransicionEnMovimiento);

        _velocidadVertical -= _gravedad * Time.deltaTime;
        _velocidad = new Vector3(_velocidad.x, _velocidadVertical, _velocidad.z);

        var flags = _controlador.Move(_velocidad * Time.deltaTime);
        if (flags == CollisionFlags.Below)
            _velocidadVertical = 0;
    }

    private void Moverse(Vector2 direccion)
    {
        _direccionInput = new Vector3(direccion.x, 0, direccion.y).normalized;
    }

    private void Interactuar()
    {
        if (!_puedeInteractuar)
            return;

        if (_activacionPersonaje != null)
            _activacionPersonaje.SetearActivacion(false);

        if (_activacionAuto != null)
            _activacionAuto.SetearActivacion(true);
    }

    private void PermiteInteractuar() => _puedeInteractuar = true;
    private void NoPermiteInteractuar() => _puedeInteractuar = false;
}
