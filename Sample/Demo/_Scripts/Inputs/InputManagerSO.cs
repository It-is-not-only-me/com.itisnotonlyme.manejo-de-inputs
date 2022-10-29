using UnityEngine;

[CreateAssetMenu(fileName = "Input manager", menuName = "Inputs/Input manager")]
public class InputManagerSO : ScriptableObject
{
    private Inputs _inputs = null;

    public Inputs Inputs
    {
        get
        {
            if (_inputs == null)
                _inputs = new Inputs();
            return _inputs;
        }
    }
}
