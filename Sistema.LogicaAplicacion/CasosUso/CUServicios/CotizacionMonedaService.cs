using Sistema.LogicaAplicacion.ICasosUso.IServicios;
using Sistema.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Sistema.LogicaAplicacion.CasosUso.CUServicios
{
    public class CotizacionMonedaService : ICotizacionMonedaService
    {
        private readonly HttpClient _http;

        public CotizacionMonedaService(HttpClient http)
        {
            _http = http;
        }

        public async Task<decimal> GetRateToUYUAsync(Moneda desde)
        {
            if (desde == Moneda.UYU)
                return 1m;

            var response = await _http.GetFromJsonAsync<ExchangeRateResponse>(
                $"https://open.er-api.com/v6/latest/{desde}"
            );

            if (response == null ||
                response.Rates == null ||
                !response.Rates.ContainsKey("UYU"))
            {
                throw new Exception(
                    $"No se pudo obtener cotización desde {desde} a UYU"
                );
            }

            return response.Rates["UYU"];
        }

        // DTO interno SOLO para esta API
        private class ExchangeRateResponse
        {
            public Dictionary<string, decimal> Rates { get; set; } = new();
        }
    }
}
