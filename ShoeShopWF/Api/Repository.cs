using Newtonsoft.Json;
using ShoeShopWF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShopWF.Api
{
    public class Repository
    {
        readonly CallApi callApi = new CallApi();
        #region Medodos para Consultar Articulos
        public List<ArticleModel> GetArticles()
        {
            List<ArticleModel> listArticle = new List<ArticleModel>();
            string jsonArticles= callApi.Execute("/articles", "GET");
            if (!string.IsNullOrEmpty(jsonArticles) && !jsonArticles.Contains("ERROR-API"))
            {
                var objArticles = JsonConvert.DeserializeObject<ArticleResponseModel>(jsonArticles);
                if (objArticles.success)
                {
                    objArticles.articles.ForEach(a =>
                    {
                        listArticle.Add(new ArticleModel()
                        {
                            Id = a.id,
                            Name = a.name,
                            Description = a.description,
                            Price = a.price,
                            Total_in_shelf = a.total_in_shelf,
                            Total_in_vault = a.total_in_vault,
                            Store = a.store.name
                        });
                    });
                }
            }
            return listArticle;
        }

        public List<ArticleModel> GetArticlesForStore(string idStore)
        {
            List<ArticleModel> listArticle = new List<ArticleModel>();
            string jsonArticles = callApi.Execute($"articles/stores/{idStore}", "GET");
            if (!string.IsNullOrEmpty(jsonArticles) && !jsonArticles.Contains("ERROR-API"))
            {
                var objArticles = JsonConvert.DeserializeObject<ArticleResponseModel>(jsonArticles);
                if (objArticles.success)
                {
                    objArticles.articles.ForEach(a =>
                    {
                        listArticle.Add(new ArticleModel()
                        {
                            Id = a.id,
                            Name = a.name,
                            Description = a.description,
                            Price = a.price,
                            Total_in_shelf = a.total_in_shelf,
                            Total_in_vault = a.total_in_vault,
                            Store = a.store.name
                        });
                    });
                }
            }
            return listArticle;
        }
        #endregion
        #region Devuelve el catalodo de las tiendas
        public List<ItemModel> GetStores()
        {
            List<ItemModel> listItems = new List<ItemModel>();
            listItems.Add(new ItemModel(){ Value="0", Text= "Select..."});
            string jsonStores = callApi.Execute("/stores", "GET");
            if (!string.IsNullOrEmpty(jsonStores) && !jsonStores.Contains("ERROR-API"))
            {
                var objStores = JsonConvert.DeserializeObject<StoreResponseModel>(jsonStores);
                if (objStores.success)
                {
                    objStores.stores.ForEach(s =>
                    {
                        string Id = s.id.ToString();
                        listItems.Add(new ItemModel()
                        {
                            Value = Id,
                            Text = s.name
                        });
                    });
                }
            }
            return listItems;
        }
        #endregion
    }
}
