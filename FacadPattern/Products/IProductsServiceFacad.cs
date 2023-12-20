using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommersShop.Persistance;
using ECommersShop.Service.Categories.Commands.AddNewCategory;
using ECommersShop.Service.Categories.Queries.GetRemovedCategoryById;
using ECommersShop.Service.Products.Commands.AddNewProduct;
using ECommersShop.Service.Products.Commands.AddNewProduct.HardRemoveProduct;
using ECommersShop.Service.Products.Commands.RemoveProduct;
using ECommersShop.Service.Products.Commands.ReturnProductRemoved;
using ECommersShop.Service.Products.Commands.UpdateProduct;
using ECommersShop.Service.Products.Queries;
using ECommersShop.Service.Products.Queries.GetAllRemovedProducts;
using ECommersShop.Service.Products.Queries.GetProductById;
using ECommersShop.Service.Products.Queries.GetRemoveProductById;
using Npgsql.Internal;

namespace ECommersShop.FacadPattern.Products
{
    public interface IProductsServiceFacad
    {
        // Queries Services
        IGetAllProductsService GetAllProducts { get; }
        IGetAllRemovedProductsService GetAllRemovedProducts { get; }
        IGetProductByIdService GetProductById { get; }
        IGetRemoveProductByIdService GetRemoveProductById { get; }

        // Commands Services
        IAddNewProductService AddNewProduct { get; }
        IUpdateProductService UpdateProduct { get; }
        IRemoveProductService RemoveProduct { get; }
        IReturnProductRemovedService ReturnProductRemoved { get; }
        IHardRemoveProductService HardRemoveProduct { get; }
    }
    public class ProductsServiceFacad : IProductsServiceFacad
    {
        private readonly DataBaseContext _context;
        public ProductsServiceFacad(DataBaseContext context) => _context = context;

        // Queries Services
        private IGetAllProductsService _getAllProducts;
        public IGetAllProductsService GetAllProducts
        {
            get
            {
                return _getAllProducts = _getAllProducts ??
                    new GetAllProductsService(_context);
            }
        }

        private IGetProductByIdService _getProductById;
        public IGetProductByIdService GetProductById
        {
            get
            {
                return _getProductById = _getProductById ??
                    new GetProductByIdService(_context);
            }
        }

        private IGetRemoveProductByIdService _getRemoveProductById;
        public IGetRemoveProductByIdService GetRemoveProductById
        {
            get
            {
                return _getRemoveProductById = _getRemoveProductById ??
                    new GetRemoveProductByIdService(_context);
            }
        }

        private IGetAllRemovedProductsService _getAllRemovedProducts;
        public IGetAllRemovedProductsService GetAllRemovedProducts
        {
            get
            {
                return _getAllRemovedProducts = _getAllRemovedProducts ??
                    new GetAllRemovedProductsService(_context);
            }
        }
        // Commands Services
        private IAddNewProductService _addNewProduct;
        public IAddNewProductService AddNewProduct
        {
            get
            {
                return _addNewProduct = _addNewProduct ??
                    new AddNewProductService(_context);
            }
        }

        private IUpdateProductService _updateProduct;
        public IUpdateProductService UpdateProduct
        {
            get
            {
                return _updateProduct = _updateProduct ??
                    new UpdateProductService(_context);
            }
        }

        private IRemoveProductService _removeProduct;
        public IRemoveProductService RemoveProduct
        {
            get
            {
                return _removeProduct = _removeProduct ??
                    new RemoveProductService(_context);
            }
        }

        private IReturnProductRemovedService _returnProductRemoved;
        public IReturnProductRemovedService ReturnProductRemoved
        {
            get
            {
                return _returnProductRemoved = _returnProductRemoved ??
                    new ReturnProductRemovedService(_context);
            }
        }

        private IHardRemoveProductService _hardRemoveProduct;
        public IHardRemoveProductService HardRemoveProduct
        {
            get
            {
                return _hardRemoveProduct = _hardRemoveProduct ??
                    new HardRemoveProductService(_context);
            }
        }
    }
}