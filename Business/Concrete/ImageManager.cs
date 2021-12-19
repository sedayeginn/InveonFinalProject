using Business.Abstract;
using CloudinaryDotNet.Actions;
using Core.Utilities.Cloudinaryy;
using Core.Utilities.FileManager;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{

    public class ImageManager : IImageService
    {
        IImagePathDal _imageDal;
        IProductDal _productDal;

        public ImageManager(IImagePathDal imageDal, IProductDal productDal)
        {
            _imageDal = imageDal;
            _productDal = productDal;
        }

        public IResult Upload(ImagePath image)
        {

            DateTime now = DateTime.Now;
            image.DateOfCreation = now;
            _imageDal.Add(image);
            Product product = _productDal.Get(i => i.Id == image.ProductId);
            product.ImageUrl = image.ImageUrl;
            _productDal.Update(product);
            return new SuccessResult("Resim Ekleme İşlemi Başarılı");
        }

        public IDataResult<List<ImagePath>> GetByProductId(int productId)
        {
            return new SuccessDataResult<List<ImagePath>>(_imageDal.GetAll(i => i.ProductId == productId));
        }

       
    }
}
