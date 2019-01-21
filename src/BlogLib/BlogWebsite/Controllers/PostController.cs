using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StraussDA.BlogLib;


namespace BlogWebsite.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepo;

        public PostController(IPostRepository postRepository)
        {
            _postRepo = postRepository;
        }
        public ActionResult Index()
        {

            return View(_postRepo.ListAll());
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {

            return View(_postRepo.GetByID(id));
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            return View(new Post());
        }

        // POST: Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post NewPost, IFormCollection collection)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View(NewPost);
                }
                _postRepo.NewPost(NewPost);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception)
            {
               //TODO log the exception
            }
            return View(NewPost);
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_postRepo.GetByID(id));
        }

        // POST: Post/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Post editedPost, IFormCollection collection)
        {
            if(!ModelState.IsValid)
            {
                return View(editedPost);
            }
            try
            {
                _postRepo.EditPost(editedPost);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception)
            {
                //TODO log the exception
            }
            return View(editedPost);
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_postRepo.GetByID(id));
        }

        // POST: Post/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _postRepo.DeletePost(id);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception)
            {
                //TODO log the exception
            }
            return View(_postRepo.GetByID(id));
        }
    }
}