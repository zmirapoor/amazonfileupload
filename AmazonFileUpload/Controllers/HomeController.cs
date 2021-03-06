﻿using System.Web.Mvc;
using AmazonFileUpload.ViewModels;
using FileStorageUtils;

namespace AmazonFileUpload.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var fileStorageProvider = new AmazonS3FileStorageProvider();

            var fileUploadViewModel = new FileUploadViewModel(fileStorageProvider.PublicKey,
                                                              fileStorageProvider.PrivateKey,
                                                              fileStorageProvider.BucketName,
                                                              string.Format("{0}home/complete", Request.Url.AbsoluteUri));

            fileUploadViewModel.SetPolicy(fileStorageProvider.GetPolicyString(
                            fileUploadViewModel.FileId, fileUploadViewModel.RedirectUrl));

            return View(fileUploadViewModel);
        }

        public ActionResult Complete()
        {
            return View();
        }
    }
}
