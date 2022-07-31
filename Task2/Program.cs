using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Task0.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (new ProductHelper()).Print(2);
        }
    }
    public class ProductHelper
    {
        public void Print(int NumProduct)
        {

            int count = 0;
            var task = GetProductAsync(2);
            while (!task.IsCompleted)
            {
                if (count < 3)
                {
                    Console.Write('.');
                    count++;
                }
                else
                {
                    count = 0;
                    Console.SetCursorPosition(0, 0);
                    Console.Write("   ");
                    Console.SetCursorPosition(0, 0);
                }
                Thread.Sleep(500);
            }
            var product = task.Result;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Описание: {product.Description} Цена: {product.UnitPrice} Вес: {product.Weight}");
            Console.ReadLine();

        }
        async Task<Product> GetProductAsync(int NumProduct)
        {
            Task<Product> product;
            using ShopDBContext db = new ShopDBContext();
            {
                product = Task.FromResult(db.Products.FromSqlRaw("EXECUTE dbo.GetInfoProduct {0}", NumProduct).ToList().FirstOrDefault());
                await Task.Delay(15000);
            }
            return await product;
        }

    }
}
