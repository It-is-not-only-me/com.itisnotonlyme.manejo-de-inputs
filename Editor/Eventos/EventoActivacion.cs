using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe.ManejoDeInputs
{
    [CreateAssetMenu(fileName = "Evento activacion", menuName = "Manejo de inputs/Eventos/Evento activacion")]
    public class EventoActivacion : ScriptableObject
    {
        public event Action<int, bool> EventoActual;

        public int Id() => GetInstanceID();

        public void SetearActivacion(bool activar) => EventoActual?.Invoke(Id(), activar);
    }
}