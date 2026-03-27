int numero1 = 0;
int numero2 = 0;
int operacao = 0;
int resultado = 0;

Console.WriteLine("Bem vinda a calculadora em C#!");

Console.Write("Digite o primeiro número que quer calcular: ");
numero1 = int.Parse(Console.ReadLine());
Console.Write("Digite o segundo número que quer calcular: ");
numero2 = int.Parse(Console.ReadLine());

Console.WriteLine("Selecione a operação desejada: ");
Console.Write("1- Somar\n2- Subtrair\n3- Multiplicar\n4- Dividir\n0- Sair\nSua escolha: ");
operacao = int.Parse(Console.ReadLine());

switch (operacao) 
{

    case 1:
        resultado = numero1 + numero2;
        Console.WriteLine("Resultado: " + resultado);
    break;
    
    case 2:
        resultado = numero1 - numero2;
        Console.WriteLine("Resultado: " + resultado);
    break;

    case 3:
        resultado = numero1 * numero2;
        Console.WriteLine("Resultado: " + resultado);
    break;

    case 4:
        if(numero1 == 0 || numero2 == 0)
        {
            Console.WriteLine("Não é possível dividir por 0!");
            return;
        }
        resultado = numero1 / numero2;
        Console.WriteLine("Resultado: " + resultado);
    break;

    case 0:
    return;

    default:
        Console.WriteLine("Opção inválida");
    break;
}