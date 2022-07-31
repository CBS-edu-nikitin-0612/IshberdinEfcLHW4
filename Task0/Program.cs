using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Task0.Models;

namespace Task0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using ShopDBContext db = new ShopDBContext();
            {
                foreach (Product product in db.Products)
                {
                    Console.WriteLine($"Описание: {product.Description} Цена: {product.UnitPrice} Вес: {product.Weight}");
                }
            }
            Console.ReadLine();
        }
    }
}
