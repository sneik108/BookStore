using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        IBookRepository repository;

        public AdminController(IBookRepository repo)
        {
            repository = repo;
        }
        
        public ViewResult Index()
        {
            return View(repository.Books);
        }

        public ViewResult Edit(int bookId)
        {
            Book book = repository.Books.FirstOrDefault(b => b.BookId == bookId);

            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                repository.SaveBook(book);
                TempData["message"] = string.Format("Изменение информации о книге \"{0}\" сохранены", book.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(book);
            }
        }
        [HttpPost]
        public ActionResult Delete(int bookId)
        {
            Book book = repository.Books.FirstOrDefault(b => b.BookId == bookId);
            repository.DeleteBook(book);
            TempData["message"] = string.Format("Удаление книги \"{0}\" выполнено", book.Name);
            return RedirectToAction("Index");
        }
        public ViewResult Create()
        {
            Book book = new Book();
            book.BookId = repository.Books.Max(b => b.BookId) + 1;
            return View(book);
        }
        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                repository.AddBook(book);
                TempData["message"] = string.Format("Добавлена книга \"{0}\" в базу", book.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(book);
            }
        }

        public ActionResult ShowMap()
        {
            return View();
        }
    }
}