using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItIsNotOnlyMe.ManejoDeInputs;

public class ZonaInteraccion : MonoBehaviour
{
    [SerializeField] private Evento _entraEnZona;
    [SerializeField] private Evento _saleDeZona;

    private void OnTriggerEnter(Collider other) => _entraEnZona?.Invoke();
    private void OnTriggerExit(Collider other) => _saleDeZona?.Invoke();
}
