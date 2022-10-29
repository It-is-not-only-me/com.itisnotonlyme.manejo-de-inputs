using UnityEngine;

[CreateAssetMenu(fileName = "Manejo de Inputs", menuName = "Inputs/ManejoDeInputs")]
public class ManejoDeInputsSO : ScriptableObject
{
    private Inputs _manejoDeInputs = null;

    public Inputs Inputs
    {
        get
        {
            if (_manejoDeInputs == null)
                _manejoDeInputs = new Inputs();
            return _manejoDeInputs;
        }
    }
}
