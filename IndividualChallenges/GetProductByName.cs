public void GetProductByName(string productName)
{
    // SQL injection vulnerability
    string query = $"SELECT * FROM Products WHERE Name = '{productName}'";
    using (var context = new YourDbContext())
    {
        var products = context.Database.SqlQuery<Product>(query).ToList();
        foreach (var product in products)
        {
            Console.WriteLine($"Product: {product.Name}");
        }
    }
}

// solve the above vulnerability

public void GetProductByName(string productName)
{
    using (var context = new YourDbContext())
    {
        var products = context.Products.Where(p => p.Name == productName).ToList();
        foreach (var product in products)
        {
            Console.WriteLine($"Product: {product.Name}");
        }
    }
}