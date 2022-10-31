using UnityEngine;
using UnityEngine.InputSystem;
using ItIsNotOnlyMe.ManejoDeInputs;

[CreateAssetMenu(fileName = "Input Personaje", menuName = "Inputs/Input Personaje")]
public class InputsPersonajesSO : InputSO, Inputs.IPersonajeActions
{
    [SerializeField] private InputManagerSO _manejoDeInputs;

    public bool Atacando { get { return _atacando; } }
    [SerializeField] private Evento _eventoAtacarEmpezar;
    [SerializeField] private Evento _eventoAtacarTerminar;


    public bool Defendiendo { get { return _defendiendo; } }
    [SerializeField] private Evento _eventoDefenderEmpezar;
    [SerializeField] private Evento _eventoDefenderTerminar;


    public Vector2 Direccion { get { return _direccion; } }
    [SerializeField] private EventoVector2 _eventoMover;

    [SerializeField] private Evento _eventoInteractuar;
    

    private Inputs.PersonajeActions _accionesDelPersonaje => _manejoDeInputs.Inputs.Personaje;
    
    private bool _atacando = false;
    private bool _defendiendo = false;
    private Vector2 _direccion = Vector2.zero;

    private void OnEnable() => _accionesDelPersonaje.SetCallbacks(this);

    public override void Activar() => _accionesDelPersonaje.Enable();
    public override void Desactivar() => _accionesDelPersonaje.Disable();

    public void OnAtacar(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            _eventoAtacarEmpezar?.Invoke();
            EmpiezaAAtacar();
        }

        if (context.phase == InputActionPhase.Canceled)
        {
            _eventoAtacarTerminar?.Invoke();
            TerminaDeAtacar();
        }
    }

    public void OnDefender(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            _eventoDefenderEmpezar?.Invoke();
            EmpiezaADefender();
        }

        if (context.phase == InputActionPhase.Canceled)
        {
            _eventoDefenderTerminar?.Invoke();
            TerminaDeDefender();
        }
    }

    public void OnMovimiento(InputAction.CallbackContext context)
    {
        Vector2 direccion = context.ReadValue<Vector2>();
        _eventoMover?.Invoke(direccion);
        Moviendose(direccion);
    }

    public void OnInteractuar(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
            _eventoInteractuar?.Invoke();
    }

    private void EmpiezaAAtacar() => _atacando = true;
    private void TerminaDeAtacar() => _atacando = false;

    private void EmpiezaADefender() => _defendiendo = true;
    private void TerminaDeDefender() => _defendiendo = false;

    private void Moviendose(Vector2 direccion) => _direccion = direccion;
}


