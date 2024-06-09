using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TP_ClubDeportivo
{
    public class ClubDeportivo
    {
        public List<Suplemento> suplementos = new List<Suplemento>();
        public List<ServicioDeportivo> servicios = new List<ServicioDeportivo>();

        public int CantServiciosSimples()
        {
            int count = 0;
            foreach (var servicio in servicios)
            {
                if (servicio is ClasesGrupales clasesGrupales && clasesGrupales.NumeroParticipantes < 10)
                {
                    count++;
                }
            }
            return count;
        }

        public decimal CalcularMontoTotalFacturado()
        {
            decimal total = 0;
            foreach (var servicio in servicios)
            {
                total += servicio.CalcularPrecio();
            }
            foreach (var suplemento in suplementos)
            {
                total += suplemento.Precio;
            }
            return total;
        }
    }
}
