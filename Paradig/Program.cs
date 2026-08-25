namespace Paradig;

class Program
{
    static void Main(string[] args)
    {
        var obj = new Corretor();

        string[] nomes = obj.Nomes;
        string[] estados = obj.Estados;
        string[] CPFs = obj.CPFs;
        for (int i = 0; i < obj.Nomes.Length; i++)
        {
            if (i != 0)
            {
                Console.WriteLine(nomes[i] + " | " + CPFs[i] + " | " + estados[i]);
            }
            else
            {
                Console.WriteLine("Nome" + " | " + "CPF" + " | " + "Estado");
            }
        }
    }
}