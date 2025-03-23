// Tarea semana 14

// Un ejemplo de árboles binarios, con tipos de datos primitivos (enteros, cadenas, etc.)

using System;

// Definición de la clase Nodo que representa cada elemento del árbol binario
class Nodo
{
    public int Dato; // Almacena el valor del nodo
    public Nodo Izquierdo, Derecho; // Referencias a los nodos hijos
    
    public Nodo(int dato)
    {
        Dato = dato;
        Izquierdo = Derecho = null; // Inicializa los hijos como nulos
    }
}

// Clase que define el Árbol Binario de Búsqueda
class ArbolBinario
{
    private Nodo Raiz; // Nodo raíz del árbol
    
    public ArbolBinario()
    {
        Raiz = null; // Inicializa el árbol vacío
    }
    
    // Método para insertar un nuevo valor en el árbol
    public void Insertar(int dato)
    {
        Raiz = InsertarRecursivo(Raiz, dato);
    }
    
    // Método recursivo para insertar un nodo en el árbol
    private Nodo InsertarRecursivo(Nodo raiz, int dato)
    {
        if (raiz == null) // Si el árbol está vacío o se encontró una posición vacía
        {
            raiz = new Nodo(dato); // Se crea un nuevo nodo con el valor
            return raiz;
        }
        if (dato < raiz.Dato) // Si el valor es menor, se inserta en el subárbol izquierdo
            raiz.Izquierdo = InsertarRecursivo(raiz.Izquierdo, dato);
        else if (dato > raiz.Dato) // Si el valor es mayor, se inserta en el subárbol derecho
            raiz.Derecho = InsertarRecursivo(raiz.Derecho, dato);
        return raiz;
    }
    
    // Método para buscar un valor en el árbol
    public bool Buscar(int dato)
    {
        return BuscarRecursivo(Raiz, dato);
    }
    
    // Método recursivo para buscar un nodo en el árbol
    private bool BuscarRecursivo(Nodo raiz, int dato)
    {
        if (raiz == null) return false; // Si el árbol está vacío o se llegó a una hoja
        if (raiz.Dato == dato) return true; // Si el valor es encontrado
        return dato < raiz.Dato ? BuscarRecursivo(raiz.Izquierdo, dato) : BuscarRecursivo(raiz.Derecho, dato); // Búsqueda en los subárboles
    }
    
    // Método para recorrer el árbol en InOrden (Izquierda - Raíz - Derecha)
    public void InOrden() => InOrdenRecursivo(Raiz);
    private void InOrdenRecursivo(Nodo raiz)
    {
        if (raiz != null)
        {
            InOrdenRecursivo(raiz.Izquierdo);
            Console.Write(raiz.Dato + " ");
            InOrdenRecursivo(raiz.Derecho);
        }
    }
    
    // Método para recorrer el árbol en PreOrden (Raíz - Izquierda - Derecha)
    public void PreOrden() => PreOrdenRecursivo(Raiz);
    private void PreOrdenRecursivo(Nodo raiz)
    {
        if (raiz != null)
        {
            Console.Write(raiz.Dato + " ");
            PreOrdenRecursivo(raiz.Izquierdo);
            PreOrdenRecursivo(raiz.Derecho);
        }
    }
    
    // Método para recorrer el árbol en PostOrden (Izquierda - Derecha - Raíz)
    public void PostOrden() => PostOrdenRecursivo(Raiz);
    private void PostOrdenRecursivo(Nodo raiz)
    {
        if (raiz != null)
        {
            PostOrdenRecursivo(raiz.Izquierdo);
            PostOrdenRecursivo(raiz.Derecho);
            Console.Write(raiz.Dato + " ");
        }
    }
}

// Clase principal que maneja el menú interactivo
class Program
{
    static void Main()
    {
        ArbolBinario arbol = new ArbolBinario(); // Creación de un nuevo árbol binario
        int opcion, valor;
        
        do
        {
            // Menú de opciones para el usuario
            Console.WriteLine("\n--- Menu Arbol Binario ---");
            Console.WriteLine("\n1. Insertar nodo");
            Console.WriteLine("2. Buscar nodo");
            Console.WriteLine("3. Recorrido In-Orden");
            Console.WriteLine("4. Recorrido Pre-Orden");
            Console.WriteLine("5. Recorrido Post-Orden");
            Console.WriteLine("6. Salir");
            Console.Write("\nSeleccione una opcion: ");
            opcion = int.Parse(Console.ReadLine());
            
            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese valor a insertar: ");
                    valor = int.Parse(Console.ReadLine());
                    arbol.Insertar(valor); // Inserta el valor en el árbol
                    break;
                case 2:
                    Console.Write("Ingrese valor a buscar: ");
                    valor = int.Parse(Console.ReadLine());
                    Console.WriteLine(arbol.Buscar(valor) ? "Valor encontrado" : "Valor no encontrado"); // Busca un valor en el árbol
                    break;
                case 3:
                    Console.Write("Recorrido InOrden: ");
                    arbol.InOrden(); // Muestra el recorrido InOrden
                    Console.WriteLine();
                    break;
                case 4:
                    Console.Write("Recorrido PreOrden: ");
                    arbol.PreOrden(); // Muestra el recorrido PreOrden
                    Console.WriteLine();
                    break;
                case 5:
                    Console.Write("Recorrido PostOrden: ");
                    arbol.PostOrden(); // Muestra el recorrido PostOrden
                    Console.WriteLine();
                    break;
                case 6:
                    Console.WriteLine("Saliendo..."); // Opción para salir del programa
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo."); // Mensaje de error para opciones no válidas
                    break;
            }
        } while (opcion != 6); // El menú se repite hasta que el usuario elija salir
    }
}

// Fin del programa.

// Universidad Estatal Amazónica.

// Andrés Ponce M.