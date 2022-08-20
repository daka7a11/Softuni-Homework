using BattleCards.Data;
using BattleCards.Models;
using BattleCards.ViewModels.Cards;
using System.Collections.Generic;
using System.Linq;

namespace BattleCards.Services
{
    public class CardsService : ICardsService
    {
        private readonly ApplicationDbContext db;

        public CardsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public int Create(CreateCardViewModel card)
        {
            Card cardToAdd = new Card()
            {
                Name = card.Name,
                ImageUrl = card.Image,
                Keyword = card.Keyword,
                Attack = card.Attack,
                Health = card.Health,
                Description = card.Description,
            };

            db.Cards.Add(cardToAdd);
            db.SaveChanges();
            return cardToAdd.Id;
        }

        public void AddCardToUser(string userId, int cardId)
        {
            if (db.UserCards.Any(x => x.UserId == userId && x.CardId == cardId))
            {
                return;
            }

            db.UserCards.Add(new UserCard() { UserId = userId, CardId = cardId });
            db.SaveChanges();
        }

        public List<CardViewModel> GetAll()
        {
            return db.Cards
                .Select(x => new CardViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Image = x.ImageUrl,
                    Description = x.Description,
                    Keyword = x.Keyword,
                    Attack = x.Attack,
                    Health = x.Health,
                }).OrderBy(x => x.Name)
                .ToList();
        }

        public List<CardViewModel> GetByUserId(string userId)
        {
            return db.UserCards.Where(x => x.UserId == userId)
                .Select(x => new CardViewModel()
                {
                    Id = x.Card.Id,
                    Name = x.Card.Name,
                    Image = x.Card.ImageUrl,
                    Description = x.Card.Description,
                    Keyword = x.Card.Keyword,
                    Attack = x.Card.Attack,
                    Health = x.Card.Health,
                }).OrderBy(x => x.Name)
                .ToList();
        }

        public void RemoveFromCollection(string userId, int cardId)
        {
            var userCard = db.UserCards.FirstOrDefault(x => x.UserId == userId && x.CardId == cardId);
            if (userCard != null)
            {
                db.UserCards.Remove(userCard);
                db.SaveChanges();
            }
        }
    }
}
