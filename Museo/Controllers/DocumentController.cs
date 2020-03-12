using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Museo.Models;
using Museo.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Controllers
{
    public class DocumentController : Controller
    {
        public readonly IDocumentRepository repository;
        private readonly IHostingEnvironment hostingEnvironment;

        public DocumentController(IDocumentRepository repository, IHostingEnvironment hostingEnvironment)
        {
            this.repository = repository;
            this.hostingEnvironment = hostingEnvironment;
        }

        public ViewResult All()
        {
            Dictionary<Document, string> dictionary = new Dictionary<Document, string>();
            var list = repository.GetAll();
            foreach (var x in list)
            {
                dictionary.Add(x, repository.GetCategoryNameById(x.DocumentCategoryId));
            }
            return View(dictionary);
        }

        public ViewResult Add()
        {
            AddDocumentViewModel viewModel = new AddDocumentViewModel(repository.AllCategories());
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddDocumentViewModel document)
        {
            if (!ModelState.IsValid)
            {
                AddDocumentViewModel viewModel = new AddDocumentViewModel(repository.AllCategories());
                return View(viewModel);
            }

            string uniquefilename = null;

            var c = document.Manager.ContentType;

            if (document.Manager != null)
            {
                string folder = Path.Combine(hostingEnvironment.WebRootPath, "documents");
                uniquefilename = Guid.NewGuid().ToString() + "_" + document.Manager.FileName;
                string path = Path.Combine(folder, uniquefilename);
                await document.Manager.CopyToAsync(new FileStream(path, FileMode.Create));
            }
            Document d = new Document()
            {
                Name = document.Name,
                Author = document.Author,
                Date = document.Date,
                Description = document.Description,
                DocumentCategoryId = document.DocumentCategoryId,
                PublicationDate = document.PublicationDate,
                Manager = uniquefilename
            };
            repository.AddEntity(d);
            return RedirectToAction("All");
        }
        public IActionResult Delete(int Id)
        {
            repository.Delete(Id);
            return RedirectToAction("All");
        }

        [HttpGet]
        public ViewResult Update(int Id)
        {
            var document = repository.GetById(Id);
            AddDocumentViewModel viewModel = new AddDocumentViewModel(repository.AllCategories());
            viewModel.Name = document.Name;
            viewModel.Author = document.Author;
            viewModel.Date = document.Date;
            viewModel.Description = document.Description;
            viewModel.DocumentCategoryId = document.DocumentCategoryId;
            viewModel.PublicationDate = document.PublicationDate;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Update(Document document)
        {
            repository.Update(document);
            return RedirectToAction("All");
        }
    }
}
