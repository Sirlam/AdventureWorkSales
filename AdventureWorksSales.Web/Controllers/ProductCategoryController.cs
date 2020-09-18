using AdventureWorksSales.Core.DAC;
using AdventureWorksSales.Core.Entities;
using AdventureWorksSales.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdventureWorksSales.Web.Controllers
{
    public class ProductCategoryController : Controller
    {
        ProductCategoryDAC _productCategoryDAC;

        public ProductCategoryController()
        {
            _productCategoryDAC = new ProductCategoryDAC();
        }

        // GET: ProductCategory
        public ActionResult Index()
        {
            var model = new List<ProductCategoryModel>();

            var items = _productCategoryDAC.SelectProductCategories();

            foreach (var i in items)
            {
                ProductCategoryModel product = new ProductCategoryModel();

                product.ProductCategoryID = i.ProductCategoryID;
                product.Name = i.Name;
                product.rowguid = i.rowguid;
                product.ModifiedDate = i.ModifiedDate;

                model.Add(product);
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new ProductCategoryModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(ProductCategoryModel model)
        {
            if (ModelState.IsValid)
            {
                PRODUCTCATEGORY category = new PRODUCTCATEGORY 
                { 
                    Name = model.Name,
                    rowguid = Guid.NewGuid(),
                    ModifiedDate = DateTime.Now,
                };


                _productCategoryDAC.InsertProductCategory(category);
                ViewBag.Message = "Category created successfully";
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _productCategoryDAC.SelectCategoryById(id);
            var model = new ProductCategoryModel();

            model.ProductCategoryID = data.ProductCategoryID;
            model.rowguid = data.rowguid;
            model.Name = data.Name;
            model.ModifiedDate = data.ModifiedDate;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ProductCategoryModel model)
        {
            if (ModelState.IsValid)
            {
                PRODUCTCATEGORY category = _productCategoryDAC.SelectCategoryById(model.ProductCategoryID);

                category.Name = model.Name;
                category.ModifiedDate = DateTime.Now;
                _productCategoryDAC.UpdateProductCategory(category);
                ViewBag.Message = "Category updated successfully";
            }
            return View(model);
        }
    }
}