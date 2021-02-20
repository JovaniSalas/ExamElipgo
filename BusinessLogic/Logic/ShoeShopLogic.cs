using BusinessEntities;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ShoeShopLogic
    {
        readonly Validations valitation = new Validations();
        public ShoeShopLogic()
        {
        }

        #region Obtiene todos los articulos
        public AnswerModel GetArticles()
        {
            AnswerModel anware = new AnswerModel();
            anware.articles = ConsultArticles();
            anware.success = true;
            return anware;
        }
        #endregion

        #region Metodo para obtener las tiendas
        public AnswerModel GetStores()
        {
            AnswerModel anware = new AnswerModel();
            anware.stores = ConsultStores();
            anware.success = true;
            return anware;
        }
        #endregion

        #region Metodo para obtener los articulos de acuerdo a la tienda
        public AnswerModel GetArticlesByStores(string store_id)
        {
            AnswerModel anware = new AnswerModel();
            if (valitation.isNumeric(store_id))
            {
                anware.articles = ConsultArticlesByStores(int.Parse(store_id));
            }
            else
            {
                anware.error_msg = "Bad Request";
                anware.error_code = 400;
                anware.success = false;
            }
            return anware;
        }
        #endregion

        #region Metodos privacos para Consulta de Articulos
        private List<Article> ConsultArticles()
        {
            List<Article> listArticles = new List<Article>();
            using (var context = new ShoeShopDbContext())
            {
                var allArticles = (from a in context.Articles
                                   join s in context.Stores on a.store.id equals s.id
                                   select new
                                   {
                                       articles = a,
                                       store = s
                                   }).ToList();
                allArticles.ForEach(ra =>
                {
                    var article = new Article();
                    article = ra.articles;
                    article.store = ra.store;
                    listArticles.Add(article);
                });
            }
            return listArticles;
        }
        private List<Article> ConsultArticlesByStores(int store_id)
        {
            List<Article> listArticles = new List<Article>();
            using (var context = new ShoeShopDbContext())
            {
                var allArticles = (from a in context.Articles
                                   join s in context.Stores on a.store.id equals s.id
                                   where s.id == store_id
                                   select new
                                   {
                                       articles = a,
                                       store = s
                                   }).ToList();
                allArticles.ForEach(ra =>
                {
                    var article = new Article();
                    article = ra.articles;
                    article.store = ra.store;
                    listArticles.Add(article);
                });
            }
            return listArticles;
        }
        #endregion

        #region Metodos privados para Consulta de Tiendas
        private List<Store> ConsultStores()
        {
            List<Store> listStore = new List<Store>();
            using (var context = new ShoeShopDbContext())
            {
                listStore = context.Stores.ToList();
            }
            return listStore;
        }
        #endregion

    }
}

