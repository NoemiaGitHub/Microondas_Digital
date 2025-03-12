using System;
using System.Collections.Generic;

namespace MicroondasDigital
{
    public class CadastrarProgramaAquecimento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Alimento { get; set; }
        public int CadPotencia { get; set; }
        public string Caractere { get; set; }
        public int CadTempo { get; set; }
        public string InstrucoesII { get; set; }
        public string StringAquecimento { get; set; }

        // Construtor sem parâmetros M
        public CadastrarProgramaAquecimento() { }

        // Construtor com 7 parâmetros I
        public CadastrarProgramaAquecimento(string nome, string alimento, int cadPotencia, string caractere, int cadTempo, string instrucoesII, string stringAquecimento)
        {
            Nome = nome;
            Alimento = alimento;
            CadPotencia = cadPotencia;
            Caractere = caractere;
            CadTempo = cadTempo;
            InstrucoesII = instrucoesII;
            StringAquecimento = stringAquecimento;
        }

        // Construtor com 6 parâmetros A
        public CadastrarProgramaAquecimento(string nome, string alimento, int cadPotencia, string caractere, int cadTempo, string instrucoesII)
        {
            Nome = nome;
            Alimento = alimento;
            CadPotencia = cadPotencia;
            Caractere = caractere;
            CadTempo = cadTempo;
            InstrucoesII = instrucoesII;
        }

        public void Validar(List<CadastrarProgramaAquecimento> programasExistentes)
        {
            if (string.IsNullOrWhiteSpace(Nome) || string.IsNullOrWhiteSpace(Alimento) ||
                CadPotencia <= 0 || string.IsNullOrWhiteSpace(Caractere) || CadTempo <= 0)
            {
                throw new ArgumentException("Todos os campos obrigatórios devem ser preenchidos.");
            }

            if (Caractere == ".")
            {
                throw new ArgumentException("O caractere de aquecimento não pode ser '.'.");
            }

            // Verifica se o caractere já está em uso
            foreach (var programa in programasExistentes)
            {
                if (programa.Caractere == Caractere)
                {
                    throw new ArgumentException($"O caractere '{Caractere}' já está em uso por outro programa.");
                }
            }
        }
    }
}
