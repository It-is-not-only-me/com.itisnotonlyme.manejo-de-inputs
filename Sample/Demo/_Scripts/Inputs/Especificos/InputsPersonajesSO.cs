using UnityEngine;
using UnityEngine.InputSystem;
using ItIsNotOnlyMe.ManejoDeInputs;

[CreateAssetMenu(fileName = "Input Personaje", menuName = "Inputs/Input Personaje")]
public class InputsPersonajesSO : InputSO, Inputs.IPersonajeActions
{
    [SerializeField] private InputManagerSO _manejoDeInputs;

    public bool Atacando { get { return _atacando; } }
    [SerializeField] private Evento EventoAtacarEmpezar;
    [SerializeField] private Evento EventoAtacarTerminar;


    public bool Defendiendo { get { return _defendiendo; } }
    [SerializeField] private Evento EventoDefenderEmpezar;
    [SerializeField] private Evento EventoDefenderTerminar;


    public Vector2 Direccion { get { return _direccion; } }
    [SerializeField] private EventoGenerico<Vector2> EventoMover;
    

    private Inputs.PersonajeActions _accionesDelPersonaje => _manejoDeInputs.Inputs.Personaje;
    
    private bool _atacando = false;
    private bool _defendiendo = false;
    private Vector2 _direccion = Vector2.zero;

    public override void Activar() => _accionesDelPersonaje.Enable();
    public override void Desactivar() => _accionesDelPersonaje.Disable();

    public void OnAtacar(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            EventoAtacarEmpezar?.Invoke();
            EmpiezaAAtacar();
        }

        if (context.phase == InputActionPhase.Canceled)
        {
            EventoAtacarTerminar?.Invoke();
            TerminaDeAtacar();
        }
    }

    public void OnDefender(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            EventoDefenderEmpezar?.Invoke();
            EmpiezaADefender();
        }

        if (context.phase == InputActionPhase.Canceled)
        {
            EventoDefenderTerminar?.Invoke();
            TerminaDeDefender();
        }
    }

    public void OnMovimiento(InputAction.CallbackContext context)
    {
        Vector2 direccion = context.ReadValue<Vector2>();
        EventoMover?.Invoke(direccion);
        Moviendose(direccion);
    }

    private void EmpiezaAAtacar() => _atacando = true;
    private void TerminaDeAtacar() => _atacando = false;

    private void EmpiezaADefender() => _defendiendo = true;
    private void TerminaDeDefender() => _defendiendo = false;

    private void Moviendose(Vector2 direccion) => _direccion = direccion;
}


