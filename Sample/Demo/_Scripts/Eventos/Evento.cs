using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Evento void", menuName = "Eventos/Evento void")]
public class Evento : ScriptableObject
{
    public event Action EventoActual;

    public void Invoke() => EventoActual?.Invoke();
}

