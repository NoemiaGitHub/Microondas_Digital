using System;
using System.Collections.Generic;

namespace MicroondasDigital
{
    public class Microondas
    {
        public string Aquecer(int tempo, int potencia)
        {
            if (tempo < 1 || tempo > 120)
            {
                return "Por favor, informe um tempo válido (1s - 2min).";
            }

            if (potencia < 1 || potencia > 10)
            {
                return "Por favor, informe uma potência válida (1 - 10).";
            }

            if (tempo > 60 && tempo < 100)
            {
                int minutos = tempo / 60;
                int segundos = tempo % 60;
                return $"Aquecimento iniciado: {minutos}:{segundos:D2} min com potência {potencia}.";
            }

            return $"Aquecimento iniciado: {tempo} segundos com potência {potencia}.";
        }
    }
}