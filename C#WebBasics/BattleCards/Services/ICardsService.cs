using BattleCards.ViewModels.Cards;
using System.Collections.Generic;

namespace BattleCards.Services
{
    public interface ICardsService
    {
        public int Create(CreateCardViewModel card);

        public void AddCardToUser(string userId, int cardId);

        public List<CardViewModel> GetAll();

        public List<CardViewModel> GetByUserId(string userId);

        public void RemoveFromCollection(string userId, int cardId);
    }
}
