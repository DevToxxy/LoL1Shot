using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace LoL1Shot.Data_Access_Layer
{
    public class ComboXmlDB //: IComboDB
    {
        //XmlDocument db = new XmlDocument();
        //string xmlDB_path;

        //public ComboXmlDB(IConfiguration _configuration)
        //{
        //    xmlDB_path = _configuration.GetValue<string>("AppSettings:XmlDB_path");

        //    LoadDB();
        //}
        
        //#region Data Base
        //private void LoadDB() => db.Load(xmlDB_path);
        //private void SaveDB() => db.Save(xmlDB_path);
        //#endregion
        
        //#region Data Access
        //public List<Product> List
        //{
        //    get
        //    {
        //        List<Product> productList = new List<Product>();
        //        XmlNodeList productXmlNodeList = db.SelectNodes("/store/product");

        //        foreach (XmlNode productXmlNode in productXmlNodeList)
        //        {
        //            productList.Add(XmlNodeProduct2Product(productXmlNode));
        //        }
        //        return productList;
        //    }
        //}

        //public Product Get(int id) => XmlNodeProduct2Product(XmlNodeProductGet(id));

        //public int GetAvailableId
        //{
        //    get
        //    {
        //        bool exists = false;

        //        for (int i = 0; i < int.MaxValue; i++)
        //        {
        //            foreach (Product item in List)
        //            {
        //                if(item.id == i)
        //                {
        //                    exists = true;
        //                    break;
        //                }
        //            }

        //            if (!exists) return i;
        //        }

        //        throw new Exception("Brak dostępnych Id");
        //    }
        //}
        //#endregion

        //#region Operations
        //public void Update(Product product)
        //{
        //    LoadDB();

        //    XmlNode node = XmlNodeProductGet(product.id);
        //    node["name"].InnerText = product.name;
        //    node["price"].InnerText = product.price.ToString();

        //    SaveDB();
        //}
        
        //public void Delete(int id)
        //{
        //    LoadDB();
        //    XmlNodeList list = db.SelectNodes($"/store/product[@id={id}]");
        //    list[0].ParentNode.RemoveChild(list[0]);
        //    SaveDB();
        //}
        
        //public void Add(Product product)
        //{
        //    LoadDB();

        //    product.id = GetAvailableId;

        //    XmlNode store = db.DocumentElement;
        //    XmlElement xmlProduct = db.CreateElement("product");

        //    XmlAttribute nameAttribute = db.CreateAttribute("id");
        //    nameAttribute.Value = product.id.ToString();
        //    xmlProduct.Attributes.Append(nameAttribute);
        //    //ALBO SZYBCIEJ:  xmlProduct.SetAttribute("id", product.id.ToString());

        //    XmlElement nameElement = db.CreateElement("name");
        //    nameElement.InnerText = product.name;
        //    xmlProduct.AppendChild(nameElement);

        //    XmlElement priceElement = db.CreateElement("price");
        //    priceElement.InnerText = product.price.ToString();
        //    xmlProduct.AppendChild(priceElement);

        //    store.AppendChild(xmlProduct);

        //    SaveDB();
        //}
        //#endregion

        //#region XML Translation
        //private XmlNode XmlNodeProductGet(int id)
        //{
        //    XmlNodeList list = db.SelectNodes($"/store/product[@id={id}]");
        //    return list[0];
        //}

        //private Product XmlNodeProduct2Product(XmlNode node)
        //{
        //    return new Product()
        //    {
        //        id = int.Parse(node.Attributes["id"].Value),
        //        name = node["name"].InnerText,
        //        price = decimal.Parse(node["price"].InnerText)
        //    };
        //}
        //#endregion
    }
}
