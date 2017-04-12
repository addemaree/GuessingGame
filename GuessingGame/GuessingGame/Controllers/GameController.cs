using GuessingGame.Models;
using GuessingGame.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuessingGame.Controllers
{

    public class GameController : Controller
    {
        //readonly means that the only time this can be changed is in the constructor
        private readonly IRandomNumberGenerator _rng;
        
        public GameController(IRandomNumberGenerator rng)
        {
            _rng = rng;
        }

        public ActionResult Index()
        {
            IRandomNumberGenerator rng = new AdvancedNumberGenerator();

            Session["Answer"] = rng.GetNext(1, 10);

            return View();
        }

        private bool GuessWasCorrect(int guess) =>
            guess == (int)Session["Answer"];

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(GameModel model)
        {
            if(ModelState.IsValid)
            {
                ViewBag.Win = GuessWasCorrect(model.Guess);
            }           

            return View(model);
        }
    }
}