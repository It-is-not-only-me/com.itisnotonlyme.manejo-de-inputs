using System;
using UnityEngine;

namespace ItIsNotOnlyMe.ManejoDeInputs
{
    [CreateAssetMenu(fileName = "Evento generico", menuName = "Manejo de inputs/Eventos/Evento generico")]
    public class EventoGenerico<TTipo> : ScriptableObject
    {
        public event Action<TTipo> EventoActual;

        public void Invoke(TTipo tipo) => EventoActual.Invoke(tipo);
    }
}

