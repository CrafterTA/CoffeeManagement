using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class IngredientService
    {
        private static IngredientService _instance;
        public static IngredientService Instance
        {
            get
            {
                if (_instance == null) _instance = new IngredientService();
                return _instance;
            }
            set => _instance = value;
        }
        public List<Ingredient> GetAllIngredients()
        {
            return DALIngredient.Instance.GetAllIngredients();
        }
        public Ingredient GetIngredientByID(string ingredientID)
        {
            return DALIngredient.Instance.GetIngredientByID(ingredientID);
        }
        public bool AddIngredient(string ingredientID, string ingredientName, string unit, decimal unitPrice, decimal stock)
        {
            return DALIngredient.Instance.AddIngredient(ingredientID, ingredientName, unit, unitPrice, stock);
        }
        public bool UpdateIngredient(Ingredient ingredient)
        {
            return DALIngredient.Instance.UpdateIngredient(ingredient);
        }
    }
}
