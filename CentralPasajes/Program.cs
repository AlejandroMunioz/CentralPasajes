// See https://aka.ms/new-console-template for more information
using Crypto;
Console.WriteLine("introduzca el texto");
string entrada = Console.ReadLine();
var alg1 = new Algoritmo1();


Func<int, int> FuncDencrypt = x => x - 1;
Func<int, int> FuncEncrypt = x => x + 1;
var alg2 = new Algoritmo2(FuncEncrypt, FuncDencrypt);
var alg3 = new Algoritmo3();

Encriptador enc = new Encriptador(alg1, alg2, alg3);
var result = enc.Encrypt(entrada);

Console.WriteLine($"El texto cifrado es: {result}");

Console.WriteLine($"El texto descriptado es: {enc.Decrypt(result)}");
