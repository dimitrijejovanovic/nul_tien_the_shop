﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace TheShop.Models.Entities
{
    public abstract class Supplier : Entity
    {
        public string Name { get; private set; }
        public SupplierOrganisation Organisation { get; private set; }
        public List<Article> Articles { get; private set; }

        public Supplier()
        {
            Articles = new List<Article>();
        }

        public Supplier(string name) : this()
        {
            Name = name;
        }

        public bool ArticleInInventory(int id)
        {
            return Articles.Any(a => a.ID == id && !a.IsSold);
        }

        public Article GetArticle(int id)
        {
            return Articles.Find(a => a.ID == id);
        }

        public void AddArticle(Article article)
        {
            if (article == null)
            {
                throw new Exception("Can't add empty article");
            }

            Articles.Add(article);
            article.SetSuplier(this);
        }

        public void SetOrganisation(SupplierOrganisation organisation)
        {
            Organisation = organisation ?? throw new Exception("No organisation provided to supplier");

            if (!organisation.Suppliers.Any(a => a == this))
                organisation.AddSupplier(this);
        }

        public bool HasViableleArticle(int articleId, int maxArticlePrice)
        {
            return ArticleInInventory(articleId)
                    && GetArticle(articleId).IsOrderable(maxArticlePrice);
        }

    }
}
