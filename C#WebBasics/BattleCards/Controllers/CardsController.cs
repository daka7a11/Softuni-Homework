using BattleCards.Services;
using BattleCards.ViewModels.Cards;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Collections.Generic;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {
        private readonly ICardsService cardsService;

        public CardsController(ICardsService cardsService)
        {
            this.cardsService = cardsService;
        }
        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return Redirect("/Users/Login");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(CreateCardViewModel card)
        {
            if (!this.IsUserSignedIn())
            {
                return Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(card.Name) || card.Name.Length < 5 || card.Name.Length > 15)
            {
                return this.Error("Name should be between 5 and 15 characters!");
            }

            if (string.IsNullOrWhiteSpace(card.Image))
            {
                return this.Error("URL is required!");
            }

            if (string.IsNullOrWhiteSpace(card.Keyword))
            {
                return this.Error("Keyword is required!");
            }

            if (card.Attack < 0)
            {
                return this.Error("Invalid attack!");
            }

            if (card.Health < 0)
            {
                return this.Error("Invalid health!");
            }

            if (string.IsNullOrWhiteSpace(card.Description) || card.Description.Length > 200)
            {
                return this.Error("Description is required and it should have max 200 characters!");
            }

            int cardId = cardsService.Create(card);
            string userId = this.GetUserId();

            cardsService.AddCardToUser(userId, cardId);

            return this.Redirect("/");
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return Redirect("/Users/Login");
            }

            List<CardViewModel> viewModel = cardsService.GetAll();

            return this.View(viewModel);
        }

        public HttpResponse Collection()
        {
            if (!this.IsUserSignedIn())
            {
                return Redirect("/Users/Login");
            }

            string userId = GetUserId();

            List<CardViewModel> viewModel = cardsService.GetByUserId(userId);

            return this.View(viewModel);
        }

        public HttpResponse AddToCollection(int cardId)
        {
            string userId = this.GetUserId();

            cardsService.AddCardToUser(userId, cardId);

            return this.Redirect("/Cards/All");
        }

        public HttpResponse RemoveFromCollection(int cardId)
        {
            string userId = this.GetUserId();

            cardsService.RemoveFromCollection(userId, cardId);

            return this.Redirect("/Cards/Collection");
        }
    }
}
