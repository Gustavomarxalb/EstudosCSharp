using System.IO;
using System;

namespace Paradig;

public class Corretor
{
    public string[] Nomes { get; private set; }
    public string[] CPFs { get; private set; }
    public string[] Estados { get; private set; }
    
    private string[] Conteudo;


    public Corretor()
    {
        LerDados();
        Nomes = ConsertaNomes();
        Estados = SiglaEstado();
        CPFs = ConsertaCpf();
    }
    
    public void LerDados()
    {
        Conteudo = File.ReadAllLines("tema11.txt");
    }

    public string[] ConsertaNomes()
    {
        string[] nomes = new string[Conteudo.Length];

        for (int i = 0; i < Conteudo.Length; i++)
        {
            string coluna = Conteudo[i].Split('|')[0];
            coluna = coluna.TrimEnd();

            while (coluna.Contains("  "))
            {
                coluna = coluna.Replace("  ", " ");
            }

            if (coluna.Contains("nome"))
                coluna = coluna.Remove(coluna.IndexOf("nome"));
            nomes[i] = coluna;
        }

        return nomes;
    }

    public string[] SiglaEstado()
    {
        string[] estados = new string[Conteudo.Length];

        for (int i = 0; i < Conteudo.Length; i++)
        {
            string coluna = Conteudo[i].Split('|')[2].Trim().ToUpper();
            
            if (coluna.Length == 2 && !coluna.Contains(" "))
            {
                estados[i] = coluna;
                continue;
            }
            
            var partes = coluna.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (partes.Length == 1)
            {
                estados[i] = partes[0].Substring(0, 2);
            }
            else
            {
                estados[i] = $"{partes[0][0]}{partes[^1][0]}";
            }
            
        }
        if (estados[0] == "ES")
            estados[0] = estados[0].Remove(estados[0].IndexOf("ES")); 
        return estados;
    }

    public string[] ConsertaCpf()
    {
        string[] cpf = new string[Conteudo.Length];

        for (int i = 0; i < Conteudo.Length; i++)
        {
            string coluna = Conteudo[i].Split('|')[1].Trim();
            
            if (coluna.Contains("cpf"))
            {
                cpf[i] = "";
                continue;
            }
            
            string apenasNumeros = System.Text.RegularExpressions.Regex.Replace(coluna, @"\D", "");
            
            if (apenasNumeros.Length == 11)
            {
                
                string bloco1 = apenasNumeros.Substring(0, 3); 
                string bloco2 = apenasNumeros.Substring(3, 3); 
                string bloco3 = apenasNumeros.Substring(6, 3); 
                string digitos = apenasNumeros.Substring(9, 2); 
                
                cpf[i] = $"{bloco1}.{bloco2}.{bloco3}-{digitos}";
            }
            else
            {
                cpf[i] = apenasNumeros;
            }
        }
        return cpf;
    }
}