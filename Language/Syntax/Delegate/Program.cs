using System;

namespace Delegate
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductFactory productFactory = new ProductFactory();
            WrapFactory wrapFactory = new WrapFactory();

            Func<Product> func1 = new Func<Product>(productFactory.MakePizza);
            Func<Product> func2 = new Func<Product>(productFactory.MakeToyCar);

            Logger logger = new Logger();
            Action<Product> log = new Action<Product>(logger.Log);

            Box box1 = wrapFactory.WrapProduct(func1, log);
            Box box2 = wrapFactory.WrapProduct(func2, log);

            Console.WriteLine(box1.Product.Name);
            Console.WriteLine(box2.Product.Name);


        }
    }

    class Logger
    {
        public void Log(Product product)
        {
            Console.WriteLine("Product '{0}' created at {1}. Price is {2}", product.Name, DateTime.UtcNow, product.Price);
        }
    }

    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    class Box
    {
        public Product Product { get; set; }
    }

    class WrapFactory
    {
        public Box WrapProduct(Func<Product> getProduct, Action<Product> logCallback)
        {
            Box box = new Box();
            Product product = getProduct.Invoke();   //代码重用, 模板方法
            if (product.Price >=50)
            {
                logCallback(product);  // 如果价格大于50， 调用记录方法
            }
            box.Product = product;
            return box;
        }
    }

    class ProductFactory
    {
        public Product MakePizza()
        {
            Product product = new Product();
            product.Name = "Pizza";
            product.Price = 12; 
            return product; 
        }

        public Product MakeToyCar()
        {
            Product product = new Product();
            product.Name = "Toy Car";
            product.Price = 100;
            return product; 
        }
    }
}
