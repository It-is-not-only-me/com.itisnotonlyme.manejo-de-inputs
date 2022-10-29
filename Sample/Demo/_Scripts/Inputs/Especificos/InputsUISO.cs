using UnityEngine;
using UnityEngine.InputSystem;
using ItIsNotOnlyMe.ManejoDeInputs;

[CreateAssetMenu(fileName = "Input UI", menuName = "Inputs/Input UI")]
public class InputsUISO : InputSO, Inputs.IUIActions
{
    [SerializeField] private InputManagerSO _manejoDeInputs;

    [SerializeField] private Evento EventoInventario;

    [SerializeField] private Evento EventoMenu;

    private Inputs.UIActions _accionesDeUI => _manejoDeInputs.Inputs.UI;

    public override void Activar() => _accionesDeUI.Enable();
    public override void Desactivar() => _accionesDeUI.Disable();

    public void OnInventario(InputAction.CallbackContext context)
    {
        EventoInventario?.Invoke();
    }

    public void OnMenu(InputAction.CallbackContext context)
    {
        EventoMenu?.Invoke();
    }
}


