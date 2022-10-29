using System;
using UnityEngine;

namespace ItIsNotOnlyMe.ManejoDeInputs
{
    [CreateAssetMenu(fileName = "Evento void", menuName = "Manejo de inputs/Eventos/Evento void")]
    public class Evento : ScriptableObject
    {
        public event Action EventoActual;

        public void Invoke() => EventoActual?.Invoke();
    }
}

