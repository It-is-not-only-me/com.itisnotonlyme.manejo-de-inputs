using UnityEngine;
using UnityEngine.InputSystem;
using ItIsNotOnlyMe.ManejoDeInputs;

[CreateAssetMenu(fileName = "Input Auto", menuName = "Inputs/Input Auto")]
public class InputsAutoSO : InputSO, Inputs.IAutoActions
{
    [SerializeField] private InputManagerSO _manejoDeInputs;

    public Vector2 Direccion { get { return _direccion; } }
    [SerializeField] private EventoGenerico<Vector2> _eventoMover;

    [SerializeField] private Evento _eventoSalir;

    public bool Turbo { get { return _turbo; } }
    [SerializeField] private Evento _eventoTurboEmpezar;
    [SerializeField] private Evento _eventoTurboTerminar;

    private Inputs.AutoActions _accionesDelAuto => _manejoDeInputs.Inputs.Auto;

    private Vector2 _direccion;
    private bool _turbo = false;

    private void OnEnable() => _accionesDelAuto.SetCallbacks(this);

    public override void Activar() => _accionesDelAuto.Enable();
    public override void Desactivar() => _accionesDelAuto.Disable();

    public void OnMovimiento(InputAction.CallbackContext context)
    {
        Vector2 direccion = context.ReadValue<Vector2>();
        _eventoMover?.Invoke(direccion);
        Moviendose(direccion);
    }

    public void OnSalir(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
            _eventoSalir?.Invoke();
    }

    public void OnTurbo(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            _eventoTurboEmpezar?.Invoke();
            EmpezandoTurbo();
        }

        if (context.phase == InputActionPhase.Canceled)
        {
            _eventoTurboTerminar?.Invoke();
            TerminandoTurbo();
        }
    }

    private void Moviendose(Vector2 direccion) => _direccion = direccion;
    private void EmpezandoTurbo() => _turbo = true;
    private void TerminandoTurbo() => _turbo = false;
}

