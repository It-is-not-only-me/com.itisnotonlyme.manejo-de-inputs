using UnityEngine;
using UnityEngine.InputSystem;
using ItIsNotOnlyMe.ManejoDeInputs;

[CreateAssetMenu(fileName = "Input Auto", menuName = "Inputs/Input Auto")]
public class InputsAutoSO : ScriptableObject, Inputs.IAutoActions, ICambio
{
    [SerializeField] private ManejoDeInputsSO _manejoDeInputs;

    public Vector2 Direccion { get { return _direccion; } }
    [SerializeField] private Evento<Vector2> EventoMover;

    [SerializeField] private Evento EventoSalir;

    public bool Turbo { get { return _turbo; } }
    [SerializeField] private Evento EventoTurboEmpezar;
    [SerializeField] private Evento EventoTurboTerminar;

    private Inputs.AutoActions _accionesDelAuto => _manejoDeInputs.Inputs.Auto;

    private Vector2 _direccion;
    private bool _turbo = false;


    public void Activar() => _accionesDelAuto.Enable();
    public void Desactivar() => _accionesDelAuto.Disable();

    public void OnMovimiento(InputAction.CallbackContext context)
    {
        Vector2 direccion = context.ReadValue<Vector2>();
        EventoMover?.Invoke(direccion);
        Moviendose(direccion);
    }

    public void OnSalir(InputAction.CallbackContext context)
    {
        EventoSalir?.Invoke();
    }

    public void OnTurbo(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            EventoTurboEmpezar?.Invoke();
            EmpezandoTurbo();
        }

        if (context.phase == InputActionPhase.Canceled)
        {
            EventoTurboTerminar?.Invoke();
            TerminandoTurbo();
        }
    }

    private void Moviendose(Vector2 direccion) => _direccion = direccion;
    private void EmpezandoTurbo() => _turbo = true;
    private void TerminandoTurbo() => _turbo = false;
}

