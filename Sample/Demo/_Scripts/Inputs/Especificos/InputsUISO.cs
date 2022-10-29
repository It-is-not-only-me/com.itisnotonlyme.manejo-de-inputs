using UnityEngine;
using UnityEngine.InputSystem;
using ItIsNotOnlyMe.ManejoDeInputs;

[CreateAssetMenu(fileName = "Input UI", menuName = "Inputs/Input UI")]
public class InputsUISO : InputSO, Inputs.IUIActions
{
    [SerializeField] private InputManagerSO _manejoDeInputs;

    [Space]

    [SerializeField] private Evento EventoInventario;
    [SerializeField] private Evento EventoMenu;

    private Inputs.UIActions _accionesDeUI => _manejoDeInputs.Inputs.UI;

    private void OnEnable() => _accionesDeUI.SetCallbacks(this);

    public override void Activar() => _accionesDeUI.Enable();
    public override void Desactivar() => _accionesDeUI.Disable();

    public void OnInventario(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
            EventoInventario?.Invoke();
    }

    public void OnMenu(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
            EventoMenu?.Invoke();
    }
}


