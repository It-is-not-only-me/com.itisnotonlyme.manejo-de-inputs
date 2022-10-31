using ItIsNotOnlyMe.ManejoDeInputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ControlarAuto : MonoBehaviour
{
    [SerializeField] private EventoActivacion _activacionAuto;
    [SerializeField] private EventoActivacion _activacionPersonaje;

    [Space]

    [SerializeField] private EventoVector2 _eventoMover;
    [SerializeField] private Evento _eventoSalir;

    [Space]

    [SerializeField] private float _rapidezAlCaminar = 10;
    [SerializeField] private float _gravedad = 10;
    [SerializeField] private float _tiempoDeTransicionEnMovimiento;

    private CharacterController _controlador;
    private Vector3 _direccionInput;
    private Vector3 _velocidad;
    private float _velocidadVertical;

    private void Awake()
    {
        _controlador = GetComponent<CharacterController>();

        if (_eventoMover != null)
            _eventoMover.EventoActual += Moverse;

        if (_eventoSalir != null)
            _eventoSalir.EventoActual += Salir;
    }

    private void OnDestroy()
    {
        if (_eventoMover != null)
            _eventoMover.EventoActual -= Moverse;

        if (_eventoSalir != null)
            _eventoSalir.EventoActual -= Salir;
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

    private void Salir()
    {
        if (_activacionAuto != null)
            _activacionAuto.SetearActivacion(false);

        if (_activacionPersonaje != null)
            _activacionPersonaje.SetearActivacion(true);
    }
}
