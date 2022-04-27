bool salir = false;
while (!salir)
{
    try
    {
        Console.WriteLine("1. Ejercicio 1");
        Console.WriteLine("2. Opción 2");
        Console.WriteLine("3. Salir");
        Console.WriteLine("Elige una de las opciones");
        int opcion = Convert.ToInt32(Console.ReadLine());

        switch (opcion)
        {
            case 1:
                Console.WriteLine("Has elegido Ejercicio 1");
                Ejercio1();
                break;

            case 2:
                Console.WriteLine("Has elegido Ejercicio 2");
                break;

            case 3:
                Console.WriteLine("Has elegido salir de la aplicación");
                salir = true;
                break;
            default:
                Console.WriteLine("Elige una opcion entre 1 y 3");
                break;
        }
    }
    catch (FormatException e)
    {
        Console.WriteLine(e.Message);
    }
}
Console.ReadLine();

/// <summary>
/// Funcion que servira obtener cuantas contraseñas validas hay
/// en caso de ejercicio1.
/// 
/// </summary>
static void Ejercio1(){
    int counter = 0;

    // Siempre que lea un linea, este for each se ejecutara.
    foreach (string line in File.ReadLines(@"../../../input.txt"))
    {
        //Incializo una lista que seran los numeros.
        List<int> numeros = new List<int>();

        //Divido la linea en 3, dado que se que solamente hay 3 items necesarios.
        string[] division = line.Split(' ');

        //Los items necesarios los he dividido en cantidadLetras, letraConCaracter, contraseña
        string cantidadLetras = division[0];
        string letraConCaracter = division[1];
        string contraseña = division[2];

        //Dado que la variable letraConCaracter viene con un char no necesario lo borrare.
        char[] charABorrar = { ':' };
        string letra = letraConCaracter.TrimEnd(charABorrar);

        //Separo los numeros del - con el que vienen.
        string[] cantidadLetrasSeparadas = cantidadLetras.Split('-');

        //Recorro cantidadLetrasSeparadas y añado en numeros el valor.
        foreach (var numero in cantidadLetrasSeparadas)
        {
            numeros.Add(int.Parse(numero));
        }

        //Inicializo una variable que sera para comprobar que la cantidad de letras son las necesarias para que la contraseña sea valida.
        int validarCantidadCaracteres = 0;
        
        //separo en chars la variable contraseña
        char[] cantidadCaracteres = contraseña.ToCharArray();

        //Recorro cantidadCaracteres comprobar las letras necesarias.
        foreach (char caracter in cantidadCaracteres)
        {
            //en caso de que el char coincida con la letra necesaria sumo validarCantidadCaracteres
            if (caracter == Convert.ToChar(letra))
                validarCantidadCaracteres++;
        }

        //En el siguiente caso, counter sumara y se comprobara que la contraseña es valida.
        if (numeros[0] <= validarCantidadCaracteres && numeros[1] >= validarCantidadCaracteres)
            counter++;
    }
    Console.WriteLine("Hay un total de " + counter + " contraseñas validas.");
}