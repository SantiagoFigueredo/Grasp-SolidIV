using System;
using System.Collections.Generic;
using System.Linq;

namespace Full_GRASP_And_SOLID
{
    public class Program
    {
        private static ICatalog<Product> productCatalog = new ProductCatalog();
        private static ICatalog<Equipment> equipmentCatalog = new EquipmentCatalog();

        public static void Main(string[] args)
        {
            PopulateCatalogs();

            Recipe recipe = new Recipe();
            recipe.FinalProduct = productCatalog.GetItem("Café con leche");
            recipe.AddStep(new Step(productCatalog.GetItem("Café"), 100, equipmentCatalog.GetItem("Cafetera"), 120));
            recipe.AddStep(new Step(productCatalog.GetItem("Leche"), 200, equipmentCatalog.GetItem("Hervidor"), 60));

            IPrinter printer;
            printer = new ConsolePrinter();
            printer.PrintRecipe(recipe);
            printer = new FilePrinter();
            printer.PrintRecipe(recipe);
        }

        private static void PopulateCatalogs()
        {
            productCatalog.AddItem(new Product("Café", 100));
            productCatalog.AddItem(new Product("Leche", 200));
            productCatalog.AddItem(new Product("Café con leche", 300));

            equipmentCatalog.AddItem(new Equipment("Cafetera", 1000));
            equipmentCatalog.AddItem(new Equipment("Hervidor", 2000));
        }
    }
}

/* 
Se agregó una nueva interfaz llamada ICatalog<T> que define los métodos AddItem y GetItem.

Se implementó la clase ProductCatalog que ahora utiliza la interfaz ICatalog<Product>. La clase ProductCatalog tiene una lista de productos y 
proporciona la funcionalidad para agregar productos y buscar productos por descripción.

Se implementó la clase EquipmentCatalog que también utiliza la interfaz ICatalog<Equipment>. La clase EquipmentCatalog tiene una lista de 
equipos y proporciona la funcionalidad para agregar equipos y buscar equipos por descripción.

En la clase Program, se modificó la declaración de las variables productCatalog y equipmentCatalog para que ahora sean ICatalog<Product> 
y ICatalog<Equipment>.

Se actualizó el método PopulateCatalogs en la clase Program para utilizar los métodos AddItem de los catálogos en lugar de acceder directamente 
a las listas internas.

Con estos cambios, se ha aplicado el patrón Creator en los catálogos de productos y equipos, esto permite que podamos utilizar los catálogos a
través de la interfaz genérica sin depender directamente de las implementaciones concretas.
*/

