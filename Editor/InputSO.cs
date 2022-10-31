using System.Collections;
using UnityEngine;

namespace ItIsNotOnlyMe.ManejoDeInputs
{
    public abstract class InputSO : ScriptableObject, ICambio
    {
        public abstract void Activar();
        public abstract void Desactivar();
    }
}
