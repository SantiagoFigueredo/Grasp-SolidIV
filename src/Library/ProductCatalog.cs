using System.Collections.Generic;
using System.Linq;
using Full_GRASP_And_SOLID;

public class ProductCatalog : ICatalog<Product>
{
    private List<Product> products = new List<Product>();

    public void AddItem(Product product)
    {
        products.Add(product);
    }

    public Product GetItem(string description)
    {
        return products.FirstOrDefault(p => p.Description == description);
    }
}
